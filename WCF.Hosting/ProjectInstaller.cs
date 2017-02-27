using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

namespace WCF.Hosting
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
