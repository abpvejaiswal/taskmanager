<%@ Page Title="" Language="C#" MasterPageFile="~/tm-admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StateMaster.aspx.cs" Inherits="TaskManager.tm_admin.StateMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="content">
        <div class="container">
            <div class="row">
                <div class="col-sm-6">
                    <div class="card">
                        <div class="card-header">
                            <h2>Add State</h2>
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
                                <div class="form-group">
                                    <p class="f-500 c-black m-b-15">
                                        State Name
                                            <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtstate"
                                                ID="RequiredFieldValidator1" runat="server" ValidationGroup="state" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*
                                            </asp:RequiredFieldValidator>
                                    </p>

                                    <div class="dtp-container fg-line">
                                        <asp:TextBox runat="server" ID="txtstate" ValidationGroup="state" CssClass="form-control" placeholder="State Name"></asp:TextBox>

                                        <%--<input type='text' class="form-control date-picker" placeholder="Click here...">--%>
                                    </div>
                                </div>
                                <br />
                                <asp:Button runat="server" ID="btnsubmit" ValidationGroup="state" Text="Submit" OnClick="lbSubmit_Click" CssClass="custom-submit-btn btn-primary btn-sm m-t-10" />
                                <asp:Button runat="server" ID="btnupdate" ValidationGroup="state" Visible="false" OnClick="lbUpdate_Click" Text="Update" CssClass="custom-submit-btn btn-primary btn-sm m-t-10" />
                                
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">

                    <div class="card">
                        <div class="card-header">
                            <h2>State Data </h2>
                        </div>

                        <div class="card-body table-responsive">

                            <div class="table-responsive">
                                <asp:Repeater runat="server" ID="gv">
                                    <HeaderTemplate>
                                        <table class="table table-striped">
                                            <thead>
                                                <tr>

                                                    <th data-column-id="name">State Name</th>
                                                    <th data-column-id="action">Action
                                                    </th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("Name") %></td>
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
                            <%--<asp:GridView runat="server" CssClass="data-table-basic table table-bordered panel table-hover" AutoGenerateColumns="False" ID="gv">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="State Name" />
                                    

                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CssClass="btn btn-default waves-effect waves-float" CommandArgument='<%# Eval("ID") %>'
                                                ID="lbEdit"><i class="zmdi zmdi-edit"></i></asp:LinkButton>
                                            <asp:LinkButton runat="server" class="btn btn-danger waves-effect waves-float" CommandArgument='<%# Eval("id") %>'
                                                 OnClientClick="return confirm('Are you sure?');" ID="lbDelete"><i class="zmdi zmdi-delete"></i></asp:LinkButton>
                                            
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
    </section>
</asp:Content>
