var app = angular.module('Homeapp', []);

app.controller('HomeController', function ($scope,$http) {
    $scope.BtnText = "讀取雲端資料";
    $scope.LoadData = function () {
        $scope.BtnText = "資料讀取中....";
        let GetUrl = "https://opendata.cwb.gov.tw/api/v1/rest/datastore/O-A0005-001?Authorization=CWB-3C826B8A-89CC-4AE3-89A4-803732D1B75A&format=JSON";
        $http.get(GetUrl).then(function (d) {
            $scope.datalist = d.data.records.weatherElement.location;
            console.log(d.data.records.weatherElement.elementName);
            $scope.decription = d.data.records.weatherElement.elementName;
            $scope.dt = d.data.records.weatherElement.time.dataTime;
            $scope.BtnText = "讀取雲端資料";
        });

       
    };


});