<%@ Page Title="" Language="C#" MasterPageFile="~/tm-admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MyTaskReport.aspx.cs" Inherits="TaskManager.tm_admin.MyTaskReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>

        $(document).ready(function () {
            $("#filterbydate").hide();
            var selectedValue = $(".ddlFilter").val();
            if (selectedValue == 'filterbydate') {
                $("#filterbydate").show();
            }
            else {
                $("#filterbydate").hide();
            }
        });
    </script>

    <script>
        function FilterDropdownChange(filter) {
            var selectedValue = filter.value;
            if (selectedValue == 'filterbydate') {
                $("#filterbydate").show();
            }
            else {
                $("#filterbydate").hide();
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="content">
        <div class="container">
            <div class="modal fade" id="modalDefault" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Task Detail</h4>
                        </div>
                        <div class="modal-body">
                            <div class="table-responsive">
                                <table class="table table-bordered">
                                    <tr>
                                        <td>Subject</td>
                                        <td><span ng-bind="TASK_DETAIL.SUBJECT"></span></td>
                                    </tr>
                                    <tr>
                                        <td>Due Date</td>
                                        <td><span ng-bind="TASK_DETAIL.DUE_DATE"></span></td>
                                    </tr>
                                    <tr>
                                        <td>Repeat type</td>
                                        <td><span ng-bind="TASK_DETAIL.REPEAT_TYPE"></span></td>
                                    </tr>
                                    <tr>
                                        <td>Status</td>
                                        <td>
                                            <select name="Status" ng-model="TASK_DETAIL.STATUS" class="form-control">
                                                <option>Not Started</option>
                                                <option>In Progress</option>
                                                <option>Waiting for input</option>
                                                <option>Completed</option>
                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Work from home</td>
                                        <td>
                                            <div class="fg-line ">
                                                <div class="toggle-switch">
                                                    <label for="tsworkfromhome" class="ts-label"></label>
                                                    <input id="tsworkfromhome" ng-model="TASK_DETAIL.WORK_FROM_HOME" type="checkbox" ng-true-value="true" ng-false-value="false" name="WORK_FROM_HOME" hidden="hidden">
                                                    <label for="tsworkfromhome" class="ts-helper"></label>
                                                </div>
                                            </div>

                                            <%--<span ng-bind="TASK_DETAIL.STATUS"></span>--%>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td>Description</td>
                                        <td>
                                            <textarea class="form-control" ng-model="TASK_DETAIL.DESCRIPTION"></textarea>
                                            <%--<span ng-bind="TASK_DETAIL.DESCRIPTION"></span>--%>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Notes</td>
                                        <td>
                                            <textarea class="form-control" ng-model="TASK_DETAIL.NOTES"></textarea>
                                        </td>
                                    </tr>


                                </table>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" ng-if="TASK_DETAIL.IS_CLOSED!='1'" title="View Task" ng-confirm-click="Are You Sure To Close this task ? " confirmed-click="UpdateTask(TASK_DETAIL,1)"
                                class="btn btn-danger waves-effect waves-float pull-left">
                                <i class="zmdi zmdi-close-circle-o">Close Task</i>
                            </button>

                            <button type="button" ng-if="TASK_DETAIL.IS_CLOSED!='1'" title="View Task" ng-click="UpdateTask(TASK_DETAIL,0)"
                                class="btn btn-primary waves-effect waves-float">
                                Update Task
                            </button>



                            <%--<button type="button" class="btn btn-danger">Close Task</button>--%>
                            <button type="button" class="btn btn-link closepopup" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="alert alert-danger" runat="server" id="divError" visible="false">
                    Changes Not Done ! 
                </div>
                <div class="alert alert-success" runat="server" id="divSuccess" visible="false">
                    Changes Successfully Done ! 
                </div>
                <div class="card-header">
                    <h2>Task Report
                        <a href="#" class="notifications btn btn-success" style="visibility: hidden;" data-type="success">Success</a>
                        <span class="pull-right" style="width: 200px;"></span>
                    </h2>
                    <h2>
                        <asp:Literal runat="server" ID="ltrnotfound"></asp:Literal>
                    </h2>

                    <hr />
                    <div class="row">
                        <div class="col-sm-2">
                            <%--onchange="FilterDropdownChange(this)" --%>
                            <asp:DropDownList ID="ddlColumn" runat="server" CssClass="selectpicker">
                                <asp:ListItem Value="CREATED">Task Create Time</asp:ListItem>
                                <asp:ListItem Value="UPDATED">Task Modified Time</asp:ListItem>
                                <asp:ListItem Value="CLOSED_DATE">Task Closed Time</asp:ListItem>
                                <asp:ListItem Value="DUE_DATE">Task Due Time</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlFilter" CssClass="ddlFilter selectpicker" runat="server" onchange="FilterDropdownChange(this)">
                                <asp:ListItem Value="0">Current Month</asp:ListItem>
                                <asp:ListItem Value="1">Next Month</asp:ListItem>
                                <asp:ListItem Value="-1">Previous Month</asp:ListItem>
                                <asp:ListItem Value="filterbydate">Custom</asp:ListItem>
                            </asp:DropDownList>
                            <%--<select class="form-control" ng-change="FilterDropdownChange()" ng-model="FilterOption">
                                <option value="todays+overdue">Todays + Overdue Task</option>
                                <option value="myopentask">My Open Task</option>
                                <option value="next7daystask">Next 7 days Task</option>
                                <option value="overduetask">Overdue Task</option>
                                <option value="todaystask">Today's Task</option>
                                <option value="closetask">Close Task</option>
                                <option value="filterbydate">Filter by date</option>
                                <option value="Workfromhome">Work from home</option>
                                <option value="alltask">All Task</option>
                                <option value="0" disabled="disabled">---------------------------------</option>
                                <option value="In Progress">In Progress Task</option>
                                <option value="Not Started">Not Started Task</option>
                                <option value="yesterdaycomletetask">Yesterday Complete Task</option>
                            </select>--%>
                        </div>
                        <div id="filterbydate">
                            <div class="col-sm-2">
                                <div class="form-group fg-line  m-b-10">
                                    <label class="sr-only" for="exampleInputEmail2">From Date</label>
                                    <asp:TextBox runat="server" ID="txtFromDate" CssClass="form-control date-picker" placeholder="Select from date"></asp:TextBox>
                                    <%--<input type="text" id="FROM_DATE" class="form-control date-picker" placeholder="Select from date" />--%>
                                </div>
                            </div>

                            <div class="col-sm-2">
                                <div class="form-group fg-line m-b-10">
                                    <label class="sr-only" for="exampleInputPassword2">To Date</label>
                                    <asp:TextBox runat="server" ID="txtToDate" CssClass="form-control date-picker" placeholder="Select to date"></asp:TextBox>
                                    <%--<input type="text" id="TO_DATE" class="form-control date-picker" placeholder="Select to date" />--%>
                                </div>
                            </div>

                        </div>
                        <div class="col-sm-2">
                            <asp:LinkButton runat="server" ID="lbFilter" CssClass="btn btn-primary btn-sm" OnClick="lbFilter_Click">Filter</asp:LinkButton>
                            <%--<button type="button" ng-click="GetMyTask()" class="btn btn-primary btn-sm m-t-5">Filter</button>--%>
                        </div>
                        <div class="col-sm-2 pull-right">
                            <div class="dropdown" data-animation="bounceIn,bounceOut,1000">
                                <button type="button" class="btn btn-primary" data-toggle="dropdown">Export <i class="caret"></i></button>
                                <ul class="dropdown-menu">
                                    <li>
                                        <asp:LinkButton runat="server" ID="lbExportExcel" OnClick="lbExportExcel_Click">Export to Excel</asp:LinkButton>

                                    </li>
                                    <li>
                                        <asp:LinkButton runat="server" ID="LinkButton1" CssClass="" OnClick="ExportToPDF">Export to PDF</asp:LinkButton></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <%--<ul class="tab-nav" role="tablist">
                    <li class="active"><a href="#opentask" aria-controls="opentask" role="tab" data-toggle="tab">Task Listing</a></li>
                    <li><a href="#closedtask" aria-controls="closedtask" role="tab" data-toggle="tab">Closed Task</a></li>
                </ul>
                <div class="tab-content">--%>
                <%--<div role="tabpanel" class="tab-pane active" id="opentask">--%>
                <div class="table-responsive">
                    <div class="card-body">
                        <%--<span style="margin-left: 10px;" id="spanalldeleted">
                            <button type="button" title="Delete" ng-confirm-click="Are You Sure To Delete this Record ? " confirmed-click="DeleteSeletedTask()"
                                class="btn btn-danger waves-effect waves-float">
                                <i class="zmdi zmdi-delete"></i>&nbsp;Delete Selected
                            </button>
                        </span>--%>
                        <table class="table table-bordered">
                            <asp:Repeater runat="server" ID="rpMyTask">
                                <HeaderTemplate>
                                    <tr>
                                        <th>SUBJECT</th>
                                        <th>STATUS</th>
                                        <th>CREATED TIME</th>
                                        <th>DUE DATE</th>
                                        <th>CLOSED TIME</th>
                                        <th>DESCRIPTION</th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("SUBJECT") %>
                                        </td>
                                        <td>
                                            <%# Eval("STATUS") %>
                                        </td>
                                        <td>
                                            <%# Convert.ToDateTime(Eval("CREATED")).ToString("dd-MM-yyyy HH:mm tt")  %>
                                        </td>
                                        <td>
                                            <%# Convert.ToDateTime(Eval("DUE_DATE")).ToString("dd-MM-yyyy") %>
                                        </td>
                                        <td>
                                            <%# Eval("CLOSED_DATE").ToString()!="" ? Convert.ToDateTime(Eval("CREATED")).ToString("dd-MM-yyyy HH:mm tt")  :"" %>
                                        </td>
                                        <td>
                                            <%# Eval("DESCRIPTION") %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <asp:GridView CssClass="table table-bordered" runat="server" ID="gvTask" AutoGenerateColumns="false" ShowFooter="true">
                            <Columns>
                                <asp:BoundField DataField="SUBJECT" HeaderText="SUBJECT" />
                                <asp:BoundField DataField="STATUS" HeaderText="STATUS" />
                                <asp:BoundField DataField="CREATED" HeaderText="CREATED TIME" DataFormatString="{0:dd-MM-yyyy HH:mm tt}" />
                                <asp:BoundField DataField="DUE_DATE" HeaderText="DUE DATE" DataFormatString="{0:dd-MM-yyyy}" />
                                <asp:BoundField DataField="CLOSED_DATE" HeaderText="CLOSED TIME" DataFormatString="{0:dd-MM-yyyy HH:mm tt}" />
                                <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" />
                            </Columns>
                        </asp:GridView>


                    </div>

                </div>
            </div>
        </div>
    </section>

</asp:Content>
