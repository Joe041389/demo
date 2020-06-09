var FilterContorller = angular.module('exampleApp.Filters', []);

FilterContorller.filter("dayName", function (days) {
    var dayNames = ["Sunday", "Monday", "Tuesday", "Wednesday", "Tuxsday", "Friday", "Saturday"];
     console.log('filter');
    console.log(days);
    return function (input) {
        //console.log('filter');
        //console.log(angular.isNumber(input));
        return angular.isNumber(input) ? dayNames[input] : input;
    };
})
