(function () {
    'use strict';

   angular.module(ApplicationConfiguration.applicationModuleName).controller("ShippingController",
        ['$rootScope', '$scope', '$stateParams', '$state', 'logger', '$timeout', OnlineConfiguration.services.eventService,
            OnlineConfiguration.services.shippingService, CoreConfiguration.constants, "usSpinnerService", 'client',
            function ($rootScope, $scope, $stateParams, $state, logger, $timeout, eventService, shippingService, constants, usSpinnerService, client) {
                
                $scope.guid = $stateParams.guid;
                $scope.isCollapsed = true;
                var selectedOptionId = -1;
                var selectedProductId = -1;

                $scope.isPosted = false;
                $scope.shippingOptionChange = false;
                $scope.productOptionItemChange = false;
                $scope.EventType = constants.EventType;

                $scope.loader_back = false;
                $scope.loader_next = false;

                function init() {

                    shippingService.GetShippingOption($stateParams.guid).then(function (result) {

                        $scope.AllShippingOptions = result.AllShippingOptions;
                        $scope.AllProducts = result.AllProducts;
                        $scope.tempCart = result.RequestValidationModel.TempCart;
                        $scope.shipping = result;
                        if ($scope.AllProducts != null && $scope.AllProducts.length > 0 && $scope.EventType.Retail == $scope.shipping.EventType) {
                            $.each($scope.AllProducts, function (index, product) {
                                if (product.ProductId == 2)
                                    product.ShortDescription = product.ShortDescription + ' For purchasing the Ultrasound Images, we will provide Unlimited online access and a complementary mailed copy of your report and ultrasound images on a CD.';
                            });
                        }

                        selectedOptionId = $scope.tempCart.ShippingId;
                        selectedProductId = $scope.tempCart.ProductId;
                        $scope.shippingOptionsAvilable = $scope.AllShippingOptions;

                        $.each($scope.AllShippingOptions, function (index, shipping) {
                            shipping.disabled = false;
                            shipping.isChecked = false;
                            if (shipping.ShippingOptionId == selectedOptionId)
                                shipping.isChecked = true;
                        });


                        $.each($scope.AllProducts, function (index, product) {
                            product.isChecked = false;
                            if (product.ProductId == selectedProductId)
                                product.isChecked = true;
                        });


                        $scope.UpdateShippingPriceAndStatus(true);

                        setTimeout(function () {
                            usSpinnerService.stop('online-spinner');
                        }, 1000);
                    });
                }

                init();

                $scope.changeShippingOption = function (optionId, answer) {
                    $scope.shippingOptionChange = true;

                    $.each($scope.shipping.AllShippingOptions, function (index, shipping) {
                        shipping.isChecked = false;
                        if (shipping.ShippingOptionId == optionId && answer) {
                            shipping.isChecked = true;
                        }
                    });
                };

                function getSelectedProductId() {
                    var selectedProductIds = new Array();
                    $.each($scope.shipping.AllProducts, function (index, product) {

                        if (product.isChecked) {
                            selectedProductIds.push(product.ProductId);
                        }
                    });

                    return selectedProductIds;
                }

                function getSelectedShipingId() {
                    var selectedShippingOptionId = -1;
                    $.each($scope.shipping.AllShippingOptions, function (index, shipping) {
                        if (shipping.isChecked) {
                            selectedShippingOptionId = shipping.ShippingOptionId;
                        }
                    });

                    return selectedShippingOptionId;
                }

                $scope.showProductwithFreeShippingPrice = false;
                $scope.ProductwithFreeShippingPrice = 0;

                $scope.productOptionChanged = function () {

                    $scope.productOptionItemChange = true;
                    $scope.UpdateShippingPriceAndStatus(false);
                };

                $scope.UpdateShippingPriceAndStatus = function (isIntialState) {
                    var selectedProductionIds = getSelectedProductId();

                    if ($scope.EventType.Retail == $scope.shipping.EventType) {
                        if (selectedProductionIds.length > 0) {
                            if ($scope.shipping.IsHospitalPartnerEvent === true) {

                                //if hospital has only one shipping then select it if customer purchased ultrasound images
                                if ($scope.shipping.AllShippingOptions.length == 1) {
                                    $.each($scope.shipping.AllShippingOptions, function (index, shipping) {
                                        shipping.isChecked = true;
                                        shipping.disabled = true;
                                    });
                                }
                                //if hospital has more than one shipping then select first priority for free online + free paper copy mailed and second priority for paper coly mailed with price.
                                if ($scope.shipping.AllShippingOptions.length > 1) {
                                    var freePaperShippingFound = false;
                                    var paperShippingWithPrice = false;
                                    $.each($scope.shipping.AllShippingOptions, function (index, shipping) {
                                        if (shipping.ShippingOptionId > 0 && shipping.Price == 0) {
                                            freePaperShippingFound = true;
                                        }
                                        if (shipping.ShippingOptionId > 0 && shipping.Price > 0) {
                                            paperShippingWithPrice = true;
                                        }
                                    });
                                    //if shipping option contains free paper copy mailed shipping option then select it.
                                    if (freePaperShippingFound) {
                                        $.each($scope.shipping.AllShippingOptions, function (index, shipping) {
                                            shipping.isChecked = false;
                                            shipping.disabled = true;
                                            //$scope.showProductwithFreeShippingPrice = true;
                                            if (shipping.ShippingOptionId > 0 && shipping.Price == 0) {
                                                shipping.isChecked = true;
                                            }

                                        });
                                    }
                                    //if free paper copy not found then select paper copy 
                                    if (!freePaperShippingFound) {
                                        $.each($scope.shipping.AllShippingOptions, function (index, shipping) {
                                            shipping.isChecked = false;
                                            shipping.disabled = true;
                                            //$scope.showProductwithFreeShippingPrice = true;
                                            if (shipping.ShippingOptionId > 0) {
                                                shipping.isChecked = true;
                                            }
                                        });
                                    }
                                }
                            } else {
                                $.each($scope.shipping.AllShippingOptions, function (index, shipping) {
                                    shipping.isChecked = false;
                                    shipping.disabled = true;
                                    $scope.showProductwithFreeShippingPrice = true;
                                    if (shipping.ShippingOptionId > 0 && shipping.Price == 0) {
                                        shipping.isChecked = true;
                                    }

                                });
                            }


                        } else if (isIntialState == false) {
                            $scope.showProductwithFreeShippingPrice = false;
                            $.each($scope.shipping.AllShippingOptions, function (index, shipping) {
                                shipping.disabled = false;
                                shipping.isChecked = false;
                            });
                        }
                    }
                };

                $scope.submitShippingAndProcut = function () {

                    var shippingProductEditModel = {
                        SelectedProductIds: getSelectedProductId(),
                        SelectedShippingOptionId: getSelectedShipingId(),
                        Guid: $scope.guid
                    };

                    $scope.isPosted = true;
                    $scope.loader_next = true;

                    if (shippingProductEditModel.SelectedShippingOptionId == null || shippingProductEditModel.SelectedShippingOptionId < 0) {
                        logger.showToasterError('Please select one of the result shipping Option.');
                        $scope.isPosted = false;
                        $scope.loader_next = false;
                        return;
                    }
                    else if ($scope.productOptionItemChange || $scope.shippingOptionChange) {

                        shippingService.saveSelectedShippingOption(shippingProductEditModel).then(function (result) {
                            $scope.isPosted = false;
                            $scope.loader_next = false;
                            client(shippingProductEditModel);
                        }, function () {
                            $scope.isPosted = false;
                            $scope.loader_next = false;
                        });
                    } else {
                        client(shippingProductEditModel);
                    }
                };

                //$scope.goToPreviousStep = function () {
                //    $scope.isPosted = true;
                //    $scope.loader_back = true;
                //    $state.go('Customer', { guid: $scope.guid });

                //};
            }]);

})();