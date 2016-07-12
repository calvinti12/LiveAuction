/// <reference path="../Scripts/angular.js" />

var app = angular.module("mainModule", ["ngRoute"]);

app.controller("mainController", function ($scope) {
    $scope.msg = "working";
});

app.config(function ($routeProvider) {
    $routeProvider
    .when("#/TCAG/index", {
        templateUrl: "../index.aspx"

    })
     .when("#/TCAG/bid-detail", {
         templateUrl: "../bid-detail.aspx"

     })
    .when("/TCAG/index", {
        template: "../Default.aspx"
    })
    .otherwise({
        templateUrl: "/"
    });
});