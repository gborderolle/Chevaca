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
        {/*
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;
            string exception_message = string.Empty;

            using (ChevacaDB1 context = new ChevacaDB1())
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
            }*/
            return "Hello from GMaps Controller";
        }

        [HttpPost]
        public IHttpActionResult SendText(string data_value)
        {
            return Ok("OK data: " + data_value);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] JSON_Body objectJSON)
        {
            try
            {
                // Logger variables
                System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
                System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
                string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
                string methodName = stackFrame.GetMethod().Name;
                string exception_message = string.Empty;

                using (ChevacaDB1 context = new ChevacaDB1())
                {
                    try
                    {
                        logs_API _log_API = new logs_API();
                        _log_API.Fecha = DateTime.Now;
                        _log_API.Gateway = objectJSON.applicationName;
                        _log_API.Metodo = "Post";
                        _log_API.Body = objectJSON.ToString();

                        if (!string.IsNullOrWhiteSpace(objectJSON.objectJSON))
                        {
                            _log_API.JSON = objectJSON.objectJSON;

                            JSON_Body_Data_2 _JSON_Body_Data = JsonConvert.DeserializeObject<JSON_Body_Data_2>(objectJSON.objectJSON);
                            if (_JSON_Body_Data != null)
                            {

                                int latitud_int = 0;
                                if (!int.TryParse(_JSON_Body_Data.alt, out latitud_int))
                                {
                                    latitud_int = 0;
                                    Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, _JSON_Body_Data.alt);
                                }
                                _log_API.Altitud = latitud_int;

                                decimal hdop_decimal = 0;
                                if (!decimal.TryParse(_JSON_Body_Data.hdop, out hdop_decimal))
                                {
                                    hdop_decimal = 0;
                                    Logs.AddErrorLog("Excepcion. Convirtiendo decimal. ERROR:", className, methodName, _JSON_Body_Data.hdop);
                                }
                                _log_API.Hdop = hdop_decimal;

                                decimal latitud_decimal = 0;
                                if (!decimal.TryParse(_JSON_Body_Data.lat, out latitud_decimal))
                                {
                                    latitud_decimal = 0;
                                    Logs.AddErrorLog("Excepcion. Convirtiendo decimal. ERROR:", className, methodName, _JSON_Body_Data.lat);
                                }
                                _log_API.Latitud = latitud_decimal;

                                decimal longitud_decimal = 0;
                                if (!decimal.TryParse(_JSON_Body_Data.lon, out longitud_decimal))
                                {
                                    longitud_decimal = 0;
                                    Logs.AddErrorLog("Excepcion. Convirtiendo decimal. ERROR:", className, methodName, _JSON_Body_Data.lon);
                                }
                                _log_API.Longitud = longitud_decimal;
                            }
                        }

                        context.logs_API.Add(_log_API);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Logs.AddErrorLog("Excepcion. Usando API HttpPost. ERROR:", className, methodName, ex.Message);
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
            //public JSON_Body_Data objectJSON { get; set; }
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
            public int alt { get; set; }
            public decimal hdop { get; set; }
            public string info { get; set; }
            public decimal lat { get; set; }
            public decimal lon { get; set; }

            public override string ToString()
            {
                return "{alt:" + alt + ",hdop:" + hdop + ",info:" + info + ",lat:" + lat + ",lon:" + lon + "}";
            }
        }

        public class JSON_Body_Data_2
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