using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Tenta.Services;
using Xamarin.Forms;

namespace Tenta.ViewModels
{
    [QueryProperty(nameof(Category), nameof(Category))]
    public class JokePageViewModel : BaseViewModel
    {
        private string category = string.Empty;
        private string joke = string.Empty;

        public readonly IApiService _service;

        public JokePageViewModel()
        {
            _service = new ApiService();
        }

        public string Category
        {
            get => category;
            set
            {
                category = value;
                LoadJoke(value);
            }
        }

        public string Joke
        {
            get => joke;
            set => SetProperty(ref joke, value);
        }

        // Binds the jokeCategory and makes Apicall 
        public async void LoadJoke(string jokeCategory)
        {
            ApiService service = new ApiService();
            var jokeString = await service.GetJokeFromCategory(jokeCategory);

            Joke = jokeString.Value;
        }

    }
}
