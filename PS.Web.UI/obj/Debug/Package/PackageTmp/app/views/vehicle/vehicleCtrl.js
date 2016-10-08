(function (app) {
    'use strict';

    app.controller('vehicleCtrl', vehicleCtrl);

    vehicleCtrl.$inject = ['$scope'];

    function vehicleCtrl($scope) {
        $scope.entryButtonStatus = "Save";
    }
})(angular.module('vehicleManagementSystem'));