<%@ Page Title="" Language="C#" MasterPageFile="~/tm-admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AllTask.aspx.cs" Inherits="TaskManager.tm_admin.AllTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script>

            $(document).ready(function () {

                $("#spanalldeleted").hide();
                $("#filterbydate").hide();
          
            });


            function CheckAll(check) {                
                if (check.checked) {
                    $('.checkbox_grid').each(function () {
                        this.checked = true;
                    });
                    $("#spanalldeleted").show();
                }
                else {
                    $('.checkbox_grid').each(function () {
                        this.checked = false;
                    });
                    $("#spanalldeleted").hide();
                }                
            }


            $('.checkall').bind("click", function () {
                alert();
                debugger;
                //if (this.checked) {
                //    $('.checkbox_grid').each(function () {
                //        this.checked = true;
                //    });
                //    $("#spanalldeleted").show();
                //}
                //else {
                //    $('.checkbox_grid').each(function () {
                //        this.checked = false;
                //    });
                //    $("#spanalldeleted").hide();
                //}
            });
            function IsCheckedOrNot(check) {
                //alert(check.checked);
                //if (check.checked == true)
                //    $("#spanalldeleted").show();
                //else
                //    $("#spanalldeleted").hide();

                var i = 0;
                $('.checkbox_grid').each(function () {
                    //alert(this.checked);
                    if (this.checked == true) {
                        i++;
                    }
                });

                if (i >= 1)
                    $("#spanalldeleted").show();
                else
                    $("#spanalldeleted").hide();
            }
        </script>
    <script>
        function FilterDropdownChange(filter) {
            var selectedValue = filter.value;
            //console.log(filter);
            //alert(selectedValue);
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

    <section id="content" ng-app="ToDoListApp" ng-controller="ToDoListController">
        <div class="container">
            <%--<div class="block-header">
                <h2>ALL LEAD</h2>
            </div>--%>
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
                                        <td>Actual Date of Work finish</td>
                                        <td><span ng-bind="TASK_DETAIL.ACTUAL_WORK_FINISH_DATE"></span></td>                                        
                                    </tr>                                                                        
                                    <tr>
                                        <td>Actual Days taken</td>
                                        <td><span ng-bind="TASK_DETAIL.ACTUAL_DAYS_TAKEN"></span></td>
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
                                            <%--<span ng-bind="TASK_DETAIL.STATUS"></span>--%>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trWorkHome" visible="false">
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
                                    <%--<tr>
                                        <td></td>
                                        <td>
                                            <button type="button" title="View Task" ng-confirm-click="Are You Sure To Close this task ? " confirmed-click="CloseTask(TASK_DETAIL)"
                                                class="btn btn-danger waves-effect waves-float">
                                                <i class="zmdi zmdi-close-circle-o">Close Task</i>
                                            </button>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <%--<button type="button" ng-if="TASK_DETAIL.IS_CLOSED!='1'" title="View Task" ng-confirm-click="Are You Sure To Close this task ? " confirmed-click="UpdateTask(TASK_DETAIL,1)"
                                class="btn btn-danger waves-effect waves-float pull-left">
                                <i class="zmdi zmdi-close-circle-o">Close Task</i>
                            </button>--%>

                            <button type="button" style="display:none;" ng-if="TASK_DETAIL.IS_CLOSED!='1'" title="View Task" ng-click="UpdateTask(TASK_DETAIL)"
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
                    <h2>All Task
                        <a href="#" class="notifications btn btn-success" style="visibility: hidden;" data-type="success">Success</a>
                        <a href="CreateTask.aspx" class="pull-right btn btn-info">
                            <i class="zmdi zmdi-plus text-center"></i>&nbsp;Create Task</a>

                    </h2>
                    <h2>
                        <asp:Literal runat="server" ID="ltrnotfound"></asp:Literal>
                    </h2>

                    <hr />
                    <div class="row">
                        <div class="col-sm-2">
                            <%--onchange="FilterDropdownChange(this)" --%>
                            <select class="form-control" ng-change="FilterDropdownChangeAllTask()" ng-model="FilterOption">
                                <option value="todays+overdue">Todays + Overdue Task</option>
                                <option value="myopentask">Open Task</option>
                                <option value="next7daystask">Next 7 days Task</option>
                                <option value="overduetask">Overdue Task</option>
                                <option value="todaystask">Today's Task</option>
                                <option value="closetask">Completed Task</option>
                                <option value="filterbydate">Filter by date</option>
                                <%--<option value="Workfromhome">Work from home</option>--%>
                                <option value="alltask">All Task</option>
                                <option value="0" disabled="disabled">---------------------------------</option>
                                <option value="In Progress">In Progress Task</option>
                                <option value="Not Started">Not Started Task</option>
                                <option value="yesterdaycomletetask">Yesterday Completed Task</option>
                            </select>
                        </div>
                        <div id="filterbydate">
                            <div class="col-sm-2">
                                <div class="form-group fg-line  m-b-10">
                                    <label class="sr-only" for="exampleInputEmail2">From Date</label>
                                    <input type="text" id="FROM_DATE" class="form-control date-picker" placeholder="Select from date" />
                                </div>
                            </div>

                            <div class="col-sm-2">
                                <div class="form-group fg-line m-b-10">
                                    <label class="sr-only" for="exampleInputPassword2">To Date</label>
                                    <input type="text" id="TO_DATE" class="form-control date-picker" placeholder="Select to date" />
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <button type="button" ng-click="GetAllTask()" class="btn btn-primary btn-sm m-t-5">Filter</button>
                            </div>
                        </div>
                    </div>

                </div>
                <%--<ul class="tab-nav" role="tablist">
                    <li class="active"><a href="#opentask" aria-controls="opentask" role="tab" data-toggle="tab">Open Task</a></li>
                    <li><a href="#closedtask" aria-controls="closedtask" role="tab" data-toggle="tab">Closed Task</a></li>
                </ul>
                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane active" id="opentask">--%>
                <div class="table-responsive">
                    <div class="card-body">
                        <span style="margin-left: 10px;" id="spanalldeleted">
                            <button type="button" title="Delete" ng-confirm-click="Are You Sure To Delete this Record ? " confirmed-click="DeleteSeletedTask()"
                                class="btn btn-danger waves-effect waves-float">
                                <i class="zmdi zmdi-delete"></i>&nbsp;Delete Selected
                            </button>
                        </span>

                        <table class="table table-hover" datatable="ng">
                            <thead>
                                <tr>
                                    <%--<th>#</th>--%>
                                    <th>
                                        <div class="checkbox">
                                            <label>
                                                <input class="checkall" onclick="CheckAll(this)" type="checkbox" value="">
                                                <i class="input-helper"></i>
                                            </label>
                                        </div>
                                    </th>

                                    
                                    <th>Assign to</th>
                                    <th>Client Name</th>
                                    <th>Contact Person</th>
                                    <th>Client Number</th>
                                    <th>Email ID</th>
                                    <th>Client Group</th>
                                    <th>Nature Of Work</th>                                    
                                    <th>Work Recieved On    </th>
                                    <th>Due Date</th>
                                    <th>Closed Date</th>
                                    <th>Status</th>
                                    <th>Remark</th>
                                    <th>Priority</th>

                                    <%--<th>Subject</th>
                                    <th>Created Time</th>
                                    <th>Due Date</th>
                                    <th>Closed Date</th>
                                    <th>Status</th>
                                    <th>Description</th>
                                    <th>Priority</th>                   
                                    <th>Repeat Type</th>--%>
                                    <th>Task Owner</th>                                   
                                    
                                     <th>Action</th>
                                </tr>
                            </thead>

                            <tbody>
                                <tr ng-repeat="x in alltasklist">
                                    <%--<td><span>{{$index+1}}</span>
                                            </td>--%>
                                    <td>
                                        <div class="checkbox ">
                                            <label>
                                                <input type="checkbox" onclick="IsCheckedOrNot(this)" class="checkbox_grid" value="{{x.ID}}" />
                                                <i class="input-helper"></i>
                                            </label>
                                        </div>

                                    </td>
                                    
                                    <td ng-bind="x.ASSIGNED_EMPLOYEE_NAME"></td>
                                                                        
                                    <td ng-bind="x.SUBJECT"></td>
                                    <td ng-bind="x.CONTACT_PERSON"></td>
                                    <td ng-bind="x.CONTACT_NUMBER"></td>                        
                                    <td ng-bind="x.CONTACT_EMAIL_ID"></td>
                                    <td ng-bind="x.CLIENT_GROUP"></td>                                    
                                    <td ng-bind="x.NATURE_OF_WORK"></td>                                                                        
                                    <td ng-bind="x.START_DATE"></td>
                                    <td ng-bind="x.DUE_DATE"></td>
                                    <td ng-bind="x.CLOSED_DATE"></td>
                                    <td ng-bind="x.STATUS"></td>
                                    <td ng-bind="x.DESCRIPTION"></td>
                                    <td ng-bind="x.PRIORITY"></td>
                                    
                                    <td ng-bind="x.TASK_OWNER_NAME"></td>
                                    <td>
                                        <button data-toggle="modal" ng-click="ViewTaskDetail(x)" href="#modalDefault" type="button" title="View Task"
                                            class="btn btn-primary waves-effect waves-float">
                                            <i class="zmdi zmdi-eye"></i>
                                        </button>
                                        <button type="button" title="Delete" ng-confirm-click="Are You Sure To Delete this Record ? " confirmed-click="DeleteTask(x.ID,'alltask')"
                                            class="btn btn-danger waves-effect waves-float">
                                            <i class="zmdi zmdi-delete"></i>
                                        </button>


                                    </td>
                                    <%-- <td>
                                                <button data-toggle="modal" ng-click="ViewTaskDetail(x)" href="#modalDefault" type="button" title="View Task"
                                                    class="btn btn-primary waves-effect waves-float">
                                                    <i class="zmdi zmdi-eye"></i>
                                                </button>
                                                <button type="button" title="Delete" ng-confirm-click="Are You Sure To Delete this Record ? " confirmed-click="DeleteTask(x.ID)"
                                                    class="btn btn-danger waves-effect waves-float">
                                                    <i class="zmdi zmdi-delete"></i>
                                                </button>


                                            </td>--%>
                                </tr>
                            </tbody>
                        </table>
                        <%--<asp:GridView runat="server" CssClass="table-responsive table table-bordered panel table-hover " AutoGenerateColumns="False" ID="gv">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr. No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SUBJECT" HeaderText="SUBJECT" />
                                        <asp:BoundField DataField="DUE_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="DUE_DATE" />
                                        <asp:BoundField DataField="REPEAT_TYPE" HeaderText="REPEAT_TYPE" />
                                        <asp:BoundField DataField="STATUS" HeaderText="STATUS" />
                                        <asp:BoundField DataField="PRIORITY" HeaderText="PRIORITY" />
                                        <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" />

                                        <asp:BoundField DataField="CREATED" DataFormatString="{0:dd/MM/yyyy}" HeaderText="CREATED AT" />
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <span runat="server" id="divAction">
                                                    <asp:LinkButton runat="server" CssClass="btn btn-primary waves-effect waves-float" CommandArgument='<%# Eval("ID") %>'
                                                        ID="lbEdit"><i class="zmdi zmdi-eye"></i></asp:LinkButton>
                                                    <asp:LinkButton runat="server" class="btn btn-danger waves-effect waves-float" CommandArgument='<%# Eval("id") %>'
                                                        OnClientClick="return confirm('Are you sure?');" ID="lbDelete" OnClick="lbDelete_Click"><i class="zmdi zmdi-delete"></i></asp:LinkButton>
                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>--%>
                    </div>

                </div>
                <%--</div>--%>                
                <%--</div>--%>
            </div>
        </div>
    </section>

</asp:Content>
