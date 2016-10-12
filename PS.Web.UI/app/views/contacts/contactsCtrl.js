(function (app) {
    'use strict';

    app.controller('contactsCtrl', contactsCtrl);

    contactsCtrl.$inject = ['$scope'];

    function contactsCtrl($scope) {
        $scope.entryButtonStatus = "Save";
    }
})(angular.module('vehicleManagementSystem'));