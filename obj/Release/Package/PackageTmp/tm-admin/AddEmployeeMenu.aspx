<%@ Page Title="" Language="C#" MasterPageFile="~/tm-admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddEmployeeMenu.aspx.cs" Inherits="TaskManager.tm_admin.AddEmployeeMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="content" ng-app="ProductApp" ng-controller="ProductController">
        <div class="container">
            <div class="card">

                <div class="card-body card-padding">
                    <div class="alert alert-success" role="alert" runat="server" id="divSuccess" visible="false">
                        <asp:Literal runat="server" ID="ltrSuccess"></asp:Literal>
                        <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                    </div>

                    <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">
                        <asp:Literal runat="server" ID="ltrError"></asp:Literal>
                        <asp:Label runat="server" ID="lblError"></asp:Label>
                    </div>


                    <!--<small>Place one add-on or button on either side of an input. You may also place one on both sides of an input.</small>-->
                    <div role="tabpanel">

                        <div class="tab-content">

                            <div role="tabpanel" class="tab-pane active" id="productinfo">
                                <br />
                                <div class="row">

                                    <div class="col-sm-3">
                                        <div class="form-group fg-float">
                                            <p class="f-500 c-black m-b-15">Select Employee</p>
                                            <asp:DropDownList runat="server" ID="ddlemployee" OnSelectedIndexChanged="ddlemployee_SelectedIndexChanged" AutoPostBack="true" CssClass="selectpicker bs-select-hidden">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="card bs-item z-depth-1">
                        <div class="card-header">
                            <h2>Menu Selection
                            </h2>
                        </div>

                        <div class="table-responsive">
                            <asp:Repeater ID="dlMenu" runat="server" OnItemDataBound="dlMenu_ItemDataBound">
                                <HeaderTemplate>
                                    <table class="table table-hover" id="tblCustomers">
                                        <thead>
                                            <tr>
                                                <td>
                                                    <label class="col-sm-12">
                                                    <asp:CheckBox ID="chkHeader" runat="server" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Check All
                                                        </label>
                                                </td>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tbody>



                                        <tr>
                                            <td class="col-sm-12">
                                                <label class="col-sm-12">
                                                    <asp:CheckBox runat="server" ID="chkMenu" />
                                                    <%--<input type="checkbox" runat="server" id="chkproduct" class="option-input checkbox" />--%>
                                                    <asp:HiddenField ID="hdMenu" runat="server" Value='<%# Eval("ID") %>' />
                                                    <%--<asp:Label runat="server" ID="lblproductid" Visible="false" Text='<%# Eval("ID") %>'></asp:Label>--%>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <%--Product Name--%> <%# Eval("NAME") %>
                                                </label>
                                            </td>
                                        </tr>


                                    </tbody>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>

                            </asp:Repeater>
                        </div>
                    </div>
                    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                    <script type="text/javascript">
                        $(function () {
                            $("#tblCustomers [id*=chkHeader]").click(function () {
                                debugger;
                                if ($(this).is(":checked")) {
                                    $("#tblCustomers [id*=chkMenu]").prop('checked', true);
                                } else {
                                    $("#tblCustomers [id*=chkMenu]").prop('checked', false);
                                }
                            });
                            //$("#tblCustomers [id*=chkMenu]").click(function () {
                            //    if ($("#tblCustomers [id*=chkMenu]").length == $("#tblCustomers [id*=chkMenu]:checked").length) {
                            //        $("#tblCustomers [id*=chkHeader]").attr("checked", "checked");
                            //    } else {
                            //        $("#tblCustomers [id*=chkHeader]").removeAttr("checked");
                            //    }
                            //});
                        });
                    </script>

                    <p class="c-black f-500 m-b-5">
                        <%--Client Master--%>
                        <a href="#" class="notifications btn btn-success" data-custommessage="" style="visibility: hidden;" data-type="success">Success</a>
                        <span class="pull-right">
                            <%--<asp:Button runat="server" ID="Submit"  CssClass="btn btn-primary" />--%>
                            <asp:LinkButton runat="server" ID="btnsave" OnClick="btnsave_Click" CssClass="btn btn-primary" Text="Submit"></asp:LinkButton>
                            <%--<button type="button" class="btn btn-primary" id="submit">Submit</button>--%>
                            <button type="reset" class="btn btn-danger ">Cancel</button>
                            <!--<input id="ContentPlaceHolder1_btnsubmit" class="btn btn-primary" name="ctl00$ContentPlaceHolder1$btnsubmit" value="Submit" type="submit">-->
                        </span>
                    </p>
                </div>
                <br />
            </div>
        </div>
    </section>
</asp:Content>
