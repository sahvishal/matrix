(function () {
    'use strict';

    angular.module(CallCenterConfiguration.moduleName).controller(CallCenterConfiguration.controllers.medicareController,
        ['$scope', '$modalInstance', 'logger', function ($scope, $modalInstance, logger) {

        $scope.PatientCurrentMedications = [];
        $scope.medicationUnits = [
            { value: 0, text: 'Select Unit' },
            { value: 1, text: 'Kg' },
            { value: 2, text: 'Mg' },
            { value: 3, text: 'Mtr' },
        ];
        $scope.medicationFrequency = [
            { value: 0, text: 'Select Frequency' },
            { value: 1, text: 'Once a day' },
            { value: 2, text: 'Twice a day' },
            { value: 3, text: 'Thrice a day' },
        ];

        $scope.init = function () {
            $scope.addCurrentMedication();
        }

        $scope.addCurrentMedication = function () {
            $scope.PatientCurrentMedications[$scope.PatientCurrentMedications.length] = {
                Id: $scope.PatientCurrentMedications.length,
                ProprietaryName: '',
                ServiceDate: '',
                Dose: '',
                Unit: 0,
                Frequency: 0,
                IsPrescribed: false,
                IsOtc: false,
                Indication: ''
            };
        };

        $scope.removeCurrentMedication = function (index) {
            $scope.PatientCurrentMedications.splice(index, 1);
            if($scope.PatientCurrentMedications.length == 0)
            { $scope.addCurrentMedication(); }
        };

        $scope.Cancel = function () {
            $modalInstance.dismiss();
        }

        $scope.Save = function () {
            logger.showToasterSuccess('data is saved.')
            $modalInstance.close();
        }

        $scope.init();
    }]);
}());