
function activateCam() {
    // Grab elements, create settings, etc.
    var video = document.getElementById('video');
    
    //If val is 1, then we want activate cam, and if 2, then disable
        video.style.visibility = "visible";

        // Get access to the camera!
        if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
            // Not adding `{ audio: true }` since we only want video now
            navigator.mediaDevices.getUserMedia({ video: true }).then(function (stream) {
                video.srcObject = stream;
                video.play();

                document.getElementById("activateCamButton").addEventListener("click", function () {
                    activateCam();
                });
            });
        }            
}

function initTriggers() {
    // Trigger photo take
    document.getElementById("activateCamButton").addEventListener("click", function () {
        activateCam();
    });

    document.getElementById("shoot").addEventListener("click", function () {
        takeSnapAndSaveUrl();
    }); 

    document.getElementById("disableCam").addEventListener("click", function () {
        disableCam();
    });
}

function takeSnapAndSaveUrl() {
    // Elements for taking the snapshot
    var canvas = document.getElementById('canvas');
    var context = canvas.getContext('2d');

    var imageURL = null;

    var cancasWidth = 250;
    var canvasHeight = 150;

    context.drawImage(video, 0, 0, cancasWidth, canvasHeight);

    imageURL = canvas.toDataURL(); console.log("URL: " + imageURL);
}

function disableCam() {
    var video = document.getElementById('video');
    video.style.visibility = "hidden";

    if (video.srcObject != null) {
        video.srcObject.getVideoTracks().forEach(track => track.stop());
    }
}

function sendImageUrl(MemberID, action, controller) {
    var url = '/' + action + '/' + controller;

    $.ajax({
        url: url,
        data: $("form").serialize(),
        contentType: 'application/html; charset=utf-8',
        dataType: "html",
        success: function(msg) {
            alert("Success");
        },
        error: function(msg) {
            alert("Error");
        }
    })
}








