$(document).ready(function () {

    $("#success-alert").fadeTo(5000, 500).slideUp(500, function () {
        $("#success-alert").slideUp(1000);
    });

    $("#danger-alert").fadeTo(5000, 500).slideUp(500, function () {
        $("#danger-alert").slideUp(1000);
    });

    $("#info-alert").fadeTo(5000, 500).slideUp(500, function () {
        $("#info-alert").slideUp(1000);
    });


})



