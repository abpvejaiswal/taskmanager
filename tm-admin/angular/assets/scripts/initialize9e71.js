var App = {
	name:"myApp",
	hostKey:"jdomni",
	socketUrl:"http://apps.jdomni.com/notifyUsers",
	socketConnected:false,
	Common:{
		Controller:{}
	},
	production:"true",
	keys : {
			TAB: 'tab',
			ENTER:'enter',
			ESC:'esc',
			LEFT_ARROW:'leftArrow',
			RIGHT_ARROW:'rightArrow',
			UP_ARROW: 'upArrow',
			DOWN_ARROW: 'downArrow',
			DELETE:'delete',
			N:'n',
			Y:'y'
	},
	type:"PRODUCT",
	revisionNo:"69316-170217-2032"
};

/*
	It will add dependency to current angular app.

*/

App.addModule = function(strName){
	var app = angular.module(App.name);
	app.requires.push(strName);
}

App.keyboardNavigation = {
	"9":App.keys.TAB,
	"13":App.keys.ENTER,
	"27":App.keys.ESC,
	"37":App.keys.LEFT_ARROW,
	"38":App.keys.UP_ARROW,
	"39":App.keys.RIGHT_ARROW,
	"40":App.keys.DOWN_ARROW,
	"46":App.keys.DELETE,
	"78":App.keys.N,
	"89":App.keys.Y	
};
/**
 * Object for change the content of Coming Soon page.
 * 		@iconClass : class to be shown on Middle of the page.
 * 		@headerString : header bread crumb comma separated.
 * 		@headerLinks : header link comma separated (if any).
 * 		@parentPageId : pageid of the left menu link that has to be highlight and sub menu open (From leftmenu.json).
 * 		@pageId : pageid of the left sub menu that has to be highlight (From leftmenu.json).
 */
