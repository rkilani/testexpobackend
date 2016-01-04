

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

    public class DeviceClient
    {
        internal const string TableName = "Devices";
        internal const string partitionKeyConst = "AAA";
        internal const string rowKeyConst = "0001";
        private static CloudTable table;
        public DeviceClient()
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


        public long RetrieveAndUpdateDeviceID()
        {
            // Create a retrieve operation that takes a customer entity.
            TableOperation retrieveOperation = TableOperation.Retrieve<DevicesEntity>(partitionKeyConst, rowKeyConst);

            // Execute the retrieve operation.
            TableResult retrievedResult = table.Execute(retrieveOperation);



            if (retrievedResult.Result != null)
            {
                var entityToUpdate = (DevicesEntity)retrievedResult.Result;

                // Change the phone number.
                entityToUpdate.deviceID = entityToUpdate.deviceID + 1;

                // Create the InsertOrReplace TableOperation.
                TableOperation updateOperation = TableOperation.Replace(entityToUpdate);

                // Execute the operation.
                table.Execute(updateOperation);

                return ((DevicesEntity)retrievedResult.Result).deviceID;
            }
            return 0;
        }

    }
}
