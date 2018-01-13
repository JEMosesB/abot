using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using CryptoAlerts.ConsoleApp.BaseModels;
using CsQuery;
using NLog;

namespace CryptoAlerts.ConsoleApp.Core
{
    public class CoinMarketCapExtractor
    {
        protected static readonly ILogger CmcLogger = LogManager.GetLogger("CoinMarketCapLogger");
        protected static readonly ILogger CmcDealsLogger = LogManager.GetLogger("CoinMarketCapDealFinder");

        private string _allCoinsUrl = "https://api.coinmarketcap.com/v1/ticker/?limit=0";
        private int IntervalInMilliseconds { get; set; } = 500;
        private List<Coin> Coins { get; set; }


        public CoinMarketCapExtractor()
        {
            
        }

        public async Task StartMonitoring()
        {
            //while (true)
            //{
                await UpdateCoinsList();

                foreach (var coin in Coins)
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(IntervalInMilliseconds));

                    await CheckNextCoin(coin);
                }
            //}
        }

        private async Task CheckNextCoin(Coin coin)
        {
            coin.Markets = await GetMarketsForCoin(coin);

            FindSweetDeals(coin);

            //Console.WriteLine(deals);
        }

        private void FindSweetDeals(Coin coin)
        {
            int percentsForSignal = 50;

            var goodMarkets = coin.Markets.Where(x => x.Volume24h > 500000).ToList();
            if (goodMarkets.Count > 1)
            {
                var minPriceMarket = goodMarkets.OrderBy(x => x.Price).First();
                var maxPriceMarket = goodMarkets.OrderByDescending(x => x.Price).First();

                if (((minPriceMarket.Price + ((minPriceMarket.Price / 100) * percentsForSignal)) < maxPriceMarket.Price) && (minPriceMarket.Price > 0))
                {
                    var diffPercents = Math.Round((maxPriceMarket.Price - minPriceMarket.Price) * 100 / minPriceMarket.Price, 2);
                    CmcDealsLogger.Info($"Deal found!\n" +
                                        $"Coin [{coin.Id.ToUpper()}] ({coin.Name})\n" +
                                        $"on [{minPriceMarket.Name}] market ({minPriceMarket.Pair} pair): min price is ${minPriceMarket.Price}\n" +
                                        $"on [{maxPriceMarket.Name}] market ({maxPriceMarket.Pair} pair): max price is ${maxPriceMarket.Price}\n" +
                                        $"which is a {diffPercents}% difference\n" +
                                        $"Link: {coin.MarketUrl}");
                }
            }
        }

        private async Task<List<Market>> GetMarketsForCoin(Coin coin)
        {
            //var url = $"https://coinmarketcap.com/currencies/{coin.Id}/#markets";
            //var url = $"https://coinmarketcap.com/currencies/quantstamp/#markets";

            var results = new List<Market>();

            try
            {
                Stopwatch timer = Stopwatch.StartNew();
                var b = await ContentGetter.GetHtml(coin.MarketUrl);
                CQ html = b;
                timer.Stop();
                CmcLogger.Info($"Success. Crawling [{coin.Id}] page has taken [{timer.Elapsed}] seconds");

                var marketsTable = html["div#markets table#markets-table tbody tr"].ToList();

                foreach (var row in marketsTable)
                {
                    var tdList = row.Cq().Find("td").ToList();
                    var marketRow = new Market()
                    {
                        Name = tdList[1].Cq().Find("a").Text().Trim(),
                        Pair = tdList[2].Cq().Find("a").Text().Trim(),
                        Volume24h = Convert.ToDecimal(tdList[3].Cq().Find("span").Text().Replace("$", "").Replace(",", "").Replace("*", "").Trim()),
                        Price = Convert.ToDecimal(tdList[4].Cq().Find("span").Text().Replace("$", "").Replace(",", "").Replace("*", "").Trim()),
                        VolumePercent = Convert.ToDecimal(tdList[5].InnerText.Replace("%", "").Replace("*", "").Trim()),
                        Updated = tdList[6].InnerText.Trim()
                    };
                    results.Add(marketRow);
                }

                return results;
            }
            catch (Exception e)
            {
                CmcLogger.Info($"Failed. Crawling [{coin.Id}] page has failed. Url: {coin.MarketUrl}\nError:\n{e.Message}");
            }

            return results;
        }

        private async Task UpdateCoinsList()
        {
            Coins = await GetLatestCoins(_allCoinsUrl);
        }

        private async Task<List<Coin>> GetLatestCoins(string url)
        {
            var result = new List<Coin>();

            try
            {
                Stopwatch timer = Stopwatch.StartNew();
                dynamic responseJson = await ContentGetter.GetJsonArray(url);
                timer.Stop();
                CmcLogger.Info($"Success. Getting all CoinMarketCap currencies has taken [{timer.Elapsed}] seconds\n");

                result = ((IEnumerable)responseJson).Cast<dynamic>()
                    .Select(x => new Coin
                    {
                        Id = (string)x.id,
                        Name = (string)x.name,
                        Symbol = (string)x.symbol,
                        Rank = (int)x.rank,
                        LastUpdated = (string)x.last_updated == null ? (DateTime?)null : new DateTime((long)x.last_updated),
                        // MarketUrl = $"https://coinmarketcap.com/currencies/{(string)x.id}/#markets"
                        MarketUrl = $"https://coinmarketcap.com/currencies/{(string)x.id}/#markets"
                    })
                    .OrderBy(x => x.Name)
                    .ToList();
            }
            catch (Exception e)
            {
                CmcLogger.Info($"Failed. Getting all CoinMarketCap currencies has failed. Error:\n{e.Message}");
            }

            return result;
        }
    }

    public class Coin
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Rank { get; set; }
        public DateTime? LastUpdated { get; set; }
        public List<Market> Markets { get; set; }
        public string MarketUrl { get; set; }
    }

    public class Market
    {
        public string Name { get; set; }
        public string Pair { get; set; }
        public decimal Volume24h { get; set; }
        public decimal Price { get; set; }
        public decimal VolumePercent { get; set; }
        public string Updated { get; set; }
    }
}