App.comingSoonModules = {
	"Privilegemembership" : {
								"iconClass" : 'icon-Privilege_Membership',
								"headerString" : "Customers,Privilege Membership",
								"headerLinks" : "#/customer/customerLandingPage",
								"parentPageId" : 'salesMenu',
								"pageId" : 'customerLandingPage'
							},
	"AddSupplierBankDetails" : {
								"iconClass" : 'icon-bank',
								"headerString" : "Suppliers,Add Supplier Bank Details",
								"headerLinks" : "#/vendor/supplierLandingPage",
								"parentPageId" : 'stockMenu',
								"pageId" : 'manageSupplier'
							},
	"EnterMissingMRP" : {
								"iconClass" : "icon-entermissingMRP",
								"headerString" : "Quick Start,Enter Missing MRP",
								"headerLinks" : "#/quickStart/manage",
								"parentPageId" : 'manageQuickStart',
								"pageId" : 'manageQuickStart'
						},						
	"EnterMissingCostPrice" : {
								"iconClass" : "icon-entermissingCp",
								"headerString" : "Quick Start,Enter Missing Cost Price",
								"headerLinks" : "#/quickStart/manage",
								"parentPageId" : 'manageQuickStart',
								"pageId" : 'manageQuickStart'
						},
	"SetDiscountRules" : {
								"iconClass" : "icon-no_discount",
								"headerString" : "Quick Start,Set Discount Rules",
								"headerLinks" : "#/quickStart/manage",
								"parentPageId" : 'manageQuickStart',
								"pageId" : 'manageQuickStart'
						},
	"EditSellingPrice" : {
								"iconClass" : "icon-Transactions",
								"headerString" : "Quick Start,Edit Selling Price",
								"headerLinks" : "#/quickStart/manage",
								"parentPageId" : 'manageQuickStart',
								"pageId" : 'manageQuickStart'
						},
	"EditZeroStockQuantity" : {
								"iconClass" : "icon-missing_stock",
								"headerString" : "Quick Start,Edit Zero Stock Quantity",
								"headerLinks" : "#/quickStart/manage",
								"parentPageId" : 'manageQuickStart',
								"pageId" : 'manageQuickStart'
						},
	"AddLoyaltyRewards" : {
								"iconClass" : "icon-rewards",
								"headerString" : "Quick Start,Add Loyalty Rewards",
								"headerLinks" : "#/quickStart/manage",
								"parentPageId" : 'manageQuickStart',
								"pageId" : 'manageQuickStart'
						},
	"SendCampaignToCustomers" : {
								"iconClass" : "icon-promotion",
								"headerString" : "Quick Start,Send Campaign To Customers",
								"headerLinks" : "#/quickStart/manage",
								"parentPageId" : 'manageQuickStart',
								"pageId" : 'manageQuickStart'
						},
	"DeliverySetup" : {
								"iconClass" : "icon-delivery_setup",
								"headerString" : "Quick Start,Delivery Setup",
								"headerLinks" : "#/quickStart/manage",
								"parentPageId" : 'manageQuickStart',
								"pageId" : 'manageQuickStart'
						},
	"TrackDelivery" : {
								"iconClass" : "icon-location",
								"headerString" : "Quick Start,Track Delivery",
								"headerLinks" : "#/quickStart/manage",
								"parentPageId" : 'manageQuickStart',
								"pageId" : 'manageQuickStart'
						},
	"IntelligentPO" : {
								"iconClass" : 'icon-Intelligent_PO',
								"headerString" : "Purchases,Intelligent PO",
								"headerLinks" : "#/purchase/purchaseOrderLandingPage",
								"parentPageId" : 'stockMenu',
								"pageId" : 'purchaseOrder'
							},
	"officeAdmin" : {
								"iconClass" : 'icon-Officeadmin',
								"headerString" : "Office Admin",
								"headerLinks" : "",
								"parentPageId" : "supportMenu",
								"pageId" : "officeAdmin"
							},
	"accounting" : {
								"iconClass" : 'icon-Accounting',
								"headerString" : "Accounting",
								"headerLinks" : "",
								"parentPageId" : "supportMenu",
								"pageId" : "accounting"
							},
	"delivery" : {
								"iconClass" : 'icon-Intelligent_PO',
								"headerString" : "Delivery",
								"parentPageId" : "salesMenu",
								"pageId" : "delivery"
							},	
	"taxation" : {
								"iconClass" : 'icon-Taxation',
								"headerString" : "Taxation",
								"headerLinks" : "",
								"parentPageId" : "supportMenu",
								"pageId" : "taxation"
							},
	"uploadCustomerListExcel" : {
								"iconClass" : 'icon-people-group',
								"headerString" : "Quick Start,Upload Customers List Excel",
								"headerLinks" : "#/quickStart/manage",
								"parentPageId" : "manageQuickStart",
								"pageId" : "manageQuickStart"
							} 
}
var POS = {
	RouteController:function($scope,outletData){
		$scope.accounts = outletData.outlets;
	}
};
var PUV = {
		CheckboxAutosuggest:{}
};
var SellerAdmin = {
	Controller:{
	},
	Settings:{
		Shipping:{},
		Tax:{},
		Controller:{}
	},
	Products:{
		Controller:{}
	},
	Reports:{
		Controller:{}
	},
	Promotions:{
		Controller:{}
	},
	Common:{
		Controller:{}
	},
	Inventory:{
		Controller:{}
	},
	Order:{
		Controller:{}
	},
	Enquiry:{
		Controller:{}
	},
	QuickStart:{
		Controller:{}
	},
	CreditVoucher:{
		Controller:{}
	},
	EcsPayment:{
		Controller:{}
	},
	CustomerCredit:{
		Controller:{}
	},
	SupplierPayment:{
		Controller:{}
	},
	PurchaseOrder:{
		Controller:{}
	},
	Customer:{
		Controller:{}
	},
	Payment:{
		Controller:{}
	},
	Vendor:{
		Controller:{}
	},
	Tools:{
		Controller:{}
	},
	OnlineStore:{
		Controller:{}
	},
	Tally:{
		Controller:{}
	}
};

