using System;
using System.ServiceProcess;

namespace Prueba.Servicios
{
    partial class ServicioPrueba : ServiceBase
    {
        private readonly IExecuteJobs _executeTask;

        public ServicioPrueba()
        {
            InitializeComponent();
            _executeTask = new ExecuteJobs();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: agregar código aquí para iniciar el servicio.
            try
            {
                _executeTask.Start();
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal("ServicioPrueba:OnStart", ex);
            }
        }

        protected override void OnStop()
        {
            // TODO: agregar código aquí para realizar cualquier anulación necesaria para detener el servicio.
            try
            {
                _executeTask.Stop();
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal("ServicioPrueba:OnStop", ex);
            }
        }
    }
}