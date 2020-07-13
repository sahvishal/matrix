namespace Falcon.Jobs
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.JobServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.JobServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // JobServiceProcessInstaller
            // 
            this.JobServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.JobServiceProcessInstaller.Password = null;
            this.JobServiceProcessInstaller.Username = null;
            // 
            // JobServiceInstaller
            // 
            this.JobServiceInstaller.ServiceName = "JobService";
            this.JobServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.JobServiceProcessInstaller,
            this.JobServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller JobServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller JobServiceInstaller;
    }
}