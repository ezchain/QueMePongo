using QueMePongo.Dominio.Interfaces;
using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Negocio.Comunicacion
{
    public class Email : INotificador
    {
        public void NotificarSugerencias(int idUsuario, Evento evento)
        {

        }
        public void NotificarAlertaMeterologica(int idUsuario, string alerta)
        {

        }

    }

    public class SMS : INotificador
    {
        public void NotificarSugerencias(int idUsuario, Evento evento)
        {

        }
        public void NotificarAlertaMeterologica(int idUsuario, string alerta)
        {

        }

    }
    public class Whatapps : INotificador
    {
        public void NotificarSugerencias(int idUsuario, Evento evento)
        {

        }
        public void NotificarAlertaMeterologica(int idUsuario, string alerta)
        {

        }
    }
}
