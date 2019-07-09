
var appp = angular.module('ProductEditApp', ['ngRoute', 'flow', 'ngAnimate', 'ngProgress', 'ngTagsInput']);
appp.service('DataService', function () {
    this.msg = null;
});
appp.filter('split', function () {
    return function (input, splitChar, splitIndex) {
        // do some bounds checking here to ensure it has that index
        return input.split(splitChar)[splitIndex];
    }
});
appp.service("MyService", function ($http) {
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

appp.directive('ngFiles', ['$parse', function ($parse) {
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


appp.directive('fileModel', ['$parse', function ($parse) {
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
appp.directive('ngConfirmClick', [
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

appp.service('fileUpload', ['$http', function ($http) {
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


appp.controller('ProductEditController', function ($window, $scope, $rootScope, $http, DataService, fileUpload, $timeout, ngProgressFactory) {

    var getUrlParameter = function (param, dummyPath) {

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

    var ProductId = getUrlParameter('ProductId');

    $scope.product = [];

    $scope.GetProductDetail = function () {

        var data = $.param({
            type: "productdetail",
            ProductId: ProductId
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/GetProductDetail',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            $scope.product = success.data;
            console.log($scope.product);
            $scope.progressbar.complete();
        }, function (error) {

        });
    };
    $scope.GetProductDetail();

    $scope.EditPrdSp = false;
    $scope.tagVariant = [];
    $scope.Attr_RowId = "";
    $scope.Edit_tagVariant = [];
    $scope.EditProductSpecification = function (atm) {
        $scope.EditPrdSp = true;
        $scope.tagVariant = [];
        // alert();
        //S$scope.Attr_RowId = index;
        console.log(atm);
        console.log(atm.Value);
        $scope.txtOptionName = atm.OptionName;
        var value = JSON.stringify(atm.Value);
        for (var i = 0; i < atm.Value.length; i++) {
            //alert(atm.Value[i].text);
            var _atm = {
                text: atm.Value[i].text
            };
            debugger;
            $scope.tagVariant.push(_atm);
        }
        $scope.Edit_tagVariant = atm;
        //$scope.tagVariant = [{ "text": "asd", "$$hashKey": "object:147" }, { "text": "las", "$$hashKey": "object:148" }, { "text": "d", "$$hashKey": "object:149" }, { "text": "a", "$$hashKey": "object:150" }, { "text": "sd", "$$hashKey": "object:151" }];
        debugger;
        //$scope.tagVariant = JSON.stringify(atm.Value);
        //$scope.tagVariant = eventstring;

        //alert($scope.tagVariant);
        $('.productspecification_modal').trigger('click');
        //$scope.$apply();
        //[{ "text": "2131", "$$hashKey": "object:97" }, { "text": "1", "$$hashKey": "object:98" }, { "text": "23", "$$hashKey": "object:99" }, { "text": "123123", "$$hashKey": "object:100" }]
    }

    //update product specification 
    $scope.UpdateAttributeMaster = function () {
        debugger;
        var _index = $scope.AttributeMasterList.indexOf($scope.Edit_tagVariant);
        //alert(_index);
        $scope.AttributeMasterList.splice(_index, 1);
        $scope.AttributeMasterList = $scope.AttributeMasterList;

        $scope.SaveAttributeMaster();


    }

    $scope.Edit_ProductAttribute = [];
    $scope.EditPrdAttribute = false;
    $scope.EditProductAttribute = function (atm) {
        //alert();
        $scope.EditPrdAttribute = true;
        $scope.VariantList = [];
        $scope.VariantList1 = [];
        // alert();
        //S$scope.Attr_RowId = index;
        console.log(atm);
        console.log(atm.Attribute);
        $scope.OptionName = atm.OptionName;
        $scope.ddlControlType.Value = atm.ControlType;

        //alert(atm.ControlType);

        var value = JSON.stringify(atm.Attribute);
        for (var i = 0; i < atm.Attribute.length; i++) {
            // alert(atm.Attribute[i].text);
            var _atm = {
                OptionName: atm.OptionName,
                text: atm.Attribute[i].text,
                Quantity: atm.Attribute[i].Quantity,
                Price: atm.Attribute[i].Price,
                OldPrice: atm.Attribute[i].OldPrice,
                ProductCost: '0',
                Barcode: '',
                Image: '',
                IsPreSelected: atm.Attribute[i].IsPreSelected
            };
            var _atm1 = {
                text: atm.Attribute[i].text
            };

            $scope.VariantList.push(_atm);
            $scope.VariantList1.push(_atm1);
        }
        $scope.Edit_ProductAttribute = atm;
        debugger;
        //alert($scope.tagVariant);
        $('.productattribute_modal').trigger('click');
        //$scope.$apply();
        //[{ "text": "2131", "$$hashKey": "object:97" }, { "text": "1", "$$hashKey": "object:98" }, { "text": "23", "$$hashKey": "object:99" }, { "text": "123123", "$$hashKey": "object:100" }]
    }


    //update product specification 
    $scope.UpdateAttribute = function () {
        debugger;
        var _index = $scope.AllAttributeList.indexOf($scope.Edit_ProductAttribute);
        //alert(_index);
        $scope.AllAttributeList.splice(_index, 1);
        $scope.AllAttributeList = $scope.AllAttributeList;

        $scope.SaveAttribute();


    }



    //Start Product Specification
    $scope.AttributeMasterList = [];

    $scope.GetProductSpecification = function () {
        var data = $.param({
            type: "specification",
            ProductId: ProductId
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/GetProductSpecification',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            $scope.AttributeMasterList = success.data;
            console.log($scope.AttributeMasterList);
            $scope.progressbar.complete();
        }, function (error) {

        });
    };
    $scope.GetProductSpecification();
    //End Product Specification

    //Start Product Attribute
    $scope.AllAttributeList = [];
    $scope.GetAllProductAttribute = function () {
        var data = $.param({
            type: "productattribute",
            ProductId: ProductId
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/GetAllProductAttribute',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            $scope.AllAttributeList = success.data;
            console.log($scope.AllAttributeList);
            $scope.progressbar.complete();
        }, function (error) {

        });
    };
    $scope.GetAllProductAttribute();
    //End Product Attribute


    $scope.Controls = [{
        Value: "0",
        Name: 'Select Control Type'
    },
    {
        Value: "checkbox",
        Name: 'Multiple Selection'
    }, {
        Value: "radio",
        Name: 'Single Selection'
    }];

    $scope.ddlControlType = $scope.Controls[0];
    //get Material Master
    $scope.material = [];
    var getMaterialMaster = function () {
        var data = $.param({
            type: "getmaterial",
        });
        debugger;
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/getMaterialMaster',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            $scope.material = success.data;
            debugger;

            console.log('getMaterialMaster');
            console.log($scope.material);
            $scope.progressbar.complete();
        }, function (error) {
            debugger;
        });
    };
    getMaterialMaster();




    $scope.Attr_RowId = "";
    $scope.OpenPopupFor_modalAttributeValue = function (index) {
        // alert(index);
        $scope.Attr_RowId = index;

        $('.modalAttributeValue' + index).trigger('click');
    }


    $scope.AttributeValueList = [];
    $scope.categoryname = [];
    $scope.attributemaster = [];
    $scope.product = [];
    $scope.Fruits = [{
        Id: "1",
        Name: "Apple"
    }, {
        Id: '2',
        Name: 'Mango'
    }, {
        Id: '3',
        Name: 'Orange'
    }];





    var data = $.param({
        type: "CategoryName",
    });
    var config = {
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            //   'Cross'
        }
    }
    $http({
        method: 'POST',
        url: '/AdminOperation.asmx/GetCategoryName',
        data: data,
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
    }).then(function (success) {
        $scope.categoryname = success.data;
        console.log($scope.categoryname);
        $scope.progressbar.complete();
    }, function (error) {

    });

    $scope.Fruits = $scope.categoryname;
    console.log($scope.Fruits);
    $scope.progressbar = ngProgressFactory.createInstance();

    $scope.color = 'firebrick';
    $scope.height = '5px';
    $scope.progressbar.start();

    $timeout(function () {
        $scope.progressbar.complete();
        //  $scope.show = true;
    }, 1000);


    //alert('prod');
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

    //EditCategoty
    var DisplayCategory = function () {

        var data = $.param({
            type: "CategoryName",
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }

        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/GetCategoryName',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            $scope.categoryname = success.data;
            console.log($scope.categoryname);
            $scope.progressbar.complete();
        }, function (error) {

        });
    };


    // Get Attribute Master
    var DisplayAttributeMaster = function () {
        var data = $.param({
            type: "attributemaster",
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/GetAttributeMaster',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            $scope.attributemaster = success.data;
            console.log('Attribute Master ');
            console.log($scope.attributemaster);
            $scope.progressbar.complete();
        }, function (error) {

        });
    };
    DisplayAttributeMaster();
    // DisplayCategory();


    // Save Atttribute Master

    $scope.SaveAttributeMaster = function () {
        //console.log($scope.tagVariant);
        //console.log($scope.txtOptionName);
        //console.log(JSON.stringify($scope.tagVariant));

        var _atm = {
            OptionName: $scope.txtOptionName,
            Value: $scope.tagVariant,
            DisplayOrder: $scope.txtDisplayOrder
        };

        $scope.AttributeMasterList.push(_atm);
        console.log('Added Attribute Master : ');
        console.log($scope.AttributeMasterList);
        $('.notifications').trigger('click');
        $('.closemodal_variant').trigger('click');
    };

    // click To Add Attirbute Value

    $scope.AddAttributeValue = function () {
        //   alert();
        var _atm = {
            AttributeMasterId: "",
            AttributeValue: "",
            AttributeValue_DisplayOrder: ""
        };
        $scope.editattr = true;
        $scope.AttributeValueList.push(_atm);
    };
    var i = 1;
    // Save Atttribute Value

    $scope.SaveAttributeValue = function (AttrMapping_Id) {
        $scope.editattr = false;
        var _atm = {
            Id: $scope.AttributeValueList.length + 1,
            AttributeMapping_Id: AttrMapping_Id,
            AttributeMasterId: $scope.ddlAttributeMaster.ID,
            AttributeValue: $scope.txtAttributeValue,
            AttributeValue_DisplayOrder: $scope.txtAttributeValue_DisplayOrder
        };
        console.log(_atm);
        $scope.AttributeValueList.push(_atm);
        console.log('Added Attribute Value : ');
        console.log($scope.AttributeValueList);
        $('.notifications').trigger('click');
    };


    // For File Uploading
    $scope.files = [];

    $scope.browseClick = function () {
        // debugger;
        // $window.alert("Select File");
        $scope.btnSubStatus = false;
    }

    var formdata = new FormData();
    $scope.getTheFiles = function ($files) {
        debugger;
        angular.forEach($files, function (value, key) {
            formdata.append(key, value);
        });
        $scope.files = $files;
    };

    var formdata_sizechart = new FormData();
    $scope.getTheProductChartFiles = function ($files) {
        debugger;
        angular.forEach($files, function (value, key) {
            formdata_sizechart.append(key, value);
        });
        $scope.files = $files;
    };
    $scope.BARCODE = "";
    $scope.GenerateProductBarcode = function () {
        var data = $.param({
            type: "generatebarcode",
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/GenerateProductBarcode',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            $scope.BARCODE = success.data;
            console.log($scope.BARCODE);
        }, function (error) {
            console.log(error);
            $window.alert('Failed To Generate ! ');
        });
    }

    $scope.GenerateProductVariantBarcode = function (Variant) {
        console.log(Variant);
        var data = $.param({
            type: "generatebarcode",
        });
        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
            }
        }
        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/GenerateProductVariantBarcode',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            Variant.Barcode = success.data;

            console.log($scope.BARCODE);
        }, function (error) {
            console.log(error);
            $window.alert('Failed To Generate ! ');
        });
    }




    //$scope.Var = [{ Quantity: '', Price: '', OldPrice: '', ProductCost: '', Barcode: '' }];
    $scope.VariantList = []; //[{ text: 'Size', Quantity: '', Price: '', OldPrice: '', ProductCost: '', Barcode: '' }];
    $scope.OptionName = "";
    $scope.VariantList1 = [];

    $scope.SaveAttribute = function () {
        var _atm = {
            AttributeId: $scope.AllAttributeList.length + 1,
            OptionName: $scope.OptionName,
            ControlType: $scope.ddlControlType.Value,
            Attribute: $scope.VariantList
        };
        console.log('all attribute');
        $scope.AllAttributeList.push(_atm);
        console.log($scope.AllAttributeList);
        $('.closemodal_variant').trigger('click');
    }
    $scope.AttributeTag = [];
    $scope.ChangedTagInput = function (VariantList) {
        var _atm = {
            OptionName: $scope.OptionName,
            text: VariantList[VariantList.length - 1].text,
            Quantity: '0',
            Price: '0',
            OldPrice: '0',
            ProductCost: '0',
            Barcode: '',
            Image: '',
            IsPreSelected: '0'
        };
        $scope.VariantList.push(_atm);

        console.log($scope.VariantList);
        console.log(VariantList);
    }
    $scope.RemovedTag = function (tag) {
        console.log(tag.text);
        var index = $scope.VariantList.map(function (img) { return img.text; }).indexOf(tag.text);
        console.log(index);
        $scope.VariantList.splice(index, 1);
    }
    //Product Packaging
    $scope.PRODUCT_PACKAGING_SELECT_BOX = [
                             {
                                 'name': 'None',
                                 'value': '0'
                             },
                               {
                                   'name': 'Pair(pr)',
                                   'value': 'pr'
                               },
                               {
                                   'name': 'Packet(pkt)',
                                   'value': 'pkt'
                               },
                               {
                                   'name': 'Piece(pc)',
                                   'value': 'pc'
                               }
    ];
    //$scope.PRODUCT_PACKAGING = $scope.PRODUCT_PACKAGING_SELECT_BOX[0].value;
    $scope.PRODUCT_PACKAGING = $scope.PRODUCT_PACKAGING_SELECT_BOX[0].value;

    $scope.Product = [];
    $scope.PRODUCT_PACKAGING = "0";
    $scope.ddlMaterial = "0";
    $scope.ddlBrand = "0";
    $scope.UpdateProduct = function (product) {
        console.log(product);
        var cities = $('#cities').val();
        //  alert(cities);
        $scope.progressbar.start();
        var lb = $('#lbCategory option:selected');
        console.log(lb);

        debugger;
        var cat_id = "";
        var cat_name = "";
        if (lb.length > 0) {
            for (var i = 0; i < lb.length; i++) {
                cat_id = cat_id + lb[i].value + ",";
                cat_name = cat_name + lb[i].text + ",";
            }
        }
        else {
            $window.alert('Please Select Atleast One Category ! ');
            $scope.progressbar.complete();
            return;
        }

        // get Pin Code Seleted Values
        var lbpin = $('#lbPinCode option:selected');
        var pin_id = "";
        var pin_code = "";
        for (var i = 0; i < lbpin.length; i++) {
            pin_id = pin_id + lbpin[i].value + ",";
            pin_code = pin_code + lbpin[i].text + ",";
        }

        //return $sce.trustAsHtml($scope.snippet);
        var long_desc = [];
        long_desc = {
            Content: $("#long_desc").val()
        };


        var LongDesc = $("#long_desc").val();//$scope.LongDesc; // JSON.stringify(long_desc);
        //   alert(LongDesc);

        var ProductName = product.NAME;
        var ShortDesc = product.SHORT_DISC;
        //  var LongDesc = $scope.LongDesc;
        var StockQuantity = product.STOCK_QTY;
        var Price = product.PRICE;
        var OldPrice = product.OLD_PRICE;
        var ProductCost = product.PRODUCT_COST;
        var SKU = product.SKU;
        //   var GTIN = $scope.GTIN;

        var Display = product.STATUS;
        var Display_Order = 1;
        // var IsNew = $scope.IsNew;
        var AttributeMasterList = JSON.stringify($scope.AttributeMasterList);
        var AllAttributeList = JSON.stringify($scope.AllAttributeList);

        var message = "";

        // debugger;

        var config = {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                //   'Cross'
            }
        }
        console.log('Product : ');
        console.log(data);
        //debugger;

        //upload Size Chart
        $scope.SizeChartImage = '';
        var SizeChartImage = "";





        debugger;

        var request = {
            method: 'POST',
            url: '/AdminOperation.asmx/UploadProductImage',
            data: formdata,
            headers: {
                'Content-Type': undefined
            }
        };


        debugger;
        var data = $.param({
            ProductName: ProductName,
            ShortDesc: ShortDesc,
            LongDesc: LongDesc,
            Price: Price,
            OldPrice: OldPrice,
            SKU: SKU,
            // GTIN: GTIN,
            //ShowOnPage: ShowOnPage,
            Display: Display,
            //  IsNew: IsNew,
            VariantList: AttributeMasterList,
            //  AttributeValueList: AttributeValueList,
            StockQuantity: StockQuantity,
            ProductCost: ProductCost,
            Display_Order: Display_Order,
            CategoryId: cat_id,
            //  MainAttributeList: MainAttributeList,
            ProductImage: "",
            SizeChartImage: "",
            PinCodeId: pin_id,
            NETWEIGHT: product.WEIGHT,
            // PRODUCT_UNIT: PRODUCT_UNIT,
            //    PRODUCT_PACKAGING: PRODUCT_PACKAGING,
            BARCODE: product.BARCODE,
            PRODUCT_EXPIRY: product.PRODUCT_EXPIRY,
            BRAND_ID: product.BRAND_ID,
            MATERIAL_ID: product.MATERIAL_ID,
            AllAttributeList: AllAttributeList,
            //UrlKey: $scope.UrlKey,
            MetaKeyword: product.META_KEYWORD,
            MetaTitle: product.META_TITLE,
            MetaDescription: product.META_DESCRIPTION,
            IS_SOFA: product.IS_SOFA,
            PRODUCT_ID: ProductId

            // PRODUCT_VARIANT: PRODUCT_VARIANT
        });
        debugger;

        $http({
            method: 'POST',
            url: '/AdminOperation.asmx/UpdateProduct',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success);
            DataService.msg = success.data;
            $scope.progressbar.complete();
            debugger;

            $(".notifications").attr("data-custommessage", "Product Updated Successfully ! We are Redirecting to Add Multiple Images of This Product/Attribute");
            $('.notifications').trigger('click');

            setInterval(function ()
            { window.location = "ProductImages.aspx?ProductId=" + success.data; }, 4000);

        }, function (error) {
            debugger;
            console.log(error);
            $scope.progressbar.complete();
            $window.alert('Failed To Save ! ');

            //$('.closemodal').trigger('click');
        });

        //    $http.post("Product/AddProduct", PrdData)
        //        .success(function (respond) {
        //            debugger;
        //            $scope.Product = {};
        //            document.getElementById("fileImg").value = null;
        //            $window.alert(respond);
        //        })
        //        .error(function (respond) {
        //            debugger;
        //            $window.alert(respond);
        //        });
        //})
        //.error(function () {
        //});



        console.log($scope.successMessage);
    };

    //Delete Prdocut

    $scope.DeleteProduct = function (ID) {
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
            url: '/AdminOperation.asmx/DeleteProduct',
            data: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        }).then(function (success) {
            console.log(success);
            DataService.msg = success.data;
            $('.deletenotifications').trigger('click');
            GetAllProducts();
        }, function (error) {
            console.log(error);
        });
        console.log($scope.successMessage);
    };



    $scope.DeleteAttributeValue = function (avl) {

        //$scope.progressbar.start();
        var _index = $scope.AttributeValueList.indexOf(avl);
        $scope.AttributeValueList.splice(_index, 1);

        console.log($scope.successMessage);
    };

    $scope.ProductList_PID = "";
    $scope.OpenPopupFor_UploadSizeChartImage = function (pid) {

        // alert(pid);
        $scope.ProductList_PID = pid;
        //$window.alert($scope.Attr_RowId);
        //    $('.UploadSizeChartImage').trigger('click');
    }

    $scope.ProductList_PID = "";
    $scope.OpenPopupFor_UploadProductImage = function (pid) {

        // alert(pid);
        $scope.ProductList_PID = pid;
        //$window.alert($scope.Attr_RowId);
        //    $('.UploadSizeChartImage').trigger('click');
    }



    $scope.UploadSizeChartImage = function () {
        var ProductId = $scope.ProductList_PID;
        var FileUploadCtrl = document.getElementById("fileImg");
        var FilePath = FileUploadCtrl.value;
        var Ext = FilePath.substring(FilePath.lastIndexOf('.') + 1).toLowerCase();
        debugger;
        if (Ext == "jpg" || Ext == "png" || Ext == "jpeg") {
            var request = {
                method: 'POST',
                url: '/AdminOperation.asmx/UploadProductSizeChart',
                data: formdata,
                headers: {
                    'Content-Type': undefined
                }
            };
            $http(request).then(function (success) {
                console.log(success);
                $('.notifications').trigger('click');
                var data = $.param({
                    type: "upload",
                    Imagename: success.data,
                    ProductId: ProductId
                });

                $http({
                    method: 'POST',
                    url: '/AdminOperation.asmx/UpdateSizeChartImage',
                    data: data,
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                }).then(function (success) {
                    console.log(success);
                    DataService.msg = success.data;
                    $('.notifications').trigger('click');

                    $('.closemodal').trigger('click');
                    GetAllProducts();
                }, function (error) {
                    console.log(error);
                });


            }, function (error) {
                console.log(error);
            });
            console.log($scope.successMessage);
        }
        else if (Ext == '') {
            alert("You have not Selected Image Yet....Please Select Image to Upload");
        }
        else {
            alert("Only Image File Allowed.!");
            document.getElementById("fileImg").value = null;
            return false;
        }
    };

    //Delete Master Attribute 

    $scope.DeleteAttributeMaster = function (atm) {
        //$scope.progressbar.start();
        var _index = $scope.AllAttributeList.indexOf(atm);
        $scope.AllAttributeList.splice(_index, 1);
        $scope.AllAttributeList = $scope.AllAttributeList;
        console.log($scope.AllAttributeList);
        $scope.$apply();
    };
    $scope.DeleteProductSpecification = function (atm) {
        //$scope.progressbar.start();
        var _index = $scope.AttributeMasterList.indexOf(atm);
        $scope.AttributeMasterList.splice(_index, 1);
        $scope.AttributeMasterList = $scope.AttributeMasterList;
        console.log($scope.AttributeMasterList);
        $scope.$apply();
    };



    $scope.UpdateProductImage = function () {
        var ProductId = $scope.ProductList_PID;
        var FileUploadCtrl = document.getElementById("ProductImage");
        var FilePath = FileUploadCtrl.value;
        var Ext = FilePath.substring(FilePath.lastIndexOf('.') + 1).toLowerCase();
        debugger;
        if (Ext == "jpg" || Ext == "png" || Ext == "jpeg") {
            var request = {
                method: 'POST',
                url: '/AdminOperation.asmx/UploadProductImage',
                data: formdata,
                headers: {
                    'Content-Type': undefined
                }
            };
            $http(request).then(function (success) {
                console.log(success);
                $('.notifications').trigger('click');
                var data = $.param({
                    type: "upload",
                    Imagename: success.data,
                    ProductId: ProductId
                });

                $http({
                    method: 'POST',
                    url: '/AdminOperation.asmx/UpdateProductImage',
                    data: data,
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                }).then(function (success) {
                    console.log(success);
                    DataService.msg = success.data;
                    $('.notifications').trigger('click');

                    $('.closemodal').trigger('click');
                    GetAllProducts();
                }, function (error) {
                    alert('Failed To Upload');
                    console.log(error);
                });


            }, function (error) {
                alert('Failed To Upload');
                console.log(error);
            });
            console.log($scope.successMessage);
        }
        else if (Ext == '') {
            alert("You have not Selected Image Yet....Please Select Image to Upload");
        }
        else {
            alert("Only Image File Allowed.!");
            document.getElementById("ProductImage").value = null;
            return false;
        }
    };


});