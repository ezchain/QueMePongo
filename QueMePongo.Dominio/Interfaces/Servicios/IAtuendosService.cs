﻿using System.Collections.Generic;
using QueMePongo.Dominio.DTOs;
using QueMePongo.Dominio.Models;

namespace QueMePongo.Dominio.Interfaces.Servicios
{
    public interface IAtuendosService
    {
        IEnumerable<Atuendo> GenerarAtuendosPorGuardarropa(int guardarropaId);
        IEnumerable<Atuendo> GenerarAtuendosPorUsuario(int usuarioId);
        IEnumerable<Atuendo> GenerarAtuendosPorEvento(decimal? temperatura, Evento evento);
        bool ValidarSugerencia(Atuendo atuendo, int idUsuario);
    }
}