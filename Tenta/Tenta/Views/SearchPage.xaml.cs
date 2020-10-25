using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenta.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tenta.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        SearchViewModel model;
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = model = new SearchViewModel();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            JokeSearcher.Focus();
        }

        // Used in XAML-Page
        private async void JokeSearcher_SearchButtonPressed(object sender, EventArgs e)
        {
            var query = (SearchBar)sender;
            var returnQuery = await model.service.SearchJokes(query.Text);

            Jokes.ItemsSource = returnQuery;

        }

        private void StarButton_Clicked(object sender, EventArgs e)
        {
            var x = (ImageButton)sender;
        }
    }
}