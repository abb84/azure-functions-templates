using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Abstractions;
using Microsoft.Azure.Functions.Worker.Extensions.CosmosDB;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class CosmosDBTriggerCSharp
    {
        [FunctionName("CosmosDBTriggerCSharp")]
        public static void Run([CosmosDBTrigger(
            databaseName: "DatabaseValue",
            collectionName: "CollectionValue",
            ConnectionStringSetting = "ConnectionValue",
            LeaseCollectionName = "leases")] IReadOnlyList<MyDocument> input, FunctionContext context)
        {
            var logger = context.Logger;
            if (input != null && input.Count > 0)
            {
                logger.LogInformation("Documents modified " + input.Count);
                logger.LogInformation("First document Id " + input[0].Id);
            }
        }
    }

    public class MyDocument
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public int Number { get; set; }

        public bool Boolean { get; set; }
    }
}