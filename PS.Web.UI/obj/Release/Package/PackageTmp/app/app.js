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
(function () {
    'use strict';
    angular.module('vehicleManagementSystem', ['ngMaterial', 'ngMdIcons', 'ngRoute', 'ngMessages', 'cfp.hotkeys', 'data-table']).
        config(function ($mdIconProvider, $mdThemingProvider) {
            $mdIconProvider
                .icon('menu', '../Images/icons/menu.svg', 24)
                .icon('delete', '../Images/icons/delete.svg', 24)
                .icon('edit', '../Images/icons/pencil.svg', 24)
                .icon('car', '../Images/icons/car.svg', 24);
            $mdThemingProvider.theme('default').
                primaryPalette('blue').
                accentPalette('red');
        }).config(config);
    //.run(run);

    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: 'app/views/home/index.html',
                controller: 'indexCtrl'
            })
            .when("/vehicle", {
                templateUrl: 'app/views/vehicle/index.html',
                controller: 'vehicleCtrl'
            })
            .when("/projectInfo", {
                templateUrl: 'app/views/project/project.html',
                controller: 'projectCtrl'
            })
            .when("/acHead", {
                templateUrl: 'app/views/acHead/acHead.html',
                controller: 'acHeadCtrl'
            })
            .when("/acLedger", {
                templateUrl: 'app/views/acLedger/acLedger.html',
                controller: 'acLedgerCtrl'
            })
            .when("/chartOfAccounts", {
                templateUrl: 'app/views/reports/chartOfAccounts/chartOfAccounts.html',
                controller: 'acLedgerCtrl'
            })
            .when("/bankCashLedgeramreMap", {
                templateUrl: 'app/views/bankCashMap/bankCashLedgerMap.html',
                controller: 'bankCashLedgerMapCtrl'
            })
            .when("/voucher/:voucherType", {
                templateUrl: 'app/views/voucher/voucher.html',
                controller: 'voucherCtrl'
            })
            .otherwise({ redirectTo: "/" });
    }
})();
