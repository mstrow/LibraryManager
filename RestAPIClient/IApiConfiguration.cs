namespace RestAPIClient
{
    public interface IApiConfiguration
    {
        int Timeout { get; set; }
        string Url { get; set; }
    }
}