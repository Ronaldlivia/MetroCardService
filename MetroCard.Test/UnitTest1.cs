using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace MetroCard.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAutenticarOk()
        {
            WSSeguridad.SeguridadServiceClient proxy = new WSSeguridad.SeguridadServiceClient();

            WSSeguridad.Usuario objUsuario = new WSSeguridad.Usuario();
            objUsuario.Correo = "gp.paraguay@gmail.com";
            objUsuario.Clave = "12345+";

            WSSeguridad.UsuarioResponse objUsuarioResponse = proxy.AutenticarUsuario(objUsuario);
        }

        [TestMethod]
        public void TestAutenticarError1()
        {
            WSSeguridad.SeguridadServiceClient proxy = new WSSeguridad.SeguridadServiceClient();

            WSSeguridad.Usuario objUsuario = new WSSeguridad.Usuario();
            objUsuario.Correo = "gp.paraguay@gmail.com";
            objUsuario.Clave = "";

            WSSeguridad.UsuarioResponse objUsuarioResponse = proxy.AutenticarUsuario(objUsuario);

            if (!objUsuarioResponse.EsValido)
            {
                Assert.AreEqual("Error", objUsuarioResponse.Mensaje);
            }
        }

        [TestMethod]
        public void TestAutenticarError2()
        {
            WSSeguridad.SeguridadServiceClient proxy = new WSSeguridad.SeguridadServiceClient();

            WSSeguridad.Usuario objUsuario = new WSSeguridad.Usuario();
            objUsuario.Correo = "gp.paraguay@gmail.com";
            objUsuario.Clave = "1234+";

            WSSeguridad.UsuarioResponse objUsuarioResponse = proxy.AutenticarUsuario(objUsuario);

            if (!objUsuarioResponse.EsValido)
            {
                Assert.AreEqual("Error", objUsuarioResponse.Mensaje);
            }
        }

        //[TestMethod]
        //public void TestRegistarUsuario()
        //{
        //    WSUsuario.UsuarioServiceClient proxy = new WSUsuario.UsuarioServiceClient();

        //    try
        //    {
        //        WSUsuario.Usuario objUsuario = new WSUsuario.Usuario();
        //        objUsuario.Nombres = "CARLOS";
        //        objUsuario.ApellidoPaterno = "HERNANDEZ";
        //        objUsuario.ApellidoMaterno = "PEREZ";
        //        objUsuario.IdTipoDocumento = 1;
        //        objUsuario.NroDocumento = "00996677";
        //        objUsuario.FechaNacimiento = Convert.ToDateTime("12/11/1982");
        //        objUsuario.NroTelefono = "998526374";
        //        objUsuario.Correo = "ch.perez@gmail.com";
        //        objUsuario.Clave = "12345+";

        //        int resultado = proxy.RegistrarUsuario(objUsuario);
        //    }
        //    catch (FaultException<WSUsuario.RepetidorException> error)
        //    {
        //        Assert.AreEqual("Error", error.Reason);
        //    }
        //}
    }
}
