using Prueba.Servicios.StringTools;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Specialized;

namespace Prueba.Servicios
{
    public class ExecuteJobs : IExecuteJobs, IDisposable
    {
        /// <summary>
        /// Sheduler Time
        /// </summary>
        private static IScheduler _scheduler;

        /// <summary>
        /// StdSchedulerFactory
        /// </summary>
        private static StdSchedulerFactory _schedulerFactory;

        private bool disposedValue;

        /// <summary>
        /// Nombre del proceso
        /// </summary>
        private const string nameProcess = "ExecuteTaskTest";

        private readonly int minutesInterval;

        private readonly NameValueCollection collection = new NameValueCollection()
                {
                    {"quartz.threadPool.threadCount","5"},
                    {"quartz.scheduler.instanceName",string.Format("Scheduler{0}",nameProcess)},
                    {"quartz.threadPool.type","Quartz.Simpl.SimpleThreadPool, Quartz"},
                    {"quartz.threadPool.threadPriority","Normal"}
                };

        public ExecuteJobs()
        {
            var minutesKey = "minutesInterval".ReadAppConfig("5");
            minutesInterval = int.Parse(minutesKey);
            _schedulerFactory = new StdSchedulerFactory(collection);
        }

        public void Start()
        {
            try
            {
                IScheduler sheduler = _schedulerFactory.GetScheduler(nameProcess);
                _scheduler = sheduler ?? _schedulerFactory.GetScheduler();

                if (!_scheduler.IsStarted)
                    _scheduler.Start();

                JobDetailImpl job = new JobDetailImpl(nameProcess, typeof(MyJob));

                ITrigger trigger = trigger = TriggerBuilder.Create().
                            WithIdentity(string.Format("Trigger{0}", "TriggerExecuteTask"), string.Format("Group{0}", "groupExecuteTask"))
                            .WithSimpleSchedule
                            (s => s.WithIntervalInMinutes(minutesInterval).RepeatForever()).Build();

                DateTimeOffset date = _scheduler.ScheduleJob(job, trigger);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Stop()
        {
            try
            {
                if (_scheduler != null)
                    _scheduler.Shutdown(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region [Dispose]

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~ExecuteJobs()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion [Dispose]
    }

    public interface IExecuteJobs : IDisposable
    {
        void Start();

        void Stop();
    }
}