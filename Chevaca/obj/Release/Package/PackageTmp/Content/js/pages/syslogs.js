$(document).ready(function () {
    bindEvents();
    bindDelayEvents();
});


function bindEvents() {
    $("#gridLogs").tablesorter();
    $(".datepicker").datepicker({ dateFormat: 'dd-mm-yy' });

}

function bindDelayEvents() {
    setTimeout(function () {

        var gridLogs = $("#gridLogs tbody tr");
        $("#txbSearch").quicksearch(gridLogs);

    }, 100);
}