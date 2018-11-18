using System;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace ResultReg.Storage
{
    public class StorageQueue
    {
        private readonly CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
        private CloudQueueClient queueClient;
        private CloudQueue queue;

        public StorageQueue()
        {
            queueClient = storageAccount.CreateCloudQueueClient();

            string queueName = ResRegAppSettings.Storage.MessageQueue.QueueName;
            queue = queueClient.GetQueueReference(queueName);
            try
            {
                queue.CreateIfNotExistsAsync();
            }
            catch
            {
                Console.WriteLine("If you are running with the default configuration please make sure you have started the storage emulator.  ess the Windows key and type Azure Storage to select and run it from the list of applications - then restart the sample.");
                Console.ReadLine();
                throw;
            }
        }

        public async Task AddMessageToQueueAsync(string message)
        {
            await queue.AddMessageAsync(new CloudQueueMessage(message));
        }

    }

}

