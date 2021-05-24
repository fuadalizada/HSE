var employeeUserId;
var rowEmployeeUserId;
var instructionFormId;
var fincode;
var counter = 0;
var len = 0;
var maxChar = 7;
var toastr;
var isSuccess = false;

$(document).ready(function () {
    OpenPopUpForTakingPicture();
    OpenPopUpForShowingPicture();
    ConfirmModal();
    $(".takePicture").on("click",
        function () {
            counter++;
            take_snapshot();
        });

    $(".close_modal").click(function () {
        $("#takeApictureModal").modal("hide");
        Webcam.reset();
        counter = 0;
    });

    auto_grow(document.getElementById("ShortContentIncoming"));
    ShowLeftCharactersForFincode();
});

function showSuccessMessage(message, title) {
    toastr["success"](message, title);
}
function showErrorMessage(message, title) {
    toastr["error"](message, title);
}
function showInfoMessage(message, title) {
    toastr["info"](message, title);
}
function showWarningMessage(message, title) {
    toastr["warning"](message, title);
}

function OpenPopUpForTakingPicture() {
    $("body").on("click", ".openPopUp",
        function () {
            employeeUserId = $(this).attr("data-employeeUserId");
            var employeeFullName = $(this).attr("data-employeeFullName");
            $(".nameSurnameModal").val(employeeFullName);

            $("#takeApictureModal").modal({
                backdrop: "static",
                keyboard: false
            });
            var finCode = $(".fincode").val();
            if (finCode !== null) {
                document.getElementById("fin_code").value = "";
                document.getElementById("results").innerHTML = `<img src="${null}"/>`;
                $(".fincodeValidationMessage").html("");
            }
            attachCamera();
            $("#example").tooltip({
                title: "Şəxsiyyət vəsiqəsinin fərdi identifikasiya nömrəsi"
            });
        });
}

function OpenPopUpForShowingPicture() {
    $("body").on("click", ".ShowPicturePopUp",
        function () {
            var empUserId = $(this).attr("data-employeeUserId");
            instructionFormId = $(".instructionFormId").val();
            $("#shoPhotoModalLabel").text(`Form № ${instructionFormId}`);
            var employeeFullName = $(this).attr("data-employeeFullName");
            $(".nameSurnameShowModal").val(employeeFullName);

            $.ajax({
                type: "Post",
                url: "/Form/GetPhotoDate",
                data: { instructionFormId: instructionFormId, employeeUserId: empUserId },
                success: function (data) {
                    $(".photoDateShowModal").val(data);
                }
            });

            document.getElementById("photoResult").innerHTML =
                `<img src="/Camera/IsThePhotoExist?employeeUserId=${empUserId}&instructionFormId=${instructionFormId}"/>`;

            document.getElementById("matchPhotoResult").innerHTML =
                `<img style="height:169px;" src="/Camera/GetEmployeePhotoByFincode?employeeUserId=${empUserId}"/>`;

            document.getElementById("qrcode").innerHTML =
                `<img style="margin-top:-15px;" src="/File/GenerateQrCode?employeeUserId=${empUserId}&instructionFormId=${instructionFormId}"/>`;

            $("#showPhotoModal").modal("show");
        });
}

function ConfirmModal() {
    
    $("#ConfirmPictureModal").on("click",
        function () {
            isSuccess = false;
            fincode = $(".fincode").val();
            instructionFormId = $(".instructionFormId").val();
            if (!isEmpty(fincode)) {
                if (LengthCheck(fincode, 7)) {
                    $.ajax({
                        type: "Post",
                        url: "/Form/CheckIfFincodeAndEmpUserIdIsTrue",
                        data: { fincode: fincode, employeeUserId: employeeUserId },
                        success: function (data) {
                            if (data === true) {
                                if (counter !== 0) {
                                    if (instructionFormId !== null) {
                                        UpdateEmployeeForm(instructionFormId, employeeUserId);
                                        $("#takeApictureModal").modal("hide");
                                        $(`[data-employeeuserid="${employeeUserId}"]`).html('<i class="fas fa-eye mr-1" title="Təsdiqlənib" style="font-size:20px;color:green" aria-hidden="true"></i>').removeClass("openPopUp").addClass("ShowPicturePopUp");
                                        Webcam.reset();
                                        counter = 0;
                                        isSuccess = true;
                                        showSuccessMessage("Sənəd uğurla təsdiq olundu.");
                                    } else {
                                        $(".fincodeValidationMessage").html("Formun id nömrəsi yoxdur");
                                    }
                                } else if (!isSuccess) {
                                    console.log(counter);
                                    showWarningMessage("Təlimat alanın şəklini çəkin.", "Bildiriş");
                                }
                            } else {
                                console.log(counter);
                                $(".fincodeValidationMessage").html("Fin kod yanlishdir.");
                            }
                        }
                    });
                } else {
                    console.log(counter);
                    $(".fincodeValidationMessage").html("Fin kodu düzgün daxil edin.");
                }
            } else {
                console.log(counter);
                $(".fincodeValidationMessage").html("Fin kod daxil edilmeyib");
            }
        });
}

function ShowLeftCharactersForFincode() {
    $('#fin_code').keyup(function () {
        len = this.value.length;
        if (len > maxChar) {
            return false;
        } else if (len > 0) {
            $(".fincodeValidationMessage").html(`Daxil ediləcək simvol sayı: ${maxChar - len}`);
        } else {
            $(".fincodeValidationMessage").html(`Daxil ediləcək simvol sayı: ${maxChar}`);
        }
    });
}

// verifying length
function LengthCheck(value, length) {
    if (String(value).length !== length) { return false; }
    return true;
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

function auto_grow(element) {
    element.style.height = "5px";
    element.style.height = (element.scrollHeight) + "px";
}