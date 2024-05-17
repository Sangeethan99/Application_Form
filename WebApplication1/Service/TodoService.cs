using WebApplication1.Models;
using Microsoft.Azure.Cosmos;
using WebApplication1.Service;

namespace WebApplication1.Service
{
    public class TodoService : ITodoService
    {
        private readonly Container _container;

        public TodoService(
            CosmosClient cosmosClient, 
            string databaseName, 
            string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName,
            containerName);
        }
        public async Task<Models.User> Add(Models.User task)
        {
            var item = await _container.CreateItemAsync<Models.User>(task, new PartitionKey(task.Id));

            return item;
        }
        public async Task Delete(string id, string partition)
        {
            await _container.DeleteItemAsync<Models.User>(id, new PartitionKey(partition));
        }
        public async Task<List<Models.User>> Get(string cosmosQuery)
        {
            var query = _container.GetItemQueryIterator <Models.User>(new QueryDefinition(cosmosQuery));
            List<Models.User> results = new List<Models.User>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }
        public async Task<Models.User> Update(Models.User task)
        {
            var item = await _container.UpsertItemAsync<Models.User>(task, new PartitionKey(task.Id));
            return item;
        }

        Task<Models.User> ITodoService.Delete(string id, string partition)
        {
            throw new NotImplementedException();
        }
    }
}
