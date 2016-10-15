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
            //Contacts
            saveContact: function (contact) {
                var deferred = $q.defer();
                $http({
                    url: '/api/VMS/HREmployee/Save',
                    method: 'POST',
                    data: contact
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            getAllContacts: function (contact, pageSize) {
                var deferred = $q.defer();
                $http({
                    url: '/api/VMS/HREmployee/GetAll',
                    method: 'POST',
                    params: { 'pageSize': pageSize },
                    data: contact
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            },
            deleteContact: function (contact) {
                var deferred = $q.defer();
                $http({
                    url: '/api/VMS/HREmployee/Delete',
                    method: 'POST',
                    data: contact
                }).success(deferred.resolve).error(deferred.reject);
                return deferred.promise;
            }

        }
    }

})(angular.module('vehicleManagementSystem'))