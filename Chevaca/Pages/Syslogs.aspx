<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Syslogs.aspx.cs" Inherits="Chevaca.Syslogs" Title="Logs"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <!-- STYLES EXTENSION -->

    <!-- Theme style -->
    <link rel="stylesheet" href="/Content/css/pages/datos.css" />

    <style type="text/css">
        .body-content {
            margin-top: 30px;
        }

        @media (max-width: 768px) {
            body {
                width: fit-content;
            }

            h2 {
                font-size: large;
            }
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SubbodyContent" runat="server">

    <!-- PAGE SCRIPTS -->
    <script type="text/javascript" src="../Content/js/libs/jquery.quicksearch.js"></script>
    <script type="text/javascript" src="../Content/js/libs/jquery.tablesorter.js"></script>

    <!-- PAGE JS -->
    <script type="text/javascript" src="../Content/js/pages/syslogs.js"></script>

    <!-- PAGE CSS -->
    <script type="text/javascript" src="../Content/css/helpers/modal_styles.css"></script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box box-default">
        <div class="box-header with-border" style="padding-bottom: 0;">

            <div class="row">
                <div class="col-md-9">
                    <h1 style="font-size: 24px;">Menú de Logs</h1>
                </div>
            </div>

            <div class="panel panel-default" style="margin-top: 10px; padding-top: 10px;">

                <div class="row" style="padding: 20px; padding-top: 3px">
                    <div class="col-md-2 col-sm-12 pull-left">
                            <div class="input-group ">
                                <input type="text" id="txbSearch" name="q" class="form-control" placeholder="Buscar..."/>
                                <span class="input-group-btn">
                                    <a id="btnSearchPedidos" role="button" href="#" name="search" class="btn btn-info">
                                        <i class="glyphicon glyphicon-search"></i>
                                    </a>
                                </span>
                            </div>
                    </div>

                    <div class="col-md-2 col-sm-12 pull-right" style="display: flex;">
                        <input type="text" id="txbFiltro1" class="form-control datepicker" placeholder="Desde" runat="server" style="width: 120px;">
                        <span class="input-group-btn"></span>

                        <input type="text" id="txbFiltro2" class="form-control datepicker" placeholder="Hasta" runat="server" style="width: 120px;">
                        <span class="input-group-btn"></span>

                        <asp:Button ID="btnSearch" runat="server" Text="Filtrar" CssClass="btn btnUpdate btn-sm"
                            OnClick="btnSearch_Click" UseSubmitBehavior="false" ClientIDMode="Static" CausesValidation="false" />
                    </div>
                </div>

            <div class="panel panel-default">

                <asp:UpdatePanel ID="upgridLogs" runat="server">
                    <ContentTemplate>

                        <asp:Label ID="gridLogs_lblMessage" runat="server" Text="" ForeColor="Red" Font-Size="Large"></asp:Label>
                        <asp:GridView ID="gridLogs" runat="server" ClientIDMode="Static" HorizontalAlign="Center"
                            AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-hover table-striped"
                            DataKeyNames="Log_ID" PageSize="30"
                            OnPageIndexChanging="grid_PageIndexChanging" AllowSorting="True">

                            <FooterStyle Font-Size="12pt" />
                            <PagerStyle Font-Size="16pt" HorizontalAlign="Center" />

                            <RowStyle Font-Size="Medium" />

                            <AlternatingRowStyle BackColor="#E2E2E2" />

                            <Columns>
                                <asp:BoundField DataField="Log_ID" HeaderText="ID" HtmlEncode="false" ReadOnly="true" ItemStyle-CssClass="hiddencol_real" HeaderStyle-CssClass="hiddencol_real">
                                    <HeaderStyle CssClass="hiddencol_real" />
                                    <ItemStyle CssClass="hiddencol_real" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha_creado" HeaderText="Fecha" DataFormatString="{0:dd-MM-yyyy HH:mm:ss}" HtmlEncode="false" ReadOnly="true" />
                                <asp:BoundField DataField="Usuario" HeaderText="Usuario" HtmlEncode="false" ReadOnly="true" />
                                <asp:BoundField DataField="IP_client" HeaderText="IP" HtmlEncode="false" ReadOnly="true" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" HtmlEncode="false" ReadOnly="true" />
                                <asp:BoundField DataField="Dato_afectado" HeaderText="ID Objeto" HtmlEncode="false" ReadOnly="true" />
                            </Columns>
                        </asp:GridView>

                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
            </div>
        </div>
    </div>



</asp:Content>
