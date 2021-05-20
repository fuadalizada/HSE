var requiredMessage = 'Bu sahə məcburidir';
var shortContetnrequiredMessage = 'Qısa məzmun məcburidir';
var addressedUserValidationMessage = 'Ünvanlanan şəxs dərkənarda ola bilməz.';
var requiredInstructionMessage = 'Dərkənar məcburidir.';
var mainExecutorInvalidOperationMessage = 'Əsas icraçı üçün əməliyyat növü "Məlumat üçün" seçilə bilməz.';
var fromWhoWorkflowInvalidMessage = 'Əməliyyatlar düzgün daxil edilməyib."Kimin adından"-sahəsini yoxlayın.';
var workflowInvalidMessage = 'Əməliyyatlar düzgün daxil edilməyib.';
var successMessage = 'Əməliyyat uğurla yerinə yetirildi.';
var errorMessage = 'Xəta baş verdi.';
var toastrTitle = 'Bildiriş';
var result = $('#result');
var currentFile;
var coordinates;
var jcropAPI;
var isRedirectedFromLogin = false;
var userLayoutOptions = {
    boxedLayout: '',
    boxedlayoutBackground: '',
    fixedHeader: '',
    fixedSidebar: '',
    closedSidebar: '',
    headerStyle: '',
    sidebarStyle: ''
};
var toastr;

// jQuery plugin to prevent double submission of forms
jQuery.fn.preventDoubleSubmission = function () {
    $("form").on("submit", function (e) {
        var $form = $(this);

        if ($form.data("submitted") === true) {
            // Previously submitted - don't submit again
            e.preventDefault();
            return false;
        } else {
            // Mark it so that the next submit can be ignored
            $form.data("submitted", true);
        }
    });
    return this;
};

$(document).ready(function () {

    adjustDatatableColumns(1000);

    $("body").on("click", function (e) {
        //only buttons
        if ($(e.target).data("toggle") !== "popover"
            && $(e.target).parents(".popover.in").length === 0) {
            $('[data-id="#popover-search"]').popover("hide").data("bs.popover").inState.click = false
        }
        });

    $(".modal").on("hidden.bs.modal", function (event) {
        $(this).removeClass('fv-modal-stack');
        $("body").data("fv_open_modals", $("body").data("fv_open_modals") - 1);
    });

    $(".modal").on("hidden.bs.modal", function (e) {
        if ($(".modal").hasClass("in")) {
            $("body").addClass("modal-open");
        }
    });

    $("form").preventDoubleSubmission();

    if (sessionStorage.getItem("isOpen")) {
        if (parseInt(sessionStorage.getItem("isOpen")) === 0) {
            $("#sidebar, #content").addClass("active");
        }
    }

    $("#sidebar-menu a:not(#close-sidebar)").each(function (k) {
        $(this).attr("id", k + 100);
    });

    $("a:not(.hasSubMenu)").on("click", function (e) {
        e.stopPropagation();
    });

    $("#sidebar-menu a,#sidebar-menu a:not(.hasSubMenu)").on("click", function (e) {
        sessionStorage.setItem("activeId", $(this).attr("id"));

        var isItDirectedNewPage = $(this).hasClass("dropdown-toggle");
        var isInMobileView = $("#sidebar ul li.mobileCollapseListItem").css("display") === "list-item";

        if (!isItDirectedNewPage && isInMobileView) {
            $("#sidebar, #content").toggleClass("active");
            sessionStorage.setItem("isOpen", 0);
        }
    });


    $(".related-document-view").on("click", function (e) {
        e.stopPropagation();
        $(this).parents("tr").addClass("selected");
    });

    ChangeUrlOnClick();
    UserSetting();
    ReDrawDatableOnCollapseSidebar();
    SearchDocument();

    $(".related-document-tr").popover({
        html: true,
        trigger: "hover",
        placement: "auto"
    });

    $(function () {
        "use strict";
        $(".tabs").tabs();
    });

    $(function () {
        "use strict";
        $(".tabs-hover").tabs({
            event: "mouseover"
        });
    });

    InitLayoutOptions();

    $(".js-acc-btn").unbind();
});

