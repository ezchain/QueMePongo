using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using System.Net.Mail;

namespace QueMePongo.Negocio.Comunicacion
{
    public class Email : INotificador
    {
        public string Mail { get; set; }
        public SmtpClient Client { get; set; }

        public Email(string mail, string credenciales, string dominio)
        {
            this.Mail = mail;
            Client = new SmtpClient(mail, 25)
            {
                Credentials = new System.Net.NetworkCredential(mail, credenciales),
                UseDefaultCredentials = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };
        }

        public void NotificarSugerencias(Usuario usuario, Evento evento)
        {
            MailMessage mail = new MailMessage(Mail, usuario.Mail)
            {
                Subject = "Nueva sugerencia",
                Body = "Sugerencia lista para el evento " + evento.Nombre
            };
            Client.Send(mail);

        }
        public void NotificarAlertaMeterologica(int idUsuario, string alerta)
        {

        }

    }

    public class SMS : INotificador
    {
        public void NotificarSugerencias(Usuario usuario, Evento evento)
        {

        }
        public void NotificarAlertaMeterologica(int idUsuario, string alerta)
        {

        }

    }
    public class Whatapps : INotificador
    {
        public void NotificarSugerencias(Usuario usuario, Evento evento)
        {

        }
        public void NotificarAlertaMeterologica(int idUsuario, string alerta)
        {

        }
    }
}
