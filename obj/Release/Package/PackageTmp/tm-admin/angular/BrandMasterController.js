
var app = angular.module('BrandMasterApp', ['ngRoute', 'flow', 'ngAnimate', 'ngProgress']);
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
app.controller('BrandMasterController', function ($window, $scope, $rootScope, $http, DataService, fileUpload, $timeout, ngProgressFactory) {


    $scope.progressbar = ngProgressFactory.createInstance();

    $scope.color = 'firebrick';
    $scope.height = '5px';
    $scope.progressbar.start();

    $scope.successMessage = "";
    $scope.brand = [];
    //EditCategoty
    var DisplayBrand = function () {
        var data = $.param({
            type: "getbrand",
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/GetBrandMaster',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success.data);
            $scope.brand = success.data;
            $scope.progressbar.complete();
        }, function (error) {

        });
    };
    DisplayBrand();

    $scope.CategoryList_ID = "";
    $scope.OpenPopupFor_UploadSizeChartImage = function (cid) {


        $scope.CategoryList_ID = cid;
        //$window.alert($scope.Attr_RowId);
        //    $('.UploadSizeChartImage').trigger('click');
    }
    $scope.SUCCESS_MESSAGE = "";
    $scope.SaveBrand = function () {
        $scope.progressbar.start();
        var data = $.param({
            brandname: $scope.txtBrandName,
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/SaveBrand',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success);
            DataService.msg = success.data;
            DisplayBrand();
            //$scope.SUCCESS_MESSAGE = "Saved Successfully ";

            $(".notifications").attr("data-custommessage", "Saved Successfully");
            $('.notifications').trigger('click');
            $('.closemodal').trigger('click');


            /* Close with Interval
            setTimeout(function () {
                $('.closemodal').trigger('click');
            }, 10000);  */


        }, function (error) {

            alert('Failed To Save ! ');
            //$('.closemodal').trigger('click');
        });
        console.log($scope.successMessage);

    };
    $scope.EditCategory = function (ID, NAME, IMAGE) {
        $scope.categoryname = NAME;
        $scope.filename = IMAGE;
    };

    // for upload image
    $scope.imageStrings_update = [];
    $scope.processFilesForUpdateImage = function (files) {

        //     console.log(files);
        angular.forEach(files, function (flowFile, i) {
            var fileReader = new FileReader();
            fileReader.onload = function (event) {
                var uri = event.target.result;
                //  alert(uri);
                $scope.imageStrings_update[i] = uri;
            };
            //        console.log($scope.imageStrings);
            fileReader.readAsDataURL(flowFile.file);
        });
    };

    $scope.UpdateCategoryImage = function () {
        debugger;
        var data = $.param({
            id: $scope.CategoryList_ID,
            filename: $scope.imageStrings_update[0]
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/UpdateCategoryImage',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            debugger;
            console.log(success);
            DataService.msg = success.data;
            $('.notifications').trigger('click');
            DisplayCategory();
            $('.closemodal').trigger('click');
        }, function (error) {
            console.log(error);
        });
        console.log($scope.successMessage);
    };


    $scope.UpdateBrand = function (ID, NAME) {
        var data = $.param({
            id: ID,
            brandname: NAME
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/UpdateBrand',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success);
            DataService.msg = success.data;
            $(".notifications").attr("data-custommessage", "Updated Successfully");            
            $('.notifications').trigger('click');
            DisplayBrand();

        }, function (error) {
            console.log(error);
        });
        console.log($scope.successMessage);
    };


    $scope.DeleteBrand = function (ID) {
        $scope.progressbar.start();
        var data = $.param({
            id: ID
        });

        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/DeleteBrand',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success);
            DataService.msg = success.data;

            $(".notifications").attr("data-custommessage", "Deleted Successfully");            

            $('.notifications').trigger('click');
            DisplayBrand();
        }, function (error) {
            console.log(error);
        });
        console.log($scope.successMessage);
    };

    $scope.CancelBrand = function () {
        DisplayBrand();
    };
});