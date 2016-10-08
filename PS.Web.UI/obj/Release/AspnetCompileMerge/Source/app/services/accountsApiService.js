/*
 * Services
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

    app.factory('accountsApiService', accountsApiService);

    accountsApiService.$inject = ['$http', '$q'];

    function accountsApiService($http, $q) {
        return {
            //Project
            saveProjectInfo: function (projectInfo) {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/ProjectInfo/Save',
                    method: 'POST',
                    data: projectInfo
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            getAllProjectInfo: function () {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/ProjectInfo/GetAll',
                    method: 'GET'
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            getAllProjectInfoByPageSize: function (pageSize) {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/ProjectInfo/GetAllByPage',
                    method: 'GET',
                    params: { 'pageSize': pageSize }
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            deleteProjectInfo: function (id) {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/ProjectInfo/Delete',
                    method: 'GET',
                    params: { 'id': id }
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            //AcHead
            saveACHead: function (acHead) {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/ACHead/Save',
                    method: 'POST',
                    data: acHead
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            getAllACHead: function (acHead, pageSize) {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/ACHead/GetAll',
                    method: 'POST',
                    params: { 'pageSize': pageSize },
                    data: acHead
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            deleteACHead: function (id) {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/ACHead/Delete',
                    method: 'GET',
                    params: { 'id': id }
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            //AcHead
            saveACLedger: function (acLedger) {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/ACLedger/Save',
                    method: 'POST',
                    data: acLedger
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            getAllACLedger: function (acHead, pageSize) {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/ACLedger/GetAll',
                    method: 'POST',
                    params: { 'pageSize': pageSize },
                    data: acHead
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            deleteACLedger: function (id) {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/ACLedger/Delete',
                    method: 'GET',
                    params: { 'id': id }
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            //ACBankCashLedgerMap
            saveACBankCashLedgerMap: function (acBankCashLedgerMap) {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/ACBankCashLedgerMap/Save',
                    method: 'POST',
                    data: acBankCashLedgerMap
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            getAllACBankCashLedgerMap: function (acBankCashLedgerMap, pageSize) {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/ACBankCashLedgerMap/GetAll',
                    method: 'POST',
                    params: { 'pageSize': pageSize },
                    data: acBankCashLedgerMap
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            deleteACBankCashLedgerMap: function (id) {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/ACBankCashLedgerMap/Delete',
                    method: 'GET',
                    params: { 'id': id }
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            //ACBankCashLedgerMap
            saveACVoucher: function (acVoucher) {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/ACVoucher/Save',
                    method: 'POST',
                    data: acVoucher
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            getAllACVoucher: function (acVoucher, pageSize) {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/ACVoucher/GetAll',
                    method: 'POST',
                    params: { 'pageSize': pageSize },
                    data: acVoucher
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            deleteACVoucher: function (id) {
                var deferred = $q.defer();
                $http({
                    url: '/api/FMS/acVoucher/Delete',
                    method: 'GET',
                    params: { 'id': id }
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            }
        }
    }

})(angular.module('vehicleManagementSystem'))