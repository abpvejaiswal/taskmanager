<%@ Page Title="" Language="C#" MasterPageFile="~/tm-admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeMaster.aspx.cs" Inherits="TaskManager.tm_admin.EmployeeMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .option-input {
            -webkit-appearance: none;
            -moz-appearance: none;
            -ms-appearance: none;
            -o-appearance: none;
            appearance: none;
            position: relative;
            top: 13.33333px;
            right: 0;
            bottom: 0;
            left: 0;
            height: 40px;
            width: 40px;
            transition: all 0.15s ease-out 0s;
            background: #cbd1d8;
            border: none;
            color: #fff;
            cursor: pointer;
            display: inline-block;
            margin-right: 0.5rem;
            outline: none;
            position: relative;
            z-index: 1000;
        }

            .option-input:hover {
                background: #9faab7;
            }

            .option-input:checked {
                background: #40e0d0;
            }

                .option-input:checked::before {
                    height: 40px;
                    width: 40px;
                    position: absolute;
                    content: '✔';
                    display: inline-block;
                    font-size: 26.66667px;
                    text-align: center;
                    line-height: 40px;
                }

                .option-input:checked::after {
                    -webkit-animation: click-wave 0.65s;
                    -moz-animation: click-wave 0.65s;
                    animation: click-wave 0.65s;
                    background: #40e0d0;
                    content: '';
                    display: block;
                    position: relative;
                    z-index: 100;
                }

            .option-input.radio {
                border-radius: 50%;
            }

                .option-input.radio::after {
                    border-radius: 50%;
                }
    </style>

    <script type="text/javascript">
        var currentTab = 0;
        $(function () {
            $("#tabs").tabs({
                select: function (e, i) {
                    currentTab = i.index;
                }
            });
        });
        $("#btnNext").live("click", function () {
            var tabs = $('#tabs').tabs();
            var c = $('#tabs').tabs("length");
            currentTab = currentTab == (c - 1) ? currentTab : (currentTab + 1);
            tabs.tabs('select', currentTab);
            $("#btnPrevious").show();
            if (currentTab == (c - 1)) {
                $("#btnNext").hide();
            } else {
                $("#btnNext").show();
            }
        });
        $("#btnPrevious").live("click", function () {
            var tabs = $('#tabs').tabs();
            var c = $('#tabs').tabs("length");
            currentTab = currentTab == 0 ? currentTab : (currentTab - 1);
            tabs.tabs('select', currentTab);
            if (currentTab == 0) {
                $("#btnNext").show();
                $("#btnPrevious").hide();
            }
            if (currentTab < (c - 1)) {
                $("#btnNext").show();
            }
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="content">
        <div class="container">
            <div class="card">
                <!--<div class="card-header">
                            <h2>Input Groups <small>Extend form controls by adding text or buttons before, after, or on both sides of any text-based inputs.</small></h2>
                        </div>
                        -->
                <div class="card-body card-padding">
                    <div class="alert alert-success alert-dismissable" id="divSuccess" runat="server" visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                        Success ! Changes Done Successfully
                    </div>
                    <div class="alert alert-danger alert-dismissable" id="divError" runat="server" visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                        Failure ! Changes Not Done Successfully !
                    </div>
                    <p class="c-black f-500 m-b-5">
                        Add Employee
                          <a href="#" class="notifications btn btn-success" data-custommessage="" style="visibility: hidden;" data-type="success">Success</a>

                    </p>
                    <!--<small>Place one add-on or button on either side of an input. You may also place one on both sides of an input.</small>-->
                    <div role="tabpanel">
                        <ul class="tab-nav" role="tablist">
                            <li class="active"><a href="#productinfo" aria-controls="productinfo" role="tab" data-toggle="tab">Add Employee</a></li>
                            <li><a href="#viewdata" aria-controls="seo" role="tab" data-toggle="tab">Employee Details</a></li>
                            <%--<li><a href="#oth" aria-controls="seo" role="tab" data-toggle="tab">Other Information</a></li>--%>
                        </ul>
                        <div class="tab-content">
                            <div role="tabpanel" class="tab-pane active" id="productinfo">
                                <br />
                                <div class="row">
                                    <div class="col-sm-3" style="display:none;">
                                        <div class="form-group fg-float" style="display:none;">
                                            <div class="fg-line ">
                                                <asp:TextBox runat="server" ValidationGroup="reg" ID="txtEmployeeId" TextMode="Email" CssClass="form-control">

                                                </asp:TextBox>
                                            </div>
                                            <label class="fg-label">Employee Id</label>
                                        </div>
                                    </div>

                                    <div class="col-sm-3">
                                        <div class="form-group fg-float">
                                            <div class="fg-line">
                                                <asp:TextBox runat="server" ValidationGroup="reg" ID="FIRST_NAME" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="reg" runat="server" ForeColor="Red" ID="RequiredFieldValidator2" ControlToValidate="FIRST_NAME" Display="Dynamic" ClientIDMode="Inherit" ErrorMessage="Please enter your first name!" />
                                            </div>
                                            <label class="fg-label">First name</label>
                                        </div>
                                    </div>

                                    <div class="col-sm-3">
                                        <div class="form-group fg-float">
                                            <div class="fg-line">
                                                <asp:TextBox runat="server" ValidationGroup="reg" ID="LAST_NAME" CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="reg" runat="server" ID="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="LAST_NAME" Display="Dynamic" ClientIDMode="Inherit" ErrorMessage="Please enter your last name!" />
                                            </div>
                                            <label class="fg-label">Last Name</label>
                                        </div>
                                    </div>

                                    <div class="col-sm-3">
                                        <div class="form-group fg-float">
                                            <div class="fg-line">
                                                <asp:TextBox runat="server" ValidationGroup="reg" ID="DOB" CssClass="form-control date-picker"></asp:TextBox>
                                            </div>
                                            <label class="fg-label">Date Of Birth</label>
                                        </div>
                                    </div>

                                    <div class="col-sm-3" style="display:none;"  >
                                        <div class="form-group fg-float">
                                            <div class="fg-line">
                                                <asp:DropDownList runat="server" ValidationGroup="reg" ID="ddldesighnation" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                            <label class="fg-label">Designation</label>
                                        </div>
                                    </div>

                                    <div class="col-sm-3">
                                        <div class="form-group fg-float">
                                            <div class="fg-line">
                                                <asp:TextBox runat="server" ValidationGroup="reg" TextMode="Number" ID="MOBILE_NUMBER" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" ControlToValidate="MOBILE_NUMBER" Display="Dynamic" ValidationGroup="reg" runat="server" ValidationExpression="^[0-9]{10}$"
                                                    ErrorMessage="Only 10 Digit Number allow"></asp:RegularExpressionValidator>
                                            </div>
                                            <label class="fg-label">Mobile Number</label>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        
                                        <div class="form-group fg-float">
                                            <div class="fg-line">
                                                <asp:TextBox runat="server" ValidationGroup="reg" ID="EMAIL" TextMode="Email" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ValidationGroup="reg" ID="regexEmailValid" Display="Dynamic" ClientIDMode="Inherit" runat="server" ForeColor="Red" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EMAIL" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ValidationGroup="reg" runat="server" ID="reqName" ControlToValidate="EMAIL" Display="Dynamic" ClientIDMode="Inherit" ForeColor="Red" ErrorMessage="Please Enter Email Address !" />

                                            </div>
                                            <label class="fg-label">Email Address</label>
                                        </div>

                                        <%--<asp:RequiredFieldValidator runat="server" ID="reqName" ControlToValidate="EMAIL" ForeColor="Red" ErrorMessage="Please enter your Email!" />--%>
                                    </div>
                                    <div class="col-sm-3" style="display:none;" >
                                        <div class="form-group fg-float">
                                            <div class="fg-line">
                                                <asp:TextBox runat="server" ValidationGroup="reg" TextMode="Number" ID="ALT_MOBILE_NUMBER" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" ControlToValidate="ALT_MOBILE_NUMBER" Display="Dynamic" ValidationGroup="reg" runat="server" ValidationExpression="^[0-9]{10}$"
                                                    ErrorMessage="Only 10 Digit Number allow"></asp:RegularExpressionValidator>
                                            </div>
                                            <label class="fg-label">Alternative Mobile Number</label>
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <div class="form-group fg-float">
                                            <div class="fg-line">
                                                <asp:TextBox runat="server" ValidationGroup="reg" ID="RES_ADDRESS" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <label class="fg-label"><b>Address :-</b></label>
                                        </div>
                                    </div>

                                    <div class="col-sm-3">
                                        <div class="form-group fg-float">
                                            <div class="fg-line">
                                                <asp:TextBox runat="server" ValidationGroup="reg" ID="R_LANDMARK" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <label class="fg-label">Landmark</label>
                                        </div>
                                    </div>

                                    <div class="col-sm-3" >
                                        <div class="form-group fg-float">
                                            <div class="fg-line">
                                                <asp:TextBox runat="server" ValidationGroup="reg" ID="R_AREA" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <label class="fg-label">City</label>
                                        </div>
                                    </div>
                                    
                                    <div class="col-sm-3" >
                                        <div class="form-group fg-float">
                                            <div class="fg-line">
                                                <asp:TextBox runat="server" ValidationGroup="reg" ID="txtPinCode" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <label class="fg-label">Pin Code</label>
                                        </div>
                                    </div>

                                    <div class="col-sm-3" style="display:none;" >
                                        <div class="form-group fg-float">
                                            <div class="fg-line fg-toggled">
                                                <%--<asp:TextBox runat="server" ID="BLOOD_GROUP" CssClass="form-control"></asp:TextBox>--%>
                                                <asp:DropDownList ID="BLOOD_GROUP" CssClass="form-control" runat="server">
                                                    <asp:ListItem Text="A+" Value="A+"></asp:ListItem>
                                                    <asp:ListItem Text="A-" Value="A-"></asp:ListItem>
                                                    <asp:ListItem Text="B+" Value="B+"></asp:ListItem>
                                                    <asp:ListItem Text="B-" Value="B-"></asp:ListItem>
                                                    <asp:ListItem Text="AB+" Value="AB+"></asp:ListItem>
                                                    <asp:ListItem Text="AB-" Value="AB-"></asp:ListItem>
                                                    <asp:ListItem Text="O+" Value="O+"></asp:ListItem>
                                                    <asp:ListItem Text="O-" Value="O-"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <label class="fg-label">Blood Group</label>
                                        </div>
                                    </div>
                                    <div class="col-sm-3" style="display:none;" >
                                        <div class="form-group fg-float">
                                            <div class="fg-line fg-toggled">
                                                <asp:DropDownList runat="server" ValidationGroup="reg" ID="ddlZone" CssClass="form-control">
                                                    <asp:ListItem Value="0">Select Zone</asp:ListItem>
                                                    <asp:ListItem Value="East">East</asp:ListItem>
                                                    <asp:ListItem Value="West">West</asp:ListItem>
                                                    <asp:ListItem Value="North">South</asp:ListItem>
                                                    <asp:ListItem Value="South">South</asp:ListItem>
                                                    <asp:ListItem Value="International">International</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <label class="fg-label">Zone </label>
                                        </div>
                                    </div>
                                    <div class="col-sm-3" style="display:none;" >
                                        <div class="form-group fg-float">
                                            <div class="fg-line fg-toggled">
                                                <asp:DropDownList runat="server" ValidationGroup="state" ID="ddlState" CssClass="tag-select" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                </asp:DropDownList>

                                            </div>
                                            <label class="fg-label">State</label>
                                        </div>
                                    </div>

                                    <div class="col-sm-3" style="display:none;" >
                                        <div class="form-group fg-float">
                                            <div class="fg-line fg-toggled">
                                                <asp:DropDownList runat="server" ValidationGroup="state" ID="ddlCity" CssClass="tag-select">
                                                </asp:DropDownList>
                                            </div>
                                            <label class="fg-label">City</label>
                                        </div>
                                    </div>

                                    <div class="col-sm-3" style="display:none;" >
                                        <div class="form-group fg-float">
                                            <div class="fg-line fg-toggled">
                                                <asp:DropDownList runat="server" ValidationGroup="state" ID="ddlbranch" CssClass="tag-select">
                                                </asp:DropDownList>
                                            </div>
                                            <label class="fg-label">Branch</label>
                                        </div>
                                    </div>

                                    
                                    <div class="col-sm-12">
                                        <div class="form-group fg-float m-t-20">
                                            <div class="fg-line">
                                                <div class="toggle-switch">
                                                    <label for="chkStatus" class="ts-label">Status</label>
                                                    <asp:CheckBox runat="server" ClientIDMode="Static" ID="chkStatus" />
                                                    <%--<input onchange="IsRepeatRadio()" id="ts1" type="checkbox" ng-true-value="true" ng-false-value="false" name="repeatradio" hidden="hidden">--%>
                                                    <label for="chkStatus" class="ts-helper"></label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-3" style="display:none;" >
                                        <div class="form-group fg-float">
                                            <div class="fg-line fg-toggled">

                                                <asp:DropDownList ID="ddlStatus" CssClass="form-control" runat="server">
                                                    <asp:ListItem Text="Working" Value="Working"></asp:ListItem>
                                                    <asp:ListItem Text="Resign" Value="Resign"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <label class="fg-label">Status</label>
                                        </div>
                                    </div>


                                    <div class="col-sm-12 text-center">
                                        <span class="">
                                            <asp:LinkButton runat="server" ID="Submit" ValidationGroup="reg" OnClick="Submit_Click" CssClass="btn btn-primary" Text="Submit"></asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="lbupdate" ValidationGroup="reg" Visible="false" OnClick="lbupdate_Click" CssClass="btn btn-primary" Text="Update"></asp:LinkButton>
                                            <%--<button type="button" runat="server" id="btnsubmit" onclick="Submit_Click" class="btn btn-primary">Submit</button>--%>
                                            <button type="reset" class="btn btn-danger" runat="server" id="btncancel">Cancel</button>
                                            <!--<input id="ContentPlaceHolder1_btnsubmit" class="btn btn-primary" name="ctl00$ContentPlaceHolder1$btnsubmit" value="Submit" type="submit">-->
                                        </span>
                                    </div>
                                </div>
                            </div>

                            <div role="tabpanel" class="tab-pane" id="viewdata">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="card">
                                            <div class="card-body table-responsive">

                                                <asp:GridView runat="server" CssClass="table table-bordered panel table-hover" AutoGenerateColumns="False" ID="gv">
                                                    <Columns>
                                                        <asp:BoundField DataField="first_name" HeaderText="First Name" />
                                                        <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                                                        <asp:BoundField DataField="email" HeaderText="Email" />                                                        
                                                        <asp:BoundField DataField="Mobile_number" HeaderText="Mobile" />
                                                        <asp:BoundField DataField="AREA" HeaderText="Area" />
                                                        <asp:TemplateField HeaderText="Action">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" class="btn btn-primary waves-effect waves-float" CommandArgument='<%# Eval("id") %>'
                                                                    OnClick="lbEdit_Click" ID="lbEdit"><i class="zmdi zmdi-edit"></i></asp:LinkButton>
                                                                <asp:LinkButton runat="server" class="btn btn-danger waves-effect waves-float" CommandArgument='<%# Eval("id") %>'
                                                                    OnClick="lbDelete_Click" OnClientClick="return confirm('Are you sure?');" ID="lbDelete"><i class="zmdi zmdi-delete"></i></asp:LinkButton>
                                                                
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>

                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>


                </div>
            </div>
        </div>
        <br />


    </section>
</asp:Content>
