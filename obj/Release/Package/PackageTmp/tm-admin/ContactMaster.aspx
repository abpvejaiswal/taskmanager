<%@ Page Title="" Language="C#" MasterPageFile="~/tm-admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ContactMaster.aspx.cs" Inherits="TaskManager.tm_admin.BankMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section id="content">
        <div class="container">
            <div class="row">
                <div class="col-sm-5">

                    <div class="card">
                        <div class="card-header">
                            <h2>Add Contact Detail</h2>
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

                            <div role="form">                                
                                <div class="form-group fg-float">                                    
                                    <div class="dtp-container fg-line">
                                        <asp:TextBox runat="server" ID="txtContactPerson" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <label class="fg-label">Contact Person</label>
                                </div>

                                <div class="form-group fg-float">
                                    <div class="dtp-container fg-line">
                                        <asp:TextBox runat="server" ID="txtContactNumber" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <label class="fg-label">Contact Number</label>
                                </div>

                                <div class="form-group fg-float">
                                    <div class="dtp-container fg-line">
                                        <asp:TextBox runat="server" ID="txtEmailId" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <label class="fg-label">E mail Id</label>
                                </div>

                                <br />
                                <asp:Button runat="server" ID="btnsubmit" ValidationGroup="add" Text="Submit" CssClass="custom-submit-btn btn-primary btn-sm m-t-10" OnClick="lbSubmit_Click" />
                                <asp:Button runat="server" ID="btnupdate" ValidationGroup="add" Visible="false" Text="Update" OnClick="lbUpdate_Click" CssClass="custom-submit-btn btn-primary btn-sm m-t-10" />                               
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-sm-7">

                    <div class="card">
                        <div class="card-header">
                            <h2>Contact Data </h2>
                        </div>
                        
                            <asp:Repeater runat="server" ID="gv">
                                <HeaderTemplate>
                                    <table class="table table-striped">
                                  <thead>
                                    <tr>
                                        <th data-column-id="BENEFICIARY_NAME">CONTACT PERSON</th>
                                        <th data-column-id="BANKNAME">CONTACT NUMBER</th>
                                        <th data-column-id="BRANCH">EMAIL ID</th>
                                        <th data-column-id="action">Action</th>
                                    </tr>
                                </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("CONTACT_PERSON") %></td>
                                            <td><%# Eval("CONTACT_NUMBER") %></td>
                                            <td><%# Eval("EMAIL_ID") %></td>
                                            <td>
                                                <asp:LinkButton runat="server" ID="lbEdit" CssClass="btn btn-primary btn-circle waves-effect btn-sm zmdi zmdi-edit" CommandArgument='<%# Eval("ID") %>' OnClick="lbEdit_Click"></asp:LinkButton>
                                                <asp:LinkButton runat="server" ID="lbDelete" OnClientClick="return confirm('Are You Sure Want To Delete ?')" CssClass="btn-outline btn btn-danger btn-circle waves-effect btn-sm zmdi zmdi-delete" CommandArgument='<%# Eval("ID") %>' OnClick="lbDelete_Click"></asp:LinkButton>
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
    </section>
</asp:Content>
