var employeeUserId;
$(document).ready(function () {
    OpenPopUpForTakingPicture();
});

function OpenPopUpForTakingPicture() {
    $(".openPopUp").on("click",
        function () {
            employeeUserId = $(this).attr("data-employeeUserId");
            $("#takeApictureModal").modal("show");
            attachCamera();
            ConfirmModal();
        });
}

function ConfirmModal() {

    $(".takePicture").on("click",
        function() {
            take_snapshot();
        });

    $(".close_modal").click(function () {
        $("#takeApictureModal").modal("hide");
    });

    $("#ConfirmPictureModal").on("click",
        function () {
            const fincode = $(".fincode").val();
            const instructionFormId = $(".instructionFormId").val();
            if (!isEmpty(fincode) ) {
                $.ajax({
                    type: "Post",
                    url: "/Form/CheckIfFincodeIsTrue",
                    data: { fincode: fincode },
                    success: function (data) {
                        if (data === true) {
                            
                            if (instructionFormId !== null) {
                                UpdateEmployeeForm(instructionFormId,employeeUserId);
                                $("#takeApictureModal").modal("hide");
                                document.getElementById("openPictureModal").innerHTML = '<i class="fas fa-eye mr-1" style="font-size:20px;color:green" aria-hidden="true"></i>';
                            } else {
                                alert("formun id-si yoxdur");
                            }
                        } else {
                            alert("fincode yanlishdir.");
                        }
                    }
                });
            } else {
                alert("fincode daxil edilmeyib");
            }
        });
}

function UpdateEmployeeForm(instructionFormId,employeeUserId) {
    $.ajax({
        type: "Post",
        url: "/Form/UpdateEmployeeForm",
        data: { instructionFormId: instructionFormId, employeeUserId: employeeUserId }
    });
}

function isEmpty(str) {
    return (!str || str.length === 0);
}

function take_snapshot() {
    // take snapshot and get image data
    Webcam.snap(function (dataUri) {
        console.log(dataUri);
        // display results in page
        document.getElementById("results").innerHTML =
            `<img src="${dataUri}"/>`;

        Webcam.upload(dataUri,
            "/Camera/Capture",
            function () {
                alert("Photo Captured");
            });
    });
}

function attachCamera() {
    Webcam.set({
        width: 320,
        height: 240,
        image_format: "jpeg",
        jpeg_quality: 90
    });
    Webcam.attach("#my_camera");
}