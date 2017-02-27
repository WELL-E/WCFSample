using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WCF.Common;

namespace WCF.Client
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LogHelper.Debug("------Onstartup------");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            LogHelper.Debug("------OnExit------");

            base.OnExit(e);
        }
    }
}
