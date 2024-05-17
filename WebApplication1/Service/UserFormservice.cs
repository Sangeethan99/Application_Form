using Microsoft.Azure.Cosmos;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class UserFormservice :IUserFormService
    {
        private readonly Container _container;

        public UserFormservice(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }
        public async Task<UserForm> Add(UserForm userForm)
        {
            var item = await _container.CreateItemAsync<UserForm>(userForm, new PartitionKey(userForm.Id));

            return item;
        }
        public async Task<UserForm> Delete(string id, string partition)
        {
            var result = await _container.DeleteItemAsync<UserForm>(id, new PartitionKey(partition));
            return result;
        }
        public async Task<List<UserForm>> Get(string cosmosQuery)
        {
            var query = _container.GetItemQueryIterator<UserForm>(new QueryDefinition(cosmosQuery));
            List<UserForm> results = new List<UserForm>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }

        public async Task<UserForm> GetById(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<UserForm>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<UserForm> Update(UserForm userForm)
        {
            var item = await _container.UpsertItemAsync<UserForm>(userForm, new PartitionKey(userForm.Id));
            return item;
        }
    }
}
