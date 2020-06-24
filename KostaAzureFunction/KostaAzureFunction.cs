using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace KostaAzureFunction
{
    public class KostaAzureFunction
    {
        private readonly OrderContext _context;

        public KostaAzureFunction(OrderContext context)
        {
            _context = context;
        }

        [FunctionName("KostaAzureFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request. " + _context.Orders);

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : (ActionResult)new OkObjectResult(_context.Orders.OrderBy(o => o.PersonID).ToArray());
        }
    }
}

/**
  return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : (ActionResult)new OkObjectResult(@"
{
  ""title"": ""The Basics - Networking"",
  ""description"": ""Your app fetched this from a remote endpoint!"",
  ""movies"": [
    { ""id"": ""1"", ""title"": ""Star Wars"", ""releaseYear"": ""1977"" },
    { ""id"": ""2"", ""title"": ""Back to the Future"", ""releaseYear"": ""1985"" },
    { ""id"": ""3"", ""title"": ""The Matrix"", ""releaseYear"": ""1999"" },
    { ""id"": ""4"", ""title"": ""Inception"", ""releaseYear"": ""2010"" },
    { ""id"": ""5"", ""title"": ""Interstellar"", ""releaseYear"": ""2014"" }
  ]
}")
*/