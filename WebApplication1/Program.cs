using Microsoft.Azure.Cosmos;
using WebApplication1.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ITodoService>(options =>
{
    string url = builder.Configuration.GetSection("CosmosDb").GetValue<string>("URL");
    string primaryKey = builder.Configuration.GetSection("CosmosDb").GetValue<string>("PrimaryKey");
    string dbName = builder.Configuration.GetSection("CosmosDb").GetValue<string>("DatabaseName");
    string containerName = builder.Configuration.GetSection("CosmosDb").GetValue<string>("ContainerName");

    var cosmosClient = new CosmosClient(url, primaryKey);
    return new TodoService(cosmosClient, dbName, containerName);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
