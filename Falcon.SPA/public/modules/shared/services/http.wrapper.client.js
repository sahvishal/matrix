(function () {

    'use strict';

    var HttpMethod = { Get: 1, Post: 2, Put: 3, Delete: 4 };
    var MessageType = { Success: 0, Error: 1, Warning: 2, Unathorized: 3 };

    angular.module(ApplicationConfiguration.applicationModuleName).factory("httpWrapper", ["$http", "$q", "logger", "$modal", "$state",
        function ($http, $q, logger, $modal, state) {

            var defaultOptions = function (httpMethod) {

                return {
                    url: '',
                    data: '',
                    disableNotification: false,
                    method: httpMethod,
                    onBeforeSuccess: function () { },
                    onBeforeError: function () { },
                    success: function (deffered, result, def) {
                        $("span.validation-message").val('').hide();
                        $(".validation-message").each(function () {
                            $(this).removeClass("validation-message");
                        });

                        if (result.data.Message.MessageType === MessageType.Unathorized) {
                            window.location = '/Home/UnauthorizeAccess';
                        } else if (result.data.Message.MessageType === MessageType.Error) {
                            def.onBeforeError(result.data);

                            if (result.data != null) {
                                if (result.data.ModelValidation != null && result.data.ModelValidation.IsValid == false) {
                                    if (!this.disableNotification) {
                                        displayErrors(result.data.ModelValidation.Errors);
                                    }
                                } else {
                                    logError(result);
                                }
                            }
                            deffered.reject();
                        } else {
                            def.onBeforeSuccess(result.data);
                            if (result.data != null && result.data.Message != null && typeof (result.data.Message) == "object") {
                                if (!def.disableNotification && def.method != HttpMethod.Get) {
                                    displayMessage(result.data.Message);
                                }
                            }

                            deffered.resolve(result.data.Data);
                        }

                    },
                    error: function (deffered, result, def) {
                        def.onBeforeError(result.data);

                        if (result != null && result.data != null) {
                            if (result.data.ModelValidation != null && result.data.ModelValidation.IsValid == false) {
                                if (!this.disableNotification) {
                                    displayErrors(result.data.ModelValidation.Errors);
                                }
                            } else {
                                logError(result);
                            }
                        }
                        deffered.reject();
                    }
                };
            };

            function displayMessage(obj) {
               
                if (obj.MessageType == MessageType.Success) {
                    // logger.showToasterSuccess(obj.Message);
                }
                else if (obj.MessageType == MessageType.Error) {
                    logger.showToasterError(obj.Message);
                }
            }

            function logError(result) {
                if (result.data.Message != null) {
                    displayMessage(result.data.Message);
                }
            }

            function displayErrors(validationsList) {
                $("span.validation-message").val('').hide();
                $(".validation-message").each(function () {
                    $(this).removeClass("validation-message");
                });
                $("span.validation-message").val('').hide();
                
                for (var x = 0; x < validationsList.length; x++) {
                    var propertyCompleteName = validationsList[x].Name;
                    
                    if ($('form').find("[ng-model='" + propertyCompleteName + "']").length > 0) {
                        
                        $('form').find("[ng-model='" + propertyCompleteName + "']").each(function () {
                            $(this).$error = true;
                            $(this).addClass('validation-message');
                            var thisName = $(this).attr('name');
                            if (thisName != undefined && thisName != '') {
                                $('form').find("[name='" + thisName + "']").addClass('validation-message');
                                if (validationsList[x].Error != null && validationsList[x].Error != '') {
                                    $('<span class="validation-message">' + validationsList[x].Error + '</span>').insertAfter(this);
                                }
                            } else {
                                if (validationsList[x].Error != null && validationsList[x].Error != '') {
                                    $('form').find("[name='" + thisName + "']").addClass('validation-message');
                                    $('<p class="text-danger top-buffer-2 coupon-error-text info-text bottom-buffer-0 ng-binding validation-message">' + validationsList[x].Error + '</p>').insertAfter(this);
                                }
                            }
                        });
                    } else if ($('form').find("[validationFor='" + propertyCompleteName + "']").length > 0) {
                        $('form').find("[validationFor='" + propertyCompleteName + "']").each(function () {
                            $(this).$error = true;
                            $(this).addClass('validation-message');
                            var thisName = $(this).attr('name');
                            if (thisName != undefined && thisName != '') {
                                $('form').find("[name='" + thisName + "']").addClass('validation-message');
                                if (validationsList[x].Error != null && validationsList[x].Error != '') {
                                    $('<span class="validation-message">' + validationsList[x].Error + '</span>').insertAfter(this);
                                }
                            } else {
                                if (validationsList[x].Error != null && validationsList[x].Error != '') {
                                    $('form').find("[name='" + thisName + "']").addClass('validation-message');
                                    $('<span class="validation-message">' + validationsList[x].Error + '</span>').insertAfter(this);
                                }
                            }

                        });
                    } else {
                        var name = validationsList[x].Name.split('.');
                        
                        if ($('form').find("[ng-model$='" + name[name.length - 1] + "']").length > 0) {
                            $('form').find("[ng-model$='" + name[name.length - 1] + "']").each(function () {
                                $(this).$error = true;
                                $(this).addClass('validation-message');
                                var thisName = $(this).attr('name');
                                if (thisName != undefined && thisName != '') {
                                    $('form').find("[name='" + thisName + "']").addClass('validation-message');
                                    if (validationsList[x].Error != null && validationsList[x].Error != '') {
                                        $('<span class="validation-message">' + validationsList[x].Error + '</span>').insertAfter(this);
                                    }
                                } else {
                                    if (validationsList[x].Error != null && validationsList[x].Error != '') {
                                        $('form').find("[name='" + thisName + "']").addClass('validation-message');
                                        $('<p class="text-danger top-buffer-2 info-text coupon-error-text bottom-buffer-0 ng-binding validation-message">' + validationsList[x].Error + '</p>').insertAfter(this);
                                    }
                                }

                            });
                        } else if ($('form').find("[validationFor='" + name[name.length - 1] + "']").length > 0) {
                            $('form').find("[validationFor='" + name[name.length - 1] + "']").each(function () {
                                $(this).$error = true;
                                $(this).addClass('validation-message');
                                var thisName = $(this).attr('name');
                                if (thisName != undefined && thisName != '') {
                                    $('form').find("[name='" + thisName + "']").addClass('validation-message');
                                    if (validationsList[x].Error != null && validationsList[x].Error != '') {
                                        $('<span class="validation-message">' + validationsList[x].Error + '</span>').insertAfter(this);
                                    }
                                } else {
                                    if (validationsList[x].Error != null && validationsList[x].Error != '') {
                                        $('form').find("[name='" + thisName + "']").addClass('validation-message');
                                        $('<span class="validation-message">' + validationsList[x].Error + '</span>').insertAfter(this);
                                    }
                                }

                            });
                        } else {
                            logger.showToasterError(validationsList[x].Error);
                        }
                    }
                }
            }

            var remoteServiceUrl = ApplicationConfiguration.remoteServiceUrl;

            return {
                get: function (opts) {

                    var deferred = $q.defer();
                    var def = defaultOptions(HttpMethod.Get);
                    $.extend(def, opts);

                    $http({ method: 'get', url: remoteServiceUrl + def.url }).then(function (result, status, header) {
                        def.success(deferred, result, def);

                    }, function (data) {
                        def.error(deferred, data, def);

                    });

                    return deferred.promise;
                },
                post: function (opts) {
                    var deferred = $q.defer();
                    var def = defaultOptions(HttpMethod.Post);
                    $.extend(def, opts);
                    $http.post(remoteServiceUrl + def.url, def.data).then(function (result) {
                        def.success(deferred, result, def);
                    }, function (data) {
                        def.error(deferred, data, def);
                    });

                    return deferred.promise;
                },
                remove: function (opts) {
                    var deferred = $q.defer();
                    var def = defaultOptions(HttpMethod.Delete);
                    $.extend(def, opts);
                    $http.delete(remoteServiceUrl + def.url).then(function (result) {
                        def.success(deferred, result, def);
                    }, function (data) {
                        def.error(deferred, data, def);
                    });

                    return deferred.promise;
                },
                file: function (opts) {
                    var deferred = $q.defer();
                    var def = defaultOptions(HttpMethod.Post);
                    $.extend(def, opts);
                    var form = new FormData();
                    form.append('file', def.data);
                    $http.post(remoteServiceUrl + def.url, form, { transformRequest: angular.identity, headers: { 'Content-Type': undefined } }).then(function (result) {
                        def.success(deferred, result, def);
                    }, function (data) {
                        def.error(deferred, data, def);
                    });

                    return deferred.promise;
                }
            };

        }]);

})();