toastr.options = {
    "closeButton": true,
    "debug": false,
    "newestOnTop": true,
    "progressBar": true,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};

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

var addCssInterval;

var addCssToIframe = function () {
    if ($("#img-file").contents().find("img") != undefined) {
        $("#img-file").contents().find("img").attr("style", "width:100%;");
        clearInterval(addCssInterval);
    }
};

function ChangeUrlOnClick() {
    $(".operation").on("click", function () {

        // set fromwhere
        localStorage.setItem("FromWhere", "fromSideBar");

        // set operation id
        var id = $(this).attr("data-id");
        localStorage.setItem("operationId", id);
    });
}

function UserSetting() {
    $(".settingUser").click(function() {
        if ($(".userArrow").hasClass("fa-sort-down")) {
            $(".userArrow").removeClass("fa-sort-down");
            $(".userArrow").addClass("fa-sort-up");
        } else {

            $(".userArrow").removeClass("fa-sort-up");
            $(".userArrow").addClass("fa-sort-down");
        }
    });
}


function InitLayoutOptions() {
    if (IsRedirectedFromLogin()) {
        SetLayoutOptionsFromDb();
    }
    else if (!CheckLocalStorageIsNull()) {
        SetLayoutOptionsFromLocalStorage();
    }
}

function SetLayoutOptionsFromLocalStorage() {
    var userOptionsLocalStorage = localStorage.getItem("userLayoutOptions");
    userLayoutOptions = JSON.parse(userOptionsLocalStorage);
    SetLayoutOptions(userLayoutOptions);
}

function SetLayoutOptionsFromDb() {
    if ($("#userLayoutOptions").val()) {
        userLayoutOptions = JSON.parse($("#userLayoutOptions").val());
        if (userLayoutOptions) {
            SetLayoutOptions(userLayoutOptions);
            localStorage.setItem("userLayoutOptions", JSON.stringify(userLayoutOptions));
        }
    }
    else {
        localStorage.setItem("userLayoutOptions", "");
    }
}

function CheckLocalStorageIsNull() {
    var isNull = true;
    if (localStorage.getItem("userLayoutOptions")) {
        isNull = false;
    }
    return isNull;
}

function IsRedirectedFromLogin() {
    var fromLogin = window.location.hash;
    if (fromLogin && fromLogin.includes("fromLogin")) {
        if (fromLogin === "#fromLogin") {
            window.location.hash = "";
        }
        isRedirectedFromLogin = true;
        return true;
    }
    isRedirectedFromLogin = false;
    return false;
}

