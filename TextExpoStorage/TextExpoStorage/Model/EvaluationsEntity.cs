﻿//----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//----------------------------------------------------------------------------------
namespace TextExpoStorageSample.Model
{
    using Microsoft.WindowsAzure.Storage.Table;
    using System;

    /// <summary>
    /// Define a Customer entity for demonstrating the Table Service. For the purposes of the sample we use the 
    /// customer's first name as the row key and last name as the partition key. In reality this would not be a good
    /// PK and RK combination as it would likely not be gauranteed to be unique which is one of the requirements for an entity. 
    /// <summary>
    public class EvaluationsEntity : TableEntity
    {
        // Your entity type must expose a parameter-less constructor
        public EvaluationsEntity() { }

        // Define the PK and RK
        public EvaluationsEntity(long deviceId, int presentationId)
        {
            this.PartitionKey = "Eval";
            this.RowKey = deviceId.ToString() + presentationId.ToString();
            deviceID = deviceId;
            presentationID = presentationId;
        }
        public long deviceID { get; set; }
        public int presentationID { get; set; }
        public int speakerID { get; set; }
        public int rating { get; set; }
        public string comment { get; set; }
        public DateTime timestamp { get; set; }
    }
}
