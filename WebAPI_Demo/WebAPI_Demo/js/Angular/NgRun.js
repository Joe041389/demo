var RunModule = angular.module('exampleApp.Runs', []);

RunModule.run(function (startTime) {
    console.log('Main module run: ' + startTime);
});
