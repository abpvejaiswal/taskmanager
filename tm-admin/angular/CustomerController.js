
var app = angular.module('CustomerApp', ['ngRoute', 'flow', 'ngAnimate', 'ngProgress']);
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


// Customer
app.controller('CustomerController', function ($scope, $http, $window, MyService, $timeout, ngProgressFactory) {

    $scope.progressbar = ngProgressFactory.createInstance();
    $scope.color = 'firebrick';
    $scope.height = '5px';
    $scope.progressbar.start();
    $scope.VenderOrCustomer = '';
    $scope.Type = 0;
    $scope.customerlist = [];
    // Get Attribute Master
    var GetCustomer = function () {
        var data = $.param({
            type: "Customer",
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/GetCustomer',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            $scope.customerlist = success.data;
            console.log('customerlist Master ');
            console.log($scope.customerlist);
            $scope.progressbar.complete();
        }, function (error) {
            console.log(error);
            window.alert('Failed To Load');
        });
    };
    GetCustomer();

    //Delete Prdocut

    $scope.DeleteCustomer = function (ID) {
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
            url: '/AdminOperation.asmx/DeleteCustomer',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success);
            $('.deletenotifications').trigger('click');
            GetCustomer();

        }, function (error) {
            console.log(error);
            window.alert('Failed To Load');
        });
    };

    $scope.MakeitVender = function (ID, Type) {
        $scope.progressbar.start();
        var data = $.param({
            id: ID,
            Type: Type
        });

        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        //if ($window.confirm("Are You Sure Want To Delete ?")) {

        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/MakeitVender',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success);
            $('.notifications').trigger('click');
            GetCustomer();

        }, function (error) {
            console.log(error);
            window.alert('Failed To Load');
        });
    };
    $scope.ChangeStatus = function (ID, Status) {
        $scope.progressbar.start();
        var data = $.param({
            id: ID,
            Status: Status
        });

        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        //if ($window.confirm("Are You Sure Want To Delete ?")) {

        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/ChangeStatus',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success);
            $('.notifications').trigger('click');
            GetCustomer();

        }, function (error) {
            console.log(error);
            window.alert('Failed To Load');
        });
    };


    //}


});
