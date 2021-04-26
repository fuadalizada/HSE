$(document).ready(function () {
    if (window.location.href.indexOf("showTrue") > -1) {
        bootbox.confirm({
            
            //message: `<i class="fas fa-info-circle fa-4x" style="color:#00bca4" aria-hidden="true"></i>eDoc – dakı dəyişikliklərlə tanış olmaq üçün davam edin.`,
            message: `<div class= "row" >
                            <div class="col-2">
                                    <i class="fas fa-info-circle fa-4x pulsingButton" style="color:#00bca4" aria-hidden="true"></i>
                                </div>
                                <div class="col-10" style="font-size: 21px;font-weight: bold;color: cadetblue;text-align: right;margin-top: 21px">
                                        Yeniliklərlə tanış ola bilərsiniz.
                                </div>
                        </div >`,
            buttons: {
                confirm: {
                    label: 'Davam edin',
                    className: 'btn-succ effect effect-5'
                },
                cancel: {
                    label: 'imtina edin',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                console.log('This was logged in the callback: ' + result);
                var tour = new window.Tour({
                    steps: [
                        {
                            element: "#axtar",
                            placement: "auto",
                            backdropPadding: 5,
                            content: "Sənəd nömrəsini yazaraq birbaşa sürətli axtarış edə bilərsiniz.",
                            template: "<div class='popover tour hca-tooltip--left-nav'><div class='arrow'></div><div class='row'><div class='col-sm-12'><div data-role='next' class='close'>X</div></div></div><div class='row'><div class='col-sm-2'><i style='margin-left:20px;margin-top:8px;' class='fas fa-search fa-3x' aria-hidden='true'></i></div><div class='col-sm-10'><p class='popover-content' style='font-size: 15px; font-weight: bold; color: cadetblue; text-align: right;'></p><a id='hca-left-nav--tooltip-ok' href='#' data-role='next' class='btn hca-tooltip--okay-btn effect effect-5'>Davam edin</a></div></div></div>"
                        },
                        {
                            element: "#bildirish",
                            placement: "auto",
                            backdropPadding: 5,
                            content: "Bildirişlərin növünü seçib Sizə gəlməsini tənzimləyə bilərsiniz.",
                            template:
                                "<div class='popover tour hca-tooltip--left-nav'><div class='arrow'></div><div class='row'><div class='col-sm-12'><div data-role='next' class='close'>X</div></div></div><div class='row'><div class='col-sm-2'><i style='margin-left:10px;margin-top:15px:' class='fas fa-user-cog fa-3x' aria-hidden='true'></i></div><div class='col-sm-10'><p class='popover-content' style='font-size: 15px; font-weight: bold; color: cadetblue; text-align: right;'></p><a id='hca-left-nav--tooltip-ok' href='#' data-role='next' class='btn hca-tooltip--okay-btn effect effect-5'>Davam edin</a></div></div></div>"
                        },
                        {
                            element: "#config",
                            placement: "left",
                            backdropPadding: 20,
                            content: "Dizayn və rəngləri dəyişə bilərsiniz.",
                            template: "<div class='popover tour hca-tooltip--left-nav'><div class='arrow'></div><div class='row'><div class='col-sm-12'><div data-role='next' class='close'>X</div></div></div><div class='row'><div class='col-sm-2'><i style='margin-left:10px;margin-top:15px:' class='fas fa-hand-pointer fa-rotate-90 fa-4x' aria-hidden='true'></i></div><div class='col-sm-10'><p class='popover-content' style='font-size: 14px; font-weight: bold; color: cadetblue; text-align: right;'></p><a id='hca-left-nav--tooltip-ok' href='#' data-role='next' class='btn hca-tooltip--okay-btn test effect effect-5'>Davam edin</a></div></div></div>"
                        }],

                    animation: true,
                    backdrop: true,
                    storage: false,
                    smartPlacement: true,
                    onShown: function (tour) {
                        var stepElement = getTourElement(tour);
                        $(stepElement).after($('.tour-step-background'));
                        $(stepElement).after($('.tour-backdrop'));
                        if (stepElement === "#config") {
                            $('.tour-step-background, .tour-backdrop').css('z-index', '11');
                            $('.tour-step-background, .tour-backdrop').css('position', 'fixed');
                            $('.tour-step-background, .tour-backdrop').css('background', 'black');
                        }

                        $('.hca-tooltip--left-nav .test').on("click", function () {
                            var url = window.location.toString();
                            window.location = url.replace('/#showTrue', '#FromLogin');
                            $.ajax({
                                type: "POST",
                                url: '/Account/UpdateTourDate',
                                data: true,
                                success: function (result) {
                                    console.log(result);
                                }
                            });
                        });
                    }
                });

                tour.init();
                tour.restart(true);

                function getTourElement(tour) {
                    return tour._options.steps[tour._current].element;
                }
            }
        });
        
    }
})





