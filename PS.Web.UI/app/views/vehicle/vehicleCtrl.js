(function (app) {
    'use strict';

    app.controller('vehicleCtrl', vehicleCtrl);

    vehicleCtrl.$inject = ['$scope', 'vehicleManagementSystemApiService', '$mdToast', '$anchorScroll', '$location', 'hotkeys', '$q', '$timeout'];

    function vehicleCtrl($scope, vehicleManagementSystemApiService, $mdToast, $anchorScroll, $location, hotkeys, $q, $timeout) {
        $scope.entryButtonStatus = "Save";
        $scope.Vehicle = {};

        //OnLoad
        onLoad();
        function onLoad() {
            getVehicle($scope.Vehicle, 0);
        }

        //Get
        function getVehicle(Vehicle, pageSize) {
            vehicleManagementSystemApiService.getAllVehicles(Vehicle, pageSize).then(function (data) {
                $scope.VehicleList = data.data;
            });
        }

        //Post
        $scope.save = function (Vehicle) {
            //if ($scope.form.$valid)
            {
                vehicleManagementSystemApiService.saveVehicle(Vehicle).then(function (data) {
                    if (data.data == true) {
                        $scope.successInfo(Vehicle);
                    } else {
                        $scope.showMessage("Could not save Action Information.");
                    }
                });

                //} else {
                //    $scope.showMessage("Some Error occured.");
                //}
            }
        }

        $scope.edit = function (Vehicle) {
            $scope.entryButtonStatus = "Update";
            $location.hash('top');
            $anchorScroll();
            $scope.Vehicle = Vehicle;

        }

        //delete
        $scope.delete = function (Vehicle) {
            vehicleManagementSystemApiService.deleteVehicle(Vehicle).then(function (data) {
                if (data.data == true) {
                    $scope.showMessage("Vehicle Head Info has been deleted.");
                    $scope.Vehicle = {};
                    getVehicle(Vehicle, 0);
                }
            });
        }

        //Utility
        $scope.successInfo = function (Vehicle) {
            if (!Vehicle.id) {
                $scope.showMessage("Vehicle Head Info has been saved.");
            }
            else $scope.showMessage("Vehicle Head Info has been Updated.");
            $scope.reset();
            getVehicle($scope.Vehicle, 0);
        }

        $scope.dtOptions = {
            dom: '<"top"f>rt<"bottom"<"left"<"length"l>><"right"<"info"i><"pagination"p>>>',
            pagingType: 'simple',
            autoWidth: false,
            responsive: true
        }

        $scope.reset = function () {
            $scope.entryButtonStatus = "Save";
            $scope.Vehicle = {};
            $scope.form.$setPristine();
            $scope.form.$setUntouched();
            $scope.searchType = null;
        }

        $scope.showMessage = function (message) {
            $mdToast.show($mdToast.simple().textContent(message).position('right').hideDelay(1000));
        }

        //Hot Keys
        hotkeys.add({
            combo: 'alt+s',
            description: 'save',
            callback: function () {
                $scope.save($scope.Vehicle);
            }
        });
    }
})(angular.module('vehicleManagementSystem'));