
$(document).ready(function () {
    //alert("Testing");
    $.noConflict();
    $("#addCardBox").css("display", "none");
    $("#addCardLabel").css("display", "none");

    $("#addCard").click(function () {
        //alert("Test");

        $("#addCardBox").css("display", "block");
        $("#addCardLabel").css("display", "block");
    });
    
});

function test() {
    alert("It works");
}

function cardAttached() {
    //alert("Called");
   
    $(function () {
   //     $("#msgDiv").dialog();
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
        }
    });
}