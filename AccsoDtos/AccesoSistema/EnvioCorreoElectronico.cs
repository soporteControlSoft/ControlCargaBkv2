using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MdloDtos.IModelos;

namespace AccsoDtos.AccesoSistema
{
    /// <summary>
    /// Clase para el envio de correo electronico.
    /// Daniel Alejandro Lopez
    /// </summary>
    public class EnvioCorreoElectronico: IEnvioCorreo
    {
 
        public  bool Enviar_Correo_Directo(MdloDtos.CorreoElectronico ObjcorreoElectronico)
        {
            System.Net.Mail.MailMessage email;
            System.Net.Mail.MailAddress mPara;
            System.Net.Mail.MailAddress mDe;
            System.Net.Mail.MailAddress mAddr;
            System.Net.Mail.SmtpClient SMTPClient = new System.Net.Mail.SmtpClient();
            string[] APara;
            int Cont;

            try
            {
                Cont = 0;

                if (ObjcorreoElectronico.Servidor_Correo == "") ObjcorreoElectronico.Servidor_Correo = "smtp.gmail.com";
                if (ObjcorreoElectronico.Puerto_Correo == 0) ObjcorreoElectronico.Puerto_Correo = 587;

                mDe = new System.Net.Mail.MailAddress(ObjcorreoElectronico.Cuenta_Correo);
                ObjcorreoElectronico.Para = ObjcorreoElectronico.Para.Replace("\r\n", ";").Replace(",", ";");
                ObjcorreoElectronico.Para = ObjcorreoElectronico.Para.Replace(";;", ";");
                APara = ObjcorreoElectronico.Para.Split(';');
                mPara = new System.Net.Mail.MailAddress(APara[0]);
                email = new System.Net.Mail.MailMessage(mDe, mPara);
                Cont = 0;
                foreach (string Copia in APara)
                {
                    if (Cont > 0 && Copia.Trim() != "")
                    {
                        mAddr = new System.Net.Mail.MailAddress(Copia);
                        email.CC.Add(mAddr);
                    }
                    Cont++;
                }
                email.Subject = ObjcorreoElectronico.Asunto;
                email.BodyEncoding = System.Text.Encoding.Default;
                email.IsBodyHtml = true;
                email.Body = ObjcorreoElectronico.Mensaje;
                SMTPClient.Host = ObjcorreoElectronico.Servidor_Correo; // "smtp.gmail.com"
                SMTPClient.Port = ObjcorreoElectronico.Puerto_Correo; //  465(con SSL) y en el puerto 587 (con TLS) o  puerto 25 (con SSL).
                // El protocolo TLS (Transport Layer Security, seguridad de la capa de transporte) es el protocolo sucesor de SSL. TLS es una versión mejorada de SSL. Funciona de un modo muy parecido a SSL, utilizando cifrado que protege la transferencia de datos e información
                SMTPClient.Credentials = new System.Net.NetworkCredential(ObjcorreoElectronico.Cuenta_Correo, ObjcorreoElectronico.Clave_Correo);
                SMTPClient.EnableSsl = true; // VPar.Correo_Conexion_Segura

                //SMTPClient.ConnectType = SmtpConnectType.ConnectSSLAuto;
                //  ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                // If mParametros.Ruta.Trim <> "" Then
                // Arch = mParametros.Ruta.Split(";")
                // For Each Archivo In Arch
                if (ObjcorreoElectronico.Nombre_Archivo != "")
                    email.Attachments.Add(new System.Net.Mail.Attachment(ObjcorreoElectronico.Nombre_Archivo));
                // Next
                // End If

                // Se incluye esta asignación cuando se genera el mensaje:
                // El certificado remoto no es válido según el procedimiento de validación.
                ServicePointManager.ServerCertificateValidationCallback = (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true;

                SMTPClient.Send(email);

                email.Dispose(); // Necesario para liberar los archivos enviados como adjuntos

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ObjcorreoElectronico.Msg_error = ex.Message;
                if (ex.InnerException != null)
                    ObjcorreoElectronico.Msg_error += " -> " + ex.InnerException.Message;
            }
            return false;
        }
    }
}
