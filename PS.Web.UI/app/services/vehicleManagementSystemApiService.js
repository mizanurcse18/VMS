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

    app.factory('vehicleManagementSystemApiService', vehicleManagementSystemApiService);

    vehicleManagementSystemApiService.$inject = ['$http', '$q'];

    function vehicleManagementSystemApiService($http, $q) {
        return {
            //HREmployee
            saveHREmployee: function (contact) {
                var deferred = $q.defer();
                $http({
                    url: '/api/VMS/HREmployee/Save',
                    method: 'POST',
                    data: contact
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            getAllHREmployee: function (contact, pageSize, currentPage) {
                var deferred = $q.defer();
                $http({
                    url: '/api/VMS/HREmployee/GetAll',
                    method: 'POST',
                    params: { 'pageSize': pageSize, 'currentPage': currentPage },
                    data: contact
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            hasHREmployee: function (obj) {
                var deferred = $q.defer();
                $http({
                    url: '/api/VMS/HREmployee/HasHREmployee',
                    method: 'POST',
                    data: obj
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            deleteHREmployee: function (obj) {
                var deferred = $q.defer();
                $http({
                    url: '/api/VMS/HREmployee/Delete',
                    method: 'POST',
                    data: obj
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            }

        }
    }

})(angular.module('vehicleManagementSystem'))