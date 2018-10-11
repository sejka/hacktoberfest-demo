using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;

namespace HacktoberfestServerlessDemo
{
    public static class Lottery
    {
        private const int PROBABILITY = 10000;

        [FunctionName("Lottery")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, ILogger log)
        {
            var random = new Random().Next() % PROBABILITY;

            if (random == PROBABILITY - 1)
            {
                return new OkObjectResult("win");
            }
            else
            {
                return new OkObjectResult("try again");
            }
        }
    }
}