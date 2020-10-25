using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenta.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tenta.ViewModels;

namespace Tenta.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        CategoryViewModel _model;

        public CategoryPage()
        {
            InitializeComponent();

            BindingContext = _model = new CategoryViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Bind the categories retrived from Apicall
            categories.ItemsSource = await _model.service.GetJokeCategories();
        }

        async void ButtonNavigate_Clicked(object sender, SelectedItemChangedEventArgs selectedCategory)
        {
            // Gets the selected category in stringformat
            var category = selectedCategory.SelectedItem.ToString();

            // Persists the Category attribute to be sent to the next page
            await Shell.Current.GoToAsync($"{nameof(JokePage)}?{nameof(JokePageViewModel.Category)}={category}");
        }
    }
}
