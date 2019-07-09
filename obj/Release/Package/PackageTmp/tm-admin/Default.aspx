<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TaskManager.tm_admin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Admin Panel | Nikhil Patkar</title>
    <link rel="icon" type="image/png" sizes="16x16" href="img/logo/favicon.png" />
    <!-- Vendor CSS -->
    <link href="vendors/bower_components/animate.css/animate.min.css" rel="stylesheet" />
    <link href="vendors/bower_components/material-design-iconic-font/dist/css/material-design-iconic-font.min.css" rel="stylesheet" />

    <!-- CSS -->
    <link href="css/app.min.1.css" rel="stylesheet" />
    <link href="css/app.min.2.css" rel="stylesheet" />
    <script src="angular/angular.min.js"></script>
    <script>


        var app = angular.module("myApp");


        app.controller('CategoryController', function ($window, $scope, $rootScope, $http, DataService, fileUpload) {
            $scope.successMessage = "";
            $scope.admindata = [];
            //EditCategoty
            $scope.DisplayCategory = function () {
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
                    url: 'http://localhost:25204/AdminOperation.asmx/AdminLogin',
                    data: data,
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                }).then(function (success) {
                    console.log(success.data);
                    $scope.admindata = success.data;

                }, function (error) {

                });
            };

        });
    </script>
    <style>
        body.login-content:before{
            background:#fff !important;
        }
        body{
            background-color: #1c5cc6;
        }
        .btn-danger {
            background-color: #1c5cc6;
        }
    </style>
