using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Tenta.Models;
using System.Diagnostics;

namespace Tenta.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {

        private string joke = string.Empty;
        public string Joke
        {
            get => joke;
            set => SetProperty(ref joke, value);
        }

        public SearchViewModel()
        {
            AddToFavourites = new Command<Joke>(joke => AddJokeToFavourites(joke.Value));
        }

        public Command AddToFavourites { get; }

        public void AddJokeToFavourites(string joke)
        {
            try
            {
                if (!JokePageViewModel.jokeFavourites.Contains(joke))
                {
                    JokePageViewModel.jokeFavourites.Add(joke);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
