
$(document).ready(function () {
    initMap();
});

var map;
function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: -34.91504123732739, lng: -56.15936655139458 },
        zoom: 12
    });

    /*
    var marker = new google.maps.Marker({
        position: { lat: -34.91504123732739, lng: -56.15936655139458 },
        map: map
    });
    */
}

function addMarker(coords) {
    var marker = new google.maps.Marker({
        position: coords,
        map: map
    });
}

function getDevices() {

    // Ajax call parameters
    console.log("Ajax call: Testing.aspx/Get_Devices. Params:");

    $.ajax({
        type: "POST",
        url: "Testing.aspx/Get_Devices",
        contentType: "application/json;charset=utf-8",
        data: '{dummy: ""}',
        dataType: "json",
        success: function (response) {
            if (response.d !== null && response.d !== undefined) {
                if (response.d.length > 0) {
                    for (var i = 0; i < response.d.length; i++) {

                        var Log_API_ID = check_nullValues(response.d[i].Log_API_ID);
                        var Gateway = check_nullValues(response.d[i].Gateway);
                        var Nodo = check_nullValues(response.d[i].Nodo);
                        var Altitud = check_nullValues(response.d[i].Altitud);
                        var Hdop = check_nullValues(response.d[i].Hdop);
                        var Latitud = check_nullValues(response.d[i].Latitud);
                        var Longitud = check_nullValues(response.d[i].Longitud);

                        var LastUpdate = moment(check_nullValues(response.d[i].LastUpdate), "YYYY-MM-DD").format("DD-MM-YYYY");


                        console.log("Nodo: " + (i + 1));
                        console.log("Log_API_ID, type: " + type(Log_API_ID) + ", value: " + Log_API_ID);
                        console.log("LastUpdate, type: " + type(LastUpdate) + ", value: " + LastUpdate);
                        console.log("Gateway, type: " + type(Gateway) + ", value: " + Gateway);
                        console.log("Nodo, type: " + type(Nodo) + ", value: " + Nodo);
                        console.log("Altitud, type: " + type(Altitud) + ", value: " + Altitud);
                        console.log("Hdop, type: " + type(Hdop) + ", value: " + Hdop);
                        console.log("Latitud, type: " + type(Latitud) + ", value: " + Latitud);
                        console.log("Longitud, type: " + type(Longitud) + ", value: " + Longitud);
                        console.log("----------------------------");

                        addMarker({ lat: TryParseFloat(Latitud, 0), lng: TryParseFloat(Longitud, 0) });

                    } // for
                }
                //$("#txb_Precios_lonaFrontMate").attr("placeholder", "$ " + Precios_lonaFrontMate + " por 1 CM2");
            }

        }, // end success
        failure: function (response) {
        }
    }); // Ajax    

    /*
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
    */

}