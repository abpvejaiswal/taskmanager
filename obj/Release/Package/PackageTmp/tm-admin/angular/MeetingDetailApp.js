
var app = angular.module('MeetingDetailApp', ['ngRoute']);
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

/// Category Controller
app.controller('MeetingDetailController', function ($window, $scope, $rootScope, $http) {
    //  alert();
    $scope.meetingdata = [];
    //EditCategoty
    $scope.GetMeetingDataByDate = function () {
      //  alert($("#txtfromdate").val());
        var data = $.param({
            type: "fromdatetodate",
            from_date: $("#txtfromdate").val(),
            to_date: $("#txttodate").val()
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/fromdatetodate.asmx/GetMeetingDataByDate',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success.data);
            debugger;
            $scope.meetingdata = success.data;
        }, function (error) {

        });
    };

});
