using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using GeekyMon2.Azure.Function.PasswordGenerator;

namespace GeekyMon2.Azure.Function
{
    public class RandomPasswordGenerator
    {
        private readonly ILogger<RandomPasswordGenerator> _logger;
        private PasswordGenerator _generator;
        

        public RandomPasswordGenerator(ILogger<RandomPasswordGenerator> logger, PasswordGenerator generator)
        {
            _logger = logger;
            _generator = generator;
        }

        [Function("RandomPasswordGenerator")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function RandomPasswordGenerator request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            dynamic? data = JsonSerializer.Deserialize<JsonNode>(requestBody);
            string? length = (string?)data?["length"];

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");


            string password = generator.GeneratePassword(length);

            return response.WriteAsync($"password: {password}");
        }
    }
}
