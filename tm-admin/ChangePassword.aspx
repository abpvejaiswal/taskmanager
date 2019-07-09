<%@ Page Title="" Language="C#" MasterPageFile="~/tm-admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TaskManager.tm_admin.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="content">
        <div class="container col-md-12" style="margin: 10px; position: relative; background: #fff; box-shadow: 0 1px 1px rgba(0, 0, 0, 0.15); margin-bottom: 30px; top: -4px; left: 0px;">
            <div class="">
                <div class="">
                    <h2 style="font-size: 17px;">Change Password <%--<small>Extend form controls by adding text or buttons before, after, or on both sides of any text-based inputs.</small>--%></h2>
                </div>
                <br />
                <div class="">
                    <asp:HiddenField runat="server" ID="loginid" />
                    <asp:HiddenField runat="server" ID="loginname" />
                    
                    <div class="alert alert-success alert-dismissable" id="divSuccess" runat="server" visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                        Success ! Changes Done Successfully
                    </div>
                    <div class="alert alert-danger alert-dismissable" id="divError" runat="server" visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                        Failure ! Changes Not Done Successfully !
                    </div>
                    <div class="alert alert-danger alert-dismissable" id="divconfirm" runat="server" visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                        Failure ! Password Not Match !
                    </div>
                    <div class="alert alert-danger alert-dismissable" id="divold" runat="server" visible="false">
                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                        Failure ! Old Password Not Match !
                    </div>
                    <div class="col-sm-12">
                        <div class="form-group fg-float">
                            <div class="fg-line">
                                <asp:TextBox runat="server" ValidationGroup="lead" ID="txtold" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="lead" runat="server" ForeColor="Red" ID="RequiredFieldValidator2" ControlToValidate="txtold" Display="Dynamic" ClientIDMode="Inherit" ErrorMessage="*" />
                                <%--<input type="text" ng-model="MetaKeyword" required class="form-control" rows="5" placeholder="">--%>
                            </div>
                            <label class="fg-label">Old Password</label>
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="form-group fg-float">
                            <div class="fg-line">
                                <asp:TextBox runat="server" TextMode="Password" ValidationGroup="lead" ID="txtnew" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="lead" runat="server" ForeColor="Red" ID="RequiredFieldValidator1" ControlToValidate="txtnew" Display="Dynamic" ClientIDMode="Inherit" ErrorMessage="*" />
                                <%--<input type="text" ng-model="MetaKeyword" required class="form-control" rows="5" placeholder="">--%>
                            </div>
                            <label class="fg-label">New Password</label>
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <div class="form-group fg-float">
                            <div class="fg-line">
                                <asp:TextBox runat="server" TextMode="Password" ValidationGroup="lead" ID="txtconfirm" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ValidationGroup="lead" runat="server" ForeColor="Red" ID="RequiredFieldValidator3" ControlToValidate="txtconfirm" Display="Dynamic" ClientIDMode="Inherit" ErrorMessage="*" />
                                <%--<input type="text" ng-model="MetaKeyword" required class="form-control" rows="5" placeholder="">--%>
                            </div>
                            <label class="fg-label">Confirm Password</label>
                        </div>
                    </div>
                    


                    <div class="col-sm-12">
                        <p class="c-black f-500 m-b-5">
                            <%--Client Master--%>
                            <a href="#" class="notifications btn btn-success" data-custommessage="" style="visibility: hidden;" data-type="success">Success</a>
                            <span class="pull-right">

                                <asp:Button runat="server" ID="btnsubmit" ValidationGroup="lead" Text="Update" OnClick="lbSubmit_Click" CssClass="custom-submit-btn btn-primary btn-sm m-t-10" />
                                <%--<asp:Button runat="server" ID="btnupdate" ValidationGroup="state" Visible="false" OnClick="lbUpdate_Click" Text="Update" CssClass="btn-success btn-sm m-t-10" />--%>
                                
                            </span>
                        </p>
                        <br />
                    </div>

                </div>

            </div>

        </div>
        
    </section>
</asp:Content>
