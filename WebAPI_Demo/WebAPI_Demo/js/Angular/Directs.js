var DirectiveController = angular.module('exampleApp.Directives', []);

DirectiveController.directive('highlight', function ($filter) {

    
    var dayFilter = $filter('dayName');
    console.log('highlight');
    return function (scope,element,attrs) {
        if (dayFilter(scope.day) == attrs['highlight']) {
            element.css('color', 'red');
        }
    }
});