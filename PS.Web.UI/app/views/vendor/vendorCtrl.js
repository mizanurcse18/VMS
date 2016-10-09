(function (app) {
    'use strict';

    app.controller('vendorCtrl', vendorCtrl);

    vendorCtrl.$inject = ['$scope'];

    function vendorCtrl($scope) {
        $scope.entryButtonStatus = "Save";
    }
})(angular.module('vehicleManagementSystem'));