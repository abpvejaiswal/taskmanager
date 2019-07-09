
var app = angular.module('OrderAcceptanceApp', ['ngRoute', 'ngTagsInput', 'ngProgress']);

// Order Master
app.controller('OrderAcceptanceController', function ($scope, $http, $window, ngProgressFactory) {

    $scope.progressbar = ngProgressFactory.createInstance();
    //$scope.exporting = true;
    debugger;
    $scope.VariantList = [];
    $scope.VariantList1 = [];
    $scope.addresslist = [];
    $scope.clientaddresslist = [];
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

    $scope.Changetotalstock = function (Variant) {


        $scope.stocklist[Variant].total = (parseInt($scope.stocklist[Variant].stockgoldi) + parseInt($scope.stocklist[Variant].stockkanpur) + parseInt($scope.stocklist[Variant].stockchakan) + parseInt($scope.stocklist[Variant].stockkalamboli));
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
    
    $scope.loadCountries = function ($query) {
        return countries.filter(function (country) {
            return country.Name.toLowerCase().indexOf($query.toLowerCase()) != -1;
        });
    };
    
    $scope.ChangedTagInput = function (VariantList) {
        debugger;
        $scope.exporting = false;
        var _atm = {
            OptionName: $scope.OptionName,
            text: VariantList[VariantList.length - 1].Name,
            pid: VariantList[VariantList.length - 1].id,
            
            Qty: '1',
            Date: '',

        };
        
        $scope.VariantList.push(_atm);
        console.log('changesdtagput');
        console.log($scope.VariantList);
        console.log(VariantList);
    }

    $scope.RemovedTag = function (tag) {
        debugger;
        console.log(tag.text);
        var index = $scope.VariantList.map(function (img) { return img.text; }).indexOf(tag.Name);
        console.log(index);
        $scope.VariantList.splice(index, 1);

    }

    $scope.SpecialInslist = [];
    //$scope.Total = $scope.VariantList[0].Amount;
    $scope.AddInstructionTextBox = function (number) {
        debugger;
        $scope.exporting = false;
        var _atm = {
           
            INSTRUCTION_ID: $scope.SpecialInslist.length + 1,
            INSTRUCTION_TEXT: '',

        };

        $scope.SpecialInslist.push(_atm);
        console.log('addinputtag');
        console.log($scope.SpecialInslist);
    }
    $scope.RemoveInstructionTextBox = function (tag) {
        debugger;
        console.log(tag.text);
        var index = $scope.SpecialInslist.map(function (id) { return id.INSTRUCTION_ID; }).indexOf(tag.INSTRUCTION_ID);
        console.log(index);
        $scope.SpecialInslist.splice(index, 1);

    }

    $scope.ORDER = { CLIENT_ID: '0', CADDRESS: '0', DADDRESS: '0', PNO: '', PDATE: '', PONO: '', PODATE: '', OANO: '', OADATE: '', INSPECT: '', INSURANCE: '', DISPATCH: '', TRASPORTER: '', PREPARE_BY: '', APPROVE_BY: '' };
    $scope.SEARCH_USER = { MESSAGE: '' };

    $scope.SaveOrder = function (order) {
        debugger;
        if ($(".CLIENT_ID").val() == "0" || $(".CADDRESS").val() == "0" || $(".DADDRESS").val() == "0" || order.PNO == '' || order.PONO == '' || order.OANO == '' || $(".PDATE").val() == '' || $(".PODATE").val() == '' || $(".OADATE").val() == '' || order.INSPECT == '' || order.INSURANCE == '' || order.DISPATCH == '' || order.TRASPORTER == '') {
            alert("All Field Requied");
            $scope.SEARCH_USER.MESSAGE = "*";
            return;
        }
        //$scope.HTMLPDF = document.getElementById("dvTable").innerHTML;
        $scope.exporting = true;
        $(".gifloader").html('<img src="/gg-admin/img/Rolling.gif" />');
        var detail = $.param({
            type: "insertorder",
            Data: JSON.stringify($scope.VariantList),
            ORDER_DATA: JSON.stringify(order),
            SpecialInstructionData: JSON.stringify($scope.SpecialInslist),
            QID: $(".CLIENT_ID").val(),
            CADDRESS: $(".CADDRESS").val(),
            DADDRESS: $(".DADDRESS").val(),
            PDATE: $(".PDATE").val(),
            PODATE: $(".PODATE").val(),
            OADATE: $(".OADATE").val()
        });
        $http({

            method: 'POST',
            url: '/ControllerServices.asmx/InsertOrderData',
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
    $scope.orderacceptancelist = [];
     
    var GetOrderMaster = function () {
        $scope.progressbar.start();
        debugger;
        var data = $.param({
            ACTION: "getorderdata"
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/ControllerServices.asmx/GetOrderAcceptanceData',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            debugger;
            $scope.orderacceptancelist = success.data.GetOrderData;
            console.log('orderacceptancelist');
            console.log($scope.orderacceptancelist);
            $scope.progressbar.complete();
        }, function (error) {
            console.log(error);
            window.alert('Failed To Load');
        });
    };
    GetOrderMaster();
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

    //$scope.DeleteQuotation = function (id) {
    //    debugger;


    //    //$scope.HTMLPDF = document.getElementById("dvTable").innerHTML;

    //    var detail = $.param({
    //        type: "deletequotation",
    //        qid: id

    //    });
    //    $http({

    //        method: 'POST',
    //        url: '/ControllerServices.asmx/DeleteQuotationData',
    //        data: detail,
    //        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
    //    }).then(function (success) {
    //        debugger;
    //        console.log(success.data);

    //        alert(JSON.stringify(success.data.ORIGINAL_ERROR));
    //        $window.location.reload();


    //    }, function (error) {
    //        console.log(error);
    //        debugger;
    //        window.alert('Failed To Load');

    //    });
    //}
});