App.RegEx = {
	date:/^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/,
	integerWithNegative:/^-?[0-9]\d$/,
	//alternateNumber: /^[\d]{1,}(-|\s|\.){0,}[\d]{1,}$/,
	alternateNumber: /^([0-9]{2,}[\.\-]{0,1}[0-9]{4,})([\,\/][0-9]{2,}[\.\-]{0,1}[0-9]{4,}){0,2}$/,
	alphaNumeric: /^[a-zA-Z0-9]*$/,
	 // email:/^([a-zA-Z0-9]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i,
	email:/^[a-zA-Z0-9][a-zA-Z0-9_\-\+]*(?:[\.][a-zA-Z0-9_\-\+]+)*\@(?:[a-zA-Z0-9_\-\+]+\.)+[a-zA-Z0-9_\-\+]*[a-zA-Z0-9]$/,
	/*/^[a-zA-Z0-9]([a-zA-Z0-9_\-\+])+([\.][a-zA-Z0-9_\-\+]+)*\@(([a-zA-Z0-9_\-\+])+\.)+([a-zA-Z0-9_\-\+]*)([a-zA-Z0-9]{1,40})$/,
		/^([a-zA-Z0-9]+[a-zA-Z0-9\.\_\+\-])*[a-zA-Z0-9]{1,}@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i,*/
	webAccountName:/^[0-9a-zA-Z][\w\*\{\-\#\,\}\s]{0,19}$/,  //  /[^A-Za-z0-9._-]/g,
	webAccountCode:/^[0-9a-zA-Z]+$/,  //   /[^A-Za-z0-9_-]/g,
	specialCharExclude : /[!#$%()*&+]/,
	pincode : /^([1-9])([0-9]){0,5}$/,
	onlyAlphabet :/^[a-zA-Z][^\s]*$/,
	placeName : /^([a-zA-Z\,\.\-\(\/\)]*([a-zA-Z\,\.\-\(\/\)]?\s{0,1})*)$/,//minimized backtrack.
	personName : /^[a-zA-Z_. -,']*$/,
	taxName : /^([A-Za-z,.'-]+\s?)+([A-Za-z,.'-]+\s?)*$/,
	barcode : /^([(\w)|(\W)\/\\.-]){0,20}$/,
	negateBarcode : /([^\w\/\\.-])/g,//Use to replace unwanted char.
	fullName : /^([A-Za-z,.']+ )*[A-Za-z,.']*$/,
	customerName : /[a-z]/i,
	// /^([A-Za-z,.'&]+ )*[A-Za-z,.'&]*$/,
	//  /^([A-Za-z,.']+\s?)+([A-Za-z,.']+\s?)*$/, //not allowing 2 consecutive spaces
	skuNumber : /^([A-Za-z0-9-._\/\\]+\s?)+([A-Za-z0-9-._\/\\]+\s?)*$/,
	negateSku : /[^a-zA-Z0-9-.\/\\]/g,
	mobileNo:/^(9|8|7)[0-9]{0,9}$/,
	invoiceNo:/^[a-zA-Z0-9\#\.\:\-\s]*$/,
	domainName:/^[a-z0-9]+([\-\.{1}[a-z0-9]+)*\.[a-z]{1,}$/,
	nonDigitRegEx: /\D/,
	//   /^[a-z0-9]+([\-]{1}[a-z0-9]+)*\.[a-z]{2,4}$/ //for specific domain entry
	mapCoordinates: /^([-+]?)([\d]{1,2})(((\.)(\d+)(,)))(\s*)(([-+]?)([\d]{1,3})((\.)(\d+))?)$/
};

App.encodeRedirectUrl = function(url){
	return url.replace(/\//g,"-123-");
};

App.decodeRedirectUrl = function(url){
	return url.replace(/-123-/g,"/");
};

App.$http = function(options){
	var method = options.method?options.method:"GET";
	
	var xhttp = new XMLHttpRequest();
	xhttp.open(method,options.url, false);
	xhttp.send();
	
	var response = null;
	
	try{
		response = JSON.parse(xhttp.responseText);
	}
	catch(e){
		response = xhttp.responseText;
	}
	
	return response;
}

App.loadJs = function(url,callback){
    "use strict";

    var head = document.getElementsByTagName('head')[0];
    var script = document.createElement('script');
    
    script.type = 'text/javascript';
    script.async = false;
	url = App.getStaticServer('js') + url;
    script.src = url;
    script.onreadystatechange = callback;
    script.onload = callback;

    // Fire the loading
    head.appendChild(script);
}

App.loadCSS = function ( href, before){
	"use strict";
	var element = window.document.createElement( "link" );
	var ref = before || window.document.getElementsByTagName( "script" )[ 0 ];
	var sheets = window.document.styleSheets;
	element.rel = "stylesheet";
	element.href = App.getStaticServer('css') + href;
	element.media = "only x";
	
	// inject link
	ref.parentNode.insertBefore( element, ref );
	// This function sets the link's media back to `all` so that the stylesheet applies once it loads
	// It is designed to poll until document.styleSheets includes the new sheet.
	element.onloadcelementdefined = function( loadCallback ){
		var defined;
		for( var i = 0; i < sheets.length; i++ ){
			if( sheets[ i ].href && sheets[ i ].href === element.href ){
				defined = true;
			}
		}
		if( defined ){
			loadCallback();
		} else {
			setTimeout(function() {
				element.onloadcelementdefined( loadCallback );
			});
		}
	};
	element.onloadcelementdefined(function() {
		element.media = "all";
	});
	return element;
};
if(!String.prototype.repeat){
	String.prototype.repeat= function(n){
		n= n || 1;
		return Array(n+1).join(this);
	}
}
App.getConfiguration = function(){
	var xhttp = new XMLHttpRequest();
	xhttp.open("GET", "/marketplace/static/json/staticPackaging.json", false);
	xhttp.send();
	var response = xhttp.responseText;
	var js = JSON.parse(response).js,
		arr = js.controllers.concat(js.directives,js.libraryFiles,js.services);

	return {
		files:arr,
		directives:js.commonDirectives,
		routes:js.routes
	};
}

App.getStaticServer = function(fileType){
	var staticServers = ["https://static2.jdomni.in","https://static2.jdomni.in","https://static2.jdomni.in"];
	var saticServer = '';
	if(App.production === "true"){
		switch(fileType){
			case 'js':
				saticServer = staticServers[0];
				break;

			case 'css':
				saticServer = staticServers[1];
				break;

			default:
				saticServer = staticServers[2];
		}
	}
	return saticServer;
};

window.onerror = function(messageOrEvent, source, lineno, colno, error)
{	
	if(lineno != 0 && (App.hostKey == 'gamma' || App.hostKey == 'jdomni'))
	{
		var mailtext = '';
		mailtext += 'MessageOrEvent='+messageOrEvent+'<br><br>source='+source+'<br><br>lineno='+lineno+'<br><br>colno='+colno+'<br><br>error='+error; 
		/*var mailtext = new Array();
		mailtext['MessageOrEvent']= messageOrEvent;
		mailtext['source']= source;
		mailtext['lineno']= lineno;
		mailtext['colno']= colno;
		mailtext['error']= error;*/
		
		$.ajax({
		  method: "POST",
		  url: "/marketplace/static/php/web/common_api.php?action=errorMail",
		  data: { action: "errorMail", emailText: encodeURI(mailtext)}
		})
		.done(function( msg ) {
			
		 })	
		 .fail(function (jqXHR, exception) {
			$.ajax({
			  method: "POST",
			  url: "/marketplace/static/php/web/common_api.php?action=errorMail",
			  data: { action: "errorMail", emailText: 'MessageFailed'}
			})
		});
	}
}
