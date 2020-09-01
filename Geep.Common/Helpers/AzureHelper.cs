using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geep.Common.Helpers
{
    public class AzureHelper
    {
        public static string FromAzureToBase64(string azureUri)
        {
            Uri blobUri = new Uri(azureUri);
            CloudBlockBlob blob = new CloudBlockBlob(blobUri);
            blob.FetchAttributes();//Fetch blob's properties
            byte[] arr = new byte[blob.Properties.Length];
            blob.DownloadToByteArray(arr, 0);
            var azureBase64 = Convert.ToBase64String(arr);
            return azureBase64;
        }
    }
}
