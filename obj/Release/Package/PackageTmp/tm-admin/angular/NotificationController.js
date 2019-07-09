
//var app = angular.module('NotificationApp', ['ngRoute', 'flow', 'ngAnimate', 'ngProgress', 'ngTagsInput', 'datatables']);
app.filter('split', function () {
    return function (input, splitChar, splitIndex) {
        // do some bounds checking here to ensure it has that index
        return input.split(splitChar)[splitIndex];
    }
});




// Order Master
app.controller('NotificationController', function ($scope, $http, $window, ngProgressFactory) {

    //$scope.ADD_TASK.REPEAT_WEEK_ON = {};
    $scope.progressbar = ngProgressFactory.createInstance();
    $scope.color = 'firebrick';
    $scope.height = '5px';
    // $scope.progressbar.start();

    $scope.notificationlist = [];
    $scope.GetDashboardNotification = function () {
        var data = $.param({
            type: "get_notification"
        });

        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/GetDashboardNotification',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success.data);
            $scope.notificationlist = success.data.NOTIFICATION_DATA;
        }, function (error) {
            console.log(error);
            $window.alert('Failed To get notification! ');

        });
    }
    $scope.GetDashboardNotification();


    $scope.RemoveNotification = function (noti) {
        $scope.progressbar.start();
        var data = $.param({
            type: "delete_notification",
            NOTIFICATION_ID: noti.ID
        });
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/RemoveNotification',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success.data);            
            
            if (success.data.ERROR_STATUS == true) {
                alert(success.data.MESSAGE);
            }
            $scope.GetDashboardNotification();
           // $scope.$apply();
            $scope.progressbar.complete();
        }, function (error) {
            console.log(error);
            $window.alert('Failed To delete ! ');
            $scope.progressbar.complete();
        });
    }

    $scope.RemoveAllNotification = function (noti) {
        $scope.progressbar.start();
        var data = $.param({
            type: "delete_all"            
        });
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/RemoveAllNotification',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success.data);

            if (success.data.ERROR_STATUS == true) {
                alert(success.data.MESSAGE);
            }
            $scope.GetDashboardNotification();
            // $scope.$apply();
            $scope.progressbar.complete();
        }, function (error) {
            console.log(error);
            $window.alert('Failed To delete ! ');
            $scope.progressbar.complete();
        });
    }
    
    $scope.DeleteSeletedTask = function () {
        var delete_val = "";
        $('.checkbox_grid:checked').each(function (i) {
            delete_val = delete_val + $(this).val() + ",";
        });
        //alert(delete_val);
        $scope.progressbar.start();
        var data = $.param({
            type: "delete_task",
            DELETE_TASK_IDS: delete_val
        });
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/DeleteSeletedTask',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success.data);
            alert(success.data.MESSAGE);
            $scope.GetMyTask();
            $scope.$apply();
        }, function (error) {
            console.log(error);
            $window.alert('Failed To delete ! ');
            $scope.progressbar.complete();
        });

        alert(val);
    }



});
