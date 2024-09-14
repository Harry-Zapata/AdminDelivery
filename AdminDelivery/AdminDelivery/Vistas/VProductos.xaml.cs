using AdminDelivery.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;
using Xamarin.Forms.Xaml;

namespace AdminDelivery.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VProductos : ContentPage
    {
        public VProductos()
        {
            InitializeComponent();
            BindingContext = new VMProductos(Navigation);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}