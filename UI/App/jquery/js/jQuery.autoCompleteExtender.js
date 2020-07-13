/////////////*******************************////////////////////////
// This file extends a div to add a text box and a div so as to   //
// show the search results .                                      //
/////////////*******************************////////////////////////


(function ($) {

    $.fn.autoComplete = function (providedOptions) {
        // merge users option with default options
        var completeOptions = $.extend({}, $.fn.autoComplete.defaults, providedOptions);

        var suggestionDivSelector = ".jSuggestHover";
        var suggestionDiv = "jSuggestHover";

        var initialValue = $(this).val();
        var autoCompleteControl = this;
        var autoCompleteControlValue = $(this).val();
        var idValue = '';

        var containerDivSelector = "#jSuggestContainer";

        if ($(containerDivSelector).length == 0) {
            $(completeOptions.container).append('<div id="jSuggestContainer"></div>');
        }

        $(containerDivSelector).hide();

        $(this).bind("keydown click", function (e) {
            if (e.keyCode == 27 || e.keyCode == 9) {
                $(containerDivSelector).hide();
            }

            // if enter key
            else if (e.keyCode == 13) {
                if ($(suggestionDivSelector).length == 1) {
                    $(autoCompleteControl).val($(suggestionDivSelector).text());
                    if (completeOptions.valueFieldId != '' && $("#" + completeOptions.valueFieldId).length > 0) {
                        $("#" + completeOptions.valueFieldId).val($(suggestionDivSelector).attr('id'));
                    }
                }
                $(containerDivSelector).hide();
                initialValue = $(autoCompleteControl).val();
                return false;
            }
            return true;
        });

        $(this).bind("keyup click", function (e) {

            autoCompleteControl = this;
            autoCompleteControlValue = this.value;

            if (completeOptions.valueFieldId != '' && $("#" + completeOptions.valueFieldId).length > 0) {
                $("#" + completeOptions.valueFieldId).val('');
            }

            if (this.value.length >= completeOptions.minchar) {
                var offSet = $(this).offset();

                $(containerDivSelector).css({
                    position: "absolute",
                    top: offSet.top + $(this).outerHeight() + "px",
                    left: offSet.left,
                    width: $(this).outerWidth() - 2 + "px",
                    opacity: completeOptions.opacity,
                    zIndex: completeOptions.zindex
                }).show();

                // if escape key
                if (e.keyCode == 27 || e.keyCode == 9) {
                    $(containerDivSelector).hide();
                }

                // if enter key
                else if (e.keyCode == 13) {
                    if ($(suggestionDivSelector).length == 1) {
                        $(autoCompleteControl).val($(suggestionDivSelector).text());
                        if (completeOptions.valueFieldId != '' && $("#" + completeOptions.valueFieldId).length > 0) {
                            $("#" + completeOptions.valueFieldId).val($(suggestionDivSelector).attr('id'));
                        }
                    }
                    $(containerDivSelector).hide();
                    initialValue = $(autoCompleteControl).val();
                    return false;
                }
                // if down arrow
                else if (e.keyCode == 40) {
                    // if any suggestion is highlighted
                    if ($(suggestionDivSelector).length == 1) {
                        if (!$(suggestionDivSelector).next().length == 0) {
                            $(suggestionDivSelector).next().addClass(suggestionDiv);
                            $(".jSuggestHover:eq(0)").removeClass(suggestionDiv);
                            if (completeOptions.autoChange) {
                                $(autoCompleteControl).val($(suggestionDivSelector).text());
                                if (completeOptions.valueFieldId != '' && $("#" + completeOptions.valueFieldId).length > 0) {
                                    $("#" + completeOptions.valueFieldId).val($(suggestionDivSelector).attr('id'));
                                }
                            }
                        }
                    }
                    else {
                        $("#jSuggestContainer ul li:first-child").addClass(suggestionDiv);
                        if (completeOptions.autoChange) {
                            $(autoCompleteControl).val($(suggestionDivSelector).text());
                            if (completeOptions.valueFieldId != '' && $("#" + completeOptions.valueFieldId).length > 0) {
                                $("#" + completeOptions.valueFieldId).val($(suggestionDivSelector).attr('id'));
                            }
                        }
                    }

                }

                // if up arrow
                else if (e.keyCode == 38) {
                    // if any suggestion is highlighted
                    if ($(suggestionDivSelector).length == 1) {
                        if (!$(suggestionDivSelector).prev().length == 0) {
                            $(suggestionDivSelector).prev().addClass(suggestionDiv);
                            $(".jSuggestHover:eq(1)").removeClass(suggestionDiv);
                            if (completeOptions.autoChange) {
                                $(autoCompleteControl).val($(suggestionDivSelector).text());
                                if (completeOptions.valueFieldId != '' && $("#" + completeOptions.valueFieldId).length > 0) {
                                    $("#" + completeOptions.valueFieldId).val($(suggestionDivSelector).attr('id'));
                                }
                            }
                        }
                        // if is first child
                        else {
                            $(suggestionDivSelector).removeClass(suggestionDiv);
                            $(autoCompleteControl).val(initialValue);
                        }
                    }
                }
                // new query detected
                else if (autoCompleteControl.value != initialValue) {
                    initialValue = autoCompleteControl.value;
                    if ($(".jSuggestLoading").length == 0)
                        $('<div class="jSuggestLoading"><img src="' + completeOptions.loadingImg + '" align="bottom" /> ' + completeOptions.loadingText + '</div>').prependTo("#jSuggestContainer");

                    $(".jSuggestLoading").show();


                    $(containerDivSelector).find('ul').remove();

                    var parameters = BulidParameterList(completeOptions.data, completeOptions.contextKey, $(this).val(), completeOptions.pickContextKeyfrom);

                    // optimize server performance by loading at intervals
                    $.ajax({
                        type: completeOptions.type,
                        url: completeOptions.url,
                        data: parameters,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (result) {
                            $(containerDivSelector).find('ul').remove();

                            var resultList = completeOptions.htmlElement(result.d, completeOptions.count);
                            $(containerDivSelector).append(resultList);

                            $("#jSuggestContainer ul li").bind("mouseover", function () {
                                $(suggestionDivSelector).removeClass(suggestionDiv);
                                $(this).addClass(suggestionDiv);
                                autoCompleteControlValue = $(this).text();
                                idValue = $(this).attr('id');
                                if (completeOptions.autoChange)
                                    $(autoCompleteControl).val($(suggestionDivSelector).text());
                                if (completeOptions.onSelected) {
                                    completeOptions.onSelected($(this));
                                    $(autoCompleteControl).change();
                                }
                            });

                            $("#jSuggestContainer ul li").click(function () {
                                $(this).addClass(suggestionDiv);
                                $(autoCompleteControl).val(autoCompleteControlValue);
                                if (completeOptions.valueFieldId != '' && $("#" + completeOptions.valueFieldId).length > 0) {
                                    $("#" + completeOptions.valueFieldId).val(idValue);
                                }
                            });

                            $(".jSuggestLoading").hide();
                        },
                        error: function (a, b, c) {
                            $(suggestionDivSelector).removeClass(suggestionDiv);
                            $(containerDivSelector).hide();
                        }
                    });
                }
            }
            // if text is too short do nothing and hide everything
            else {
                $(suggestionDivSelector).removeClass(suggestionDiv);
                $(containerDivSelector).hide();
            }

            // no bubbling, click is binded to autoCompleteControl to prevent document bind from firing
            return true;
        });

        $(document).bind("click", function () {
            $(containerDivSelector).hide();
            initialValue = autoCompleteControl.value;
        });

    };

    $.fn.autoComplete.defaults = {
        minchar: 3,
        opacity: 1.0,
        zindex: 20000,
        delay: 2500,
        container: 'body',
        loadingImg: '/App/jquery/css/AutoComplete/Images/ajax-loader.gif',
        loadingText: 'Loading...',
        autoChange: false,
        url: "",
        type: "POST",
        data: "",
        count: 20,
        contextKey: "notIncluded",
        pickContextKeyfrom: "",
        valueFieldId: "",
        htmlElement: function (data, count) { return BuildSearchList(data, count); },
        onSelected: function (data) { }
    };


    function BulidParameterList(data, contextKey, controlValue, pickContextKeyfrom) {
        var contextKeyControl = $.trim(pickContextKeyfrom).length > 0 ? $("#" + pickContextKeyfrom) : null;

        if (data == '')
            return $(this).serialize();

        else if (data != '' && (contextKey == "notIncluded" && contextKeyControl == null))
            return "{" + data + ": '" + controlValue + "'}";

        else if (data != '' && (contextKey != "notIncluded" || (contextKeyControl != null && contextKeyControl.length > 0))) {
            var parameter = "{" + data + ": '" + controlValue + "'";
            parameter += ",'contextKey':'" + (contextKey != "notIncluded" ? contextKey : contextKeyControl.val()) + "'}";
            return parameter;
        }
    }

    function BuildSearchList(data, count) {
        var htmlElement = "<ul>";
        var counter = 0;
        $.each(data, function () {
            if (counter <= count) {
                if (this.value && this.text) {
                    htmlElement += "<li id='" + $.trim(this.value) + "'>" + $.trim(this.text) + "</li>";
                }
                else {
                    htmlElement += "<li>" + $.trim(this) + "</li>";
                }
            }
            counter++;
        });
        htmlElement += "</ul>";
        return htmlElement;
    }

})(jQuery);