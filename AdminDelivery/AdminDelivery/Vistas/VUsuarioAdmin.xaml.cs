using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AdminDelivery.ViewModel;

namespace AdminDelivery.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VUsuarioAdmin : ContentPage
    {
        public VUsuarioAdmin()
        {
            InitializeComponent();
            BindingContext = new VMUsuarioAdmin(Navigation);
        }

        private async void Regresar_A_Login(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}