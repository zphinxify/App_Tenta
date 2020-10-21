using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tenta.Models;

namespace Tenta.Services
{
    public class ApiService : IApiService
    {
        public async Task<IEnumerable<string>> GetJokeCategories()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api.chucknorris.io/jokes/categories");

            if(response.IsSuccessStatusCode)
            {
                var categoryString = await response.Content.ReadAsStringAsync();

                var jokeCategories = JsonConvert.DeserializeObject<IEnumerable<string>>(categoryString);
                return jokeCategories;
            }

            return null;
        }

        public async Task<Joke>GetJokeFromCategory(string category)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.chucknorris.io/jokes/random?category=" + category);

            if(response.IsSuccessStatusCode)
            {
                var jokeResponse = await response.Content.ReadAsStringAsync();

                var deserializedJoke = JsonConvert.DeserializeObject<Joke>(jokeResponse);

                return deserializedJoke;
            }

            return null;

        }

        public async Task<IEnumerable<Joke>>SearchJokes(string query)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://api.chucknorris.io/jokes/search?query=" + query);

            if(response.IsSuccessStatusCode)
            {
                var queryResponse = await response.Content.ReadAsStringAsync();
                var deserializedQuery = JsonConvert.DeserializeObject<JokeSearch>(queryResponse);

                return deserializedQuery.result.AsEnumerable();
            }

            return null;
        }
    }
}
