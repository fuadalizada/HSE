var instructionFormId;

$(document).ready(function () {

    OpenPopUpForShowingPicture();

    $(".close_modal").click(function () {
        $("#showPhotoModal").modal("hide");
        Webcam.reset();
    });
});

function OpenPopUpForShowingPicture() {
    $("body").on("click", ".ShowPicturePopUp",
        function () {
            var empUserId = $(this).attr("data-employeeUserId");
            instructionFormId = $(".instructionFormId").val();
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

            document.getElementById("qrcode").innerHTML =
                `<img style="margin-top:-15px;"  src="/File/GenerateQrCode?employeeUserId=${empUserId}&instructionFormId=${instructionFormId}"/>`;

            $("#showPhotoModal").modal("show");
        });
}