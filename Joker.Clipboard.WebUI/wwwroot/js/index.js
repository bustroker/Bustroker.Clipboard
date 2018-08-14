$(document).ready(function () {
    console.log("getting clipboard..");
    let clipboard = "waiting for clipboard..";
    $.get("/api/clipboard")
        .done(function (data) {
            $("#clipboard").val(data);
            console.log("done getting clipboard. data: " + data);
        })
        .fail(function () {
            console.log("failed getting clipboard..");
        });

});

function saveClipboard() {
    var clipboard = $("#clipboard").val();
    var data = {
        NewClipboard: clipboard
    };
    console.log(data);
    $.ajax({
        type: "POST",
        url: "/api/clipboard",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        success: function () {
            displayMessage("saved-message");
        },
        error: function (response) {
            console.log(response);
            displayMessage("failed-message");
        }
    });
}

function displayMessage(messageId) {
    $("#" + messageId).fadeIn().delay(2000).fadeOut();
}