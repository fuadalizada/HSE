var selectPlaceholder = "Seçin";
var inputTooShort = "Axtarış üçün minimum 3 hərf daxil edin.";
var searching = "Axtarılır...";
var noResults = "Uyğun nəticə tapılmadı.";
var employeInfoArray = [];
var employeInfo = { EmployeUserId: "",EmployeFullName: "",EmployeePosition: "", Note: "" };
var formData = new FormData();

$(document).ready(function () {
    Select2Plugins();
    CreateForm();

    $("#createDate").datetimepicker({
        format: "DD/MM/YYYY"
    });

    ChangeBorderColor();
});

function Select2Plugins() {
    $(".select").select2({
    });

    $("#InstructionType").select2({
        placeholder: selectPlaceholder,
        allowClear: true,
        language: {
            inputTooShort: function () {
                return inputTooShort;
            },
            searching: function () {
                return searching;
            },
            noResults: function () {
                return noResults;
            },
            loadingMore: function () {
                return this.loadingMore;
            }
        }
    });
}

function CreateForm() {
    $("#confirm").on("click",
        function () {

            const formCreateDate = $(".datetimepicker-input").val();
            const instructorFullName = $(".nameSurname").val();
            const instructorPosition = $(".instructorposition").val();
            const instructionType = $("#InstructionType").val();
            const instructionTypeName = $("#InstructionType option:selected").text();
            const instructionShortContent = $("#ShortContent").val();

            formData.append("FormCreateDate", formCreateDate);
            formData.append("InstructorFullName", instructorFullName);
            formData.append("InstructorPosition", instructorPosition);
            formData.append("InstructionType", instructionType);
            formData.append("instructionTypeName", instructionTypeName);
            formData.append("InstructionShortContent", instructionShortContent);

            $(".instructor_notes_body tr").each(function () {
                employeInfo = { EmployeUserId: "", EmployeFullName: "", EmployeePosition: "", Note: "" };
                employeInfo.EmployeUserId = $(this).attr("data-userId");
                employeInfo.EmployeFullName = $("td.employeeFullName", this).html();
                employeInfo.EmployeePosition = $("td.jobName", this).html();
                employeInfo.Note = $("td.Note", this).html();
                if (!employeInfo.Note) {
                    $("td.Note", this).addClass("tdNoteErrorClass");
                } else {
                    $("td.Note", this).removeClass("tdNoteErrorClass");
                }
                employeInfoArray.push(employeInfo);
            });
            
            formData.append("EmployeInfoListJsonString", JSON.stringify(employeInfoArray));
            
            var newUrl = "RetrieveFormResult?instructionFormId=";
            
            if (!instructionType || !instructionTypeName || !instructionShortContent) {
                $("#InstructionType").parent().find(".select2-container").addClass("selectErrorClass");
                $("#ShortContent").addClass("shortContentErrorClass");
            } else {
                $.ajax({
                    type: "POST",
                    url: "/Form/AddForms",
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        window.location.href = newUrl + data;
                    }
                });
            }
        });
}

function ChangeBorderColor() {
    $("#ShortContent").on("change",
        function() {
            $("#ShortContent").removeClass("shortContentErrorClass");
        });

    $("#InstructionType").on("change",
        function() {
            $("#InstructionType").parent().find(".select2-container").removeClass("selectErrorClass");
        });
}