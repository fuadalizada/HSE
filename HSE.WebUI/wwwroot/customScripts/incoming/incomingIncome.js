var startDate, endDate;
var tableIncomings = "";

$(document).ready(function () {
    CreateDataTable();
});

function CreateDataTable() {

tableIncomings = $("#incomingForms").DataTable({
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
        { "data": "formId", "name": "formId", "autoWidth": true},
        { "data": "instructionDate", "name": "instructionDate", "autoWidth": true },
        { "data": "instructorFullName", "name": "instructorFullName", "autoWidth": true },
        { "data": "instructorPosition", "name": "instructorPosition", "autoWidth": true },
        { "data": "instructorTypeName", "name": "instructorTypeName", "autoWidth": true },
        { "data": "instructionStatus", "name": "instructionStatus", "autoWidth": true }
    ],
    "processing": true,
    "serverSide": true,
    ajax: {
        "url": "/Incoming/Income",
        "type": "POST",
        data: function (data) {
            return data;
        }
    },
    "createdRow": function (row, data) {
        $(row).addClass("MesajUserTr");
    },
    "columnDefs": [
        {
            "targets": "thFormId",
            "createdCell": function (td) {
                $(td).addClass("FormId");
            }
        },
        {
            "targets": "thFormCreateDate",
            "createdCell": function (td) {
                $(td).addClass("FormCreateDate");
            }
        },
        {
            "targets": "thInstructorFullName",
            "createdCell": function (td) {
                $(td).addClass("InstructorFullName");
            }
        },
        {
            "targets": "thInstructorjobName",
            "createdCell": function (td) {
                $(td).addClass("InstructorjobName");
            }
        },{
            "targets": "thInstructionStatus",
            "createdCell": function (td, cellData, rowData, row, col) {
                var statusBadge = "";
                statusBadge = `<span class="badge badge-primary">${cellData}</span>`;
                $(td).html(statusBadge);
                $(td).addClass("InstructionStatus");
            }
        }
    ]
});

tableIncomings.columns().every(function () {
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

    $("#incomingForms thead input").on("click", function () {
    return false;
    });

    $("#incomingForms tbody").on("dblclick", "tr", function () {

        const data = tableIncomings.row(this).data();
        const newUrl = "/Incoming/RetrieveIncomingResult?instructionFormId=";
        window.open(newUrl + data.formId,"_self");
        //window.target("_blank");
    });
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