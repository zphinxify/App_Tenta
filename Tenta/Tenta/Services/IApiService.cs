using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenta.Models;

namespace Tenta.Services
{
    public interface IApiService
    {
        Task<IEnumerable<string>> GetJokeCategories();
        Task<Joke>GetJokeFromCategory(string category);
        Task<IEnumerable<Joke>> SearchJokes(string query);
    }
}
