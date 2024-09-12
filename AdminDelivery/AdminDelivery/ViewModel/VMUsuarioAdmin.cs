using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AdminDelivery.ViewModel;
using AdminDelivery.Datos;
using AdminDelivery.Modelo;
using Firebase.Auth;
using Xamarin.Forms;

namespace AdminDelivery.ViewModel
{
    public class VMUsuarioAdmin : BaseViewModel
    {
        #region Variables
        string correo;
        string dni;
        string nombreCompleto;
        string foto;
        string pass;
        #endregion
        #region Objetos
        public string txtCorreo
        {
            get { return correo; }
            set { SetValue(ref correo, value); }
        }
        public string txtDni
        {
            get { return dni; }
            set { SetValue(ref dni, value); }
        }
        public string txtNombreCompleto
        {
            get { return nombreCompleto; }
            set { SetValue(ref nombreCompleto, value); }
        }
        public string txtFoto
        {
            get { return foto; }
            set { SetValue(ref foto, value); }
        }
        public string txtPass
        {
            get { return pass; }
            set { SetValue(ref pass, value); }
        }
        #endregion
        #region Procesos
        public async Task insetarUsuarioAdmin()
        {
            var funcion = new DUsuarioAdmin();
            var campos = new MUsuarioAdmin();
            campos.Correo = correo;
            campos.Dni = dni;
            campos.NombreCompleto = nombreCompleto;
            campos.Foto = foto;
            var ejecucion = await funcion.InsertarUsuarioAdmin(campos);

            if (ejecucion == true)
            {
                await usuarioPass(txtCorreo,txtPass);
            }
        }
        public async Task usuarioPass(string correo, string pass)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Conexion.ConexionFirebase.TokenAuthentication));
            await authProvider.CreateUserWithEmailAndPasswordAsync(correo, pass);
            await DisplayAlert("Registro Exitoso", "Se registro el usuario Correctamente", "Ok");
        }
        #endregion

        #region Constructor
        public VMUsuarioAdmin(INavigation navigation)
        {
            navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
            ComandoInsertarUsuarioAdmin = new Command(async () => await insetarUsuarioAdmin());
        }
        #endregion

        #region Comando
        public Command ComandoInsertarUsuarioAdmin {  get; }
        #endregion

    }

}
