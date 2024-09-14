using AdminDelivery.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdminDelivery.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioProductos : ContentPage
    {
        public InicioProductos()
        {
            InitializeComponent();
            BindingContext = new VMInicioProductos(Navigation);
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VProductos());
        }
    }
}