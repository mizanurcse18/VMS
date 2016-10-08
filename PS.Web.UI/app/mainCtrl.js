/*
 * project Controller
 *
 *
 * (c) 2016 
 * License: MIT
 *Author:Mizanur Rahman
 *Job Type: Software Engineer
 *Email: munna.cse18@gmail.com
 */

(function (app) {
    'use strict';

    app.controller('mainCtrl', mainCtrl);

    mainCtrl.$inject = ['$scope', '$mdSidenav', '$timeout', '$log', '$mdBottomSheet', 'hotkeys', '$location'];

    function mainCtrl($scope, $mdSidenav, $timeout, $log, $mdBottomSheet, hotkeys, $location) {
        $scope.toggleSideNav = function () {
            var navID = 'left';
            $mdSidenav(navID)
              .toggle()
              .then(function () {
                  //$log.debug("toggle " + navID + " is done");
              });
        }

        $scope.message = "this is a massage from main controller";
        

        
        $scope.menu =
            [
                {
                    link: '',
                    title: 'Dashboard',
                    icon: 'dashboard'
                },
                {
                    link: '',
                    title: 'Project',
                    icon: 'group'
                },
                {
                    link: '',
                    title: 'Messages',
                    icon: 'message'
                }
            ];

        hotkeys.add({
            combo: 'ctrl+alt+h',
            description: 'goto home path',
            callback: function () {
                $scope.goToMenu('/');
            }
        });

        hotkeys.add({
            combo: 'ctrl+alt+p',
            description: 'goto home path',
            callback: function () {
                $scope.goToMenu('/projectInfo');
            }
        });
        hotkeys.add({
            combo: 'ctrl+alt+p',
            description: 'goto home path',
            callback: function () {
                $scope.goToMenu('/projectInfo');
            }
        });
        hotkeys.add({
            combo: 'ctrl+alt+1',
            description: 'goto acccounts head path',
            callback: function () {
                $scope.goToMenu('/acHead');
            }
        });
        hotkeys.add({
            combo: 'ctrl+alt+2',
            description: 'goto acccounts head path',
            callback: function () {
                $scope.goToMenu('/acLedger');
            }
        });
        hotkeys.add({
            combo: 'ctrl+alt+3',
            description: 'goto chart of accounts',
            callback: function () {
                $scope.goToMenu('/chartOfAccounts');
            }
        });
        hotkeys.add({
            combo: 'ctrl+alt+3',
            description: 'goto chart of accounts',
            callback: function () {
                $scope.goToMenu('/bankCashLedgeramreMap');
            }
        });

        $scope.goToMenu = function (path) {
            $location.path(path);
        };
    }
})
(angular.module('vehicleManagementSystem'));