using Chevaca.Global_Objects;
using Chevaca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chevaca.User_Controls
{
    public partial class Vacas : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            lblMessage.Text = "";
            gridVacas.UseAccessibleHeader = true;
            gridVacas.HeaderRow.TableSection = TableRowSection.TableHeader;
            //this.LoadCompleted();
        }

        private void BindGrid()
        {
            using (ChevacaDB1 context = new ChevacaDB1())
            {
                hdnVacasCount.Value = context.vacas.Count().ToString();
                if (context.vacas.Count() > 0)
                {
                    gridVacas.DataSource = context.vacas.ToList();
                    gridVacas.DataBind();
                }
                else
                {
                    var obj = new List<vacas>();
                    obj.Add(new vacas());
                    // Bind the DataTable which contain a blank row to the GridView
                    gridVacas.DataSource = obj;
                    gridVacas.DataBind();
                    int columnsCount = gridVacas.Columns.Count;
                    gridVacas.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridVacas.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridVacas.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    //You can set the styles here
                    gridVacas.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridVacas.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridVacas.Rows[0].Cells[0].Font.Bold = true;
                    //set No Results found to the new added cell
                    gridVacas.Rows[0].Cells[0].Text = "No hay registros";
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "updateCounts", "updateCounts();", true);
            }
        }

        protected void gridVacas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            #region Botones de acción

            ScriptManager ScriptManager1 = ScriptManager.GetCurrent(this.Page);
            if (ScriptManager1 != null)
            {
                LinkButton lnk = null;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    lnk = e.Row.FindControl("lnkEdit") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }

                    lnk = e.Row.FindControl("lnkDelete") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }

                    lnk = e.Row.FindControl("lnkInsert") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }

                    lnk = e.Row.FindControl("lnkCancel") as LinkButton;
                    if (lnk != null)
                    {
                        ScriptManager1.RegisterAsyncPostBackControl(lnk);
                    }
                }
            }

            #endregion
        }
        protected void gridVacas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            if (e.CommandName == "InsertNew")
            {
                GridViewRow row = gridVacas.FooterRow;
                TextBox txb1 = row.FindControl("txbNew1") as TextBox;
                TextBox txb2 = row.FindControl("txbNew2") as TextBox;
                TextBox txb3 = row.FindControl("txbNew3") as TextBox;

                if (txb1 != null && txb2 != null && txb3 != null)
                {
                    using (ChevacaDB1 context = new ChevacaDB1())
                    {
                        #region Agregar registro

                        vacas obj = new vacas();
                        obj.Nombre = txb1.Text;

                        int Estancia_ID = 0;
                        if (!int.TryParse(txb2.Text, out Estancia_ID))
                        {
                            Estancia_ID = 0;
                            Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, txb2.Text);
                        }
                        obj.Estancia_ID = Estancia_ID;

                        obj.MGAP_ID = txb3.Text;

                        context.vacas.Add(obj);
                        context.SaveChanges();
                        
                        #endregion 

                        #region Save log 
                        try
                        {
                            int id = 1;
                            vacas vacas = (vacas)context.vacas.OrderByDescending(p => p.Vaca_ID).FirstOrDefault();
                            if (vacas != null)
                            {
                                id = vacas.Vaca_ID;
                            }

                            string userID1 = HttpContext.Current.Session["UserID"].ToString();
                            string username = HttpContext.Current.Session["UserName"].ToString();
                            Global_Objects.Logs.AddUserLog("Agrega vacas", vacas.GetType().Name + ": " + id, userID1, username);
                        }
                        catch (Exception ex)
                        {
                            Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                        }
                        #endregion

                        lblMessage.Text = "Agregado correctamente.";
                        BindGrid();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Por favor ingrese el Nombre');", true);
                }
            }
            else if (e.CommandName == "View")
            {
                string[] values = e.CommandArgument.ToString().Split(new char[] { ',' });
                if (values.Length > 1)
                {
                    string tabla = values[0];
                    string dato = values[1];
                    if (!string.IsNullOrWhiteSpace(tabla) && !string.IsNullOrWhiteSpace(dato))
                    {
                        Response.Redirect("Listados.aspx?tabla=" + tabla + "&dato=" + dato);
                    }
                }

            }
            else
            {
                //BindGrid();
            }
        }
        protected void gridVacas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridVacas.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void gridVacas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridVacas.EditIndex = -1;
            BindGrid();
        }
        protected void gridVacas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

            GridViewRow row = gridVacas.Rows[e.RowIndex];
            TextBox txb1 = row.FindControl("txb1") as TextBox;
            TextBox txb2 = row.FindControl("txb2") as TextBox;
            TextBox txb3 = row.FindControl("txb3") as TextBox;
            if (txb1 != null && txb2 != null && txb3 != null)
            {
                using (ChevacaDB1 context = new ChevacaDB1())
                {
                    #region Update registro 

                    //vacas obj = (vacas)(e.Row.DataItem);
                    int id = Convert.ToInt32(gridVacas.DataKeys[e.RowIndex].Value);
                    vacas obj = context.vacas.FirstOrDefault(x => x.Vaca_ID == id);
                    if (obj != null)
                    {
                        obj.Nombre = txb1.Text;

                        int Estancia_ID = obj.Estancia_ID;
                        if (!int.TryParse(txb2.Text, out Estancia_ID))
                        {
                            Estancia_ID = obj.Estancia_ID;
                            Logs.AddErrorLog("Excepcion. Convirtiendo int. ERROR:", className, methodName, txb2.Text);
                        }
                        obj.Estancia_ID = Estancia_ID;

                        obj.MGAP_ID = txb3.Text;

                        context.SaveChanges();

                    }

                    #endregion

                    context.SaveChanges();

                    #region Save log 
                    try
                    {
                        string userID1 = HttpContext.Current.Session["UserID"].ToString();
                        string username = HttpContext.Current.Session["UserName"].ToString();
                        Global_Objects.Logs.AddUserLog("Modifica vacas", obj.GetType().Name + ": " + obj.Vaca_ID, userID1, username);
                    }
                    catch (Exception ex)
                    {
                        Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                    }
                    #endregion

                    lblMessage.Text = "Guardado correctamente.";
                    gridVacas.EditIndex = -1;
                    BindGrid();
                }
            }
        }
        protected void gridVacas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);
            System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;


            int Usuario_ID = Convert.ToInt32(gridVacas.DataKeys[e.RowIndex].Value);
            using (ChevacaDB1 context = new ChevacaDB1())
            {
                vacas obj = context.vacas.First(x => x.Vaca_ID == Usuario_ID);
                context.vacas.Remove(obj);
                context.SaveChanges();

                #region Save log 
                try
                {
                    string userID1 = HttpContext.Current.Session["UserID"].ToString();
                    string username = HttpContext.Current.Session["UserName"].ToString();
                    Global_Objects.Logs.AddUserLog("Borra vacas", obj.GetType().Name + ": " + obj.Vaca_ID, userID1, username);
                }
                catch (Exception ex)
                {
                    Global_Objects.Logs.AddErrorLog("Excepcion. Guardando log. ERROR:", className, methodName, ex.Message);
                }
                #endregion

                BindGrid();
                lblMessage.Text = "Borrado correctamente.";
            }
        }
        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recupera la fila.
            GridViewRow pagerRow = gridVacas.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
            //// Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gridVacas.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            lblMessage.Text = "";
        }
       
    }
}