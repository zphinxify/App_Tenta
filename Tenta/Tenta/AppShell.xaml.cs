using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenta.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tenta
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof (CategoryPage), typeof(CategoryPage));
            Routing.RegisterRoute(nameof (JokePage), typeof(JokePage));
            Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));
            Routing.RegisterRoute(nameof(FavouritePage), typeof(FavouritePage));

        }
    }
}