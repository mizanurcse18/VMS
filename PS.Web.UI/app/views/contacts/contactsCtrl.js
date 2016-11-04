(function (app) {
    'use strict';

    app.controller('contactsCtrl', contactsCtrl);

    contactsCtrl.$inject = ['$scope', 'vehicleManagementSystemApiService', '$mdToast', '$anchorScroll', '$location', 'hotkeys', '$q', '$timeout', '$mdDialog'];

    function contactsCtrl($scope, vehicleManagementSystemApiService, $mdToast, $anchorScroll, $location, hotkeys, $q, $timeout, $mdDialog) {
        $scope.entryButtonStatus = "Save";
        $scope.HREmployee = {};
        $scope.hasHREmployee = false;
        $scope.HREmployee.employeeTypeID = 2;
        $scope.currentPage = 1;
        $scope.pageSize = 20;
        $scope.ContactList = [];
        //OnLoad
        onLoad();
        function onLoad() {

            getHREmployee($scope.HREmployee, $scope.pageSize, $scope.currentPage);
        }

        //Get
        function getHREmployee(obj, pageSize, currentPage) {
            vehicleManagementSystemApiService.getAllHREmployee(obj, pageSize, currentPage).then(function (data) {
                $scope.ContactList = data.data;
            });
        }

        function getHasHREmployee(obj) {
            vehicleManagementSystemApiService.hasHREmployee(obj).then(function (data) {
                $scope.hasHREmployee = data.data;
                if ($scope.hasHREmployee == true) {
                    $scope.HREmployee.employeeTypeID = 2;
                    getHREmployee($scope.HREmployee, $scope.page, $scope.currentPage);
                }
            });
        }

        //Post
        $scope.save = function (obj) {
            obj.employeeTypeID = 2;
            obj.hrEmployeeType = null;
            if ($scope.form.$valid) {
                vehicleManagementSystemApiService.saveHREmployee(obj).then(function (data) {
                    if (data.data == true) {
                        $scope.successInfo(obj);
                    } else {
                        $scope.showMessage("Could not save Action Information.");
                    }
                });

            } else {
                $scope.showMessage("Some Error occured.");
            }
        }

        $scope.edit = function (obj) {
            $scope.entryButtonStatus = "Update";
            $location.hash('top');
            $anchorScroll();
            $scope.HREmployee = obj;

        }

        //delete
        $scope.delete = function (event, obj) {
            var confirm = $mdDialog.confirm()
          .title('Would you like to delete this Ledger?')
          .textContent('Name: ' + obj.name +
                    '. Your ledger will be deleted.')
          .ariaLabel('Lucky day')
          .targetEvent(event)
          .ok('OK')
          .cancel('Canel');
            $mdDialog.show(confirm).then(function () {
                vehicleManagementSystemApiService.deleteHREmployee(obj).then(function (data) {
                    if (data.data == true) {
                        $scope.showMessage("Contact Info has been deleted.");
                        $scope.obj = {};
                        $scope.obj.employeeTypeID = 2;
                        getHREmployee($scope.obj, $scope.pageSize, $scope.currentPage);
                    } else {
                        $scope.showMessage("Could not delete Contact Info. Some Error occured");
                    }
                });
            }, function () {
            });

        }

        //Utility
        $scope.successInfo = function (obj) {
            if (!obj.id) {
                $scope.showMessage("Contact Head Info has been saved.");
            }
            else $scope.showMessage("Contact Head Info has been Updated.");
            $scope.reset();
            $scope.HREmployee.employeeTypeID = 2;
            getHREmployee($scope.HREmployee, $scope.pageSize, $scope.currentPage);
        }

        $scope.dtOptions = {
            dom: '<"top"f>rt<"bottom"<"left"<"length"l>><"right"<"info"i><"pagination"p>>>',
            pagingType: 'simple',
            autoWidth: false,
            responsive: true
        }

        $scope.reset = function () {
            $scope.entryButtonStatus = "Save";
            $scope.HREmployee = {};
            $scope.form.$setPristine();
            $scope.form.$setUntouched();
            $scope.searchText = null;
        }

        $scope.showMessage = function (message) {
            $mdToast.show($mdToast.simple().textContent(message).position('right').hideDelay(1000));
        }

        //Action Buttons Event
        var originatorEv;

        $scope.openMenu = function ($mdOpenMenu, ev) {
            originatorEv = ev;
            $mdOpenMenu(ev);
        };

        //pagination

        $scope.paging = {
            total: 100,
            current: 1,
            onPageChanged: loadPages
        };

        function loadPages() {
            console.log('Current page is : ' + $scope.paging.current);

            // TODO : Load current page Data here

            $scope.currentPage = $scope.paging.current;
        }
    }
})(angular.module('vehicleManagementSystem'))