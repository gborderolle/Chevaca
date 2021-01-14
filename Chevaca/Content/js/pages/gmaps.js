var GMaps_map;
var GMaps_update_thread;
var GMaps_markers_green = "https://cartelux.uy/SW_Markers_green_sm.png";
var GMaps_markers_red = "https://cartelux.uy/SW_Markers_red_sm.png";
var GMaps_campo_taladro = [{ lat: -32.22763, lng: -54.15043 }, { lat: -32.23129, lng: -54.14861 }, { lat: -32.23552, lng: -54.1449 }, { lat: -32.23621, lng: -54.14121 }, { lat: -32.23442, lng: -54.13756 }, { lat: -32.23265, lng: -54.13496 }, { lat: -32.2316, lng: -54.13237 }, { lat: -32.22923, lng: -54.13402 }, { lat: -32.22859, lng: -54.1355 }, { lat: -32.22679, lng: -54.13629 }, { lat: -32.22402, lng: -54.13687 }, { lat: -32.22362, lng: -54.13846 }, { lat: -32.22463, lng: -54.14129 }, { lat: -32.22282, lng: -54.14224 }, { lat: -32.22577, lng: -54.14569 }];
var GMaps_casa_pablo = [{ lng: -56.1909381, lat: -34.867696 }, { lng: -56.1912761, lat: -34.8685762 }, { lng: -56.1901871, lat: -34.8688271 }, { lng: -56.1898652, lat: -34.86796 }, { lng: -56.1909381, lat: -34.867696 }];

$(document).ready(function () {
    GMaps_initMap(); // Inicia el mapa
    GMaps_initMap_area(); // Dibuja el mapa

    GMaps_getDevices(); // Inicia marcadores
    GMaps_initThread_loop(10); // Inicia thread cada 10 segs
});

function GMaps_initThread_pre() {
    var txtDelay = $("#txtDelay").val();
    if (txtDelay !== null && txtDelay !== undefined) {
        var delay_int = 10;
        delay_int = TryParseInt(txtDelay, 0);
        if (delay_int === 0) {
            alert("Ingreso inválido.");
        } else {
            clearInterval(GMaps_update_thread);
            GMaps_initThread_loop(delay_int);
        }
    }
    else {
        alert("Ingreso inválido.");
    }
}

function GMaps_initThread_loop(delay_int) {
    GMaps_update_thread = setInterval(GMaps_getDevices, (delay_int * 1000)); // 10 segundos default
}

function GMaps_initMap() {
    GMaps_map = new google.maps.Map(document.getElementById("GMaps_map_ID"), {
        center: { lat: -34.885298077677284, lng: -56.16710756369204 },
        zoom: 12,
        mapTypeId: 'satellite'
    }); 
}

// Dibujar área en mapa | Ojo con el orden de los datos en el array Lat y Long
function GMaps_initMap_area() {
    var GMap_polygon = new google.maps.Polygon({
        paths: GMaps_casa_pablo,
        strokeColor: 'rgb(8, 47, 104)',
        strokeOpacity: 0.8,
        strokeWeight: 3,
        fillColor: 'rgba(12, 98, 189, 0.47)',
        fillOpacity: 0.35,
    });

    GMap_polygon.setMap(GMaps_map);
}

function GMaps_addMarker(coords, image) {
    var marker = new google.maps.Marker({
        position: coords,
        map: GMaps_map,
        icon: image
    });
}

function GMaps_getDevices() {

    // Ajax call parameters
    console.log("Ajax call: GMaps.aspx/Get_Devices. Params:");

    $.ajax({
        type: "POST",
        url: "/Pages/GMaps.aspx/Get_Devices",
        contentType: "application/json;charset=utf-8",
        data: '{dummy: ""}',
        dataType: "json",
        success: function (response) {
            if (response.d !== null && response.d !== undefined) {
                if (response.d.length > 0) {

                    GMaps_setMarkers(response.d);
                }
                //$("#txb_Precios_lonaFrontMate").attr("placeholder", "$ " + Precios_lonaFrontMate + " por 1 CM2");
            }

        }, // end success
        failure: function (response) {
        }
    }); // Ajax    
}

function GMaps_setMarkers(locations_array) {
    if (locations_array.length > 0) {

        for (var i = 0; i < locations_array.length; i++) {
            var Log_API_ID = check_nullValues(locations_array[i].Log_API_ID);
            var Gateway = check_nullValues(locations_array[i].Gateway);
            var Nodo = check_nullValues(locations_array[i].Nodo);
            var Altitud = check_nullValues(locations_array[i].Altitud);
            var Hdop = check_nullValues(locations_array[i].Hdop);
            var Latitud = check_nullValues(locations_array[i].Latitud);
            var Longitud = check_nullValues(locations_array[i].Longitud);

            var LastUpdate = moment(check_nullValues(locations_array[i].LastUpdate), "YYYY-MM-DD").format("DD-MM-YYYY");

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

            var pos = { lat: TryParseFloat(Latitud, 0), lng: TryParseFloat(Longitud, 0) };

            // Si es Nodo 1 ==> Localiza el mapa
            if (i === 0) {
                GMaps_map.setCenter(pos);
                GMaps_map.setZoom(18);
            }

            GMaps_addMarker(pos, GMaps_markers_green);
        } // for
    }
}