function SetLayoutOptions(options) {
    //closed sidebar
    if (options.closedSidebar) {
        $("body").addClass("closed-sidebar");
        $("#close-sidebar .glyph-icon").addClass("icon-angle-right").removeClass("icon-angle-left");

        $("#\\#closed-sidebar").addClass("switch-on");
        $("#closed-sidebar").attr("checked", "checked");
    }

    //fixed header
    if (options.fixedHeader) {
        $("body").addClass("fixed-header");

        $("#\\#fixed-header").addClass("switch-on");
        $("#fixed-header").attr("checked", "checked");
    }

    //fixed sidebar
    if (options.fixedSidebar) {
        $("body").addClass("fixed-sidebar");

        $("#\\#fixed-sidebar").addClass("switch-on");
        $("#fixed-sidebar").attr("checked", "checked");
    }

    //boxed layout options
    var boxedLayout = options.boxedLayout;
    if (boxedLayout) {

        $("body").addClass("boxed-layout");
        $(".boxed-bg-wrapper").slideDown();

        //boxed layout background style
        if (options.boxedlayoutBackground) {
            var boxedlayoutBackground = options.boxedlayoutBackground;
            $('.set-background-style').removeClass("active");
            $('.set-background-style.' + boxedlayoutBackground.split("")[0]).addClass("active");


            $('body').addClass(boxedlayoutBackground);
        }

        $("#\\#boxed-layout").addClass("switch-on");
        $("#boxed-layout").attr("checked", "checked");
    }
    else {

        $("body").removeClass("boxed-layout");
        $(".boxed-bg-wrapper").slideUp();
        $(".set-background-style").removeClass("active");
    }

    //header style
    if (options.headerStyle) {
        var headerStyle = options.headerStyle;
        $(".set-adminheader-style").removeClass("active");
        $(`.set-adminheader-style.${headerStyle.split("")[0]}`).addClass("active");

        $("#page-header").removeClass(function (index, css) {
            return (css.match(/(^|\s)bg-\S+/g) || []).join("");
        });
        $("#page-header").removeClass(function (index, css) {
            return (css.match(/(^|\s)font-\S+/g) || []).join("");
        });
        $("#page-header").addClass(headerStyle);
    }

    //sidebar style
    if (options.sidebarStyle) {
        var sidebarStyle = options.sidebarStyle;
        $(".set-sidebar-style").removeClass("active");
        $(`.set-sidebar-style.${sidebarStyle.split("")[0]}`).addClass("active");
        $("#page-sidebar").removeClass(function (index, css) {
            return (css.match(/(^|\s)bg-\S+/g) || []).join("");
        });
        $("#page-sidebar").removeClass(function (index, css) {
            return (css.match(/(^|\s)font-\S+/g) || []).join("");
        });
        $("#page-sidebar").addClass(sidebarStyle);
    }

}

function ReDrawDatableOnCollapseSidebar() {
    $("#close-sidebar").on("click", function (e) {
        adjustDatatableColumns(700);
    });
}

function adjustDatatableColumns(delay) {
    setTimeout(function () {
        $('table[id]').each(function () {
            var jDataTable = new $.fn.dataTable.Api(`#${$(this).attr("id")}`);
            if (jDataTable) {
                jDataTable.columns.adjust();
            }
        });
    }, delay);
}

function SearchDocument() {
    $("#axtar").on("click", function (e) {
        $(".popover .search-value").focus();
    });

    $(document).on("click", ".popover .search-btn", function (e) {
        searchAjaxRequest();
    });


    $(document).on("keydown", ".popover .search-value", function (e) {
        var key = e.which;
        if (key === 13)  // the enter key code
        {
            searchAjaxRequest();
            return false;
        }
    });

    function searchAjaxRequest() {
       var searchValue = $(".popover .search-value").val();
        if (searchValue) {
            const newUrl = "/History/RetrieveHistoryResult?instructionFormId=";
            $.ajax({
                type: "Post",
                url: "/History/CheckIfInstructionFormIdExist",
                data: { instructionFormId: searchValue },
                success: function (response) {
                    if (response) {
                        window.open(newUrl + searchValue, "_self");
                    } else {
                        showErrorMessage("Axtarışa uyğun məlumat tapılmadı.", "Bildiriş");
                    }
                }
            });
        }
    }
}

/*
 * .addClassSVG(className)
 * Adds the specified class(es) to each of the set of matched SVG elements.
 */
$.fn.addClassSVG = function (className) {
    $(this).attr("class", function (index, existingClassNames) {
        return ((existingClassNames !== undefined) ? (existingClassNames + "") : "") + className;
    });
    return this;
};

/*
 * .removeClassSVG(className)
 * Removes the specified class to each of the set of matched SVG elements.
 */
$.fn.removeClassSVG = function (className) {
    $(this).attr("class", function (index, existingClassNames) {
        var re = new RegExp(`\\b${className}\\b`, "g");
        return existingClassNames.replace(re, "");
    });
    return this;
};