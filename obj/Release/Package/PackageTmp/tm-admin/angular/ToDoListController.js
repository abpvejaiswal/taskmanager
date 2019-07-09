
var app = angular.module('ToDoListApp', ['ngRoute', 'flow', 'ngAnimate', 'ngProgress', 'ngTagsInput', 'datatables']);
app.filter('split', function () {
    return function (input, splitChar, splitIndex) {
        // do some bounds checking here to ensure it has that index
        return input.split(splitChar)[splitIndex];
    }
});


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

// Order Master
app.controller('ToDoListController', function ($scope, $http, $window, ngProgressFactory, $filter) {

    $scope.ADD_TASK = { ASSIGN_TO: '0', SUBJECT: '', START_DATE: '', CONTACT_PERSON: '0', CONTACT_NUMBER: '', CONTACT_EMAIL_ID: '', TARGETED_DAYS: '',FINANCIAL_YEAR:'0', ASSESSMENT_YEAR: '', DUE_DATE: '', STATUS: 'Not Started', PRIORITY: 'High', IS_REPEAT: false, REPEAT_TYPE: 'None', REPEAT_FOR_EVERYDAY: '1', REPEAT_FOR_EVERYWEEK: '1', IS_ON_DAYWISE: true, MONTH_DAYS_NO: '1', MONTH_DAY_NO: '1', MONTH_WEEK_SEQUENCE_TYPE: 'First', MONTH_WEEKSEQUENCE_DAY: 'Sunday', MONTH_WEEKSEQUENCE_MONTH_NO: '1', DESCRIPTION: '', IS_EVERY_DAY: true, REPEAT_WEEK_ON: '', IS_YEARLY_DAYS_ON: false, YEARLY_DAYS_OF_MONTH: '1', YEARLY_DAYS_NO: '1', YEARLY_WEEKSEQUENCE_TYPE: 'First', YEARLY_WEEKSEQUENCE_NO: 'Sunday', YEARLY_WEEKSEQUENCE_MONTH_NAME: '1', REMINDER_DAY_BEFORE: '' };
    //$scope.ADD_TASK.REPEAT_WEEK_ON = {};
    $scope.progressbar = ngProgressFactory.createInstance();
    $scope.color = 'firebrick';
    $scope.height = '5px';
    // $scope.progressbar.start();

    //Fill the contact number and contact email id by contact number
    $scope.ChangeContactPerson  = function () {
        var number_email = $(".CONTACT_PERSON").val().split(',');        
        debugger;
        console.log(number_email);
        $scope.ADD_TASK.CONTACT_NUMBER = number_email[0];
        $scope.ADD_TASK.CONTACT_EMAIL_ID = number_email[1];
        $(".myfg").addClass("fg-toggled");
    }

    $scope.ChangeYear = function (financial_year) {
        $scope.ADD_TASK.ASSESSMENT_YEAR = financial_year;
    }
    //Fill the targeted days of work finish
    $scope.GetTargetedDays = function (targeted_days) {
        var wr = $("#START_DATE").val();
        $scope.mydate = new Date(wr);        
        debugger
        $scope.mydate.setDate($scope.mydate.getDate() + parseInt(targeted_days));
        $scope.ddMMyyyy = $filter('date')($scope.mydate, 'yyyy-MM-dd');
        $("#DUE_DATE").val($scope.ddMMyyyy);
        $(".fg-targeted").addClass("fg-toggled");
  
    }

    $scope.btnsubmit = false;
    $(".btnsubmit").text("Submit");

    $scope.AddTask = function (ADD_TASK) {

        var start_date = $("#START_DATE").val();
        var due_date = $("#DUE_DATE").val();

        //START_DATE: $("#START_DATE").val(),
        //DUE_DATE: $("#DUE_DATE").val(),
        debugger;
        var emp_id = $(".ddlEmployee").val();
        if (ADD_TASK.SUBJECT == '' || emp_id == '0' || start_date == '' || due_date == '' || ADD_TASK.TARGETED_DAYS == '' || ADD_TASK.CONTACT_PERSON == '0' || ADD_TASK.CONTACT_NUMBER == '' || ADD_TASK.CONTACT_EMAIL_ID == '' ) {
            alert('Please Fill compulsory fields ! ');
            return;
        }

        $scope.progressbar.start();
        var lb = $('#REPEAT_WEEK_ON option:selected');
        console.log(lb);

        var cat_id = "";
        var cat_name = "";
        if (lb.length > 0) {
            for (var i = 0; i < lb.length; i++) {
                cat_id = cat_id + lb[i].value + ",";
                cat_name = cat_name + lb[i].text + ",";
            }
        }
        else {
            //$window.alert('Please Select Atleast One Category ! ');            
            //    return;
        }
        $scope.btnsubmit = true;
        $(".btnsubmit").html('<img src="/tm-admin/img/Rolling.gif" />');
            
        debugger;
        $scope.ADD_TASK.REPEAT_WEEK_ON = cat_name;
        var data = $.param({
            type: "add_task",
            Data: JSON.stringify(ADD_TASK),
            START_DATE: $("#START_DATE").val(),
            DUE_DATE: $("#DUE_DATE").val(),
            ASSIGN_TO: $(".ddlEmployee").val(),
            REPEAT_TYPE: $(".REPEAT_TYPE").val(),
            CLIENT_GROUP: $(".CLIENT_GROUP :selected").text(),
            NATURE_OF_WORK: $(".NATURE_OF_WORK :selected").text(),
            FINANCIAL_YEAR: $('.FINANCIAL_YEAR :selected').text(),
            CONTACT_PERSON: $('.CONTACT_PERSON :selected').text()
        });

        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/AddTask',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            if (success.data.ERROR_STATUS == false) {
                alert('Task Created Successfully !');
                location.reload();
            }
            else
                alert('Failed to save !');

            $scope.btnsubmit = false;
            $(".btnsubmit").text("Submit");

            $scope.progressbar.complete();
        }, function (error) {
            console.log(error);
            $window.alert('Failed To save ! ');
            $scope.progressbar.complete();
            $scope.btnsubmit = false;
            $(".btnsubmit").text("Submit");
        });
    }


    $scope.tasklist = [];
    $scope.FilterOption = "todays+overdue";
    $scope.GetMyTask = function () {
        $scope.progressbar.start();
        var data = $.param({
            type: "get_mytask",
            DropdownValue: $scope.FilterOption,
            FROM_DATE: $("#FROM_DATE").val(),
            TO_DATE: $("#TO_DATE").val()
        });

        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/GetMyTask',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success.data);
            $scope.tasklist = success.data.TASK_DATA;
            $scope.progressbar.complete();
        }, function (error) {
            console.log(error);
            $window.alert('Failed To gwet ! ');
            $scope.progressbar.complete();
        });
    }
    $scope.GetMyTask();


    $scope.alltasklist = [];
    $scope.GetAllTask = function () {
        $scope.progressbar.start();
        var data = $.param({
            type: "get_alltask",
            DropdownValue: $scope.FilterOption,
            FROM_DATE: $("#FROM_DATE").val(),
            TO_DATE: $("#TO_DATE").val()
        });

        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/GetAllTask',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success.data);
            $scope.alltasklist = success.data.TASK_DATA;
            $scope.progressbar.complete();
        }, function (error) {
            console.log(error);
            $window.alert('Failed To get ! ');
            $scope.progressbar.complete();
        });
    }
    $scope.GetAllTask();

    $scope.DeleteTask = function (ID,page) {
        $scope.progressbar.start();
        var data = $.param({
            type: "delete_task",
            TASK_ID: ID
        });
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/DeleteTask',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success.data);
            alert(success.data.MESSAGE);
            if (page == 'alltask') {
                $scope.GetAllTask();
            } else {
                $scope.GetMyTask();
            }
            $scope.$apply();
            // $scope.progressbar.complete();

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
            debugger;
            console.log(success.data);
            alert(success.data.MESSAGE);
            $scope.progressbar.complete();
            location.reload();
            //$scope.GetMyTask();
            //$scope.$apply();
        }, function (error) {
            console.log(error);
            $window.alert('Failed To delete ! ');
            $scope.progressbar.complete();
        });

    }

    $scope.UpdateTask = function (TASK_DETAIL, IS_CLOSED) {
        debugger;
        $scope.progressbar.start();
        var data = $.param({
            type: "close_task",
            NOTES: TASK_DETAIL.NOTES,
            DESCRIPTION: TASK_DETAIL.DESCRIPTION,
            STATUS: TASK_DETAIL.STATUS,
            TASK_ID: TASK_DETAIL.ID,
            IS_CLOSED: IS_CLOSED,
            SUBJECT: TASK_DETAIL.SUBJECT,
            TASK_OWNER_ID: TASK_DETAIL.TASK_OWNER_ID,            
            ACTUAL_WORK_FINISH_DATE: $("#ACTUAL_WORK_FINISH_DATE").val(),
            ACTUAL_DAYS_TAKEN: $("#ACTUAL_DAYS_TAKEN").text()
            //WORK_FROM_HOME: TASK_DETAIL.WORK_FROM_HOME

        });
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/UpdateTask',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success.data);
            alert(success.data.MESSAGE);
            if (success.data.ERROR_STATUS == false)
                $('.closepopup').trigger('click');

            $scope.GetMyTask();
            //$scope.progressbar.complete();
            $scope.$apply();
        }, function (error) {
            console.log(error);
            $window.alert('Failed To delete ! ');
            $scope.progressbar.complete();
        });
    }



    $scope.FilterDropdownChange = function () {

        debugger;
        if ($scope.FilterOption == 'filterbydate') {
            $("#filterbydate").show();
        }
        else {
            $("#filterbydate").hide();
            $scope.GetMyTask();
        }

        //$scope.progressbar.start();
        //var data = $.param({
        //    type: "get_mytask",
        //    DropdownValue: $scope.FilterOption,
        //    FROM_DATE: $("#FROM_DATE").val(),
        //    TO_DATE: $("#TO_DATE").val()
        //});
        //$http({
        //    method: 'POST',
        //    url: '/AdminOperation.asmx/FilterDropdownChange',
        //    data: data,
        //    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        //}).then(function (success) {
        //    console.log(success.data);
        //    $scope.tasklist = success.data.TASK_DATA;
        //    $scope.progressbar.complete();
        //}, function (error) {
        //    console.log(error);
        //    $window.alert('Failed To get ! ');
        //    $scope.progressbar.complete();
        //});

    }
    //$scope.priceRange = function (item) {
    //    return (parseInt(item.PRICE) >= $scope.lower_price_bound && parseInt(item.PRICE) <= $scope.upper_price_bound);
    //};
    $scope.FilterDropdownChangeAllTask = function () {

        debugger;
        if ($scope.FilterOption == 'filterbydate') {
            $("#filterbydate").show();
        }
        else {
            $("#filterbydate").hide();
            $scope.GetAllTask();
        }
    }


    $scope.ViewTaskDetail = function (data) {
        $scope.TASK_DETAIL = data;
    }
    $(".trCompleted").hide();
    $scope.ChangeStatus = function (data) {        
        if (data == "Completed") {
            $(".trCompleted").show();
        } else {
            $(".trCompleted").hide();
        }
    }
});
