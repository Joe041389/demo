var ControllerModulle = angular.module('exampleApp.Controllers', []);

ControllerModulle.controller('dayCtrl', function ($scope, days) {

    $scope.day = days.today;

});

ControllerModulle.controller('tomorrowCtrl', function ($scope, days) {

    $scope.day = days.tomorrow;

})

ControllerModulle.controller('listCtrl', function ($scope) {
    $scope.todos = ObjTodos;

})