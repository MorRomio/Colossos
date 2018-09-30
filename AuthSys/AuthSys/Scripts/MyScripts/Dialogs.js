
$(document).ready(function () {
    //Tell JQuery not to conflict with older versions of libs
    $.noConflict();

    //$("#addCardBox").css("display", "none");
    //$("#addCardLabel").css("display", "none");

    
});


function alternateDialog(componentID) {
    $("#" + componentID).dialog({
        show: {
            effect: 'bounce',
            duration: 500
        },
        hide: {
            effect: 'clip',
            duration: 500
        },
        buttons: {
            OK: function () {
                $(this).dialog('close');
            }
        }
    });
}

function showDialog(componentID) {
    //alert("Called");
    $("#"+componentID).dialog({
        show: {
            effect: 'fade',
            duration: 500
        },
        hide: {
            effect: 'fade',
            duration: 500
        },
        buttons: {
            Ja: function () {
                $("#cardStatus").val("Kort fjernes");
                $(this).dialog('close');
                alternateDialog('confirmationDiv');
                $("#fjernKortKnap").css("display", "none");
            },
            Nej: function () {
                $(this).dialog('close');
            }
        }   
    });
}