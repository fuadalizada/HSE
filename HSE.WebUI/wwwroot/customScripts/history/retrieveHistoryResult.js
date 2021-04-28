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
            document.getElementById("photoResult").innerHTML =
                `<img src="/Camera/IsThePhotoExist?employeeUserId=${empUserId}&instructionFormId=${instructionFormId}"/>`;

            $("#showPhotoModal").modal("show");
        });
}