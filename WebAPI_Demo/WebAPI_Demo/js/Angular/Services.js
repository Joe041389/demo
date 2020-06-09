var ServiceController = angular.module('exampleApp.Services', []);

ServiceController.service('days', function () {
    this.today = (new Date().getDay()) % 7;
    this.tomorrow = (this.today + 1) % 7;


}).config(function () {
    console.log("Service config ");
}).run(function (startTime) {
    console.log("Service run " + startTime);
});
