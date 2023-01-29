using Infobip.Api.Client;
using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using OrdrdApi.Configuration;

namespace OrdrdApi.Services.Infrastructure
{
    public class InfrastructureService : IInfrastructureService
    {
        private readonly SendSmsApi _smsApi;
        private readonly IConfiguration _config;

        public InfrastructureService(IConfiguration config)
        {
            _config = config;

            var infobipSettings = _config.GetSection("InfobipSettings").Get<InfobipSettings>();
            var configuration = new Infobip.Api.Client.Configuration()
            {
                BasePath = infobipSettings?.BasePath,
                ApiKeyPrefix = infobipSettings?.ApiKeyPrefix,
                ApiKey = infobipSettings?.ApiKey
            };

            _smsApi = new SendSmsApi(configuration);
        }

        public Task SendSmsMessageAsync(string number, string message, string heading)
        {
            var smsMessage = new SmsTextualMessage()
            {
                From = heading,
                Destinations = new List<SmsDestination>()
                {
                    new SmsDestination(to: number)
                },
                Text = message
            };

            var smsRequest = new SmsAdvancedTextualRequest()
            {
                Messages = new List<SmsTextualMessage>() { smsMessage }
            };

            try
            {
                var smsResponse = _smsApi.SendSmsMessage(smsRequest);

                Console.WriteLine("Response: " + smsResponse.Messages.FirstOrDefault());
            }
            catch (ApiException apiException)
            {
                Console.WriteLine("Error occurred! \n\tMessage: {0}\n\tError content", apiException.ErrorContent);
                throw apiException;
            }

            return Task.CompletedTask;
        }
    }
}