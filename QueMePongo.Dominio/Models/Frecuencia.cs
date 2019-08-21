using QueMePongo.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace QueMePongo.Dominio.Models
{
    public class Frecuencia : IFrecuencia
    {
        Timer timer;
        public Frecuencia(double dias)
        {
            timer = new Timer(Helper.DiasEnMilisegundos(dias));
            timer.AutoReset = false;
            timer.Start();
        }
        public bool TiempoTranscurrido()
        {
            bool finalizo = !timer.Enabled;
            if (finalizo) timer.Start();
            return finalizo;
        }

    }

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

    [AttributeUsage(AttributeTargets.Field)]
    public class IntervaloFrecuencia : Attribute
    {
        public double Intervalo  { get; set; }

        public IntervaloFrecuencia(double intervalo)
        {
            Intervalo = intervalo;
        }
    }
    //public class Diaria : IFrecuencia
    //{
    //    Timer timer;
    //    public Diaria()
    //    {
    //         timer = new Timer(Helper.DiasEnMilisegundos(1));
    //         timer.AutoReset = false;
    //         timer.Start();
    //    }
    //    public bool TiempoTranscurrido()
    //    {
    //        bool finalizo = !timer.Enabled;
    //        if (finalizo) timer.Start();
    //        return finalizo;
    //    }

    //}
    //public class Semanal : IFrecuencia
    //{
    //    Timer timer;

    //    public Semanal()
    //    {
    //        timer = new Timer(Helper.DiasEnMilisegundos(7));
    //        timer.AutoReset = false;
    //        timer.Start();
    //    }
    //    public bool TiempoTranscurrido()
    //    {
    //        bool finalizo = !timer.Enabled;
    //        if (finalizo) timer.Start();
    //        return finalizo;
    //    }

    //}
    //public class Mensual : IFrecuencia
    //{
    //    Timer timer;
    //    public Mensual()
    //    {
    //        timer = new Timer(Helper.DiasEnMilisegundos(30));
    //        timer.AutoReset = false;
    //        timer.Start();
    //    }
    //    public bool TiempoTranscurrido()
    //    {
    //        bool finalizo = !timer.Enabled;
    //        if (finalizo) timer.Start();
    //        return finalizo;
    //    }

    //}

    //public class Anual : IFrecuencia
    //{
    //    Timer timer;
    //    public Anual()
    //    {
    //        timer = new Timer(Helper.DiasEnMilisegundos(365));
    //        timer.AutoReset = false;
    //        timer.Start();
    //    }
    //    public bool TiempoTranscurrido()
    //    {
    //        bool finalizo = !timer.Enabled;
    //        if (finalizo) timer.Start();
    //        return finalizo;
    //    }

    //}

}
