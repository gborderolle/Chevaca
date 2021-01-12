<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="Chevaca.Pages.Testing" %>


<!-- STYLES EXTENSION -->
<script type="text/javascript" src="../Content/js/libs/jquery.js"></script>

<%--<script type="text/javascript" src="https://code.jquery.com/jquery-1.10.2.min.js"></script>--%>
<script type="text/javascript" src="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
<script type="text/javascript" src="https://maps.google.com/maps/api/js?sensor=false&libraries=places&key=AIzaSyCCleSiqnYN-NY98Unf3KpW66aAOBPs5CA"></script>
<script type="text/javascript" src="../Content/js/libs/locationpicker.jquery.js"></script>

<link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css" />
<link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap-theme.min.css" />




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

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

                            <div id="ModalMapPreview" style="width: 100%; height: 400px;"></div>
                            <div class="clearfix">&nbsp;</div>
                            <div class="m-t-small">
                                <label class="p-r-small col-sm-1 control-label">lat.:</label>
                                <div class="col-sm-3">
                                    <asp:TextBox runat="server" ID="ModalMapLat" CssClass="form-control" />
                                </div>
                                <label class="p-r-small col-sm-1 control-label">lon.:</label>
                                <div class="col-sm-3">
                                    <asp:TextBox runat="server" ID="ModalMapLon" CssClass="form-control" />
                                </div>
                                <div class="col-sm-3">
                                    <button type="button" class="btn btn-primary btn-block" data-dismiss="modal">Aceptar</button>
                                </div>
                            </div>
                            <div class="clearfix">&nbsp;</div>

                            <script>
                                $("#ModalMapPreview").locationpicker({
                                    radius: 0,
                                    location: {
                                        latitude: -34.8686173479925,
                                        longitude: -56.190297376531205
                                    },
                                    enableAutocomplete: true,
                                    inputBinding: {
                                        latitudeInput: $('#<%=ModalMapLat.ClientID%>'),
                                        longitudeInput: $('#<%=ModalMapLon.ClientID%>'),
                                        locationNameInput: $('#<%=ModalMapaddress.ClientID%>')
                                    },
                                    onchanged: function (currentLocation, radius, isMarkerDropped) {
                                        $('#ubicacion').html($('#<%=ModalMapaddress.ClientID%>').val())
                                        
                                    }
                                });
                                $("#ModalMap").on("shown.bs.modal", function () {
                                    $("#ModalMapPreview").locationpicker("autosize");
                                });
                            </script>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
