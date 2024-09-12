using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AdminDelivery.Conexion;
using AdminDelivery.Modelo;
using Firebase.Database.Query;
namespace AdminDelivery.Datos
{
    public class DUsuarioAdmin
    {
        public async Task<bool> InsertarUsuarioAdmin(MUsuarioAdmin usuarios)
        {
            // Insertar el nuevo usuario
            await ConexionFirebase.ClientFirebase
                .Child("UsuarioAdmin")
                .PostAsync(new MUsuarioAdmin()
                {
                    Correo = usuarios.Correo,
                    Dni = usuarios.Dni,
                    NombreCompleto = usuarios.NombreCompleto,
                    Foto = usuarios.Foto,
                });

            return true;
        }
    }
}
