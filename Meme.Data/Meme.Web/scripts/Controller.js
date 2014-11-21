/// <reference path="~/Scripts/angular.js" />
/// <reference path="~/Scripts/Module.js" />


app.controller('crudController', function ($scope, crudService) {

    $scope.IsNewRecord = 1; //The flag for the new record

    loadRecords();

    //Function to load all Employee records
    function loadRecords() {
        var promiseGet = crudService.getMemes();

        promiseGet.then(function (pl) { $scope.Meme = pl.data },
              function (errorPl) {
                  $log.error('failure loading Meme', errorPl);
              });
    }

    //The Save scope method use to define the Employee object.
    //In this method if IsNewRecord is not zero then Update Employee else
    //Create the Employee information to the server
    $scope.save = function () {
        var Meme = {
            Id: $scope.Id,
            Title: $scope.Title,
            ImageUrl: $scope.ImageUrl,
            Description: $scope.Description,
            Genre: $scope.Genre
        };
        //If the flag is 1 the it si new record
        if ($scope.IsNewRecord === 1) {
            var promisePost = crudService.post(Meme);
            promisePost.then(function (pl) {
                $scope.Id = pl.data.Id;
                loadRecords();
            }, function (err) {
                console.log("Err" + err);
            });
        } else { //Else Edit the record
            var promisePut = crudService.put($scope.Id, Meme);
            promisePut.then(function (pl) {
                $scope.Message = "Updated Successfuly";
                loadRecords();
            }, function (err) {
                console.log("Err" + err);
            });
        }



    };

    //Method to Delete
    $scope.delete = function () {
        var promiseDelete = crudService.delete($scope.Id);
        promiseDelete.then(function (pl) {
            $scope.Message = "Deleted Successfuly";
            $scope.Id = 0;
            $scope.Title = "";
            $scope.ImageUrl = "";
            $scope.Description = "";
            $scope.Genre = "";
            loadRecords();
        }, function (err) {
            console.log("Err" + err);
        });
    }

    //Method to Get Single Employee based on EmpNo
    $scope.get = function (Meme) {
        var promiseGetSingle = crudService.get(Meme.Id);

        promiseGetSingle.then(function (pl) {
            var res = pl.data;
            $scope.Id = res.Id;
            $scope.Title = res.Title;
            $scope.ImageUrl = res.ImageUrl;
            $scope.Description = res.Description;
            $scope.Genre = res.Genre;

            $scope.IsNewRecord = 0;
        },
                  function (errorPl) {
                      console.log('failure loading Employee', errorPl);
                  });
    }
    //Clear the Scopr models
    $scope.clear = function () {
        $scope.IsNewRecord = 1;
        $scope.Id = 0;
        $scope.Title = "";
        $scope.ImageUrl = "";
        $scope.Description = "";
        $scope.Genre = "";
    }
});