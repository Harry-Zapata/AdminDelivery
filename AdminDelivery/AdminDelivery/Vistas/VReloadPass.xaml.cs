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

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}