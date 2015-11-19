(function () {
    //create angularjs controller
    var app = angular.module('app', []);//set and get the angular module
    app.controller('boardGameController', ['$scope', '$http', boardGameController]);

    //angularjs controller method
    function boardGameController($scope, $http) {

        //declare variable for mainain ajax load and entry or edit mode
        $scope.loading = true;
        $scope.addMode = false;

        //get all customer information
        $http.get('/api/BoardGames/').success(function (data) {
            $scope.boardGames = data;
            $scope.loading = false;
        })
        .error(function () {
            $scope.error = "Oops... something went wrong";
            $scope.loading = false;
        });

        //by pressing toggleEdit button ng-click in html, this method will be hit
        $scope.toggleEdit = function () {
            this.boardGame.editMode = !this.boardGame.editMode;
        };

        //by pressing toggleAdd button ng-click in html, this method will be hit
        $scope.toggleAdd = function () {
            $scope.addMode = !$scope.addMode;
        };

        //Insert BoardGame
        $scope.add = function () {
            $scope.loading = true;
            $http.post('/api/BoardGames/', this.newboardGame).success(function (data) {
                alert("You have a new Board Game!!!");
                $scope.addMode = false;
                $scope.boardGames.push(data);
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "Oops... something went wrong :( " + data;
                $scope.loading = false;
            });
        };

        //Edit BoardGame
        $scope.save = function () {
            //alert("Edit");
            $scope.loading = true;
            var edboardGame = this.boardGame;
            //alert(frien);
            $http.put('/api/BoardGames/' + edboardGame.Id, edboardGame).success(function (data) {
                alert("Saved Successfully!!!");
                edboardGame.editMode = false;
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "Oops... something went wrong :( " + data;
                $scope.loading = false;
            });
        };

        //Delete BoardGame
        $scope.deleteBoardGame = function () {
            $scope.loading = true;
            var Id = this.boardGame.Id;
            $http.delete('/api/BoardGames/' + Id).success(function (data) {
                alert("You have one less Board Game in your Collection.");
                $.each($scope.boardGames, function (i) {
                    if ($scope.boardGames[i].Id === Id) {
                        $scope.boardGames.splice(i, 1);
                        return false;
                    }
                });
                $scope.loading = false;
            }).error(function (data) {
                $scope.error = "Oops... something went wrong :( " + data;
                $scope.loading = false;
            });
        };
    }
})();    