
var app = angular.module('DispatchApp', ['ngRoute', 'ngTagsInput', 'ngProgress']);

// Order Master
app.controller('DispatchController', function ($scope, $http, $window, ngProgressFactory, $location) {

    $scope.progressbar = ngProgressFactory.createInstance();

    $scope.DISPATCH_NOTE = { CLIENT_ID: '0', DELIVERY_ADDRESS: '0', SALE_ORDER_NO: '', SALE_ORDER_DATE: '', DELIVERY_NO: '', DELIVERY_DATE: '', ORDER_ACCEPTANCE_NO: '', ORDER_ACCEPTANCE_DATE: '', DISPATCH_NO: '', DISPATCH_DATE: '', TRASPORTER: '', CNNO: '', DISPATCH_TERM: '', DISPATCH_THROUGH: '', VAHICLE_NO: '', INTERNAL_INSPECTION_BY: '', TP_INSPECTION_BY: '', PREPARE_BY: '', APPROVE_BY: '' };
    $scope.DISPATCH_NOTE_SPECIAL_INSTRUCTION = []; //{ INDEX: '0', SPECIAL_INSTRUCTION: '' };
    $scope.DISPATCH_NOTE_PACKING_INSTRUCTION = []; //{ INDEX: '0', SPECIAL_INSTRUCTION: '' };
    $scope.DISPATCH_NOTE_REMARK = [];
    //console.log('DISPATCH_NOTE_SPECIAL_INSTRUCTION');
    //console.log($scope.DISPATCH_NOTE_SPECIAL_INSTRUCTION);
    //$scope.exporting = true;

    $scope.VariantList = [];
    $scope.VariantList1 = [];

    $scope.tags_product = [];

    $scope.addresslist = [];
    $scope.clientaddresslist = [];
    $scope.ChangeClientDropdown = function () {
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
            $scope.addresslist = success.data.GetAddressData;
            $scope.clientaddresslist = success.data.GetClientAddressData;
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
    // Get ORder Master
    //var GetDeliveryAddress = function () {
    //    $scope.progressbar.start();
    //    var data = $.param({
    //        ACTION: "getaddress"
    //    });
    //    var config = {
    //        headers: {
    //            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
    //            //   'Cross'
    //        }
    //    }
    //    $http({
    //        method: 'POST',
    //        url: '/ControllerServices.asmx/GetDeliveryAddressData',
    //        data: data,
    //        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
    //    }).then(function (success) {
    //        debugger;
    //        $scope.addresslist = success.data.GetAddress;
    //        console.log('Address');
    //        console.log($scope.addresslist);
    //        $scope.progressbar.complete();
    //    }, function (error) {
    //        console.log(error);
    //        window.alert('Failed To Load');
    //    });
    //};
    //GetDeliveryAddress();

    $scope.ChangeOption_DeliveryAddress = function (DELIVERY_ADDRESS) {
        //alert(DELIVERY_ADDRESS);
        if (DELIVERY_ADDRESS == "addnew_del_address")
            $('.DeliveryAddresModal').trigger('click');
    }

    $scope.CUSTOM_DELIVERY_ADDRESS = { ADDRESS: '', MOBILE: '', EMAIL: '' };
    $scope.SaveDeliveryAddress = function (CUSTOM_DELIVERY) {
        debugger;
        if ($(".CLIENT_ID").val() == "0") {
            alert("Client Selection Requied");
            return;
        }
        if (CUSTOM_DELIVERY.ADDRESS == '') {
            alert("Please Enter Delivery Address");
            return;
        }
        if (CUSTOM_DELIVERY.MOBILE == '') {
            alert("Please Enter Mobile No");
            return;
        }
        if (CUSTOM_DELIVERY.EMAIL == '') {
            alert("Please Enter Email Address");
            return;
        }
        
        var detail = $.param({
            type: "insertaddress",
            Client_Id: $(".CLIENT_ID").val(),
            Data: JSON.stringify(CUSTOM_DELIVERY)
        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/InsertDeliveryAddress',
            data: detail,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {

            console.log(success.data);
            alert(JSON.stringify(success.data.ORIGINAL_ERROR));
            // alert(JSON.stringify(success.data.getallproduct));
            //$window.location.reload();
            //console.log('ordermasterlist ');
        }, function (error) {
            console.log(error);

            window.alert('Failed To Load');
        });
    }

    // start : special instruction
    $scope.AddSpecialInstructionTextbox = function () {
        var _atm = {
            INDEX: $scope.DISPATCH_NOTE_SPECIAL_INSTRUCTION.length,
            SPECIAL_INSTRUCTION: ''
        };
        console.log('AddSpecialInstructionTextbox');
        $scope.DISPATCH_NOTE_SPECIAL_INSTRUCTION.push(_atm);
    }

    $scope.RemoveSpecialInstruction = function (sp_ins) {
        console.log(sp_ins);
        var index = $scope.DISPATCH_NOTE_SPECIAL_INSTRUCTION.map(function (dtt) { return dtt.SPECIAL_INSTRUCTION; }).indexOf(sp_ins.SPECIAL_INSTRUCTION);

        $scope.DISPATCH_NOTE_SPECIAL_INSTRUCTION.splice(index, 1);
    }
    // end : special instruction

    // start : special packing instruction
    $scope.AddPackingInstructionTextbox = function () {
        var _atm = {
            INDEX: $scope.DISPATCH_NOTE_PACKING_INSTRUCTION.length ,
            PACKING_INSTRUCTION: ''
        };
        console.log('DISPATCH_NOTE_PACKING_INSTRUCTION');
        $scope.DISPATCH_NOTE_PACKING_INSTRUCTION.push(_atm);
    }

    $scope.RemovePackingInstruction = function (sp_ins) {
        console.log(sp_ins);
        var index = $scope.DISPATCH_NOTE_PACKING_INSTRUCTION.map(function (dtt) { return dtt.PACKING_INSTRUCTION; }).indexOf(sp_ins.PACKING_INSTRUCTION);

        $scope.DISPATCH_NOTE_PACKING_INSTRUCTION.splice(index, 1);
    }

    $scope.AddRemarkTextbox = function () {
        var _atm = {
            INDEX: $scope.DISPATCH_NOTE_REMARK.length,
            REMARK: ''
        };
        console.log('DISPATCH_NOTE_REMARK');
        $scope.DISPATCH_NOTE_REMARK.push(_atm);
    }

    $scope.RemoveRemark = function (sp_ins) {
        console.log(sp_ins);
        var index = $scope.DISPATCH_NOTE_REMARK.map(function (dtt) { return dtt.REMARK; }).indexOf(sp_ins.REMARK);

        $scope.DISPATCH_NOTE_REMARK.splice(index, 1);
    }
    // end : special packing instruction
    
    //var countries = [{ "id": "1", "Name": "GOLDI003PM(3WP)", "Description": "Desc 1", "Unit": "nos", "Mrp": "2017-09-07", "Tax": "5", "SellingPrice": "899", "image": "Resources/product/cctv1.png" },
    //    { "id": "2", "Name": "GOLDI005PM_18S(5WP)", "Description": "Desc 2", "Unit": "nos", "Mrp": "2017-09-07", "Tax": "5", "SellingPrice": "899", "image": "Resources/product/cctv2.jpg" },
    //    { "id": "3", "Name": "GOLDI012PM(10WP)", "Description": "Desc 3", "Unit": "nos", "Mrp": "2017-09-07", "Tax": "5", "SellingPrice": "899", "image": "Resources/product/cctv3.jpg" },
    //    { "id": "6", "Name": "GOLDI012PM_18S(10WP)", "Description": "Desc 4", "Unit": "nos", "Mrp": "2017-09-07", "Tax": "5", "SellingPrice": "999", "image": "Resources/product/cctv1.png" },
    //    { "id": "7", "Name": "GOLDI012PM(12WP)", "Description": "Desc 5", "Unit": "nos", "Mrp": "2017-09-07", "Tax": "5", "SellingPrice": "1000", "image": "Resources/product/02.jpg" },
    //    { "id": "10", "Name": "GOLDI015PM(15WP)", "Description": "testing", "Unit": "nos", "Mrp": "2017-09-07", "Tax": "5", "SellingPrice": "100", "image": "Resources/product/applogo (1).png" },
    //    { "id": "9", "Name": "GOLDI020PM(20WP)", "Description": "Desc 7", "Unit": "nos", "Mrp": "2017-09-07", "Tax": "5", "SellingPrice": "1599", "image": "Resources/product/cctv1.png" }];
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
            Unit: VariantList[VariantList.length - 1].Unit,
            Qty: '1',
            Date: VariantList[VariantList.length - 1].Mrp,
            Tax: VariantList[VariantList.length - 1].Tax,
            ProductRemark: '',
            Amount: parseInt(VariantList[VariantList.length - 1].Mrp) + parseInt(VariantList[VariantList.length - 1].Mrp * VariantList[VariantList.length - 1].Tax / 100),
            ORate: VariantList[VariantList.length - 1].Mrp,
            OAmount: VariantList[VariantList.length - 1].SellingPrice
        };
        $scope.VariantList.push(_atm);
        console.log('changesdtagput');
        console.log($scope.VariantList);
        console.log(VariantList);
    }

    $scope.ChangeRate = function (Variant) {

        $scope.VariantList[Variant].Amount = (parseInt($scope.VariantList[Variant].Rate) + parseInt($scope.VariantList[Variant].Rate * $scope.VariantList[Variant].Tax / 100)) * $scope.VariantList[Variant].Qty;
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


        $scope.VariantList[Variant].Amount = (parseInt($scope.VariantList[Variant].Rate) + parseInt($scope.VariantList[Variant].Rate * $scope.VariantList[Variant].Tax / 100)) * $scope.VariantList[Variant].Qty;




    }


    $scope.RemovedTag = function (tag) {
        debugger;
        console.log(tag.text);
        var index = $scope.VariantList.map(function (img) { return img.text; }).indexOf(tag.Name);
        console.log(index);
        $scope.VariantList.splice(index, 1);
        if ($scope.VariantList == "") {
            //$scope.exporting = true;
        }
    }
    $scope.SaveDispatchNote = function (dispatch) {
        debugger;
        if ($(".CLIENT_ID").val() == "0" || $(".SDATE").val() == "0" || $(".DELIVERY_ADDRESS").val() == "0" || $(".DELIVERY_ADDRESS").val() == "addnew_del_address" || $(".DEDATE").val() == "0" || dispatch.SORDER == '' || dispatch.DENO == '') {
            alert("All Field Requied");
            $scope.SEARCH_USER.MESSAGE = "*";
            return;
        }
        //$scope.HTMLPDF = document.getElementById("dvTable").innerHTML;
        $scope.exporting = true;
        $(".gifloader").html('<img src="/gg-admin/img/Rolling.gif" />');
        var detail = $.param({
            type: "dispatchnote",
            Data: JSON.stringify($scope.VariantList),
            DISPATCH_DATA: JSON.stringify(dispatch),
            SpecialInstructionData: JSON.stringify($scope.DISPATCH_NOTE_SPECIAL_INSTRUCTION),
            PackingInstructionData: JSON.stringify($scope.DISPATCH_NOTE_PACKING_INSTRUCTION),
            Remark: JSON.stringify($scope.DISPATCH_NOTE_REMARK),
            QID: $(".CLIENT_ID").val(),
            DELIVERY_ADDRESS: $(".DELIVERY_ADDRESS").val(),
            SALE_ORDER_DATE: $(".SALE_ORDER_DATE").val(),
            DELIVERY_DATE: $(".DELIVERY_DATE").val(),
            ORDER_ACCEPTANCE_DATE: $(".ORDER_ACCEPTANCE_DATE").val(),
            DISPATCH_DATE: $(".DISPATCH_DATE").val()
        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/InsertDispatchNote',
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

    $scope.dispatchnotelist = [];
    // Get ORder Master
    var GetDispatchNote = function () {
        $scope.progressbar.start();
        var data = $.param({
            ACTION: "getdispatchdata"
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/ControllerServices.asmx/GetDispatchNoteData',
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
        });
    };
    GetDispatchNote();

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
});
