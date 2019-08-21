using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Interfaces
{
  public interface INotificador
    {
        void NotificarSugerencias(int idUsuario, Evento evento);

        void NotificarAlertaMeterologica(int idUsuario, string alerta);

    }
}
