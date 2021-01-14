<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="Chevaca.Pages.Testing" %>


<!-- STYLES EXTENSION -->
<script type="text/javascript" src="../Content/js/libs/jquery.js"></script>

<script type="text/javascript" src="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
<%--<script type="text/javascript" src="https://maps.google.com/maps/api/js?libraries=places&key=AIzaSyCCleSiqnYN-NY98Unf3KpW66aAOBPs5CA"></script>--%>
<%--<script type="text/javascript" src="../Content/js/libs/locationpicker.jquery.js"></script>--%>
<script defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyA5b9fHo2L4fPpJZhRehtJGUjdXfgPkbUE&callback=initMap"></script>
<script type="text/javascript" src="../Content/js/libs/moment.js"></script>

<link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css" />
<link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap-theme.min.css" />

<script type="text/javascript" src="../Content/js/helpers/auxiliares.js"></script>
<script type="text/javascript" src="../Content/js/pages/gmaps.js"></script>

<style>
    #map {
        height: 100%;
    }

    html, body {
        height: 100%;
        margin: 0;
        padding: 0;
    }
</style>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="modal-content">

            <div class="form-group">
                <label class="col-sm-2 control-label">Demora </label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" ID="txtDelay" CssClass="form-control" Text="1" />
                </div>
            </div>

            <div class="modal-body">
                <div class="form-horizontal">
                    <div id="map" style="width: 100%; height: 400px;"></div>
                    <div class="clearfix">&nbsp;</div>
                    <div class="m-t-small">
                        <button type="button" class="btn btn-warning btn-block" onclick="getDevices()">Obtener dispositivos</button>
                    </div>
                    <div class="clearfix">&nbsp;</div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
