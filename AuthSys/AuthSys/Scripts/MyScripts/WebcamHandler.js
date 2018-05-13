
function activateCam() {
    // Grab elements, create settings, etc.
    var video = document.getElementById('video');

    var butVal = document.getElementById("activateCamButton").value;
    
    //If val is 1, then we want activate cam, and if 2, then disable
    if (butVal == "Aktiver kamera") {
        video.style.visibility = "visible";

        // Get access to the camera!
        if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
            // Not adding `{ audio: true }` since we only want video now
            navigator.mediaDevices.getUserMedia({ video: true }).then(function (stream) {
                video.srcObject = stream;
                video.play();

                butVal.value = "Deaktiver kamera";

                document.getElementById("activateCamButton").addEventListener("click", function () {
                    activateCam();
                });
            });
        }        
    } else {
        if(butVal === "Deaktiver kamera") {
            butVal = "Aktiver kamera";
            butVal.id = "disableCam";

            document.getElementById("disableCam").addEventListener("click", function () {
                disableCam();
            });
        }
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

    imageURL = canvas.toDataURL();
}

function isCamAlreadyActive() {

}

function disableCam() {
    var video = document.getElementById('video');
    video.style.visibility = "hidden";

    video.srcObject.getVideoTracks().forEach(track => track.stop());
}