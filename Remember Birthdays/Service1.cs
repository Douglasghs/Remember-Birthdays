using Remember_Birthdays.Log;
using Remember_Birthdays.ReadXML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Remember_Birthdays
{
    public partial class Service1 : ServiceBase
    {

        #region MyRegion

        clsReadXML clsReadXML;

        #endregion

        public Service1()
        {
            InitializeComponent();

            // DEPENDÊNCIAS
            clsReadXML = new clsReadXML();
        }

        protected override void OnStart(string[] args)
        {
            // CONFIG LOGS
            LogClass.LogPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Logs");
            clsReadXML.ReadXml();
            string _LogLevel = clsReadXML.getLog();
            LogClass.SetLogLevel(getLogLevel(_LogLevel));
            LogClass.Write(LogClass.LogTag.Info, "Progama iniciado");
        }

        protected override void OnStop()
        {
            LogClass.Write(LogClass.LogTag.Info, "Progama encerrado");
        }

        private static LogClass.LogTag getLogLevel(string Loglevel)
        {
            LogClass.LogTag result = LogClass.LogTag.Debug;
            //OfficeMarketRepasso._getLogLevel = Configuration.GetConnectionString("ConfigApp");
            //String sConfigLogLevel = ConfigurationManager.AppSettings["LogLevel"];

            String sConfigLogLevel = Loglevel;
            switch (sConfigLogLevel.ToUpper())
            {
                case "INFO":
                    result = LogClass.LogTag.Info;
                    break;
                case "ERROR":
                    result = LogClass.LogTag.Error;
                    break;
                case "SYSTEM":
                    result = LogClass.LogTag.System;
                    break;
                case "WARNING":
                    result = LogClass.LogTag.Warning;
                    break;
            }
            return result;
        }
    }
}
