using Chevaca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chevaca.Pages
{
    public partial class GMaps : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static _Log_Devices[] Get_Devices(string dummy)
        {
            return Get_DB_Devices().ToArray();
        }

        public static List<_Log_Devices> Get_DB_Devices()
        {
            List<_Log_Devices> _Log_Devices_list = new List<_Log_Devices>();

            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            using (ChevacaDB context = new ChevacaDB())
            {
                // Hago este pasaje de logs_API a log_Devices para tener más control sobre los datos a futuro.
                string empty_dataint = "0";
                List<logs_API> logs_API_elements = context.logs_API.Where(v => !v.Altitud.Equals(empty_dataint)).GroupBy(v => v.Nodo).Select(v => v.FirstOrDefault()).OrderByDescending(v => v.Fecha).ToList();
                foreach (logs_API _logs_API in logs_API_elements)
                {
                    if (_logs_API != null)
                    {
                        _Log_Devices _Log_Devices1 = new _Log_Devices();
                        _Log_Devices1.Log_API_ID = _logs_API.Log_API_ID;
                        _Log_Devices1.LastUpdate = _logs_API.Fecha;
                        _Log_Devices1.Gateway = _logs_API.Gateway;
                        _Log_Devices1.Nodo = _logs_API.Nodo;
                        _Log_Devices1.Altitud = _logs_API.Altitud;
                        _Log_Devices1.Hdop = _logs_API.Hdop;
                        _Log_Devices1.Latitud = _logs_API.Latitud;
                        _Log_Devices1.Longitud = _logs_API.Longitud;

                        _Log_Devices_list.Add(_Log_Devices1);
                    }
                } // foreach
            }
            return _Log_Devices_list;
        }

    }
    public class _Log_Devices
    {
        public int Log_API_ID { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Gateway { get; set; }
        public string Nodo { get; set; }
        public string Altitud { get; set; }
        public string Hdop { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}