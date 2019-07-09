
var app = angular.module('CategoryApp', ['ngRoute', 'flow', 'ngAnimate', 'ngProgress', 'ngTagsInput', 'datatables']);
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
app.controller('CategoryController', function ($window, $scope, $rootScope, $http, DataService, fileUpload, $timeout, ngProgressFactory) {

    $scope.selFilterCategory = '0';
    $scope.progressbar = ngProgressFactory.createInstance();

    $scope.color = 'firebrick';
    $scope.height = '5px';
    $scope.progressbar.start();

    //$timeout(function () {
    //    $scope.progressbar.complete();
    //  //  $scope.show = true;
    //}, 2000);
    //$scope.contained_progressbar = ngProgressFactory.createInstance();
    //$scope.contained_progressbar.setParent(document.getElementById('categorypage'));
    //$scope.contained_progressbar.setAbsolute();
    //$scope.contained_progressbar.start();


    // for upload image
    $scope.imageStrings = [];
    $scope.processFiles = function (files) {

        //     console.log(files);
        angular.forEach(files, function (flowFile, i) {
            var fileReader = new FileReader();
            fileReader.onload = function (event) {
                var uri = event.target.result;
                //  alert(uri);
                $scope.imageStrings[i] = uri;
            };
            //        console.log($scope.imageStrings);
            fileReader.readAsDataURL(flowFile.file);
        });
    };

    $scope.successMessage = "";
    $scope.category = [];
    //EditCategoty
    var DisplayCategory = function () {

        var data = $.param({
            type: "CategoryMaster",
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/GetCategoryMaster',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success.data);
            $scope.category = success.data;
            $scope.progressbar.complete();
        }, function (error) {

        });
    };
    DisplayCategory();
    $scope.CategoryList_ID = "";
    $scope.OpenPopupFor_UploadSizeChartImage = function (cid) {


        $scope.CategoryList_ID = cid;
        //$window.alert($scope.Attr_RowId);
        //    $('.UploadSizeChartImage').trigger('click');
    }

    $scope.cat = { NAME: '', PARENT_ID: '0', IMAGE_NAME: '', SHOW_ON_HOME_PAGE: false, INCLUDE_IN_TOP_MENUS: true, DISPLAY_ORDER: '1', STATUS: true, SHOP_BY_CATEGORY: false };

    $scope.filter = { SHOW_ON_HOME_PAGE: false, INCLUDE_IN_TOP_MENUS: true, SHOP_BY_CATEGORY: false };

    $scope.shop_by_category = function (item) {
        //var result = ($scope.filter.INCLUDE_IN_TOP_MENUS == item.INCLUDE_IN_TOP_MENUS) ||
        //             ($scope.filter.SHOW_ON_HOME_PAGE == item.SHOW_ON_HOME_PAGE) ||
        //             ($scope.filter.SHOP_BY_CATEGORY == item.SHOP_BY_CATEGORY);
        var result = ($scope.filter.SHOP_BY_CATEGORY == item.SHOP_BY_CATEGORY);
        return result;
    };

    $scope.show_on_home_page = function (item) {
        //var result = ($scope.filter.INCLUDE_IN_TOP_MENUS == item.INCLUDE_IN_TOP_MENUS) ||
        //             ($scope.filter.SHOW_ON_HOME_PAGE == item.SHOW_ON_HOME_PAGE) ||
        //             ($scope.filter.SHOP_BY_CATEGORY == item.SHOP_BY_CATEGORY);
        var result = ($scope.filter.SHOW_ON_HOME_PAGE == item.SHOW_ON_HOME_PAGE);
        return result;
    };

    $scope.SaveCategory = function (cat) {
        $scope.progressbar.start();
        debugger;

        var data = $.param({
            categoryname: cat.NAME,
            parentid: cat.PARENT_ID,
            filename: $scope.imageStrings[0],
            DisplayInTopMenu: cat.INCLUDE_IN_TOP_MENUS,
            ShowOnHomePage: cat.SHOW_ON_HOME_PAGE,
            DisplayOrder: cat.DISPLAY_ORDER,
            Status: cat.STATUS,
            SHOP_BY_CATEGORY: cat.SHOP_BY_CATEGORY

        });

        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/SaveCategory',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success);
            DataService.msg = success.data;
            DisplayCategory();
            $('.notifications').trigger('click');
            $('.closemodal').trigger('click');


            /* Close with Interval
            setTimeout(function () {
                $('.closemodal').trigger('click');
            }, 10000);  */


        }, function (error) {
            debugger;
            //$('.closemodal').trigger('click');
        });

        console.log($scope.successMessage);

    };

    $scope.editc = false;
    $scope.EditCategory = function (category) {
        $('.modalDefault1').trigger('click');
        console.log(category);
        $scope.editc = true;
        // $scope.$apply();
        //$scope.cat.NAME = category.NAME;
        //$scope.cat.PARENT_ID = category.PARENT_ID;
        //$scope.cat.SHOW_ON_HOME_PAGE = category.SHOW_ON_HOME_PAGE;
        //$scope.cat.INCLUDE_IN_TOP_MENUS = category.INCLUDE_IN_TOP_MENUS;
        //$scope.cat.DISPLAY_ORDER = category.DISPLAY_ORDER;
        //$scope.cat.STATUS = category.STATUS;

        //'', PARENT_ID: '0', IMAGE_NAME: '', SHOW_ON_HOME_PAGE: '0', INCLUDE_IN_TOP_MENUS: '1', DISPLAY_ORDER: '1', STATUS: '1' };

        $scope.cat = category;

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


    $scope.UpdateCategory = function (cat) {
        debugger;
        console.log('category');
        console.log(cat);

        var data = $.param({
            ID: cat.ID,
            categoryname: cat.NAME,
            parentid: cat.PARENT_ID,
            DisplayInTopMenu: cat.INCLUDE_IN_TOP_MENUS,
            ShowOnHomePage: cat.SHOW_ON_HOME_PAGE,
            DisplayOrder: cat.DISPLAY_ORDER,
            Status: cat.STATUS,
            SHOP_BY_CATEGORY: cat.SHOP_BY_CATEGORY
        });

        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/UpdateCategory',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success);
            DataService.msg = success.data;
            $('.notifications').trigger('click');
            $('.closemodal').trigger('click');
            DisplayCategory();

        }, function (error) {
            console.log(error);
        });
        console.log($scope.successMessage);
    };


    $scope.DeleteCategory = function (ID) {
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
            url: '/AdminOperation.asmx/DeleteCategory',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success);
            DataService.msg = success.data;
            $('.notifications').trigger('click');
            DisplayCategory();

        }, function (error) {
            console.log(error);
        });
        console.log($scope.successMessage);
    };


    $scope.CancelCategory = function () {
        alert(ID);
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
            url: '/AdminOperation.asmx/DeleteCategory',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success);
            DataService.msg = success.data;
            $('.notifications').trigger('click');

        }, function (error) {
            console.log(error);
        });
        console.log($scope.successMessage);
    };

    // File Upload
    //$scope.uploadFile = function () {
    //    var file = $scope.myFile;

    //    console.log('file is ');
    //    console.dir(file);
    //    debugger;
    //    var uploadUrl = "http://localhost:25204/AdminOperation.asmx/Upload";
    //    fileUpload.uploadFileToUrl(file, uploadUrl);
    //};


    $scope.uploadFile = function () {
        var file = $scope.myFile;
        console.log(file);
        var uploadUrl = "/AdminOperation.asmx/Upload", //Url of webservice/api/server
            promise = fileUpload.uploadFileToUrl(file, uploadUrl);
        promise.then(function (response) {
            $scope.serverResponse = response;
        }, function () {
            $scope.serverResponse = 'An error has occurred';
        })
    };
    $scope.successMessage = DataService.msg;


    $scope.changedSortingValue = function (SortValue) {
        $scope.SortingVariable = SortValue
        // alert($scope.SortingVariable);
    }
});
