

namespace DataTableStorage
{

    using TextExpoStorageSample.Model;
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using System.Configuration;
    using TestExpoWebAPI.Model;

    public class GeneralEvaluationClient
    {
        internal const string TableName = "GeneralEvaluations";
        internal const string partitionKeyConst = "GeneralEval";
        private static CloudTable table;
        public GeneralEvaluationClient()
        {
            table = CreateTable();
        }


        private static CloudTable CreateTable()
        {
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=testexpoapp;AccountKey=J+tfUiR7XIHyyM5dZcRdp3X8o4WwRGvOrWDUnu2MGuCLU0Nd/AhtVoRGsLbTerERzeyIo6jI23XzZ9Pn4XwaEQ==");

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the table if it doesn't exist.
            CloudTable table = tableClient.GetTableReference(TableName);
            table.CreateIfNotExists();
            return table;
        }

        private static CloudStorageAccount CreateStorageAccountFromConnectionString(string storageConnectionString)
        {
            CloudStorageAccount storageAccount;
            try
            {
                storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the application.");
                throw;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                Console.ReadLine();
                throw;
            }

            return storageAccount;
        }

        public void InsertUserEval(GeneralEvaluationsEntity evalEntity)
        {
            // Create a retrieve operation that takes a customer entity.
            TableOperation retrieveOperation = TableOperation.Retrieve<DevicesEntity>("GeneralEval", evalEntity.deviceID.ToString() + evalEntity.questionNumber);

            // Execute the retrieve operation.
            TableResult retrievedResult = table.Execute(retrieveOperation);

            if (retrievedResult.Result != null)
            {
                throw new AlreadyExistsException("Du har allerede afgivet evaluering af denne præsentation");
            }

            // Create the InsertOrReplace TableOperation.
            TableOperation insertOperation = TableOperation.Insert(evalEntity);

            // Execute the operation.
            table.Execute(insertOperation);

            Console.WriteLine("Entity was updated.");
        }
    }
}
