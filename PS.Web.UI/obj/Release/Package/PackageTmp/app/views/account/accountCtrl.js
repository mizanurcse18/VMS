(function (app) {
    'use strict';

    app.controller('accountCtrl', accountCtrl);

    accountCtrl.$inject = ['$scope'];

    function accountCtrl($scope) {
        $scope.messages = 'this is acccount';
    }

})(angular.module('vehicleManagementSystem'));