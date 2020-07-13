(function () {
    'use script';

    angular.module(CallCenterConfiguration.moduleName).controller(CallCenterConfiguration.controllers.eventPreviewModelController,
       ['$rootScope', '$scope', 'ModalParams', 'logger', CoreConfiguration.constants, "usSpinnerService", CallCenterConfiguration.services.contactService,
           function ($rootScope, $scope, modalParams, logger, constants, usSpinnerService, contactService) {
              
               $scope.popupmodel = true;
               $scope.showspiner = true;
               $scope.showFutureEvents = true;
               $scope.CallQueueSortOrderBy = constants.CallQueueSortOrderBy;
               $scope.SortOrderType = constants.SortOrderType;
               
               $scope.EventFilters = { zipcode: modalParams.ZipCode, city: '', state: '', radius: 50, forHealthPlanId: modalParams.HealthPlanId, tobeFilledEventId: 0, SortByOrder: $scope.CallQueueSortOrderBy.Distance, SortOrderType: $scope.SortOrderType.Ascending, ExcludeCorporateEvents: false, PageSize: 5 };
              
               
               var validateEventSearchFilter = function (filter) {

                   if (filter.zipcode === '' && filter.city === '' && filter.state === '') {
                       logger.showToasterError('Please provide zipcode or city or state');
                       return false;
                   }
                   if (filter.city != '' && filter.state === '') {
                       logger.showToasterError('Please select state');
                       return false;
                   }
                   return true;
               };

               function init() {
                  
                   usSpinnerService.spin('preview-spinner');
                   contactService.GetEventsByZipCode($scope.EventFilters, $scope.showFutureEvents, 1).then(function(eventList) {
                       $scope.Events = eventList.Events;
                       $scope.PagingModel = eventList.PagingModel;
                       $scope.showspiner = false;
                   }, function() {
                       $scope.showspiner = false;
                   });
               }

               $scope.eventShortBy = function (orderBy) {

                   if ($scope.EventFilters.SortByOrder === orderBy) {
                       if ($scope.EventFilters.SortOrderType === $scope.SortOrderType.Ascending) {
                           $scope.EventFilters.SortOrderType = $scope.SortOrderType.Descending;
                       } else {
                           $scope.EventFilters.SortOrderType = $scope.SortOrderType.Ascending;
                       }

                   } else {
                       $scope.EventFilters.SortByOrder = orderBy;
                       $scope.EventFilters.SortOrderType = $scope.SortOrderType.Ascending;
                   }

                   if (validateEventSearchFilter($scope.EventFilters)) {
                       contactService.GetEventsByZipCode($scope.EventFilters, $scope.showFutureEvents, 1).then(function (eventList) {
                           updateEventPagingfilter($scope.EventFilters);
                           $scope.Events = eventList.Events;
                           $scope.PagingModel = eventList.PagingModel;
                       }, function () {
                          
                       });
                   }
               };

               function updateEventPagingfilter(obj) {
                   $scope.EventFilters.zipcode = obj.zipcode;
                   $scope.EventFilters.city = obj.city;
                   $scope.EventFilters.state = obj.state;
                   $scope.EventFilters.radius = obj.radius;
                   $scope.EventFilters.SortByOrder = obj.SortByOrder;
               }
               
               $scope.SeachByFilters = function () {
                   if (validateEventSearchFilter($scope.EventFilters)) {
                      
                       $scope.EventFilters.ExcludeCorporateEvents = false;
                       contactService.GetEventsByZipCode($scope.EventFilters, $scope.showFutureEvents, 1).then(function (eventList) {
                           updateEventPagingfilter($scope.EventFilters);
                           $scope.Events = eventList.Events;
                           $scope.PagingModel = eventList.PagingModel;
                          
                       }, function () {
                           
                       });
                   }
               };

               init();
               
               
               $scope.Cancel = function () {
                   modalParams.onclose();
               };
              
               $scope.GetEventPage = function (pageNumber) {
                   $scope.EventFilters.ExcludeCorporateEvents = false;
                   contactService.GetEventsByZipCode($scope.EventFilters, $scope.showFutureEvents, pageNumber).then(function (eventList) {
                       $scope.Events = eventList.Events;
                       $scope.PagingModel = eventList.PagingModel;

                   });
               };
               
               $scope.ViewAll = function (eventId) {
                   window.open(ApplicationConfiguration.appUrl + '/Scheduling/AppointmentSlot/ViewAll?eventId=' + eventId, '_blank');;
               };

           }]);

}());
