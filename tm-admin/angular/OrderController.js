
var app = angular.module('OrderApp', ['ngRoute', 'flow', 'ngAnimate', 'ngProgress', 'ngTagsInput']);
app.service('DataService', function () {
    this.msg = null;
});
app.filter('split', function () {
    return function (input, splitChar, splitIndex) {
        // do some bounds checking here to ensure it has that index
        return input.split(splitChar)[splitIndex];
    }
});
app.service("MyService", function ($http) {
    this.getBook = function (bookId) {
        var response = $http({
            method: "post",
            url: "Edit/GetBookById",
            params: {
                id: JSON.stringify(bookId)
            }
        });
        return response;
    }

});

app.directive('ngFiles', ['$parse', function ($parse) {
    // debugger;
    function fn_link(scope, element, attrs) {
        var onChange = $parse(attrs.ngFiles);
        element.on('change', function (event) {
            //  debugger;
            onChange(scope, { $files: event.target.files });
        });
    };
    return {
        link: fn_link
    }
}]);


app.directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;

            element.bind('change', function () {
                scope.$apply(function () {
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
}]);
app.directive('ngConfirmClick', [
function () {
    return {
        link: function (scope, element, attr) {
            var msg = attr.ngConfirmClick || "Are you sure?";
            var clickAction = attr.confirmedClick;
            element.bind('click', function (event) {
                if (window.confirm(msg)) {
                    scope.$eval(clickAction)
                }
            });
        }
    };
}]);

app.service('fileUpload', ['$http', function ($http) {
    this.uploadFileToUrl = function (file, uploadUrl) {
        debugger;
        var fd = new FormData();
        fd.append('file', file);
        //alert();
        debugger;
        console.log(fd);
        $http.post(uploadUrl, fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .success(function () {
        })

        .error(function () {
        });
    }
}]);
// Order Master
app.controller('OrderController', function ($scope, $http, $window, MyService, ngProgressFactory, $timeout) {

    $scope.progressbar = ngProgressFactory.createInstance();
    $scope.color = 'firebrick';
    $scope.height = '5px';
    $scope.progressbar.start();

    //      $scope.progressbar.start();
    $scope.VenderOrCustomer = '';
    $scope.Type = 0;
    $scope.ordermasterlist = [];
    // Get ORder Master
    var GetOrderMaster = function () {
        var data = $.param({
            type: "ordermaster",
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/GetOrderMaster',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            $scope.ordermasterlist = success.data;
            console.log('ordermasterlist ');
            console.log($scope.ordermasterlist);
            $scope.progressbar.complete();
        }, function (error) {
            console.log(error);
            window.alert('Failed To Load');
        });
    };
    GetOrderMaster();

    //Delete Prdocut

    $scope.DeleteOrderMaster = function (ID) {
        $scope.progressbar.start();
        var data = $.param({
            id: ID
        });

        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        //if ($window.confirm("Are You Sure Want To Delete ?")) {

        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/DeleteOrderMaster',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success);
            $('.deletenotifications').trigger('click');
            GetOrderMaster();

        }, function (error) {
            console.log(error);
            window.alert('Failed To Load');
        });
    };




});
