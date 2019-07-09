
var app = angular.module('ProformaApp', ['ngRoute', 'ngTagsInput', 'ngProgress']);

// Order Master
app.controller('ProformaController', function ($scope, $http, $window, ngProgressFactory) {

    $scope.progressbar = ngProgressFactory.createInstance();
    //$scope.exporting = true;
    debugger;
    $scope.VariantList = [];
    $scope.VariantList1 = [];
//    $scope.stocklist = [{ "module": "GOLDI003PM(3WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
//{ "module": "GOLDI005PM_18S(5WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
//{ "module": "GOLDI012PM(10WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
//{ "module": "GOLDI012PM_18S(10WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
//{ "module": "GOLDI012PM(12WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
//{ "module": "GOLDI015PM(15WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
//{ "module": "GOLDI020PM(20WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
//{ "module": "GOLDI030PM(25WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
//{ "module": "GOLDI030PM(30WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
//{ "module": "GOLDI045PM(37WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
//{ "module": "GOLDI045PM(40WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" }];

    $scope.Changetotalstock = function (Variant) {


        $scope.stocklist[Variant].total = (parseFloat($scope.stocklist[Variant].stockgoldi) + parseFloat($scope.stocklist[Variant].stockkanpur) + parseFloat($scope.stocklist[Variant].stockchakan) + parseFloat($scope.stocklist[Variant].stockkalamboli));
    }

    console.log($scope.stocklist);
    $scope.tags_product = [];
    //var countries = [{ "id": "1", "Name": "GOLDI003PM(3WP)", "Description": "Desc 1", "Unit": "nos", "Mrp": "1000", "Tax": "5", "SellingPrice": "899", "image": "Resources/product/cctv1.png" }, { "id": "2", "Name": "GOLDI005PM_18S(5WP)", "Description": "Desc 2", "Unit": "nos", "Mrp": "1000", "Tax": "5", "SellingPrice": "899", "image": "Resources/product/cctv2.jpg" }, { "id": "3", "Name": "GOLDI012PM(10WP)", "Description": "Desc 3", "Unit": "nos", "Mrp": "1000", "Tax": "5", "SellingPrice": "899", "image": "Resources/product/cctv3.jpg" }, { "id": "6", "Name": "GOLDI012PM_18S(10WP)", "Description": "Desc 4", "Unit": "nos", "Mrp": "1000", "Tax": "5", "SellingPrice": "999", "image": "Resources/product/cctv1.png" }, { "id": "7", "Name": "GOLDI012PM(12WP)", "Description": "Desc 5", "Unit": "nos", "Mrp": "1200", "Tax": "5", "SellingPrice": "1000", "image": "Resources/product/02.jpg" }, { "id": "10", "Name": "GOLDI015PM(15WP)", "Description": "testing", "Unit": "nos", "Mrp": "200", "Tax": "5", "SellingPrice": "100", "image": "Resources/product/applogo (1).png" }, { "id": "9", "Name": "GOLDI020PM(20WP)", "Description": "Desc 7", "Unit": "nos", "Mrp": "2000", "Tax": "5", "SellingPrice": "1599", "image": "Resources/product/cctv1.png" }];
    var countries = [];
    $scope.GetAppProduct = function () {
        debugger;
        var detail = $.param({
            ACTION: "getallitemdata"
        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/GetAllItemData',
            data: detail,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            debugger;
            console.log(success.data.getallproduct);
            countries = success.data.getallproduct;
            // alert(JSON.stringify(success.data.getallproduct));

            //console.log('ordermasterlist ');
        }, function (error) {
            console.log(error);
            debugger;
            window.alert('Failed To Load');
        });
    }
    $scope.GetAppProduct();
    $scope.TotalAmount = 0;
    $scope.Tax = 0;
    $scope.TaxTotal = 0;
    $scope.fredght = 0;
    $scope.subamount = 0;
    $scope.loadCountries = function ($query) {
        return countries.filter(function (country) {
            return country.Name.toLowerCase().indexOf($query.toLowerCase()) != -1;
        });
    };
    $scope.totalamt = '';
    $scope.ChangedTagInput = function (VariantList) {
        debugger;
        $scope.exporting = false;
        var _atm = {
            OptionName: $scope.OptionName,
            text: VariantList[VariantList.length - 1].Name,
            pid: VariantList[VariantList.length - 1].id,
            Unit: 'nos',
            Qty: '1',
            Rate: '0',
            Tax: '0',

            Amount: '0'

        };
        $scope.TotalAmount = 0;
        //$scope.TotalAmount = parseFloat(VariantList[VariantList.length - 1].Mrp) + parseFloat($scope.TotalAmount);
        $scope.TaxTotal = 0;
        if ($scope.Tax != 0) {
            $scope.TaxTotal = ($scope.TotalAmount * $scope.Tax / 100).toFixed(2);
            $scope.TotalAmount = (parseFloat($scope.TotalAmount) + parseFloat($scope.TaxTotal)).toFixed(2);
        }

        if ($scope.fredght != 0) {

            $scope.TotalAmount = (parseFloat($scope.TotalAmount) + parseFloat($scope.fredght)).toFixed(2);
        }
        $scope.VariantList.push(_atm);
        console.log('changesdtagput');
        console.log($scope.VariantList);
        console.log(VariantList);
    }
    //$scope.Total = $scope.VariantList[0].Amount;

    $scope.ChangeRate = function (Variant) {
        debugger;
        $scope.VariantList[Variant].Amount = ($scope.VariantList[Variant].Rate * $scope.VariantList[Variant].Qty).toFixed(2);
        $scope.TotalAmount = 0;
        $scope.subamount = 0;
        for ($scope.k = 0; $scope.k <= $scope.VariantList.length - 1; $scope.k++) {
            $scope.TotalAmount = (parseFloat($scope.VariantList[$scope.k].Amount) + parseFloat($scope.TotalAmount)).toFixed(2);
            $scope.subamount = $scope.TotalAmount;
        }
        $scope.TaxTotal = 0;
        if ($scope.Tax != 0) {
            $scope.TaxTotal = ($scope.TotalAmount * $scope.Tax / 100).toFixed(2);
            $scope.TotalAmount = (parseFloat($scope.TotalAmount) + parseFloat($scope.TaxTotal)).toFixed(2);

        }
        if ($scope.fredght.text != "") {
            $scope.TotalAmount = (parseFloat($scope.TotalAmount) + parseFloat($scope.fredght)).toFixed(2);
        }
        //if ($scope.VariantList[Variant].Qty != "" && $scope.VariantList[Variant].Qty != "0") {
        //    $scope.VariantList[Variant].Amount = $scope.VariantList[Variant].Qty * $scope.VariantList[Variant].Amount;
        //    $scope.exporting = false;
        //} else {
        //    $scope.exporting = true;
        //}

        //console.log(tag.text);
        //var Rate = $scope.VariantList.map(function (img) { return img.text; }).indexOf(tag.Rate);
        //var Amount = $scope.VariantList.map(function (img) { return img.text; }).indexOf(tag.Amount);
        //console.log(index);
        //$scope.VariantList.ChangeRate(Rate * tag, 1);
        //$scope.VariantList.ChangeRate(Amount * tag, 1);

    }

    $scope.ChangeRatetwo = function (Variant) {
        $scope.TotalAmount = 0;
        $scope.subamount = 0;
        for ($scope.k = 0; $scope.k <= $scope.VariantList.length - 1; $scope.k++) {
            $scope.TotalAmount = (parseFloat($scope.VariantList[$scope.k].Amount) + parseFloat($scope.TotalAmount)).toFixed(2);
            $scope.subamount = $scope.TotalAmount;
        }
        $scope.TaxTotal = 0;
        if ($scope.Tax != 0) {
            $scope.TaxTotal = ($scope.TotalAmount * $scope.Tax / 100).toFixed(2);
            $scope.TotalAmount = (parseFloat($scope.TotalAmount) + parseFloat($scope.TaxTotal)).toFixed(2);
        }
        if ($scope.fredght.text != "") {
            $scope.TotalAmount = (parseFloat($scope.TotalAmount) + parseFloat($scope.fredght)).toFixed(2);
        }
    }




    $scope.RemovedTag = function (tag) {
        debugger;
        console.log(tag.text);
        var index = $scope.VariantList.map(function (img) { return img.text; }).indexOf(tag.Name);
        console.log(index);
        $scope.VariantList.splice(index, 1);
        if ($scope.VariantList == "") {
            $scope.exporting = true;
        }
        $scope.TotalAmount = 0;
        $scope.subamount = 0;
        for ($scope.k = 0; $scope.k <= $scope.VariantList.length - 1; $scope.k++) {
            $scope.TotalAmount = (parseFloat($scope.VariantList[$scope.k].Amount) + parseFloat($scope.TotalAmount)).toFixed(2);
            $scope.subamount = $scope.TotalAmount;
        }
        $scope.TaxTotal = 0;
        if ($scope.Tax != 0) {
            $scope.TaxTotal = ($scope.TotalAmount * $scope.Tax / 100).toFixed(2);
            $scope.TotalAmount = (parseFloat($scope.TotalAmount) + parseFloat($scope.TaxTotal)).toFixed(2);
        }
        if ($scope.fredght.text != "") {
            $scope.TotalAmount = (parseFloat($scope.TotalAmount) + parseFloat($scope.fredght)).toFixed(2);
        }
    }
    
    $scope.PROFORMA = { CLIENT_ID: '0',PERSON:'',PERSON_NO:'', EREF: '', EDATE: '', PREF: '', PDATE: '', DTERM: '', DSCHEDULE: '', TAXES: '', FREIGHT: '', DISPATCH: '', BANK: '0', SPECIAL_TERM:'',PURCHASE_TERM:'',GSTNO:'' };
    $scope.SEARCH_USER = { MESSAGE: '' };

    $scope.SaveProforma = function (proforma) {
        debugger;
        if ($(".CLIENT_ID").val() == "0" || proforma.EREF == '' || proforma.QREF == '' || proforma.DTERM == '' || proforma.DSCHEDULE == '' || $(".EDATE").val() == '' || $(".QDATE").val() == '' || proforma.TAXES == '' || proforma.FREIGHT == '' || proforma.DISPATCH == '' || proforma.STERM == '' || $(".BANK").val() == "0") {
            alert("All Field Requied");
            $scope.SEARCH_USER.MESSAGE = "*";
            return;
        }

        if ($scope.TotalAmount == "0") {
            alert("Select Item And Fill Amount");
            return;
        }
        //$scope.HTMLPDF = document.getElementById("dvTable").innerHTML;
        $scope.exporting = true;
        $(".gifloader").html('<img src="/gg-admin/img/Rolling.gif" />');
        var detail = $.param({
            type: "insertproforma",
            tax: $scope.Tax,
            //fredght: $scope.fredght,
            subtotal: $scope.subamount,
            total: $scope.TotalAmount,
            Data: JSON.stringify($scope.VariantList),
            PROFORMA_DATA: JSON.stringify(proforma),
            QID: $(".CLIENT_ID").val(),
            BANK: $(".BANK").val(),
            EDate: $(".EDATE").val(),
            PDate: $(".PDATE").val()
        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/InsertProformaData',
            data: detail,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            debugger;
            console.log(success.data);
            //countries = success.data.getallproduct;
            alert(JSON.stringify(success.data.ORIGINAL_ERROR));
            $window.location.reload();
            $scope.exporting = false;
            //console.log('ordermasterlist ');
        }, function (error) {
            console.log(error);
            debugger;
            window.alert('Failed To Load');
            $scope.exporting = false;
            $(".gifloader").text("Submit");
        });
    }
    $scope.ChangeData = function () {
        debugger;
        //$scope.disdata = true;
        $scope.progressbar.start();
        if ($(".CLIENT_ID").val() == 0) {
            $scope.VariantList = [];
            $scope.TotalAmount = 0;
            $scope.subamount = 0;
            $scope.Tax = 0;
            $scope.TaxTotal = 0;
            
            $scope.PROFORMA.DTERM = '';
            $scope.PROFORMA.DSCHEDULE = '';
            $scope.PROFORMA.TAXES = '';
            $scope.PROFORMA.FREIGHT = '';
            $scope.PROFORMA.DISPATCH = '';
            $scope.PROFORMA.SPECIAL_TERM = '';
            $scope.PROFORMA.PURCHASE_TERM = '';

            $scope.VariantList1 = [];
            $scope.GetAppProduct();

            $scope.loadCountries = function ($query) {
                return countries.filter(function (country) {
                    return country.Name.toLowerCase().indexOf($query.toLowerCase()) != -1;
                });
            };
            $scope.progressbar.complete();
            return;
        }
        var detail = $.param({
            type: "getenquiryitems",
            QID: $(".CLIENT_ID").val()
        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/GetEnquiryItemData',
            data: detail,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            debugger;
            $(".myfg").addClass("fg-toggled");
            $scope.VariantList = [];
            $scope.VariantList1 = [];
            console.log(success.data);
            $scope.TotalAmount = success.data.GetEnquiryData[0].total;
            $scope.subamount = success.data.GetEnquiryData[0].subtotal;

            $scope.PROFORMA.DTERM = success.data.GetQuotationData[0].D_Term;
            $scope.PROFORMA.DSCHEDULE = success.data.GetQuotationData[0].D_Schedule;
            $scope.PROFORMA.TAXES = success.data.GetQuotationData[0].Taxes;
            $scope.PROFORMA.FREIGHT = success.data.GetQuotationData[0].Insurance;
            $scope.PROFORMA.DISPATCH = success.data.GetQuotationData[0].Mode_Dispatch;
            $scope.PROFORMA.SPECIAL_TERM = success.data.GetQuotationData[0].S_Term;
            $scope.PROFORMA.PURCHASE_TERM = success.data.GetQuotationData[0].P_Term;

            $scope.Tax = parseFloat(success.data.GetEnquiryData[0].tax);
            $scope.TaxTotal = 0;
            if ($scope.Tax != 0) {
                $scope.TaxTotal = $scope.subamount * $scope.Tax / 100;
                //$scope.TotalAmount = (parseFloat($scope.TotalAmount) + parseFloat($scope.TaxTotal));
            }
            //$scope.VariantList1 = [];
            //$(".Taxamt").val() = success.data.GetEnquiryData[0].tax;
            for ($scope.k = 0; $scope.k <= success.data.GetEnquiryData.length - 1; $scope.k++) {
                debugger;
                var _atm = {

                    text: success.data.GetEnquiryData[$scope.k].itemname,
                    pid: success.data.GetEnquiryData[$scope.k].itemid,
                    Unit: success.data.GetEnquiryData[$scope.k].unit,
                    Qty: success.data.GetEnquiryData[$scope.k].qty,
                    Rate: success.data.GetEnquiryData[$scope.k].unit_price,
                    //Tax: 0,
                    Amount: success.data.GetEnquiryData[$scope.k].subtotal_price
                };
                $scope.VariantList.push(_atm);

                var newEntry = {};
                newEntry['Name'] = success.data.GetEnquiryData[$scope.k].itemname;
                $scope.VariantList1.push(newEntry);

                //$scope.loadCountries = function (query) {
                //    return $http.get('/VariantList1?query=' + query);
                //};
            }

            //countries = success.data.getallproduct;
            //alert(JSON.stringify(success.data.ORIGINAL_ERROR));
            //$window.location.reload();
            //$scope.exporting = false;
            //console.log('ordermasterlist ');
            $scope.progressbar.complete();
        }, function (error) {
            console.log(error);

            window.alert('Failed To Load');
            $scope.exporting = false;
            $scope.progressbar.complete();
        });

    }
    $scope.proformalist = [];
    // Get ORder Master
    var GetOrderMaster = function () {
        $scope.progressbar.start();
        debugger;
        var data = $.param({
            ACTION: "getproformadata"
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/ControllerServices.asmx/GetProformaInvoice',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            debugger;
            $scope.proformalist = success.data.GetProformaData;
            console.log('ordermasterlist');
            console.log($scope.proformalist);
            $scope.progressbar.complete();
        }, function (error) {
            console.log(error);
            window.alert('Failed To Load');
        });
    };
    GetOrderMaster();
    $scope.proformaDetaillist = [];
    $scope.proformaproductlist = [];
    $scope.proformaproducttotal = "";
    $scope.proformaproducttax = "";
    $scope.proformaproductsubtotal = "";
    // Get ORder Master
    $scope.GetEmployeeMaster = function (all, x, y, z, p, q) {
        debugger;
        $scope.proformaDetaillist = all;
        $scope.proformaproductlist = x;
        $scope.proformaproducttotal = y;
        $scope.proformaproducttax = z;
        $scope.proformaproductsubtotal = p;
    };

    $scope.DeleteQuotation = function (id) {
        debugger;


        //$scope.HTMLPDF = document.getElementById("dvTable").innerHTML;

        var detail = $.param({
            type: "deletequotation",
            qid: id

        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/DeleteQuotationData',
            data: detail,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            debugger;
            console.log(success.data);

            alert(JSON.stringify(success.data.ORIGINAL_ERROR));
            $window.location.reload();


        }, function (error) {
            console.log(error);
            debugger;
            window.alert('Failed To Load');

        });
    }
});
