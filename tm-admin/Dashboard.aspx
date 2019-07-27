<%@ Page Title="" Language="C#" MasterPageFile="~/tm-admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="TaskManager.tm_admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="modal fade in" id="addfollowup" tabindex="-1" role="dialog" aria-hidden="false" style="display: block;" runat="server" visible="false">
        <div class="modal-dialog bounceIn animated">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Update Lead Followup</h4>
                </div>
                <div class="modal-body">
                    <div class="alert alert-danger" role="alert" runat="server" id="divModalError" visible="false">
                        <asp:Literal runat="server" ID="ltrError"></asp:Literal>
                        <asp:Label runat="server" ID="lblError"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group fg-float fg-toggled">
                                <label class="">Followup Date</label>
                                <div class="fg-line">
                                    <asp:TextBox runat="server" ID="txtfollowdate" CssClass="form-control date-picker"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="lead" runat="server" ForeColor="Red" ID="RequiredFieldValidator2" ControlToValidate="txtfollowdate" Display="Dynamic" ClientIDMode="Inherit" ErrorMessage="*" />
                                </div>

                            </div>
                        </div>
                        <div class="col-sm-12">
                            <div class="form-group fg-float">
                                <label class="">Notes</label>
                                <div class="fg-line">
                                    <asp:TextBox runat="server" ID="txtnote" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                </div>

                            </div>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" Visible="false" ID="btnupdate" OnClick="btnupdate_Click" Text="Update" CssClass="btn btn-primary"></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lbClose" OnClick="lbClose_Click" Text="Close" CssClass="btn btn-danger closemodal"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <section id="content">


        <div class="container">
            <div class="block-header">
            </div>

            <div class="mini-charts">
                <div class="row">
                    <div class="col-sm-6 col-md-3">
                        <a href="<% =LoginType=="Admin"?"AllTask.aspx?Filter=NotStarted":"MyTask.aspx?Filter=NotStarted" %>">
                            <div class="mini-charts-item bgm-orange">
                                <div class="clearfix">
                                    <div class="chart stats-bar"></div>
                                    <div class="count">
                                        <h4 style="color: white">Not Started Task</h4>
                                        <h2>
                                            <asp:Literal runat="server" Text="0" ID="ltrNotStarted"></asp:Literal></h2>
                                    </div>
                                </div>
                            </div>
                        </a>
                    </div>


                    <div class="col-sm-6 col-md-3">
                      <a href="<% =LoginType=="Admin"?"AllTask.aspx?Filter=Inprogress":"MyTask.aspx?Filter=Inprogress" %>">
                            <div class="mini-charts-item bgm-purple">
                                <div class="clearfix">
                                    <div class="chart stats-bar"></div>
                                    <div class="count">
                                        <h4 style="color: white">In Progress Task</h4>
                                        <h2>
                                            <asp:Literal runat="server" Text="0" ID="ltrInprogress"></asp:Literal></h2>
                                    </div>
                                </div>
                            </div>
                        </a>
                    </div>


                    <div class="col-sm-6 col-md-3">
                        <a href="<% =LoginType=="Admin"?"AllTask.aspx?Filter=Waitingforinput":"MyTask.aspx?Filter=Waitingforinput" %>">
                            <div class="mini-charts-item bgm-amber">
                                <div class="clearfix">
                                    <div class="chart stats-bar"></div>
                                    <div class="count">
                                        <h4 style="color: white">Waiting for input Task</h4>
                                        <h2>
                                            <asp:Literal runat="server" Text="0" ID="ltrWaitingforinput"></asp:Literal></h2>
                                    </div>
                                </div>
                            </div>
                        </a>
                    </div>


                    <div class="col-sm-6 col-md-3">
                       <a href="<% =LoginType=="Admin"?"AllTask.aspx?Filter=Completed":"MyTask.aspx?Filter=Completed" %>">
                            <div class="mini-charts-item bgm-green">
                                <div class="clearfix">
                                    <div class="chart stats-bar"></div>
                                    <div class="count">
                                        <h4 style="color: white">Completed Task</h4>
                                        <h2>
                                            <asp:Literal runat="server" Text="0" ID="ltrCompleted"></asp:Literal></h2>
                                    </div>
                                </div>
                            </div>
                        </a>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <a href="<% =LoginType=="Admin"?"AllTask.aspx?Filter=TodayTask":"MyTask.aspx?Filter=TodayTask" %>">
                            <div class="mini-charts-item bgm-cyan">
                                <div class="clearfix">
                                    <div class="chart stats-bar"></div>
                                    <div class="count">
                                        <h4 style="color: white">Today's Task</h4>
                                        <h2>
                                            <asp:Literal runat="server" Text="0" ID="ltrTodayTask"></asp:Literal></h2>
                                    </div>
                                </div>
                            </div>
                        </a>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <a href="#">
                            <div class="mini-charts-item bgm-lightblue">
                                <div class="clearfix">
                                    <div class="chart stats-bar-2"></div>
                                    <div class="count">
                                        <h4 style="color: white">Total Task</h4>
                                        <h2>
                                            <asp:Literal runat="server" ID="ltrTotalTask">0</asp:Literal></h2>
                                    </div>
                                </div>
                            </div>
                        </a>
                    </div>

                    <%--<asp:LinkButton runat="server" ID="btnClick" OnClick="btnClick_Click"></asp:LinkButton>--%>
                </div>
            </div>

            <div class="row" runat="server" id="divActiveLead" visible="false">
                <div class="col-sm-12">
                    <!-- Calendar -->
                    <div id="calendar-widget"></div>
                    <!-- Recent Posts -->
                    <div class="card">
                        <div class="card-header ch-alt m-b-20">
                            <h2>Active Leads <%--<small>Phasellus condimentum ipsum id auctor imperdie</small>--%>
                                <span class="pull-right"><a href="Client.aspx" class="btn bgm-teal btn-icon waves-effect waves-circle waves-float" title="Generate Lead">
                                    <i style="vertical-align: middle;" class="zmdi zmdi-plus"></i></a></span>
                            </h2>
                        </div>
                        <div class="card-body  m-l-10 m-r-10">
                            <div class="row">
                                <div class="alert alert-danger m-10" role="alert" runat="server" id="divNoDataAL" visible="false">
                                    no more active leads
                                </div>

                                <asp:Repeater runat="server" ID="rpActiveLeads">
                                    <ItemTemplate>
                                        <div class="col-sm-4">
                                            <div class="card">
                                                <a href='LeadFollowupNew.aspx?LeadId=<%# Eval("ID") %>'>
                                                    <div class="card-header bgm-teal">
                                                        <h2><%# Eval("CLIENTNAME") %><br />
                                                            <small><%# Eval("EMAIL") %></small>
                                                            <small><%# Eval("MOBILE") %></small>
                                                        </h2>
                                                        <ul class="actions actions-alt">
                                                            <li class="dropdown">
                                                                <a href="#" data-toggle="dropdown" aria-expanded="false">
                                                                    <i class="zmdi zmdi-more-vert"></i>
                                                                </a>
                                                                <ul class="dropdown-menu dropdown-menu-right">
                                                                    <li>
                                                                        <a href='LeadFollowupNew.aspx?LeadId=<%# Eval("ID") %>'>Followup</a>
                                                                    </li>
                                                                </ul>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </a>
                                                <div class="card-body">
                                                    <div class="pmo-contact">
                                                        <ul>
                                                            <li class="ng-binding">
                                                                <b>Created Date : </b>
                                                                <i class="zmdi zmdi-calendar-check"></i>
                                                                <%# Convert.ToDateTime(Eval("LEAD_DATE")).ToString("dd-MM-yyyy") %></li>
                                                            <li class="ng-binding"><b>
                                                                <i class="zmdi zmdi-account"></i>Added By : </b>
                                                                <%# Eval("ASSIGNED_BY") %></li>
                                                            <li class="ng-binding">
                                                                <i class="zmdi zmdi-calendar-note"></i><b>Address : </b>
                                                                <%# Eval("ADDRESS") %><br />
                                                                <%# Eval("CITY_NAME") %><br />
                                                                <%# Eval("STATE_NAME") %>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>


                                <div class="col-sm-4">
                                    <div class="card">
                                        <div class="card-header bgm-teal">
                                            <h2>Anant Jaiswal<br />
                                                <small>anant@gmail.com</small>
                                                <small>9714252707</small>
                                            </h2>

                                            <ul class="actions actions-alt">
                                                <li class="dropdown">
                                                    <a href="#" data-toggle="dropdown" aria-expanded="false">
                                                        <i class="zmdi zmdi-more-vert"></i>
                                                    </a>
                                                    <ul class="dropdown-menu dropdown-menu-right">
                                                        <li>
                                                            <a href="#">Followup</a>
                                                        </li>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="card-body">
                                            <div class="pmo-contact">
                                                <ul>
                                                    <li class="ng-binding">
                                                        <b>Created Date : </b>
                                                        <i class="zmdi zmdi-calendar-check"></i>
                                                        10-10-2017</li>
                                                    <li class="ng-binding"><b>
                                                        <i class="zmdi zmdi-account"></i>Added By : </b>
                                                        Anant</li>
                                                    <li class="ng-binding">
                                                        <i class="zmdi zmdi-calendar-note"></i><b>Address : </b>
                                                        asdasd
                                        asdasdasdasd<br />
                                                        asdasd
                                        asdasdasdasd<br />
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="card">
                                        <div class="card-header bgm-teal">
                                            <h2>Anant Jaiswal<br />
                                                <small>anant@gmail.com</small>
                                                <small>9714252707</small>
                                            </h2>

                                            <ul class="actions actions-alt">
                                                <li class="dropdown">
                                                    <a href="#" data-toggle="dropdown" aria-expanded="false">
                                                        <i class="zmdi zmdi-more-vert"></i>
                                                    </a>
                                                    <ul class="dropdown-menu dropdown-menu-right">
                                                        <li>
                                                            <a href="#">Followup</a>
                                                        </li>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="card-body">
                                            <div class="pmo-contact">
                                                <ul>
                                                    <li class="ng-binding">
                                                        <b>Created Date : </b>
                                                        <i class="zmdi zmdi-calendar-check"></i>
                                                        10-10-2017</li>
                                                    <li class="ng-binding"><b>
                                                        <i class="zmdi zmdi-account"></i>Added By : </b>
                                                        Anant</li>
                                                    <li class="ng-binding">
                                                        <i class="zmdi zmdi-calendar-note"></i><b>Address : </b>
                                                        asdasd
                                        asdasdasdasd<br />
                                                        asdasd
                                        asdasdasdasd<br />
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <!-- Calendar -->
                    <div id="calendar-widget"></div>
                    <!-- Recent Posts -->
                    <div class="card">
                        <div class="card-header ch-alt m-b-20">
                            <h2>Today Followup<%--<small>Phasellus condimentum ipsum id auctor imperdie</small>--%>
                                <%--<span class="pull-right"><a href="Client.aspx" class="btn bgm-teal btn-icon waves-effect waves-circle waves-float" title="Generate Lead">
                                    <i style="vertical-align: middle;" class="zmdi zmdi-plus"></i></a></span>--%>
                            </h2>
                        </div>
                        <div class="card-body  m-l-10 m-r-10">
                            <div class="row">
                                <div class="alert alert-success" role="alert" runat="server" id="divSuccess" visible="false">
                                    <asp:Literal runat="server" ID="ltrSuccess"></asp:Literal>
                                    <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                                </div>

                                <div class="alert alert-danger m-10" role="alert" runat="server" id="divNoDataLF" visible="false">
                                    no more Lead Followup 
                                </div>


                                <asp:Repeater runat="server" ID="rpLeadFollowup">
                                    <ItemTemplate>
                                        <div class="col-sm-4">
                                            <div class="card">
                                                <div class="card-header bgm-bluegray">
                                                    <h2><%# Eval("clientname") %>
                                                        <span class="pull-right"><%# Convert.ToDateTime(Eval("LEAD_DATE")).ToString("dd-MM-yyyy") %></span>
                                                        <small><%# Eval("EMAIL") %></small>

                                                        <small>
                                                            <%# Eval("LEAD_MOBILE") %>
                                                        </small>
                                                    </h2>
                                                    <asp:LinkButton runat="server" ID="lbEdit" CommandArgument='<%# Eval("ID") %>' OnClick="lbEdit_Click" CssClass="btn bgm-teal btn-float waves-effect waves-circle waves-float" ToolTip="Edit Followup">
                                         <i class="zmdi zmdi-edit"></i>
                                                    </asp:LinkButton>
                                                </div>
                                                <div class="card-body card-padding" style="min-height: 170px;">
                                                    <div class="pmo-contact">
                                                        <ul>
                                                            <li class="ng-binding">
                                                                <b>Followup Date : </b>
                                                                <i class="zmdi zmdi-calendar-check"></i>
                                                                <%# Convert.ToDateTime(Eval("FOLLOWUP_DATE")).ToString("dd-MM-yyyy") %></li>

                                                            <li class="ng-binding">
                                                                <i class="zmdi zmdi-calendar-note"></i><b>Notes : </b>
                                                                <%# Eval("NOTE") %>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>




                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
