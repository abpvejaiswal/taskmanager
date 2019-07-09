<%@ Page Title="" Language="C#" MasterPageFile="~/tm-admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TaskManager.tm_admin.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="content">
        <div class="container">
            <div class="row">

                <div class="col-sm-12">

                    <div class="card">
                        <div class="card-header">
                            <h2>View Lead </h2>
                        </div>
                        <div class="card-body card-padding">
                        <div class="alert alert-success alert-dismissable" id="divSuccess" runat="server" visible="false">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            Success ! Changes Done Successfully
                        </div>
                        <div class="alert alert-danger alert-dismissable" id="divError" runat="server" visible="false">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            Failure ! Changes Not Done Successfully !
                        </div>
                        <asp:Repeater runat="server" ID="gv">
                            <HeaderTemplate>
                                <table class="table table-striped">
                                    <thead>
                                        <tr>
                                            <th data-column-id="id">Customer Name</th>
                                            <th data-column-id="a">Customer Mobile</th>
                                            <th data-column-id="b">Email</th>
                                            <th data-column-id="c">Address</th>
                                            <th data-column-id="d">Value Of Lead</th>
                                            <th data-column-id="e">Reference Name & Mobile</th>
                                            <th data-column-id="sender">Source Of Lead</th>
                                            <th data-column-id="action">Action</th>
                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("CLIENTNAME") %></td>
                                    <td><%# Eval("MOBILE") %></td>
                                    <td><%# Eval("EMAIL") %></td>
                                    <td><%# Eval("ADDRESS") %></td>
                                    <td><%# Eval("VALUE_OF_LEAD") %></td>
                                    <td><%# Eval("REFERENCE") %></td>
                                    <td><%# Eval("SOURCE_OF_LEAD") %></td>
                                    <td>
                                        <asp:LinkButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure Want To Delete ?')" CssClass="btn-outline btn btn-danger btn-circle waves-effect btn-sm zmdi zmdi-delete" CommandArgument='<%# Eval("Id") %>' OnClick="lbDelete_Click"></asp:LinkButton>
                                    </td>
                                </tr>



                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <footer class="text-center">
            Copyright &copy; 2017 Goldi Green
            
            
        </footer>
    </section>
</asp:Content>
