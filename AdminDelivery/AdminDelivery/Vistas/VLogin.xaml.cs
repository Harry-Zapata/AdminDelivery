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
    public partial class VLogin : ContentPage
    {
        public VLogin()
        {
            InitializeComponent();
        }

        private async void Ir_A_Registro(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VUsuarioAdmin());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VReloadPass());
        }
    }
}