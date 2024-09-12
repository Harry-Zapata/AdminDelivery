using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Auth;
namespace AdminDelivery.Conexion
{
    public class ConexionFirebase
    {
        public static FirebaseClient
            ClientFirebase = new FirebaseClient
            ("https://appadmin1260061-default-rtdb.firebaseio.com");

        public const string TokenAuthentication = "AIzaSyASIoDJIIMp3h94CSMS2-d2vqg2nD6Mg-A";
    }
}
