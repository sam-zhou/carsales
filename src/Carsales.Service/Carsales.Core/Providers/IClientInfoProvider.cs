namespace Carsales.Core.Providers
{
    public interface IClientInfoProvider
    {
        string BrowserInfo { get; }

        string ClientIpAddress { get; }

        //string ComputerName { get; }
    }
}
