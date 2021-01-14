using Chevaca.Global_Objects;
using Chevaca.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Web.Http;

namespace Chevaca
{
    public class GMapsController : ApiController
    {
        [AcceptVerbs("Get")]
        public string SayHello()
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;
            string exception_message = string.Empty;

            using (ChevacaDB context = new ChevacaDB())
            {
                try
                {
                    logs_API _log_API = new logs_API();
                    _log_API.Fecha = DateTime.Now;
                    _log_API.Metodo = "SayHello:GET";

                    context.logs_API.Add(_log_API);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Logs.AddErrorLog("Excepcion. Usando API HttpPost. ERROR:", className, methodName, ex.Message);
                }
            }
            return "Hello from GMaps Controller";
        }

        [HttpPost]
        public IHttpActionResult SendText(string data_value)
        {
            return Ok("OK data: " + data_value);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] JSON_Body _objectJSON)
        {
            try
            {
                // Logger variables
                System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
                System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
                string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
                string methodName = stackFrame.GetMethod().Name;
                string exception_message = string.Empty;

                using (ChevacaDB context = new ChevacaDB())
                {

                    logs_API _log_API = new logs_API();
                    _log_API.Fecha = GlobalVariables.GetCurrentTime();
                    _log_API.Gateway = _objectJSON.applicationName;
                    _log_API.Nodo = _objectJSON.deviceName;
                    _log_API.Metodo = "Post";
                    _log_API.Body = _objectJSON.ToString();
                    
                    if (!string.IsNullOrWhiteSpace(_objectJSON.objectJSON))
                    {
                        _log_API.JSON = _objectJSON.objectJSON;
                        JSON_Body_Data _JSON_Body_Data = JsonConvert.DeserializeObject<JSON_Body_Data>(_objectJSON.objectJSON);
                        if (_JSON_Body_Data != null)
                        {
                            _log_API.Altitud = _JSON_Body_Data.alt;
                            _log_API.Hdop = _JSON_Body_Data.hdop;
                            _log_API.Latitud = _JSON_Body_Data.lat;
                            _log_API.Longitud = _JSON_Body_Data.lon;
                        }
                        else
                        {
                            Logs.AddErrorLog("Excepcion. No pudo crear el JSON:", className, methodName, "");
                        }
                    }
                    try
                    {
                        context.logs_API.Add(_log_API);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Logs.AddErrorLog("Excepcion. Usando API HttpPost y guardando en BD. ERROR:", className, methodName, ex.Message);
                    }
                }
                var message = Request.CreateResponse(System.Net.HttpStatusCode.Created, "OK");
                message.Headers.Location = new Uri(Request.RequestUri + "Post");
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ex);
            }
        }

        public class JSON_Body
        {
            public string adr { get; set; }
            public string applicationID { get; set; }
            public string applicationName { get; set; }
            public string confirmedUplink { get; set; }
            public string data { get; set; }
            public string devAddr { get; set; }
            public string devEUI { get; set; }
            public string deviceName { get; set; }
            public string dr { get; set; }
            public string fCnt { get; set; }
            public string fPort { get; set; }
            public string objectJSON { get; set; }
            public string rxInfo { get; set; }
            public string tags { get; set; }
            public string txInfo { get; set; }

            public override string ToString()
            {
                return "{adr:" + adr + ",applicationID:" + applicationID + ",applicationName:" + applicationName + ",confirmedUplink:" + confirmedUplink + ",data:" + data + ",devAddr:" + devAddr + ",devEUI: " + devEUI + ",deviceName: " + deviceName + ",dr: " + dr + ",fCnt: " + fCnt + ",fPort: " + fPort + ",objectJSON: " + objectJSON.ToString() + ",rxInfo: " + rxInfo + ",txInfo: " + txInfo + "}";
            }
        }

        public class JSON_Body_Data
        {
            public string alt { get; set; }
            public string hdop { get; set; }
            public string info { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }

            public override string ToString()
            {
                return "{alt:" + alt + ",hdop:" + hdop + ",info:" + info + ",lat:" + lat + ",lon:" + lon + "}";
            }
        }

    }
}