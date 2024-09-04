using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Net;
using Microsoft.Azure.Functions.Worker.Http;


namespace GeekyMon2.Azure.Function.RandomPasswordGenerator
{
    public class RandomPasswordGenerator(ILogger<RandomPasswordGenerator> logger)
    {
        private readonly ILogger<RandomPasswordGenerator> _logger = logger;

        [Function("RandomPasswordGenerator")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            PasswordGenerator generator = new();
            _logger.LogInformation("C# HTTP trigger function RandomPasswordGenerator request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            dynamic? data = JsonSerializer.Deserialize<JsonNode>(requestBody);
            if (data == null) throw new ArgumentNullException(nameof(data));
            string length = (string)data["length"];

            var response = req.CreateResponse(HttpStatusCode.OK);
            ResponseData res = new(generator.GeneratePassword(length));
            await response.WriteStringAsync(JsonSerializer.Serialize(res));

            return response;
        }
    }
}
