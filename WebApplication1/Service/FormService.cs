using Microsoft.Azure.Cosmos;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class FormService:IFormService
    {
        private readonly Container _container;

        public FormService(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }
        public async Task<Form> Add(Form Form)
        {
            var item = await _container.CreateItemAsync<Form>(Form, new PartitionKey(Form.Id));

            return item;
        }
        public async Task<Form> Delete(string id, string partition)
        {
            var result = await _container.DeleteItemAsync<Form>(id, new PartitionKey(partition));
            return result;
        }
        public async Task<List<Form>> Get(string cosmosQuery)
        {
            var query = _container.GetItemQueryIterator<Form>(new QueryDefinition(cosmosQuery));
            List<Form> results = new List<Form>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }

        public async Task<Form> GetById(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Form>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<Form> Update(Form Form)
        {
            var item = await _container.UpsertItemAsync<Form>(Form, new PartitionKey(Form.Id));
            return item;
        }
    }
}
