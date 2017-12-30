namespace CryptoAlerts.ConsoleApp.Influencers
{
    public interface IInfluencer
    {
        string Name { get; set; }
        string Url { get; set; }
        string LastAnnouncement { get; set; }
        string CssString { get; set; }
        int IntervalInSeconds { get; set; }

        void ProcessHtml(string htmlContent);
        string GetSmsMessage(string newAnnouncement);
    }
}