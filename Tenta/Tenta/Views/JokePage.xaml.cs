using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenta.Models;
using Tenta.Services;
using Tenta.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tenta.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JokePage : ContentPage
    {
        private readonly JokePageViewModel _model;
        public JokePage()
        {
            InitializeComponent();
            BindingContext = _model = new JokePageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DeleteFavouriteButton.IsVisible = IsJokeFavourite();
            FavBox.IsChecked = IsJokeFavourite();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var category = _model.Category;
            _model.Joke = (await _model.service.GetJokeFromCategory(category)).Value;
            FavBox.IsChecked = IsJokeFavourite();
            DeleteFavouriteButton.IsVisible = IsJokeFavourite();
            FavouriteButton.IsVisible = IsJokeNotFavourite();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var joke = _model.Joke;
            _model.AddJokeToFavourites(joke);
            DeleteFavouriteButton.IsVisible = true;
            FavouriteButton.IsVisible = false;
        }


        private bool IsJokeNotFavourite()
        {
            var joke = JokeText.Text;
            var status = _model.CheckIfJokeIsFavourite(joke);

            if (!status)
                return true;

            return false;
        }

        private bool IsJokeFavourite()
        {
            var joke = JokeText.Text;
            var status = _model.CheckIfJokeIsFavourite(joke);

            if (status)
                return true;

            return false;
        }

        private void DeleteFavouriteButton_Clicked(object sender, EventArgs e)
        {
            var joke = JokeText.Text;
            _model.DeleteJoke(joke);
            DeleteFavouriteButton.IsVisible = false;
            FavouriteButton.IsVisible = true;
        }
    }
}