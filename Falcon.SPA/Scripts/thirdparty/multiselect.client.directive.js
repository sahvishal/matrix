"use strict";

angular.module('ui.multiselect', ["multiselect.tpl.html"])

  //from bootstrap-ui typeahead parser
  .factory('optionParser', ['$parse', function ($parse) {

      //                      00000111000000000000022200000000000000003333333333333330000000000044000
      var TYPEAHEAD_REGEXP = /^\s*(.*?)(?:\s+as\s+(.*?))?\s+for\s+(?:([\$\w][\$\w\d]*))\s+in\s+(.*)$/;

      return {
          parse: function (input) {

              var match = input.match(TYPEAHEAD_REGEXP), modelMapper, viewMapper, source;
              if (!match) {
                  throw new Error(
                    "Expected typeahead specification in form of '_modelValue_ (as _label_)? for _item_ in _collection_'" +
                      " but got '" + input + "'.");
              }

              return {
                  itemName: match[3],
                  source: $parse(match[4]),
                  viewMapper: $parse(match[2] || match[1]),
                  modelMapper: $parse(match[1])
              };
          }
      };
  }])

  .directive('multiselect', ['$parse', '$document', '$compile', 'optionParser',

    function ($parse, $document, $compile, optionParser) {
        return {
            restrict: 'E',
            require: 'ngModel',
            link: function (originalScope, element, attrs, modelCtrl) {

                var exp = attrs.options,
                    parsedResult = optionParser.parse(exp),
                    isMultiple = attrs.multiple ? true : false,
                    headertext = attrs.headertext != undefined && attrs.headertext != null?attrs.headertext:'Select',
                  required = false,
                  scope = originalScope.$new(),
                  changeHandler = attrs.change || angular.noop;

                scope.items = [];
                scope.selectedValues = [];
                scope.header = headertext;
                scope.multiple = isMultiple;
                scope.disabled = false;

                originalScope.$on('$destroy', function () {
                    scope.$destroy();
                });

                var popUpEl = angular.element('<multiselect-popup></multiselect-popup>');

                //required validator
                if (attrs.required || attrs.ngRequired) {
                    required = true;
                }
                attrs.$observe('required', function (newVal) {
                    required = newVal;
                });

                //watch disabled state
                scope.$watch(function () {
                    return $parse(attrs.disabled)(originalScope);
                }, function (newVal) {
                    scope.disabled = newVal;
                });

                //watch single/multiple state for dynamically change single to multiple
                scope.$watch(function () {
                    return $parse(attrs.multiple)(originalScope);
                }, function (newVal) {
                    isMultiple = newVal || false;
                });

                //watch option changes for options that are populated dynamically
                scope.$watch(function () {
                    return parsedResult.source(originalScope);
                }, function (newVal) {
                    if (angular.isDefined(newVal))
                        parseModel();
                    markChecked(modelCtrl.$modelValue);
                    getHeaderText();
                }, true);

                //watch model change
                scope.$watch(function () {
                    return modelCtrl.$modelValue;
                }, function (newVal, oldVal) {
                    //when directive initialize, newVal usually undefined. Also, if model value already set in the controller
                    //for preselected list then we need to mark checked in our scope item. But we don't want to do this every time
                    //model changes. We need to do this only if it is done outside directive scope, from controller, for example.
                    if (angular.isDefined(newVal)) {
                        markChecked(newVal);
                        scope.$eval(changeHandler);
                    }
                    getHeaderText();
                    modelCtrl.$setValidity('required', scope.valid());
                }, true);

                function parseModel() {
                    scope.items.length = 0;
                    var model = parsedResult.source(originalScope);
                    if (!angular.isDefined(model)) return;
                    for (var i = 0; i < model.length; i++) {
                        var local = {};
                        local[parsedResult.itemName] = model[i];
                        scope.items.push({
                            label: parsedResult.viewMapper(local),
                            model: model[i],
                            checked: false
                        });
                    }
                }

                parseModel();

                element.append($compile(popUpEl)(scope));

                function getHeaderText() {
                    if (is_empty(modelCtrl.$modelValue)) return scope.header = headertext;

                    if (isMultiple) {
                        var localMultiple = {};
                        var header = '';
                        for (var index = 0; index < scope.selectedValues.length; index++) {
                            localMultiple[parsedResult.itemName] = scope.selectedValues[index];
                            header =header+ parsedResult.viewMapper(localMultiple)+", ";
                        }
                        if (header.length > 0) {
                            header = header.substring(0, header.length - 2);
                        }
                        scope.header = header;
                        //  scope.header = modelCtrl.$modelValue.length + ' ' + 'selected';
                    } else {
                        var local = {};
                        local[parsedResult.itemName] = scope.selectedValues;

                        scope.header = parsedResult.viewMapper(local);
                    }

                    if (scope.header.length >= 45)
                        scope.header = scope.header.slice(0, 45) + "...";
                }

                function is_empty(obj) {
                    if (!obj) return true;
                    if (obj.length && obj.length > 0) return false;
                    for (var prop in obj) if (obj[prop]) return false;
                    return true;
                };

                scope.valid = function validModel() {
                    if (!required) return true;
                    var value = modelCtrl.$modelValue;
                    return (angular.isArray(value) && value.length > 0) || (!angular.isArray(value) && value != null);
                };

                function selectSingle(item) {
                    if (item.checked) {
                        scope.uncheckAll();
                    } else {
                        scope.uncheckAll();
                        item.checked = !item.checked;
                    }
                    setModelValue(false);
                }

                function selectMultiple(item) {
                    item.checked = !item.checked;
                    setModelValue(true);
                }

                function setModelValue(isMultiple) {
                    var value;
                    scope.selectedValues = [];
                    if (isMultiple) {
                        value = [];

                        angular.forEach(scope.items, function(item) {
                            if (item.checked) {
                                value.push(item.model.Value);
                                scope.selectedValues.push(item.model);
                            }
                        });
                    } else {
                        angular.forEach(scope.items, function(item) {
                            if (item.checked) {
                                value = item.model.Value;
                                scope.selectedValues = item.model;
                                return false;
                            }
                        });

                    }
                     modelCtrl.$setViewValue(value);
                    //modelCtrl.$setViewValue(selectedValues);
                }

                function markChecked(newVal) {
                    if (scope.items.length <= 0) return;
                    
                    if (!angular.isArray(newVal)) {
                        angular.forEach(scope.items, function (item,index) {
                            
                            if (angular.equals(item.model.Value.toString(), index.toString())) {
                                item.checked = true;
                                return false;
                            }
                        });
                        setModelValue(false);
                    } else {
                        angular.forEach(newVal, function (i) {
                            angular.forEach(scope.items, function (item) {
                                if (angular.equals(item.model.Value.toString(), i.toString())) {
                                    item.checked = true;
                                }
                            });
                        });
                        setModelValue(true);
                    }
                }

                scope.checkAll = function () {
                    if (!isMultiple) return;
                    angular.forEach(scope.items, function (item) {
                        item.checked = true;
                    });
                    setModelValue(true);
                };

                scope.isAllChecked = false;
                
                scope.CheckUncheckAll = function () {
                    if (scope.isAllChecked == false) {
                        scope.checkAll();
                        scope.isAllChecked = true;
                    } else {
                        scope.uncheckAll();
                        scope.isAllChecked = false;
                    }
                };

                scope.uncheckAll = function () {
                    angular.forEach(scope.items, function (item) {
                        item.checked = false;
                    });
                    setModelValue(true);
                };

                scope.select = function (item) {
                    if (isMultiple === false) {
                        selectSingle(item);
                        scope.toggleSelect();
                    } else {
                        selectMultiple(item);
                    }
                };
            }
        };
    }])

 .directive("multiselectPopup", ["$document", function ($document) {
     return {
         restrict: "E",
         scope: false,
         replace: true,
         templateUrl: "multiselect.tpl.html",
         link: function (scope, element, attrs) {

             scope.isVisible = false;

             scope.toggleSelect = function () {
                 if (element.hasClass("open")) {
                     element.removeClass("open");
                     $document.unbind("click", clickHandler);
                 } else {
                     element.addClass("open");
                     $document.bind("click", clickHandler);
                 }
             };

             //				$("ul.dropdown-menu").on("click", "[data-stopPropagation]", function(e) {
             //					e.stopPropagation();
             //				});

             function clickHandler(event) {
                 if (elementMatchesAnyInArray(event.target, element.find(event.target.tagName))) {
                     return;
                 }
                 element.removeClass("open");
                 $document.unbind("click", clickHandler);
                 scope.$apply();
             }

             var elementMatchesAnyInArray = function (element, elementArray) {
                 for (var i = 0; i < elementArray.length; i++) {
                     if (element === elementArray[i]) {
                         return true;
                     }
                 }
                 return false;
             };
         }
     };
 }]);


