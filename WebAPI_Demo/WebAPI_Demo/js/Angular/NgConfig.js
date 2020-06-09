var ConfigModule = angular.module('exampleApp.Configs', []);

ConfigModule.config(function(startTime) {
    console.log('Main module config: ' + startTime);
});