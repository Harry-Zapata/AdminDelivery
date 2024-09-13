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
    public partial class VReloadPass : ContentPage
    {
        public VReloadPass()
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