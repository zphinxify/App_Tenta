using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using Tenta.Models;
using Tenta.Services;
using Xamarin.Forms;

namespace Tenta.ViewModels
{
    [QueryProperty(nameof(Category), nameof(Category))]
    public class JokePageViewModel : BaseViewModel
    {
        private string category = string.Empty;
        private string joke = string.Empty;
        private bool isFavourite = false;

        

        public static ObservableCollection<string> jokeFavourites { get; } = new ObservableCollection<string>();

        public JokePageViewModel()
        {
            
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

        public void AddJokeToFavourites(string joke)
        { 
            try
            {
                if (!jokeFavourites.Contains(joke))
                {
                    jokeFavourites.Add(joke);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public void DeleteJoke(string joke)
        {
            try
            {
                if(jokeFavourites.Contains(joke))
                {
                    jokeFavourites.Remove(joke);
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public bool CheckIfJokeIsFavourite(string joke)
        {
            if (jokeFavourites.Contains(joke))
            {
                return true;
            }

            return false;
        }

    }
}
