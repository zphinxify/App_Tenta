using System;
using System.Collections.Generic;
using System.Text;
using Tenta.Services;
using Xamarin.Forms;

namespace Tenta.ViewModels
{
    [QueryProperty(nameof(Category), nameof (Category))]
    public class CategoryViewModel : BaseViewModel
    {
        public readonly IApiService _service;

        public CategoryViewModel()
        {
            _service = DependencyService.Get<IApiService>();
        }

        private string category = string.Empty;
        private string joke = string.Empty;

        public string Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }

        public string Joke
        {
            get => joke;
            set => SetProperty(ref joke, value);
        }
    }
}
