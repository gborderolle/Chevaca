using Chevaca.Global_Objects;
using Chevaca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chevaca.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            Logout();
            Load_IPClient();
        }

        private void Load_IPClient()
        {
            string IP_client = Logs.GetIPAddress();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowIPClient", "ShowIPClient(' " + IP_client + "');", true);
        }

        protected void btnSubmit_candidato1_ServerClick(object sender, EventArgs e)
        {
            string username = txbUser.Value;
            string password = txbPassword.Value;
            Perform_login(username, password, false);
        }

        #endregion Events

        #region Methods

        private void Logout()
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
        }

        private void Perform_login(string username, string password, bool isPasswordInput_hashed = false)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;
            string exception_message = string.Empty;

            int resultado = 0;
            if (!string.IsNullOrWhiteSpace(username) || !string.IsNullOrWhiteSpace(password))
            {
                using (ChevacaDB1 context = new ChevacaDB1())
                {
                    try
                    {
                        string IP_client = Logs.GetIPAddress();

                        context.Database.Connection.Open();
                        usuarios _usuario = (usuarios)context.usuarios.FirstOrDefault(v => v.Usuario == username && v.Clave == password);
                        if (_usuario != null)
                        {
                            Session["UserID"] = _usuario.Usuario_ID;
                            Session["UserName"] = username;

                            #region Guardar log
                            try
                            {
                                string userID1 = _usuario.Usuario_ID.ToString();
                                Logs.AddUserLog("OK: Acceso al sistema correcto con contraseña: '" + password + "'.", "", userID1, username, IP_client);
                            }
                            catch (Exception ex)
                            {
                                Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                            }
                            #endregion

                            Response.Redirect("Datos", false);
                        }
                        else
                        {
                            // No se pudo autenticar
                            resultado = 2;
                            Logs.AddUserLog("ERROR: Intento de acceso al sistema con contraseña: '" + password + "'.", "", "-", username, IP_client);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logs.AddErrorLog("Excepcion. Haciendo login. ERROR:", className, methodName, ex.Message);
                        exception_message = ex.Message;
                        resultado = 3;
                    }
                }
            }
            else
            {
                resultado = 1;
            }

            ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowErrorMessage", "ShowErrorMessage('" + resultado + "', '" + exception_message + "');", true);
        }

        #endregion Methods
    }
}