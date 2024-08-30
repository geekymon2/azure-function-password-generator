using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker.Http;
using System.Drawing.Text;

namespace GeekyMon2.Azure.Function.RandomPasswordGenerator
{
    public class RandomPasswordGenerator(ILogger<RandomPasswordGenerator> logger)
    {
        private readonly ILogger<RandomPasswordGenerator> _logger = logger;

        [Function("RandomPasswordGenerator")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            PasswordGenerator generator = new();
            _logger.LogInformation("C# HTTP trigger function RandomPasswordGenerator request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            dynamic? data = JsonSerializer.Deserialize<JsonNode>(requestBody);
            string? length = (string?)data?["length"];

            var response = req.CreateResponse(HttpStatusCode.OK);
            ResponseData res = new(generator.GeneratePassword(length));
            await response.WriteStringAsync(JsonSerializer.Serialize(res));

            return response;
        }
    }
}
