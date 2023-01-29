namespace OrdrdApi.Services.Infrastructure
{
    public interface IInfrastructureService
    {
        Task SendSmsMessageAsync(string number, string message, string heading);
    }
}
