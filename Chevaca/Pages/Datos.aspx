<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Datos.aspx.cs" Inherits="Chevaca.Pages.Datos" Title="Base de datos" %>

<%@ Register Src="~/User_Controls/Usuarios.ascx" TagPrefix="uc1" TagName="Usuarios" %>
<%@ Register Src="~/User_Controls/Vacas.ascx" TagPrefix="uc1" TagName="Vacas" %>
<%@ Register Src="~/User_Controls/Ovejas.ascx" TagPrefix="uc1" TagName="Ovejas" %>

<asp:content id="Content3" contentplaceholderid="HeadContent" runat="server">

    <!-- STYLES EXTENSION -->

    <!-- Theme style -->
    <link rel="stylesheet" href="../Content/css/pages/info_boxes.min.css" />
    <link rel="stylesheet" href="../Content/css/pages/datos.css" />

    <!-- AdminLTE Skins. Choose a skin from the css/skins
     folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="../Content/js/libs/plugins/skins/_all-skins.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="../Content/js/libs/plugins/iCheck/flat/blue.css">
    <!-- Morris chart -->
    <link rel="stylesheet" href="../Content/js/libs/plugins/morris/morris.css">
    <!-- jvectormap -->
    <link rel="stylesheet" href="../Content/js/libs/plugins/jvectormap/jquery-jvectormap-1.2.2.css">
    <!-- Date Picker -->
    <link rel="stylesheet" href="../Content/js/libs/plugins/datepicker/datepicker3.css">
    <!-- Daterange picker -->
    <link rel="stylesheet" href="../Content/js/libs/plugins/daterangepicker/daterangepicker.css">
    <!-- bootstrap wysihtml5 - text editor -->
    <link rel="stylesheet" href="../Content/js/libs/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
<script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
<script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
<![endif]-->


</asp:content>

<asp:content id="Content2" contentplaceholderid="SubbodyContent" runat="server">

    <!-- PAGE SCRIPTS -->
    <!-- Morris.js charts -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
    <script src="../Content/js/libs/plugins/morris/morris.min.js"></script>
    <!-- Sparkline -->
    <script src="../Content/js/libs/plugins/sparkline/jquery.sparkline.min.js"></script>
    <!-- jvectormap -->
    <script src="../Content/js/libs/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"></script>
    <script src="../Content/js/libs/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"></script>
    <!-- jQuery Knob Chart -->
    <script src="../Content/js/libs/plugins/knob/jquery.knob.js"></script>
    <!-- daterangepicker -->
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.11.2/moment.min.js"></script>--%>
    <script src="../Content/js/libs/moment.js"></script>
    <script src="../Content/js/libs/plugins/daterangepicker/daterangepicker.js"></script>
    <!-- datepicker -->
    <script src="../Content/js/libs/plugins/datepicker/bootstrap-datepicker.js"></script>
    <!-- Bootstrap WYSIHTML5 -->
    <script src="../Content/js/libs/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
    <!-- Slimscroll -->
    <script src="../Content/js/libs/plugins/slimScroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="../Content/js/libs/plugins/fastclick/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="../Content/js/libs/app.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script type="text/javascript" src="../Content/js/libs/jquery.quicksearch.js"></script>
    <script type="text/javascript" src="../Content/js/libs/demo.js"></script>

    <!-- PAGE JS -->
    <script type="text/javascript" src="../Content/js/helpers/auxiliares.js"></script>
    <script type="text/javascript" src="../Content/js/pages/datos.js"></script>
    <script type="text/javascript" src="../Content/js/libs/jquery.tablesorter.js"></script>

</asp:content>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="server">


    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper1">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Base de datos
        <a href="/Pages/Datos.aspx"><small style="color: black">Datos estáticos</small></a>
                <small>| </small>
                <a href="/Pages/Datos_configuracion.aspx"><small>Datos de configuración</small></a>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Inicio</a></li>
                <li class="active">Base de datos</li>
            </ol>
        </section>

        <!-- Main content -->
        <section class="content">

            <div class="row">
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box box-selected" id="divBoxUsuarios" style="border-color: darkgray; background: lightblue;">
                        <span class="info-box-icon bg-red"><i class="fa fa-users"></i></span>

                        <div class="info-box-content">
                            <span class="info-box-text">Usuarios</span>
                            <span class="info-box-number">0</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box box-selected" id="divBoxVacas">
                        <span class="info-box-icon bg-purple"><i class="fa fa-dog"></i></span>

                        <div class="info-box-content">
                            <span class="info-box-text">Vacas</span>
                            <span class="info-box-number">0</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="info-box box-selected" id="divBoxOvejas">
                        <span class="info-box-icon bg-green"><i class="fas fa-cat"></i></span>

                        <div class="info-box-content">
                            <span class="info-box-text">Ovejas</span>
                            <span class="info-box-number">0</span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>

            </div>


            <!-- =========================================================== -->


            <div class="box box-default">
                <div class="box-header with-border" style="padding-bottom: 0;">

                    <div class="row">
                        <div class="col-md-9">
                            <h3 class="box-title">
                                <label id="lblTableActive" style="font-weight: normal;"></label>
                            </h3>
                        </div>

                        <div class="col-md-2 pull-right" style="margin-right: 10px;">
                            <form action="#" method="get" class="sidebar-form" style="display: block !important; width: 100%;">
                                <div class="input-group ">
                                    <input type="text" id="txbSearch" name="q" class="form-control" placeholder="Buscar...">
                                    <span class="input-group-btn">
                                        <button type="button" name="search" id="search-btn" class="btn btn-flat">
                                            <i class="fa fa-search"></i>
                                        </button>
                                    </span>
                                </div>
                            </form>
                        </div>
                    </div>


                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <div id="divContent" style="overflow: auto;">

                                    <div class="divTables" id="divUsuarios" style="display: block;">
                                        <asp:UpdatePanel ID="upUsuarios" runat="server">
                                            <ContentTemplate>
                                                <uc1:Usuarios runat="server" ID="Usuarios" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                     <div class="divTables" id="divVacas" style="display: none;">
                                        <asp:UpdatePanel ID="upVacas" runat="server">
                                            <ContentTemplate>
                                                <uc1:Vacas runat="server" ID="Vacas" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="divTables" id="divOvejas" style="display: none;">
                                        <asp:UpdatePanel ID="upOvejas" runat="server">
                                            <ContentTemplate>
                                                <uc1:Ovejas runat="server" ID="Ovejas" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                                  
                                </div>
                            </div>

                            <!-- /.form-group -->
                        </div>
                        <!-- /.col -->
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.box-body -->
            </div>



            <!-- =========================================================== -->
        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->



</asp:content>
