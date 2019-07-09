<%@ Page Title="" Language="C#" MasterPageFile="~/tm-admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MenuMaster.aspx.cs" Inherits="TaskManager.tm_admin.MenuMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="content">
        <div class="container">
            <div class="row">
                <div class="col-sm-4">

                    <div class="card">
                        <div class="card-header">
                            <h2>Menu Master </h2>
                        </div>
                        <div class="card-body card-padding">

                            <div class="alert alert-success" role="alert" runat="server" id="divSuccess" visible="false">
                                <asp:Literal runat="server" ID="ltrSuccess"></asp:Literal>
                                <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                            </div>

                            <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">
                                <asp:Literal runat="server" ID="ltrError"></asp:Literal>
                                <asp:Label runat="server" ID="lblError"></asp:Label>
                            </div>

                            <div role="form">
                                <div class="form-group fg-line">
                                    <label for="exampleInputEmail1">Menu Name</label>
                                    <asp:TextBox runat="server" ID="txtmenuname" CssClass="form-control"></asp:TextBox>
                                    <%--<asp:TextBox runat="server" ID="txtname" CssClass="form-control input-sm"></asp:TextBox>--%>
                                </div>
                                <div class="form-group fg-line">
                                    <label for="exampleInputEmail1">Page Name</label>
                                    <asp:TextBox runat="server" ID="txtpagename" CssClass="form-control"></asp:TextBox>
                                    <%--<asp:TextBox runat="server" ID="txtname" CssClass="form-control input-sm"></asp:TextBox>--%>
                                </div>


                                <div class="form-group fg-float">
                                    <p class="f-500 c-black m-b-15">Menu Display Type</p>
                                    <asp:DropDownList runat="server" ID="ddlmenutype" CssClass="selectpicker bs-select-hidden">
                                        <asp:ListItem>Master Data</asp:ListItem>
                                        <asp:ListItem>Lead</asp:ListItem>
                                        <asp:ListItem>Enquiry</asp:ListItem>
                                        <asp:ListItem>Client</asp:ListItem>
                                        <asp:ListItem>Task Manager</asp:ListItem>
                                        <asp:ListItem>General</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group fg-line">
                                    <label for="exampleInputEmail1">Sequence</label>
                                    <asp:TextBox runat="server" ID="txtsequance" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group fg-line">
                                    <label for="exampleInputEmail1">Status</label>
                                    <asp:CheckBox runat="server" ID="chkStatus" />
                                </div>

                                <br />
                                <asp:Button runat="server" ID="btnsave" OnClick="btnSave_Click" ValidationGroup="add" Text="Submit" CssClass="btn-success btn-sm m-t-10" />
                                <%--<asp:Button runat="server" ID="btncancel" ValidationGroup="add" Text="Cancel" CssClass="btn-danger btn-sm m-t-10" />--%>
                                <asp:Button runat="server" ID="btnupdate" OnClick="btnUpdate_Click" ValidationGroup="add" Visible="false" Text="Update" CssClass="btn-success btn-sm m-t-10" />
                                <button type="reset" class="btn-danger btn-sm m-t-10">Cancel</button>
                                <%-- </form>--%>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-sm-8">

                    <div class="card">
                        <div class="card-header">
                            <h2>Data </h2>
                        </div>

                        <div class="card-body table-responsive">

                            <asp:GridView runat="server" CssClass=" table table-bordered panel table-hover" AutoGenerateColumns="False" ID="gv">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="MENU NAME" />
                                    <asp:BoundField DataField="Seq" HeaderText="SEQUENCE" />
                                    <asp:BoundField DataField="Type" HeaderText="Type" />
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkStatus" runat="server" Checked='<%#Eval("Status") %>' Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CssClass="btn btn-default waves-effect waves-float" CommandArgument='<%# Eval("ID") %>'
                                                OnClick="lbEdit_Click" ID="lbEdit"><i class="zmdi zmdi-edit"></i></asp:LinkButton>
                                            <asp:LinkButton runat="server" class="btn btn-danger waves-effect waves-float" CommandArgument='<%# Eval("id") %>'
                                                OnClick="lbDelete_Click" OnClientClick="return confirm('Are you sure?');" ID="lbDelete"><i class="zmdi zmdi-delete"></i></asp:LinkButton>
                                            <%-- <button type="button" ng-hide="editMode" class="btn btn-default btn-icon waves-effect waves-circle waves-float" ng-click="editMode = true; EditCategory(x.ID,x.NAME,x.IMAGE)"><i class="zmdi zmdi-edit"></i></button>
                                    <button title="Delete" ng-hide="editMode" ng-click="editMode=false;DeleteCategory(x.ID)" class="btn btn-danger btn-icon waves-effect waves-circle waves-float"><i class="zmdi zmdi-delete"></i></button>
                                            --%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
