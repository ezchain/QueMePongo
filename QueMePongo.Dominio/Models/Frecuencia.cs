using QueMePongo.Dominio.Interfaces;
using System;
using System.Timers;

namespace QueMePongo.Dominio.Models
{
    public class Frecuencia : IFrecuencia
    {
        private Timer _timer;
        private Action<Evento> _getSugerencia;
        private Evento _evento;

        public Frecuencia(double dias, Action<Evento> getSugerencia, Evento evento)
        {
            _evento = evento;

            _timer = new Timer(Helper.DiasEnMilisegundos(dias));
            _timer.AutoReset = false;
            _timer.Elapsed += OnTimedEvent;
            _timer.Start();
        }

        public bool TiempoTranscurrido()
        {
            bool finalizo = !_timer.Enabled;
            if (finalizo) _timer.Start();
            return finalizo;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            _getSugerencia(_evento);
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
        public double Intervalo { get; set; }

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
