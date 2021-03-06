
namespace Prueba.Servicios
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.InstallerProcessOne = new System.ServiceProcess.ServiceProcessInstaller();
            this.ServicesInstallerOne = new System.ServiceProcess.ServiceInstaller();
            // 
            // InstallerProcessOne
            // 
            this.InstallerProcessOne.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.InstallerProcessOne.Password = null;
            this.InstallerProcessOne.Username = null;
            // 
            // ServicesInstallerOne
            // 
            this.ServicesInstallerOne.Description = "Servicio de Prueba Test";
            this.ServicesInstallerOne.DisplayName = "Servicio de Prueba Test";
            this.ServicesInstallerOne.ServiceName = "ServicioPruebaTest";
            this.ServicesInstallerOne.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.InstallerProcessOne,
            this.ServicesInstallerOne});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller InstallerProcessOne;
        private System.ServiceProcess.ServiceInstaller ServicesInstallerOne;
    }
}