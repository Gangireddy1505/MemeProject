/// <reference path="~/Scripts/angular.js" />
/// <reference path="~/Scripts/Module.js" />

app.service('crudService', function ($http) {


    //Create new meme
    this.post = function (Meme) {
        var request = $http({
            method: "post",
            url: "/api/Meme",
            data: Meme
        });
        return request;
    }
    //Get Single Records
    this.get = function (Id) {
        return $http.get("/api/Meme/" + Id);
    }

    //Get All Employees
    this.getMemes = function () {
        return $http.get("/api/Meme");
    }


    //Update the Record
    this.put = function (Id, Meme) {
        var request = $http({
            method: "put",
            url: "/api/Meme/" + Id,
            data: Meme
        });
        return request;
    }
    //Delete the Record
    this.delete = function (Id) {
        var request = $http({
            method: "delete",
            url: "/api/Meme/" + Id
        });
        return request;
    }
});