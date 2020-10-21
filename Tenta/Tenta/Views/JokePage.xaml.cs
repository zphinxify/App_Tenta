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
        JokePageViewModel _model;
        public JokePage()
        {
            InitializeComponent();
            BindingContext = _model = new JokePageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var category = _model.Category;
            _model.Joke = (await _model._service.GetJokeFromCategory(category)).Value;
        }
    }
}