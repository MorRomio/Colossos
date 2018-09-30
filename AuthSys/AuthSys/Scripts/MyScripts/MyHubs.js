$(function () {
    // Reference the auto-generated proxy for the hub.
    var signalRhub = $.connection.hubSignalR;   

    //Start connection
    $.connection.hub.start().done(function () {
        $("#knap").click(function () {
            //Call the method on the server
            //signalRhub.server.test();
            console.log("clicked");
            signalRhub.server.cardAdded();
        });
    });

   
    //*****************Client functions that will be called by the server, when there is a notification ************************
    signalRhub.client.TestMessages = function (msgFromServer) {
        alert("Test func called");
        console.log("From server: " + msgFromServer);
    };

    signalRhub.client.AddCard = function (success) {
        var msg = (success ? "Kort tilføjet" : "Kort ikke tilføjet, prøv igen");
        alert(msg);
   
            alternateDialog(msg, 'cardInfoDiv');
        
    };

    signalRhub.client.cardRemoved = function (isSucces) {
        alternateDialog(compponentID);
    };

    //#endregion
});