</head>
<body class="login-content">
    <%--<span style="position: absolute;text-align:center;margin-left: 125px;color: wheat;font-size: 40px;text-decoration: overline;">
       <center>TECHNO CRM</center> </span>--%>
    <img src="img/logo/logo.png" alt="logo" style="position: absolute; margin-left: 60px;width:400px;" />
    <!-- Login -->
    <div class="lc-block toggled" id="l-login">
        <form id="form1" runat="server">
            <div class="input-group m-b-20">
                <%--<span class="input-group-addon"><i class="zmdi zmdi-account"></i></span>--%>
                <div class="fg-line">
                    <div class="alert alert-danger alert-dismissible" role="alert" runat="server" id="divError" visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button>
                        Oh snap! Username or Password is Wrong ! 
                    </div>
                </div>
            </div>
            <asp:Panel runat="server" ID="p1" DefaultButton="lbLogin">
                <div class="input-group m-b-20">
                    <span class="input-group-addon"><i class="zmdi zmdi-account"></i></span>
                    <div class="fg-line">
                        <asp:TextBox runat="server" ID="txtUsername" placeholder="Username" CssClass="form-control"></asp:TextBox>
                        <%--<input type="text" class="form-control" placeholder="Username">--%>
                    </div>
                </div>

                <div class="input-group m-b-20">
                    <span class="input-group-addon"><i class="zmdi zmdi-male"></i></span>
                    <div class="fg-line">
                        <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" placeholder="Password" CssClass="form-control"></asp:TextBox>
                        <%--<input type="password" class="form-control" placeholder="Password">--%>
                    </div>
                </div>

                <div class="clearfix"></div>

                <div class="checkbox">
                    <label>
                        <input type="checkbox" value="">
                        <i class="input-helper"></i>
                        Keep me signed in
                    </label>
                </div>

                <asp:LinkButton runat="server" ID="lbLogin" OnClick="lbLogin_Click" CssClass="btn btn-login btn-primary btn-float ">
                <i class="zmdi zmdi-arrow-forward"></i>

                </asp:LinkButton>
            </asp:Panel>
            <%--<asp:Button runat="server" ID="btnLogin" CssClass="btn btn-login btn-danger btn-float zmdi zmdi-arrow-forward" />--%>
            <%--<a href="#" class="btn btn-login btn-danger btn-float"><i class="zmdi zmdi-arrow-forward"></i></a>--%>

            <%--<ul class="login-navigation">
                <!--<li data-block="#l-register" class="bgm-red">Register</li>-->
                <li data-block="#l-forget-password" class="bgm-orange">Forgot Password?</li>
            </ul>--%>
        </form>
    </div>

    <!-- Register -->
    <div class="lc-block" id="l-register">
        <div class="input-group m-b-20">
            <span class="input-group-addon"><i class="zmdi zmdi-account"></i></span>
            <div class="fg-line">
                <input type="text" class="form-control" placeholder="Username">
            </div>
        </div>

        <div class="input-group m-b-20">
            <span class="input-group-addon"><i class="zmdi zmdi-email"></i></span>
            <div class="fg-line">
                <input type="text" class="form-control" placeholder="Email Address">
            </div>
        </div>

        <div class="input-group m-b-20">
            <span class="input-group-addon"><i class="zmdi zmdi-male"></i></span>
            <div class="fg-line">
                <input type="password" class="form-control" placeholder="Password">
            </div>
        </div>

        <div class="clearfix"></div>

        <div class="checkbox">
            <label>
                <input type="checkbox" value="">
                <i class="input-helper"></i>
                Accept the license agreement
            </label>
        </div>

        <a href="#" class="btn btn-login btn-danger btn-float"><i class="zmdi zmdi-arrow-forward"></i></a>

        <ul class="login-navigation">
            <li data-block="#l-login" class="bgm-green">Login</li>
            <li data-block="#l-forget-password" class="bgm-orange">Forgot Password?</li>
        </ul>
    </div>

    <!-- Forgot Password -->
    <div class="lc-block" id="l-forget-password">
        <p class="text-left">
            Enter your Email and get Password Link on Mail to Generate New Password.
        </p>

        <div class="input-group m-b-20">
            <span class="input-group-addon"><i class="zmdi zmdi-email"></i></span>
            <div class="fg-line">
                <input type="text" class="form-control" placeholder="Email Address">
            </div>
        </div>

        <a href="#" class="btn btn-login btn-danger btn-float"><i class="zmdi zmdi-arrow-forward"></i></a>

        <ul class="login-navigation">
            <li data-block="#l-login" class="bgm-green">Login</li>
            <!--<li data-block="#l-register" class="bgm-red">Register</li>-->
        </ul>
    </div>

    <!-- Older IE warning message -->
    <!--[if lt IE 9]>
        <div class="ie-warning">
            <h1 class="c-white">Warning!!</h1>
            <p>You are using an outdated version of Internet Explorer, please upgrade <br/>to any of the following web browsers to access this website.</p>
            <div class="iew-container">
                <ul class="iew-download">
                    <li>
                        <a href="http://www.google.com/chrome/">
                            <img src="img/browsers/chrome.png" alt="">
                            <div>Chrome</div>
                        </a>
                    </li>
                    <li>
                        <a href="https://www.mozilla.org/en-US/firefox/new/">
                            <img src="img/browsers/firefox.png" alt="">
                            <div>Firefox</div>
                        </a>
                    </li>
                    <li>
                        <a href="http://www.opera.com">
                            <img src="img/browsers/opera.png" alt="">
                            <div>Opera</div>
                        </a>
                    </li>
                    <li>
                        <a href="https://www.apple.com/safari/">
                            <img src="img/browsers/safari.png" alt="">
                            <div>Safari</div>
                        </a>
                    </li>
                    <li>
                        <a href="http://windows.microsoft.com/en-us/internet-explorer/download-ie">
                            <img src="img/browsers/ie.png" alt="">
                            <div>IE (New)</div>
                        </a>
                    </li>
                </ul>
            </div>
            <p>Sorry for the inconvenience!</p>
        </div>
    <![endif]-->
    <!-- Javascript Libraries -->
    <script src="vendors/bower_components/jquery/dist/jquery.min.js"></script>
    <script src="vendors/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>

    <script src="vendors/bower_components/Waves/dist/waves.min.js"></script>

    <!-- Placeholder for IE9 -->
    <!--[if IE 9 ]>
        <script src="vendors/bower_components/jquery-placeholder/jquery.placeholder.min.js"></script>
    <![endif]-->

    <script src="js/functions.js"></script>

</body>
</html>
