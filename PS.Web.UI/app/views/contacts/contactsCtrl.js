(function (app) {
    'use strict';

    app.controller('contactsCtrl', contactsCtrl);

    contactsCtrl.$inject = ['$scope', 'vehicleManagementSystemApiService', '$mdToast', '$anchorScroll', '$location', 'hotkeys', '$q', '$timeout'];

    function contactsCtrl($scope, vehicleManagementSystemApiService, $mdToast, $anchorScroll, $location, hotkeys, $q, $timeout) {
        $scope.entryButtonStatus = "Save";
        $scope.Contact = {};

        //OnLoad
        onLoad();
        function onLoad() {
            getContacts($scope.Contact, 0);
        }

        //Get
        function getContacts(Contact, pageSize) {
            vehicleManagementSystemApiService.getAllContacts(Contact, pageSize).then(function (data) {
                $scope.ContactList = data.data;
            });
        }

        //Post
        $scope.save = function (contact) {
            //if ($scope.form.$valid)
            {
                vehicleManagementSystemApiService.saveContact(contact).then(function (data) {
                    if (data.data == true) {
                        $scope.successInfo(contact);
                    } else {
                        $scope.showMessage("Could not save Action Information.");
                    }
                });

                //} else {
                //    $scope.showMessage("Some Error occured.");
                //}
            }
        }

        $scope.edit = function (contact) {
            $scope.entryButtonStatus = "Update";
            $location.hash('top');
            $anchorScroll();
            $scope.Contact = contact;

        }

        //delete
        $scope.delete = function (contact) {
            vehicleManagementSystemApiService.deleteContact(contact).then(function (data) {
                if (data.data == true) {
                    $scope.showMessage("Contact Head Info has been deleted.");
                    $scope.Contact = {};
                    getContacts(Contact, 0);
                }
            });
        }

        //Utility
        $scope.successInfo = function (contact) {
            if (!contact.id) {
                $scope.showMessage("Contact Head Info has been saved.");
            }
            else $scope.showMessage("Contact Head Info has been Updated.");
            $scope.reset();
            getContacts($scope.Contact, 0);
        }

        $scope.dtOptions = {
            dom: '<"top"f>rt<"bottom"<"left"<"length"l>><"right"<"info"i><"pagination"p>>>',
            pagingType: 'simple',
            autoWidth: false,
            responsive: true
        }

        $scope.reset = function () {
            $scope.entryButtonStatus = "Save";
            $scope.Contact = {};
            $scope.form.$setPristine();
            $scope.form.$setUntouched();
            $scope.searchText = null;
        }

        $scope.showMessage = function (message) {
            $mdToast.show($mdToast.simple().textContent(message).position('right').hideDelay(1000));
        }


    }
})(angular.module('vehicleManagementSystem'));