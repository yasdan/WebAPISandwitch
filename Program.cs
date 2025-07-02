// See https://aka.ms/new-console-template for more information
using HttpClientApp;
using System.Net.Http.Headers;
using System.Text.Json;
Console.WriteLine("Hello, World!Welcome To the HTTP Client");

await ShowSandwiches();


static async Task<List<Repository>> ProcessRepositoriesAsync(HttpClient client)
{
    
    await using Stream stream =
        await client.GetStreamAsync("https://localhost:7250/api/Sandwitche");
    var repositories =
        await JsonSerializer.DeserializeAsync<List<Repository>>(stream);
    return repositories ?? new();// Initialize a new instance of List<Repository> class
                                 // which is empty and has default initial capacity.
}

static async Task ShowSandwiches()
{
    using (HttpClient client = new HttpClient())
    {
        client.DefaultRequestHeaders.Accept.Clear();// clear all previosu header data.


        var repositories = await ProcessRepositoriesAsync(client);

        foreach (var repository in repositories)
        {
            Console.WriteLine($"{repository.Id}  {repository.Name}    {repository.Price}");
        }
    }
}