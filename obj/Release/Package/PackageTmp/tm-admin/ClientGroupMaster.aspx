<%@ Page Title="" Language="C#" MasterPageFile="~/tm-admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ClientGroupMaster.aspx.cs" Inherits="TaskManager.tm_admin.BranchMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="content">
        <div class="container">
            <div class="row">
                <div class="col-sm-6">

                    <div class="card">
                        <div class="card-header">
                            <h2>Add Client Group</h2>
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
                            <div>
                                
                                <div class="form-group">
                                    <p class="f-500 c-black m-b-15">Client Group Name
                                        <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtClientGroupName" 
                                            ID="RequiredFieldValidator1" runat="server" ValidationGroup="Branch" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*
                                    </asp:RequiredFieldValidator>
                                    </p>
                                    <div class="dtp-container fg-line">
                                        <asp:TextBox runat="server" ValidationGroup="Branch" ID="txtClientGroupName" CssClass="form-control" placeholder="Client Group Name"></asp:TextBox>
                                    </div>
                                </div>



                                <br />
                                <asp:Button runat="server" ID="btnsubmit"  ValidationGroup="Branch" Text="Submit" OnClick="lbSubmit_Click" CssClass="custom-submit-btn btn-primary btn-sm m-t-10" />
                                <asp:Button runat="server" ID="btnupdate" ValidationGroup="Branch" Visible="false" OnClick="lbUpdate_Click" Text="Update" CssClass="custom-submit-btn btn-primary btn-sm m-t-10" />
                                <%--<button type="submit" onclick="" class="btn btn-success btn-sm m-t-10">Submit</button>--%>
                                <%-- </form>--%>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-sm-6">

                    <div class="card">
                        <div class="card-header">
                            <h2>Client Group Data </h2>
                        </div>

                        <div class="card-body table-responsive">

                            <div class="table-responsive">
                                <asp:Repeater runat="server" ID="gv">
                                    <HeaderTemplate>
                                        <%--<table id="data-table-basic" class="table table-striped">--%>
                                            <table class="table table-striped">
                                            <thead>
                                                <tr>
                                                    <th data-column-id="name">Branch Name</th>
                                                    <th>Action</th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("CLIENT_GROUP_NAME") %></td>
                                            <td>
                                                <asp:LinkButton runat="server" ID="lbEdit" CssClass="btn btn-primary btn-circle waves-effect btn-sm zmdi zmdi-edit" CommandArgument='<%# Eval("Id") %>' OnClick="lbEdit_Click"></asp:LinkButton>
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
        </div>
        <footer class="text-center">
            Copyright &copy; 2017 Goldi Green
            
            
        </footer>
    </section>
</asp:Content>
