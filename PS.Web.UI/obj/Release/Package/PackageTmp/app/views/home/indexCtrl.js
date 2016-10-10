(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope'];

    function indexCtrl($scope) {
        $scope.messages = 'this is home page';
        $scope.home={};
        $scope.textChanged="";
       $scope.person ={};
        $scope.person.Name="write your name";

        $scope.ShowAlert = function(){
            alert($scope.home.name);
        }

        
         $scope.textChangedEvent = function(){
           $scope.textChanged = $scope.home.name;
        }

        $scope.edit = function(person){
            $scope.person = person;
        }

        $scope.data = [
        {
            ID:1,
            Name:"Kayser"
        },
        {
            ID:2,
            Name:"Rashed"
        },
        {
            ID:3,
            Name:"Mamun"
        }
        ]
    }
})(angular.module('vehicleManagementSystem'));