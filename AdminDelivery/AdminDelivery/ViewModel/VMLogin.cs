using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using AdminDelivery.Datos;
using AdminDelivery.Modelo;
using Xamarin.Forms;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Newtonsoft.Json;
using Xamarin.Essentials;
using AdminDelivery.Vistas;
namespace AdminDelivery.ViewModel
{
    public class VMLogin : BaseViewModel
    {
        #region Variables
        string correo;
        string pass;
        private bool _isPassword = true;
        private string _eyeIcon = "https://icons.veryicon.com/png/o/photographic/ant-design-official-icon-library/eye-close-1.png";
        #endregion

        #region Objetos
        public string txtCorreo
        {
            get { return correo; }
            set { SetValue(ref correo, value); }
        }
        public string txtPass
        { 
            get { return pass; } 
            set { SetValue(ref pass, value); } 
        }

        public bool IsPassword
        {
            get => _isPassword;
            set
            {
                _isPassword = value;
                OnPropertyChanged();
            }
        }

        public string EyeIcon
        {
            get => _eyeIcon;
            set
            {
                _eyeIcon = value;
                OnPropertyChanged();
            }
        }

        public Command TogglePasswordCommand { get; }

        #endregion

        #region Procesos
        public async Task<bool> Login(string correo, string pass)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Validando Datos");
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Conexion.ConexionFirebase.TokenAuthentication));
                var auth =await authProvider.SignInWithEmailAndPasswordAsync(correo, pass);
                var controlToken = JsonConvert.SerializeObject(auth);
                Preferences.Set("MyFirebaseRefreshToken", controlToken);
                return true;
            }
            catch (Exception) 
            {
                UserDialogs.Instance.HideLoading();
                await Application.Current.MainPage.DisplayAlert("Error Al Iniciar Sesion", "Credenciales no validas", "Ok");
                return false;
            }
        }

        private async Task ValidarLogin()
        {
            bool estado = await Login(txtCorreo,txtPass);
            if (estado)
            {
                Application.Current.MainPage = new NavigationPage(new VInicio());
                UserDialogs.Instance.HideLoading();
            }
        }

        private void OnTogglePassword()
        {
            IsPassword = !IsPassword;
            EyeIcon = IsPassword ? "https://icons.veryicon.com/png/o/photographic/ant-design-official-icon-library/eye-close-1.png" : "https://icons.veryicon.com/png/o/miscellaneous/myfont/eye-open-4.png";
        }
        #endregion
        #region Constructor
        public VMLogin(INavigation navigation)
        {
            navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
            ComandoLogin = new Command(async () => await ValidarLogin());
            TogglePasswordCommand = new Command(OnTogglePassword);
        }
        #endregion

        #region Comando
        public Command ComandoLogin { get; }
        #endregion
    }
}
