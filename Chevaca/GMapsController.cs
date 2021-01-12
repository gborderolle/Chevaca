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
            }

            return "Hello from GMaps Controller";
        }

        [HttpPost]
        public IHttpActionResult GeoJson(string data_value)
        {
            ObjetoJSON objeto = JsonConvert.DeserializeObject<ObjetoJSON>(data_value);
            return Ok("Nombre: " + objeto.nombre + " y appelido: " + objeto.apellido);
        }        

        [HttpPost]
        public IHttpActionResult SendText(string data_value)
        {
            return Ok("OK data: " + data_value);
        }

        [HttpPost]
        public IHttpActionResult SendGeo1(string alt, string hdop, string info, string lat, string lon)
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
                    _log_API.Dato_completo = "alt=" + alt + "&" + "hdop=" + hdop + "&" + "info=" + info + "&" + "lat=" + lat + "&" + "lon=" + lon;
                    _log_API.Metodo = "SendGeo1";

                    context.logs_API.Add(_log_API);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Logs.AddErrorLog("Excepcion. Usando API HttpPost. ERROR:", className, methodName, ex.Message);
                }
            }
            return Ok("OK data: " + info);
        }

        [HttpPost]
        public IHttpActionResult SendGeo2(string objectJSON)
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
                    _log_API.Dato_largo = objectJSON;
                    _log_API.Metodo = "SendGeo2";

                    context.logs_API.Add(_log_API);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Logs.AddErrorLog("Excepcion. Usando API HttpPost. ERROR:", className, methodName, ex.Message);
                }
            }
            return Ok("OK data: " + objectJSON);
        }

        [HttpPost]
        public IHttpActionResult SendGeo3([FromBody] ObjetoJSON objectJSON)
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
                    _log_API.Dato_largo = "objectJSON=" + objectJSON.ToString();
                    _log_API.Metodo = "SendGeo3";

                    context.logs_API.Add(_log_API);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Logs.AddErrorLog("Excepcion. Usando API HttpPost. ERROR:", className, methodName, ex.Message);
                }
            }
            return Ok("OK data: " + objectJSON);
        }

        [HttpPost]
        public IHttpActionResult SendGeo4()
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
                    _log_API.Metodo = "SendGeo4";

                    context.logs_API.Add(_log_API);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Logs.AddErrorLog("Excepcion. Usando API HttpPost. ERROR:", className, methodName, ex.Message);
                }
            }
            return Ok("OK data");
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] ObjetoJSON_2 objectJSON)
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
                        //_log_API.Dato_largo = "objectJSON=" + objectJSON.ToString();
                        _log_API.Metodo = "Post";

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

        public class ObjetoJSON
        {
            public string nombre { get; set; }
            public string apellido { get; set; }

            public string toString()
            {
                return "[" + this.nombre + " / " + this.apellido + "]";
            }
        }

        public class ObjetoJSON_2
        {
            public string adr { get; set; }
            public string applicationID { get; set; }
            public string applicationName{ get; set; }
            public string confirmedUplink { get; set; }
            public string data { get; set; }
            public string devAddr { get; set; }
            public string devEUI { get; set; }
            public string deviceName { get; set; }
            public string dr{ get; set; }
            public string fCnt { get; set; }
            public string fPort { get; set; }
            public string objectJSON { get; set; }
            public string rxInfo { get; set; }
            public string tags { get; set; }
            public string txInfo { get; set; }

            public string toString()
            {
                return "Objeto JSON";
            }
        }

    }
}