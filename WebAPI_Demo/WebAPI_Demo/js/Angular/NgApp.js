var ObjTodos = [
    { action: 'Get groceries', complete: false },
    { action: 'Call plumber', complete: false },
    { action: 'Buy running plumber', complete: true },
    { action: 'Buy flowers', complete: false },
    { action: 'Call family', complete: false }
]

var myApp = angular.module("exampleApp", [
    'exampleApp.Controllers',
    'exampleApp.Directives',
    'exampleApp.Filters',
    'exampleApp.Services',
    'exampleApp.Constants',
    'exampleApp.Configs',
    'exampleApp.Runs'
]);