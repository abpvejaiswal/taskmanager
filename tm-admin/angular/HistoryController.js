
var app = angular.module('HistoryApp', ['ngRoute', 'ngTagsInput', 'ngProgress']);

// Order Master
app.controller('HistoryController', function ($scope, $http, $window, ngProgressFactory, $location) {

    $scope.progressbar = ngProgressFactory.createInstance();
    $scope.exporting = true;
    function getUrlParameter(param, dummyPath) {
        var sPageURL = dummyPath || window.location.search.substring(1),
            sURLVariables = sPageURL.split(/[&||?]/),
            res;

        for (var i = 0; i < sURLVariables.length; i += 1) {
            var paramName = sURLVariables[i],
                sParameterName = (paramName || '').split('=');

            if (sParameterName[0] === param) {
                res = sParameterName[1];
            }
        }

        return res;
    }
    $scope.Enquirylist = [];
    $scope.GetEnquiry = function () {
        $scope.progressbar.start();
        var user = getUrlParameter('ID');
        var detail = $.param({
            ACTION: "getenquirydata",
            EID: user
        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/GetSingleEnquiryData',
            data: detail,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {

            console.log(success.data.GetEnquiryData);
            $scope.Enquirylist = success.data.GetEnquiryData;
            // alert(JSON.stringify(success.data.getallproduct));
            $scope.progressbar.complete();
            //console.log('ordermasterlist ');
        }, function (error) {
            console.log(error);
            $scope.progressbar.complete();
            window.alert('Failed To Load');
        });
    }
    $scope.GetEnquiry();

    $scope.enquiryDetaillist = [];
    $scope.singleenquirylist = [];
    
    // Get ORder Master
    $scope.GetEnquiryMaster = function (all, detail) {
        debugger;
        $scope.singleenquirylist = all;
        $scope.enquiryDetaillist = detail;
    };
    $scope.Quotationlist = [];
    $scope.GetQuotation = function () {
        debugger;
        $scope.progressbar.start();
        var user = getUrlParameter('ID');
        var detail = $.param({
            ACTION: "gethistoryquotationdata",
            QID: user
        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/GetSingleQuotationData',
            data: detail,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {

            console.log(success.data.GetQuotationData);
            $scope.Quotationlist = success.data.GetQuotationData;
            // alert(JSON.stringify(success.data.getallproduct));
            $scope.progressbar.complete();
            //console.log('ordermasterlist ');
        }, function (error) {
            console.log(error);
            $scope.progressbar.complete();
            window.alert('Failed To Load');
            $scope.progressbar.complete();
        });
    }

    $scope.quotationDetaillist = [];
    $scope.singlequotationlist = [];

    // Get ORder Master
    $scope.GetQuotationMaster = function (all, detail) {
        debugger;
        $scope.singlequotationlist = all;
        $scope.quotationDetaillist = detail;
    };
    
    $scope.UpdateStatus = function (id) {
        //$scope.HTMLPDF = document.getElementById("dvTable").innerHTML;
        var detail = $.param({
            type: "updatequotation",
            qid: id

        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/UpdateQuotationData',
            data: detail,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {

            console.log(success.data);

            alert(JSON.stringify(success.data.ORIGINAL_ERROR));
            $window.location.reload();


        }, function (error) {
            console.log(error);

            window.alert('Failed To Load');


        });
    }

    $scope.Proformalist = [];
    $scope.GetProforma = function () {
        debugger;
        $scope.progressbar.start();
        var user = getUrlParameter('ID');
        var detail = $.param({
            ACTION: "getsingleproformadata",
            PID: user
        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/GetSingleProformaInvoice',
            data: detail,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {

            console.log(success.data.GetProformaData);
            $scope.Proformalist = success.data.GetProformaData;
            // alert(JSON.stringify(success.data.getallproduct));
            $scope.progressbar.complete();
            //console.log('ordermasterlist ');
        }, function (error) {
            console.log(error);
            $scope.progressbar.complete();
            window.alert('Failed To Load');
            $scope.progressbar.complete();
        });
    }

    $scope.proformaDetaillist = [];
    $scope.singleproformalist = [];

    // Get ORder Master
    $scope.GetProformaMaster = function (all, detail) {
        debugger;
        $scope.singleproformalist = all;
        $scope.proformaDetaillist = detail;
    };

    $scope.OrderAcceptancelist = [];
    $scope.GetOrderAcceptance = function () {
        debugger;
        $scope.progressbar.start();
        var user = getUrlParameter('ID');
        var detail = $.param({
            ACTION: "getsingleorderdata",
            OID: user
        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/GetSingleOrderAcceptanceData',
            data: detail,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            debugger;
            console.log('OrderData');
            console.log(success.data.GetOrderData);
            $scope.OrderAcceptancelist = success.data.GetOrderData;
            // alert(JSON.stringify(success.data.getallproduct));
            $scope.progressbar.complete();
            //console.log('ordermasterlist ');
        }, function (error) {
            console.log(error);
            $scope.progressbar.complete();
            window.alert('Failed To Load');
            $scope.progressbar.complete();
        });
    }

    $scope.orderdatalist = [];
    $scope.orderitemlist = [];
    $scope.ordersinstructionlist = [];
    // Get ORder Master
    $scope.GetOrderMaster = function (all, item, si) {
        debugger;
        $scope.orderdatalist = all;
        $scope.orderitemlist = item;
        $scope.ordersinstructionlist = si;
    };

    $scope.dispatchnotelist = [];
    // Get ORder Master
    $scope.GetDispatchNote = function () {
        $scope.progressbar.start();
        var user = getUrlParameter('ID');
        var data = $.param({
            ACTION: "getdispatchdata",
            DID: user
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/ControllerServices.asmx/GetSingleDispatchNoteData',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            debugger;
            $scope.dispatchnotelist = success.data.GetDispatchData;
            console.log('DispatchNoteData');
            console.log($scope.dispatchnotelist);
            $scope.progressbar.complete();
        }, function (error) {
            console.log(error);
            window.alert('Failed To Load');
            $scope.progressbar.complete();
        });
    };

    $scope.dispatchdatalist = [];
    $scope.dispatchitemlist = [];
    $scope.dispatchsinstructionlist = [];
    $scope.dispatchpinstructionlist = [];
    $scope.dispatchremarklist = [];
    // Get ORder Master
    $scope.GetDispatchMaster = function (all, item, pi, si, re) {
        debugger;
        $scope.dispatchdatalist = all;
        $scope.dispatchitemlist = item;
        $scope.dispatchpinstructionlist = pi;
        $scope.dispatchsinstructionlist = si;
        $scope.dispatchremarklist = re;
    };

    $scope.GetPurchaseOrderlist = [];
    // Get ORder Master
    $scope.GetPurchaseOrder = function () {
        var user = getUrlParameter('ID');
        $scope.progressbar.start();
        var data = $.param({
            ACTION: "getpurchaseorder",
            PID:user
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/ControllerServices.asmx/GetSinglePurchaseOrderData',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            debugger;
            $scope.GetPurchaseOrderlist = success.data.GetPurchaseOrderData;
            console.log('PurchaseOrder');
            console.log($scope.GetPurchaseOrderlist);
            $scope.progressbar.complete();
        }, function (error) {
            console.log(error);
            window.alert('Failed To Load');
            $scope.progressbar.complete();
        });
    };
    $scope.GetHistoryStatuslist = [];
    $scope.Quotationcss = '';
    $scope.OrderAcceptancecss = '';
    $scope.PurchaseOrdercss = '';
    $scope.ProformaInvoicecss = '';
    $scope.DispatchNotecss = '';
    $scope.Paymentcss = '';
    $scope.GetHistoryData = function () {
        var user = getUrlParameter('ID');
        $scope.progressbar.start();
        var data = $.param({
            ACTION: "gethistory",
            ID: user
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/ControllerServices.asmx/GetHistoryStatusData',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            debugger;
            $scope.GetHistoryStatuslist = success.data.GetHistoryStatus;
            console.log('HistoryStatus');
            console.log($scope.GetHistoryStatuslist);
            if ($scope.GetHistoryStatuslist[0].QuotationStatus == 'active') {
                $scope.Quotationcss = 'zmdi zmdi-check-circle';
            }
            if ($scope.GetHistoryStatuslist[0].OrderAcceptanceStatus == 'active') {
                $scope.OrderAcceptancecss = 'zmdi zmdi-check-circle';
            }
            if ($scope.GetHistoryStatuslist[0].PurchaseOrderStatus == 'active') {
                $scope.PurchaseOrdercss = 'zmdi zmdi-check-circle';
            }
            if ($scope.GetHistoryStatuslist[0].ProformaInvoice == 'active') {
                $scope.ProformaInvoicecss = 'zmdi zmdi-check-circle';
            }
            if ($scope.GetHistoryStatuslist[0].DispatchNote == 'active') {
                $scope.DispatchNotecss = 'zmdi zmdi-check-circle';
            }
            if ($scope.GetHistoryStatuslist[0].Payment == 'active') {
                $scope.Paymentcss = 'zmdi zmdi-check-circle';
            }
            $scope.progressbar.complete();
        }, function (error) {
            console.log(error);
            window.alert('Failed To Load');
            $scope.progressbar.complete();
        });
    };
    $scope.GetHistoryData();

    $scope.GetPaymentlist = [];
    // Get ORder Master
    $scope.GetPayment = function () {
        var user = getUrlParameter('ID');
        $scope.progressbar.start();
        var data = $.param({
            ACTION: "getpaymentdata",
            PID: user
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/ControllerServices.asmx/GetSinglePaymentData',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            debugger;
            $scope.GetPaymentlist = success.data.GetPaymentData;
            console.log('Payment');
            console.log($scope.GetPaymentlist);
            $scope.progressbar.complete();
        }, function (error) {
            console.log(error);
            window.alert('Failed To Load');
            $scope.progressbar.complete();
        });
    };
});
