<%@ Page Title="" Language="C#" MasterPageFile="~/tm-admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MyDetail.aspx.cs" Inherits="TaskManager.tm_admin.MyDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="content">
        <div class="container">

            <div class="block-header">
                <h2>My Details <%--<small>Web/UI Developer, Dubai, United Arab Emirates</small>--%></h2>
            </div>

            <div class="card" id="profile-main">

                <div class="pm-body clearfix" style="padding-left: 0px;">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="pmb-block">
                                <div class="pmbb-header">
                                    <h2><i class="zmdi zmdi-account m-r-5"></i>Basic Information</h2>
                                </div>
                                <div class="alert alert-success alert-dismissable" id="divSuccess" runat="server" visible="false">
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                    Success ! Changes Done Successfully
                                </div>
                                <div class="alert alert-danger alert-dismissable" id="divError" runat="server" visible="false">
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                    Failure ! Changes Not Done Successfully !
                                </div>
                                <div class="pmbb-body p-l-30">

                                    <div class="pmbb-view">
                                        <div class="row">
                                            <dl class="dl-horizontal">
                                                <dt>First Name</dt>
                                                <dd>
                                                    <div class="dtp-container col-sm-10">
                                                        <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </dd>
                                            </dl>
                                            <dl class="dl-horizontal">
                                                <dt>Last Name</dt>
                                                <dd>
                                                    <div class="dtp-container col-sm-10">
                                                        <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </dd>
                                            </dl>
                                            <dl class="dl-horizontal">
                                                <dt>Email</dt>
                                                <dd>
                                                    <div class="dtp-container col-sm-10">
                                                        <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </dd>
                                            </dl>
                                            <dl class="dl-horizontal">
                                                <dt>Mobile</dt>
                                                <dd>
                                                    <div class="dtp-container col-sm-10">
                                                        <asp:TextBox runat="server" ID="txtMobile" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </dd>
                                            </dl>
                                            <dl class="dl-horizontal">
                                                <dt>Birthdate</dt>
                                                <dd>
                                                    <div class="dtp-container dropdown col-sm-10">
                                                        <asp:TextBox runat="server" ID="txtDOB" data-toggle="dropdown" CssClass="form-control date-picker"></asp:TextBox>
                                                        <%--<input type='text' class="form-control date-picker" data-toggle="dropdown" placeholder="Click here...">--%>
                                                    </div>
                                                </dd>
                                            </dl>
                                            <dl class="dl-horizontal">
                                                <dt></dt>
                                                <dd>
                                                    <div class="dtp-container dropdown col-sm-10">
                                                        <asp:LinkButton runat="server" ID="btnUpdate" OnClick="btnUpdate_Click" Text="UPDATE" CssClass="btn btn-primary"></asp:LinkButton>
                                                    </div>
                                                </dd>
                                            </dl>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="pmb-block">
                                <div class="pmbb-header">
                                    <h2><i class="zmdi zmdi-info m-r-5"></i>Other Information</h2>
                                </div>
                                <div class="pmbb-body p-l-30">
                                    <div class="pmbb-view">
                                     
                                        <dl class="dl-horizontal">
                                            <dt>Address</dt>
                                            <dd>
                                                <asp:Literal runat="server" ID="ltrAddress"></asp:Literal></dd>
                                        </dl>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>



                </div>
            </div>
        </div>
    </section>
</asp:Content>
