using QueMePongo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueMePongo.Dominio.Enums
{
    public enum FrecuenciaEvento
    {
        [IntervaloFrecuencia(1)]
        Diaria = 1,

        [IntervaloFrecuencia(7)]
        Semanal = 2,

        [IntervaloFrecuencia(30)]
        Mensual = 3,

        [IntervaloFrecuencia(365)]
        Anual = 4

    }
}
