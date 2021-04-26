var tableWorkerInformations = "";
var InstructorNotesDataTable = "";
var counter = 0;
var index = 0;
var selected = [];

$(document).ready(function () {
    ShowModal();
});

function ShowModal() {
    $("#openWorkerInformationModal").on("click", function () {
        counter++;

        $("#workerInformationModal").modal("show");
        if (counter === 1) {
            CreateWorkerInformationSearchPanel();
        }
    });
}
function CreateWorkerInformationSearchPanel() {

    $(".close_modal").click(function () {
        $("#workerInformationModal").modal("hide");
    });

    tableWorkerInformations = $("#worker_information_search").DataTable({
        "language": {
            "search": "<i class='fa fa-search'></i>",
            "emptyTable": "Heç bir məlumat yoxdur",
            "sLengthMenu": "_MENU_ sətir göstər",
            "paginate": {
                "previous": "Əvvəlki ",
                "next": " Sonrakı",
                "first": "Birinci",
                "last": "Axırıncı"
            },
            "info": "_TOTAL_ sətirdən _START_-dən _END_-kimi göstərir",
            "infoEmpty": "0 nəticə",
            "infoFiltered": "( _MAX_ sətirdən filter olunub)",
            "zeroRecords": "Uyğun nətica tapılmadı",
            "select": {
                "rows": "%d sətir seçilib"
            },
            "sProcessing": "<div id='loader'></div>"
        },
        lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
        deferRender: true,
        order: [],
        "columns": [
            { "data": "userId", "name": "userId", "autoWidth": true, "hidden": true },
            { "data": "firstName", "name": "firstName", "autoWidth": true },
            { "data": "lastName", "name": "lastName", "autoWidth": true },
            { "data": "patronymicName", "name": "patronymicName", "autoWidth": true },
            { "data": "jobName", "name": "jobName", "autoWidth": true },
            { "data": "organizationFullName", "name": "organizationFullName", "autoWidth": true }
        ],
        select: {
            style: "multi"
        },
        "processing": true,
        "serverSide": true,
        ajax: {
            "url": "/Form/WorkerInformation",
            "type": "POST",
            data: function (data) {
                return data;
            }
        },
        "createdRow": function (row, data) {
            $(row).addClass("MesajUserTr");
            $(row).attr("data-userId", data.userId);

            for (let i = 0; i < selected.length; i++) {
                if (parseInt(selected[i].userId) === parseInt(data.userId)) {
                    $(row).addClass("selected");
                }
            }
        },
        "columnDefs": [
            {
                "targets": "thUserId",
                "createdCell": function (td) {
                    $(td).addClass("userId");
                    $(td).hide();
                }
            },
            {
                "targets": "thuserName",
                "createdCell": function (td) {
                    $(td).addClass("userName");
                }
            },
            {
                "targets": "thuserSurname",
                "createdCell": function (td) {
                    $(td).addClass("userSurname");
                }
            },
            {
                "targets": "thuserPatronimic",
                "createdCell": function (td) {
                    $(td).addClass("userPatronymicName");
                }
            },
            {
                "targets": "thjobName",
                "createdCell": function (td) {
                    $(td).addClass("jobName");
                }
            }, {
                "targets": "thuserStructure",
                "createdCell": function (td) {
                    $(td).addClass("userStructure");
                }
            }
        ]
    });

    tableWorkerInformations.columns().every(function () {
        var that = this;
        $("input", this.header())
            .on("input",
                delay(function () {
                    if (that.search() !== this.value) {
                        that
                            .search(this.value)
                            .draw();
                    }
                }, 1200));
    });

    $("#worker_information_search thead input").on("click", function () {
        return false;
    });

    $("#selectWorkerInformation").on("click", function () {
        $(".instructor_notes_body").html("");
        index = 0;
        document.getElementById("confirm").disabled = false;
        $.each(selected, function (i, value) {
            index++;
            var tr = `<tr data-userId="${value["userId"]}">
                        <td>${index}</td>
                        <td class="employeeFullName">${value["firstName"]} ${value["lastName"]} ${value["patronymicName"]}</td>
                        <td class="jobName">${value["jobName"]}</td>
                        <td contenteditable="true" class="Note"></td>
                        <td style="text-align:center"><i class="fas fa-minus-circle mr-1" onclick="Delete(this)" style="font-size: 20px; color: dodgerblue;"></i>${""}</td>
                      </tr>`;
            $(".instructor_Notes").append(tr);
        });
    });

    $("#worker_information_search tbody").on("click", "tr", function () {

        const data = tableWorkerInformations.row(this).data();
        const indx = $.inArray(data, selected);

        if (indx === -1) {
            selected.push(data);
        } else {
            selected.splice(indx, 1);
        }
        $(this).toggleClass("selected");
    });
}

function Delete(element) {

    const userId = $(element).parents("tr").attr("data-userId");
    var indx = -1;
    for (let i = 0; i < selected.length; i++) {
        if (parseInt(selected[i].userId) === parseInt(userId)) {
            indx = i;
            break;
        }
    }

    if (indx > -1) {
        selected.splice(indx, 1);
    }

    $(`[data-userId=${userId}]`).removeClass("selected");
    const tr = $(element).parents("tr").removeClass("selected");
    tr.popover("hide").remove();
}

function delay(callback, ms) {
    var timer = 0;
    return function () {
        var context = this, args = arguments;
        clearTimeout(timer);
        timer = setTimeout(function () {
            callback.apply(context, args);
        }, ms || 0);
    };
}