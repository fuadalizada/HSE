var employeeUserId;
var rowEmployeeUserId;
var instructionFormId;
var fincode;
$(document).ready(function () {
    OpenPopUpForTakingPicture();
    OpenPopUpForShowingPicture();
    $(".takePicture").on("click",
        function () {
            take_snapshot();
        });
    $(".close_modal").click(function () {
        $("#takeApictureModal").modal("hide");
        Webcam.reset();
    });
});

function OpenPopUpForTakingPicture() {
    $("body").on("click", ".openPopUp",
        function () {
            employeeUserId = $(this).attr("data-employeeUserId");
            $("#takeApictureModal").modal("show");
            var finCode = $(".fincode").val();
            if (finCode !== null) {
                document.getElementById("fin_code").value = "";
                document.getElementById("results").innerHTML = `<img src="${null}"/>`;
            }
            attachCamera();
            ConfirmModal();
        });
}

function OpenPopUpForShowingPicture() {
    $("body").on("click", ".ShowPicturePopUp",
        function () {
            var empUserId = $(this).attr("data-employeeUserId");
            instructionFormId = $(".instructionFormId").val();

            document.getElementById("photoResult").innerHTML =
                `<img src="/Camera/IsThePhotoExist?employeeUserId=${empUserId}&instructionFormId=${instructionFormId}"/>`;

            $("#showPhotoModal").modal("show");
        });
}

function ConfirmModal() {

    $("#ConfirmPictureModal").on("click",
        function () {
            fincode = $(".fincode").val();
            instructionFormId = $(".instructionFormId").val();
            if (!isEmpty(fincode)) {
                $.ajax({
                    type: "Post",
                    url: "/Form/CheckIfFincodeAndEmpUserIdIsTrue",
                    data: { fincode: fincode, employeeUserId: employeeUserId },
                    success: function (data) {
                        if (data === true) {

                            if (instructionFormId !== null) {
                                UpdateEmployeeForm(instructionFormId, employeeUserId);
                                $("#takeApictureModal").modal("hide");
                                $(`[data-employeeuserid="${employeeUserId}"]`).html('<i class="fas fa-eye mr-1" title="Təsdiqlənib" style="font-size:20px;color:green" aria-hidden="true"></i>').removeClass("openPopUp").addClass("ShowPicturePopUp");
                                Webcam.reset();
                            } else {
                                $(".fincodeValidationMessage").html("Formun id nömrəsi yoxdur");
                            }
                        } else {
                            $(".fincodeValidationMessage").html("Fin kod yanlishdir.");
                        }
                    }
                });
            } else {
                $(".fincodeValidationMessage").html("Fin kod daxil edilmeyib");
            }
        });
}

function UpdateEmployeeForm(instructionFormId, employeeUserId) {
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

    const instructionFormId = $(".instructionFormId").val();
    // take snapshot and get image data
    Webcam.snap(function (dataUri) {
        // display results in page
        document.getElementById("results").innerHTML =
            `<img src="${dataUri}"/>`;

        Webcam.upload(dataUri,
            `/Camera/Capture?employeeUserId=${employeeUserId}&instructionFormId=${instructionFormId}`,
            function () {
                //bootbox.alert("Şəkil çəkildi.");
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