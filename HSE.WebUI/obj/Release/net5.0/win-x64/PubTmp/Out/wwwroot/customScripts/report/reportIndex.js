var startDate, endDate, isAllSelected = false;
var start = moment().subtract(1, "month");
var end = moment();
var tableReportForms = "";

$(document).ready(function () {
    CreateDataTable();
});

function CreateDataTable() {

    var dateRangePickerHtml = $.parseHTML(
        `<div class="btn btn-default" title="Əməliyyat tarixi" id="reportrange" style="background: #fff; cursor: pointer; padding: 5px 10px; border: 1px solid #ccc; margin-left:35px;">
                                                                                        <i class="fa fa-calendar"></i>&nbsp;
                                                                                        <span></span> <i class="fa fa-caret-down"></i>
                                                                                     </div>`
    );

    //var buttonsHtml = $.parseHTML(
    //    `<a href="#" id="btnExcelExport">
    //        <img title="Excel" height="30" width="30" src="/images/export-to-excel-icon.png" />
    //     </a>`);

    tableReportForms = $("#reportTable").DataTable({
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
        dom: "<'row dt-header'<'col-sm-12 col-md-1 dt-length'l><'col-sm-12 col-md-5 dt-date-range'><'col-sm-12 col-md-offset-5 col-md-1 dt-buttons-icon-container'>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
        lengthMenu: [[10, 25, 50, 100], [10, 25, 50, 100]],
        deferRender: true,
        order: [],
        "columns": [
            { "data": "formId", "name": "formId", "autoWidth": true },
            { "data": "instructionDate", "name": "instructionDate", "autoWidth": true },
            { "data": "instructorFullName", "name": "instructorFullName", "autoWidth": true },
            { "data": "instructorOrganizationFullName", "name": "instructorOrganizationFullName", "autoWidth": true },
            { "data": "instructorPosition", "name": "instructorPosition", "autoWidth": true },
            { "data": "instructorTypeName", "name": "instructorTypeName", "autoWidth": true },
            { "data": "isActive", "name": "isActive", "autoWidth": true }
        ],
        "processing": true,
        "serverSide": true,
        ajax: {
            "url": "/Report/ReportIndex",
            "type": "POST",
            data: function (data) {
                if ($("#reportrange span").html() !== "Invalid date - Invalid date") {

                    data.dateRange = $("#reportrange span").html();
                } else {
                    data.dateRange = $("#reportrange span").html();
                    $("#reportrange span").html("Hamısı");
                }
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
                "targets": "thInstructorOrganizationFullName",
                "createdCell": function (td) {
                    $(td).addClass("InstructorOrganizationFullName");
                }
            },
            {
                "targets": "thInstructorjobName",
                "createdCell": function (td) {
                    $(td).addClass("InstructorjobName");
                }
            }, {
                "targets": "thInstructionStatus",
                "createdCell": function (td, cellData, rowData, row, col) {
                    var statusBadge = "";
                    if (rowData.isActive === "Prosesdə") {
                        statusBadge = `<span class="badge badge-primary">${cellData}</span>`;
                    }
                    else {
                        statusBadge = `<span class="badge badge-secondary">${cellData}</span>`;
                    }

                    $(td).html(statusBadge);
                    $(td).addClass("InstructionStatus");
                }
            }
        ]
    });

    //$('.dt-buttons-icon-container').html(buttonsHtml);
    $(".dt-date-range").html(dateRangePickerHtml);

    tableReportForms.columns().every(function () {
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

    $("#reportTable thead input").on("click", function () {
        return false;
    });

    $("#reportTable tbody").on("dblclick", "tr", function () {

        const data = tableReportForms.row(this).data();
        const newUrl = "/History/RetrieveHistoryResult?instructionFormGuidId=";
        window.open(newUrl + data.formGuidId);
        window.target("_blank");
    });

    function cb(start, end) {
        if (!isAllSelected) {
            $("#reportrange span").html(start.format("DD/MM/YYYY") + " - " + end.format("DD/MM/YYYY")).change();
        } else {
            $("#reportrange span").html("Hamısı").change();
        }
    }

    if (!start._isValid || !end._isValid) {
        start = moment().subtract(1, "month");
        end = moment();
    }

    $("#reportrange").on("change", function () {
        tableReportForms.draw();
    });

    $("#reportrange").daterangepicker({
        startDate: start,
        endDate: end,
        ranges: {
            'Hamısı': [null, null],
            'Bu gün': [moment(), moment()],
            'Dünən': [moment().subtract(1, "days"), moment().subtract(1, "days")],
            'Son 7 gün': [moment().subtract(6, "days"), moment()],
            'Son 30 gün': [moment().subtract(29, "days"), moment()],
            'Bu ay': [moment().startOf("month"), moment().endOf("month")],
            'Keçən ay': [moment().subtract(1, "month").startOf("month"), moment().subtract(1, "month").endOf("month")]
        },
        "locale": {
            "format": "DD/MM/YYYY",
            "separator": " - ",
            "applyLabel": "Tətbiq et",
            "cancelLabel": "Bağla",
            "fromLabel": "From",
            "toLabel": "To",
            "customRangeLabel": "Aralıq seç"
        }
    }, cb);
    cb(start, end);
}

function ExportToExcel() {
    //$("#btnExcelExport").on("click", function (e) {
    //    e.preventDefault();
    //    var tableId = "reportTable";
    //    var reportTitle = $("#reportTitle").html();
    //    ExportTableToExcel(tableId, reportTitle, 5);
    //});

    $("#btnExcelExport").on("click", function () {
        var search;
        if (typeof tableReportForms !== 'undefined') {
            search = tableReportForms.search();
        }

        var documentModel = getFormData($('#ReportForm'));

        $.ajax({
            "url": "/DocumentReport/ExportToExcel",
            "type": "GET",
            data: {
                documentModel: documentModel,
                userColumnsJson: $('#userColumnsJson').val(),
                generalSearch: search
            },
            xhrFields: {
                responseType: 'text'
            },
            success: function (response) {
                // convert json response to csv format
                JSONToExcelConvertor(response);
            }
        });
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