angular.module("multiselect.tpl.html", []).run(["$templateCache", function ($templateCache) {
    $templateCache.put("multiselect.tpl.html",
			'<div class="dropdown multiselect">' +
  "<label class=\" form-control\" ng-click=\"toggleSelect()\" ng-disabled=\"disabled\" ng-class=\"{'error': !valid()}\">" +
    '<span class="pull-left">{{header}}</span>' +
  '</label>' +
  '<ul class="dropdown-menu">' +
    '<li>' +
      '<input class="input-block-level" type="text" ng-model="searchText.label" autofocus="autofocus" placeholder="Filter" />' +
    '</li>' +
    '<li ng-show="multiple">' +
		"<a style='width:100%;display: inline-block;'  ng-click='CheckUncheckAll(); focus()'> <i style='margin-right:5px;' ng-class=\"{'fa fa-check-square-o': isAllChecked, 'fa fa-square-o': !isAllChecked}\"></i><span>Check All </span></a>" +
    '</li>' +
	'<li><div class="multi-select-ddl"><ul>'+ 
	'<li ng-repeat="i in items | filter:searchText">' +
      '<a style="width:100%;display: inline-block;"  ng-click="select(i); focus()">' +
        "<i style='margin-right:5px;' ng-class=\"{'fa fa-check-square-o': i.checked, 'fa fa-square-o': !i.checked}\"></i><span>{{i.label}} </span></a>" +
    '</li></ul></div></li>' +
    '</ul>' +
    '</div>');
}]);
