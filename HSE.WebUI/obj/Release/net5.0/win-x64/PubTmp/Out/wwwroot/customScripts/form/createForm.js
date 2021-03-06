var selectPlaceholder = "Seçin";
var inputTooShort = "Axtarış üçün minimum 3 hərf daxil edin.";
var searching = "Axtarılır...";
var noResults = "Uyğun nəticə tapılmadı.";
var employeInfoArray = [];
var employeInfo = { EmployeUserId: "", EmployeFullName: "", EmployeePosition: "", Note: "" };
var formData = new FormData();
var isNoteTrue;
var tdNote;

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
            isNoteTrue = true;
            var formCreateDate = $(".datetimepicker-input").val();
            var instructorFullName = $(".nameSurname").val();
            var instructorPosition = $(".instructorposition").val();
            var instructionType = $("#InstructionType").val();
            var instructionTypeName = $("#InstructionType option:selected").text();
            var instructionShortContent = $("#ShortContent").val();


            employeInfoArray = [];
            $(".instructor_notes_body tr").each(function () {
                employeInfo = { EmployeUserId: "", EmployeFullName: "", EmployeePosition: "", Note: "" };
                employeInfo.EmployeUserId = $(this).attr("data-userId");
                employeInfo.EmployeFullName = $("td.employeeFullName", this).html();
                employeInfo.EmployeePosition = $("td.jobName", this).html();
                employeInfo.Note = $("td.Note", this).text();
                if (!employeInfo.Note) {
                    tdNote = $("td.Note", this);
                    isNoteTrue = false;
                } else {
                    $("td.Note", this).removeClass("tdNoteErrorClass");
                }
                employeInfoArray.push(employeInfo);
            });



            var newUrl = "RetrieveFormResult?instructionFormGuidId=";

            if (!instructionType || !instructionTypeName) {
                $("#InstructionType").parent().find(".select2-container").addClass("selectErrorClass");
            }
            else if (!instructionShortContent) {
                $("#ShortContent").addClass("shortContentErrorClass");
            }
            else if (!isNoteTrue) {
                tdNote.addClass("tdNoteErrorClass");
            }
            else {
                formData.append("FormCreateDate", formCreateDate);
                formData.append("InstructorFullName", instructorFullName);
                formData.append("InstructorPosition", instructorPosition);
                formData.append("InstructionType", instructionType);
                formData.append("instructionTypeName", instructionTypeName);
                formData.append("InstructionShortContent", instructionShortContent);
                formData.append("EmployeInfoListJsonString", JSON.stringify(employeInfoArray));
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
        function () {
            $("#ShortContent").removeClass("shortContentErrorClass");
        });

    $("#InstructionType").on("change",
        function () {
            $("#InstructionType").parent().find(".select2-container").removeClass("selectErrorClass");
            if ($("#InstructionType option:selected").text() === "Giriş") {
                $.ajax({
                    type: "POST",
                    url: "/Form/GetFormContentListByInstructionType",
                    success: function (data) {
                        
                        $("#ShortContent").text(data);
                        var nameList = "";
                        for (var i = 0; i < data.length; i++) {
                            nameList = nameList + (i + 1) + ") " + data[i].name + "\n";
                        }
                        
                        $("#ShortContent").val(nameList).change();
                        auto_grow(document.getElementById("ShortContent"));
                    }
                });
            } else {
                $("#ShortContent").val("");
                auto_grow(document.getElementById("ShortContent"));
            }
        });
}

function auto_grow(element) {
    element.style.height = "5px";
    element.style.height = (element.scrollHeight) + "px";
}