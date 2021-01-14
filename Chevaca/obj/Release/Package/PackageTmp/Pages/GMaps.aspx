<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GMaps.aspx.cs" Inherits="Chevaca.Pages.GMaps" Title="Google Maps" %>


<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">

    <!-- STYLES EXTENSION -->
    <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap-theme.min.css" />
    <%--<script type="text/javascript" src="https://code.jquery.com/jquery-1.10.2.min.js"></script>--%>
    <script type="text/javascript" src="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>

    <!-- Theme style -->

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


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="SubbodyContent" runat="server">

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
    <script type="text/javascript" src="../Content/js/libs/jquery.tablesorter.js"></script>
    <script type="text/javascript" src="https://maps.google.com/maps/api/js?libraries=places&key=AIzaSyB0SMtERQOVpwjLuROR_N2v-S-jEWdcMaM"></script>
    <script type="text/javascript" src="../Content/js/libs/locationpicker.jquery.js"></script>


    <!-- PAGE CSS -->
    <link rel="stylesheet" href="../Content/css/helpers/modal_styles.css" />

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Navegación -->
    <section class="content-header">
        <h1>Google Maps
        </h1>
    </section>

    <!-- Main content -->
    <section class="content">
        <button type="button" data-toggle="modal" data-target="#ModalMap" class="btn btn-default">
            <span class="glyphicon glyphicon-map-marker"></span><span id="ubicacion">Seleccionar ubicación</span>
        </button>

        <div class="modal fade" id="ModalMap" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Ubicación: </label>
                                <div class="col-sm-9">
                                    <asp:TextBox runat="server" ID="ModalMapaddress" CssClass="form-control" />
                                </div>
                                <div class="col-sm-1">
                                    <button class="close" data-dismiss="modal" aria-label="Cerrar">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <!-- =========================================================== -->
    </section>
    <!-- /.content -->



</asp:Content>
