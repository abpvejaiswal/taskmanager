
var app = angular.module('QuotationApp', ['ngRoute', 'ngTagsInput', 'ngProgress']);

// Order Master
app.controller('QuotationController', function ($scope, $http, $window, ngProgressFactory, $location) {

    $scope.update = false;
    $scope.submit = true;
    $scope.progressbar = ngProgressFactory.createInstance();
    //$scope.exporting = true;

    $scope.VariantList = [];
    $scope.VariantList1 = [];
        $scope.stocklist = [{ "module": "GOLDI003PM(3WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
    { "module": "GOLDI005PM_18S(5WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
    { "module": "GOLDI012PM(10WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
    { "module": "GOLDI012PM_18S(10WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
    { "module": "GOLDI012PM(12WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
    { "module": "GOLDI015PM(15WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
    { "module": "GOLDI020PM(20WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
    { "module": "GOLDI030PM(25WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
    { "module": "GOLDI030PM(30WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
    { "module": "GOLDI045PM(37WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" },
    { "module": "GOLDI045PM(40WP)", "stockgoldi": "1600", "stockkanpur": "1400", "stockchakan": "1000", "stockkalamboli": "1000", "total": "5000", "reservedstock": "100", "customername": "ABC", "netstock": "2100", "incoming": "100", "final": "2200", "KW": "11.76", "mounting": "Test" }];

    $scope.Changetotalstock = function (Variant) {


        $scope.stocklist[Variant].total = (parseFloat($scope.stocklist[Variant].stockgoldi) + parseFloat($scope.stocklist[Variant].stockkanpur) + parseFloat($scope.stocklist[Variant].stockchakan) + parseFloat($scope.stocklist[Variant].stockkalamboli));
    }

    console.log($scope.stocklist);
    $scope.tags_product = [];
    //var countries = [{ "id": "1", "Name": "GOLDI003PM(3WP)", "Description": "Desc 1", "Unit": "nos", "Mrp": "1000", "Tax": "5", "SellingPrice": "899", "image": "Resources/product/cctv1.png" }, { "id": "2", "Name": "GOLDI005PM_18S(5WP)", "Description": "Desc 2", "Unit": "nos", "Mrp": "1000", "Tax": "5", "SellingPrice": "899", "image": "Resources/product/cctv2.jpg" }, { "id": "3", "Name": "GOLDI012PM(10WP)", "Description": "Desc 3", "Unit": "nos", "Mrp": "1000", "Tax": "5", "SellingPrice": "899", "image": "Resources/product/cctv3.jpg" }, { "id": "6", "Name": "GOLDI012PM_18S(10WP)", "Description": "Desc 4", "Unit": "nos", "Mrp": "1000", "Tax": "5", "SellingPrice": "999", "image": "Resources/product/cctv1.png" }, { "id": "7", "Name": "GOLDI012PM(12WP)", "Description": "Desc 5", "Unit": "nos", "Mrp": "1200", "Tax": "5", "SellingPrice": "1000", "image": "Resources/product/02.jpg" }, { "id": "10", "Name": "GOLDI015PM(15WP)", "Description": "testing", "Unit": "nos", "Mrp": "200", "Tax": "5", "SellingPrice": "100", "image": "Resources/product/applogo (1).png" }, { "id": "9", "Name": "GOLDI020PM(20WP)", "Description": "Desc 7", "Unit": "nos", "Mrp": "2000", "Tax": "5", "SellingPrice": "1599", "image": "Resources/product/cctv1.png" }];
    var countries = [];
    $scope.GetAppProduct = function () {

        var detail = $.param({
            ACTION: "getallitemdata"
        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/GetAllItemData',
            data: detail,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {

            console.log(success.data.getallproduct);
            countries = success.data.getallproduct;
            // alert(JSON.stringify(success.data.getallproduct));

            //console.log('ordermasterlist ');
        }, function (error) {
            console.log(error);

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

        $scope.exporting = false;
        var _atm = {
            OptionName: $scope.OptionName,
            text: VariantList[VariantList.length - 1].Name,
            pid: VariantList[VariantList.length - 1].id,
            Unit: 'nos',
            Qty: '1',
            Rate: '0',
            //Tax: '0',

            Amount: '0'

        };
        $scope.TotalAmount = 0;
        //$scope.TotalAmount = parseInt(VariantList[VariantList.length - 1].Mrp) + parseInt($scope.TotalAmount);
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
        debugger;
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
    $scope.QuotationId = "";
    $scope.QUOTATION = { CLIENT_ID: '0', EREF: '', EDATE: '', QREF: '', QDATE: '', DTERM: '', DSCHEDULE: '', TAXES: '', FREIGHT: '', DISPATCH: '', STERM: '', BANK: '0', PTERM: '' };
    $scope.SEARCH_USER = { MESSAGE: '' };

    $scope.SaveQuotation = function (quotation) {

        if ($(".CLIENT_ID").val() == "0" || quotation.EREF == '' || quotation.QREF == '' || quotation.DTERM == '' || quotation.DSCHEDULE == '' || $(".EDATE").val() == '' || $(".QDATE").val() == '' || quotation.TAXES == '' || quotation.FREIGHT == '' || quotation.DISPATCH == '' || quotation.STERM == '' || $(".BANK").val() == "0") {
            alert("All Field Requied");
            $scope.SEARCH_USER.MESSAGE = "*";
            return;
        }

        if ($scope.TotalAmount == "0") {
            alert("Select Item And Fill Amount");
            return;
        }
        $scope.Revice_id = 0;
        var user = getUrlParameter('ID');
        if (typeof user != 'undefined') {
            $scope.Revice_id = user;
        }
        //$scope.HTMLPDF = document.getElementById("dvTable").innerHTML;
        $scope.exporting = true;
        $(".gifloader").html('<img src="/gg-admin/img/Rolling.gif" />');
        var detail = $.param({
            type: "insertquotation",
            tax: $scope.Tax,
            taxamt: $scope.TaxTotal,
            fredght: $scope.fredght,
            subtotal: $scope.subamount,
            total: $scope.TotalAmount,
            Data: JSON.stringify($scope.VariantList),
            QUOTATION_DATA: JSON.stringify(quotation),
            ID: "",
            CLIENT_ID: $(".CLIENT_ID").val(),
            BANK: $(".BANK").val(),
            EDate: $(".EDATE").val(),
            QDate: $(".QDATE").val(),
            Revice: $scope.Revice_id
        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/InsertQuotationData',
            data: detail,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {

            console.log(success.data);

            //countries = success.data.getallproduct;
            alert(JSON.stringify(success.data.MESSAGE));
			if(success.data.ERROR_STATUS==false)
			{
				location.href("ViewQuotation.aspx");
			}
            $scope.exporting = false;
			
            //console.log('ordermasterlist ');
        }, function (error) {
            console.log(error);
            $(".gifloader").text("Submit");
            window.alert('Failed To save');
            $scope.exporting = false;
        });
    }

    $scope.UpdateQuotation = function (quotation) {
        debugger;
        var user = getUrlParameter('UID');
        if ($(".CLIENT_ID").val() == "0" || quotation.EREF == '' || quotation.QREF == '' || quotation.DTERM == '' || quotation.DSCHEDULE == '' || $(".EDATE").val() == '' || $(".QDATE").val() == '' || quotation.TAXES == '' || quotation.FREIGHT == '' || quotation.DISPATCH == '' || quotation.STERM == '' || $(".BANK").val() == "0") {
            alert("All Field Requied");
            $scope.SEARCH_USER.MESSAGE = "*";
            return;
        }

        if ($scope.TotalAmount == "0") {
            alert("Select Item And Fill Amount");
            return;
        }
        $scope.Revice_id = 0;
        //$scope.HTMLPDF = document.getElementById("dvTable").innerHTML;
        $scope.exporting = true;
        $(".gifloader").html('<img src="/gg-admin/img/Rolling.gif" />');
        var detail = $.param({
            type: "updatequotation",
            tax: $scope.Tax,
            taxamt: $scope.TaxTotal,
            fredght: $scope.fredght,
            subtotal: $scope.subamount,
            total: $scope.TotalAmount,
            Data: JSON.stringify($scope.VariantList),
            QUOTATION_DATA: JSON.stringify(quotation),
            ID: user,
            CLIENT_ID: $(".CLIENT_ID").val(),
            BANK: $(".BANK").val(),
            EDate: $(".EDATE").val(),
            QDate: $(".QDATE").val(),
            Revice: $scope.Revice_id
        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/InsertQuotationData',
            data: detail,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {

            console.log(success.data);

            //countries = success.data.getallproduct;
            alert(JSON.stringify(success.data.ORIGINAL_ERROR));
            location.href("ViewQuotation.aspx");
            $scope.exporting = false;
            //console.log('ordermasterlist ');
        }, function (error) {
            console.log(error);
            $(".gifloader").text("Submit");
            window.alert('Failed To Load');
            $scope.exporting = false;
        });
    }

    $scope.ChangeData = function () {
        debugger;
        $scope.progressbar.start();
        if ($(".CLIENT_ID").val() == 0) {
            $scope.VariantList = [];
            $scope.TotalAmount = 0;
            $scope.subamount = 0;
            $scope.Tax = 0;
            $scope.TaxTotal = 0;

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
            type: "getitemsforquotation",
            QID: $(".CLIENT_ID").val()
        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/GetEnquiryItemData',
            data: detail,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            debugger;
            $scope.VariantList = [];
            $scope.VariantList1 = [];
            console.log(success.data);
            
            $scope.TotalAmount = success.data.GetEnquiryData[0].total;
            $scope.subamount = success.data.GetEnquiryData[0].subtotal;

            $scope.Tax = parseFloat(success.data.GetEnquiryData[0].tax);
            $scope.TaxTotal = 0;
            if ($scope.Tax != 0) {
                $scope.TaxTotal = $scope.subamount * $scope.Tax / 100;
                //$scope.TotalAmount = (parseInt($scope.TotalAmount) + parseInt($scope.TaxTotal));
            }
            //$(".Taxamt").val() = success.data.GetEnquiryData[0].tax;
            //$scope.VariantList1 = [];
            for ($scope.k = 0; $scope.k <= success.data.GetEnquiryData.length - 1; $scope.k++) {
                debugger;
                var _atm = {

                    text: success.data.GetEnquiryData[$scope.k].itemname,
                    pid: success.data.GetEnquiryData[$scope.k].itemid,
                    Unit: success.data.GetEnquiryData[$scope.k].unit,
                    Qty: success.data.GetEnquiryData[$scope.k].qty,
                    Rate: success.data.GetEnquiryData[$scope.k].unit_price,
                    Amount: success.data.GetEnquiryData[$scope.k].subtotal_price
                };
                $scope.VariantList.push(_atm);
                console.log('VariantList');
                console.log($scope.VariantList);

                var newEntry = {};
                newEntry['Name'] = success.data.GetEnquiryData[$scope.k].itemname;
                $scope.VariantList1.push(newEntry);
                
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

    var GetSingleQuotationMaster = function () {
        debugger;
        var user = getUrlParameter('ID');
        if (typeof user != 'undefined') {
            //var myvalue = $location.search()['ID'];
            
            $scope.progressbar.start();
            var data = $.param({
                ACTION: "getsinglequotationdata",
                QID: user
            });
            var config = {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                    //   'Cross'
                }
            }
            $http({
                method: 'POST',
                url: '/ControllerServices.asmx/GetSingleQuotationData',
                data: data,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            }).then(function (success) {
                debugger;
                $(".myfg").addClass("fg-toggled");
                $scope.QUOTATION.CLIENT_ID = success.data.GetQuotationData[0].cid;
                $scope.QUOTATION.EREF = success.data.GetQuotationData[0].e_refe;
                $scope.QUOTATION.EDATE = success.data.GetQuotationData[0].e_date;
                $scope.QUOTATION.QREF = success.data.GetQuotationData[0].q_refe;
                $scope.QUOTATION.QDATE = success.data.GetQuotationData[0].q_date;
                $scope.QUOTATION.DTERM = success.data.GetQuotationData[0].delivery_term;
                $scope.QUOTATION.DSCHEDULE = success.data.GetQuotationData[0].d_schedule;
                $scope.QUOTATION.TAXES = success.data.GetQuotationData[0].taxes;
                $scope.QUOTATION.FREIGHT = success.data.GetQuotationData[0].freight;
                $scope.QUOTATION.DISPATCH = success.data.GetQuotationData[0].mode_dispatch;
                $scope.QUOTATION.STERM = success.data.GetQuotationData[0].s_term;
                $scope.QUOTATION.PTERM = success.data.GetQuotationData[0].p_term;
                $scope.QUOTATION.BANK = success.data.GetQuotationData[0].bank;
                $scope.TotalAmount = success.data.GetQuotationData[0].total;
                $scope.subamount = success.data.GetQuotationData[0].subtotal;
                $scope.fredght = parseFloat(success.data.GetQuotationData[0].freight_changes);
                $scope.Tax = parseFloat(success.data.GetQuotationData[0].tax);
                $scope.TaxTotal = 0;
                if ($scope.Tax != 0) {
                    $scope.TaxTotal = $scope.subamount * $scope.Tax / 100;
                    //$scope.TotalAmount = (parseInt($scope.TotalAmount) + parseInt($scope.TaxTotal));
                }
                //$scope.VariantList1 = [];
                for ($scope.k = 0; $scope.k <= success.data.GetQuotationData[0].GetQuotationProductData.length - 1; $scope.k++) {
                    debugger;
                    var _atm = {

                        text: success.data.GetQuotationData[0].GetQuotationProductData[$scope.k].itemname,
                        pid: success.data.GetQuotationData[0].GetQuotationProductData[$scope.k].eid,
                        Unit: success.data.GetQuotationData[0].GetQuotationProductData[$scope.k].unit,
                        Qty: success.data.GetQuotationData[0].GetQuotationProductData[$scope.k].qty,
                        Rate: success.data.GetQuotationData[0].GetQuotationProductData[$scope.k].unit_price,
                        Amount: success.data.GetQuotationData[0].GetQuotationProductData[$scope.k].subtotal
                    };
                    $scope.VariantList.push(_atm);
                    console.log('VariantList');
                    console.log($scope.VariantList);

                    var newEntry = {};
                    newEntry['Name'] = success.data.GetQuotationData[0].GetQuotationProductData[$scope.k].itemname;
                    $scope.VariantList1.push(newEntry);
                    
                    
                }
                $scope.progressbar.complete();
            }, function (error) {
                console.log(error);
                window.alert('Failed To Load');
            });

        }
        var user2 = getUrlParameter('UID');
        if (typeof user2 != 'undefined') {
            //var myvalue = $location.search()['ID'];
            $scope.update = true;
            $scope.submit = false;
            $scope.progressbar.start();
            var data = $.param({
                ACTION: "getsinglequotationdata",
                QID: user2
            });
            var config = {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                    //   'Cross'
                }
            }
            $http({
                method: 'POST',
                url: '/ControllerServices.asmx/GetSingleQuotationData',
                data: data,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            }).then(function (success) {
                debugger;
                $(".myfg").addClass("fg-toggled");
                $scope.QUOTATION.CLIENT_ID = success.data.GetQuotationData[0].cid;
                $scope.QUOTATION.EREF = success.data.GetQuotationData[0].e_refe;
                $scope.QUOTATION.EDATE = success.data.GetQuotationData[0].e_date;
                $scope.QUOTATION.QREF = success.data.GetQuotationData[0].q_refe;
                $scope.QUOTATION.QDATE = success.data.GetQuotationData[0].q_date;
                $scope.QUOTATION.DTERM = success.data.GetQuotationData[0].delivery_term;
                $scope.QUOTATION.DSCHEDULE = success.data.GetQuotationData[0].d_schedule;
                $scope.QUOTATION.TAXES = success.data.GetQuotationData[0].taxes;
                $scope.QUOTATION.FREIGHT = success.data.GetQuotationData[0].freight;
                $scope.QUOTATION.DISPATCH = success.data.GetQuotationData[0].mode_dispatch;
                $scope.QUOTATION.STERM = success.data.GetQuotationData[0].s_term;
                $scope.QUOTATION.PTERM = success.data.GetQuotationData[0].p_term;
                $scope.QUOTATION.BANK = success.data.GetQuotationData[0].bank;
                $scope.TotalAmount = success.data.GetQuotationData[0].total;
                $scope.subamount = success.data.GetQuotationData[0].subtotal;
                $scope.fredght = parseFloat(success.data.GetQuotationData[0].freight_changes);
                $scope.Tax = parseFloat(success.data.GetQuotationData[0].tax);
                $scope.TaxTotal = 0;
                if ($scope.Tax != 0) {
                    $scope.TaxTotal = $scope.subamount * $scope.Tax / 100;
                    //$scope.TotalAmount = (parseInt($scope.TotalAmount) + parseInt($scope.TaxTotal));
                }
                //$scope.VariantList1 = [];
                for ($scope.k = 0; $scope.k <= success.data.GetQuotationData[0].GetQuotationProductData.length - 1; $scope.k++) {
                    debugger;
                    var _atm = {

                        text: success.data.GetQuotationData[0].GetQuotationProductData[$scope.k].itemname,
                        pid: success.data.GetQuotationData[0].GetQuotationProductData[$scope.k].eid,
                        Unit: success.data.GetQuotationData[0].GetQuotationProductData[$scope.k].unit,
                        Qty: success.data.GetQuotationData[0].GetQuotationProductData[$scope.k].qty,
                        Rate: success.data.GetQuotationData[0].GetQuotationProductData[$scope.k].unit_price,
                        Amount: success.data.GetQuotationData[0].GetQuotationProductData[$scope.k].subtotal
                    };
                    $scope.VariantList.push(_atm);
                    console.log('VariantList');
                    console.log($scope.VariantList);

                    var newEntry = {};
                    newEntry['Name'] = success.data.GetQuotationData[0].GetQuotationProductData[$scope.k].itemname;
                    $scope.VariantList1.push(newEntry);


                }
                $scope.progressbar.complete();
            }, function (error) {
                console.log(error);
                window.alert('Failed To Load');
            });

        }
    };
    GetSingleQuotationMaster();
    $scope.quotationlist = [];
    // Get ORder Master
    var GetOrderMaster = function () {
        $scope.progressbar.start();
        var data = $.param({
            ACTION: "getquotationdata"
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/ControllerServices.asmx/GetQuotationData',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            debugger;
            $scope.quotationlist = success.data.GetQuotationData;
            console.log('ordermasterlist');
            console.log($scope.quotationlist);
            $scope.progressbar.complete();
        }, function (error) {
            console.log(error);
            window.alert('Failed To Load');
        });
    };
    GetOrderMaster();
    $scope.quotationDetaillist = [];
    $scope.quotationproductlist = [];
    $scope.quotationproducttotal = "";
    $scope.quotationproducttax = "";
    $scope.quotationproducttaxamt = "";
    $scope.quotationproductsubtotal = "";
    $scope.quotationproductfreight = "";
    // Get ORder Master
    $scope.GetEmployeeMaster = function (all, list, total, tax, taxamt, subtotal, freight) {
        $scope.quotationDetaillist = all;
        $scope.quotationproductlist = list;
        $scope.quotationproducttotal = total;
        $scope.quotationproducttax = tax;
        $scope.quotationproducttaxamt = taxamt;
        $scope.quotationproductsubtotal = subtotal;
        $scope.quotationproductfreight = freight;
    };
    
    $scope.DeleteQuotation = function (id) {
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

            console.log(success.data);

            alert(JSON.stringify(success.data.ORIGINAL_ERROR));
            $window.location.reload();


        }, function (error) {
            console.log(error);

            window.alert('Failed To Load');

        });
    }
    $scope.QuotationId = "";
    $scope.GetQuotationId = function (QID) {
        $scope.QuotationId = QID;
    }
    $scope.UPDATE_QUOTATION = { STATUS: '1', COMMENT: '' };
    $scope.UpdateStatus = function (update_quotation) {
        
        var detail = $.param({
            type: "updatequotation",
            qid: $scope.QuotationId,
            status: $(".STATUS").val(),
            comment: update_quotation.COMMENT

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
    $scope.PrintQuotation = function (id) {
        window.open('Reports/ReportDocument.aspx?reportName=Quotation&id=' + id);
    }
    
});
