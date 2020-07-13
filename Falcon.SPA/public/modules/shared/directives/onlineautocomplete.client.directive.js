(function () {
    'use strict';

    angular.module(ApplicationConfiguration.applicationModuleName).directive(SharedConfiguration.directives.onlineautocomplete, ["httpWrapper", function (hw) {
        return {
            restrict: 'A',
            scope: {
                
            },
            link: function (scope, element, attrs) { 
                var autoCompleteUrl = attrs.onlineAutocomplete;
                var autoCompleteposition = attrs.autocompletePosition; 
                element.autocomplete({
                    appendTo: element.parent(),
                    source: function (request, response) {
                        var tUrl = '';

                        if (autoCompleteUrl.indexOf("?") > 0)
                            tUrl = autoCompleteUrl + "&text=" + request.term;
                        else
                            tUrl = autoCompleteUrl + "?text=" + request.term;

                        hw.get({ url: tUrl }).then(function (result) {
                            response(result);
                        });

                        if (autoCompleteposition == "top") {
                            element.next().addClass("ui-autocomp-show-top");
                        }
                    },
                    autoFocus:true,
                    minLength: 3, 
                    
                    open: function () {
                       // scope.locationId = null;
                        $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
                    },
                    close: function () {
                         
                        $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
                    },
                    select: function(event, ui) {
                        //scope.locationId = ui.item.id;
                        $(this).val(ui.item.label);
                        element.trigger('input'); 
                    }
                }).data("ui-autocomplete")._renderItem = function (ul, item) {
                    return $("<li>")
                        .attr("data-value", item.value)
                        .append($("<a>").text(item.label))
                        .appendTo(ul);
                };
            }
        };
    }]);
})();