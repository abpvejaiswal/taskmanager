<%@ Page Title="" Language="C#" MasterPageFile="~/tm-admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CreateTask.aspx.cs" Inherits="TaskManager.tm_admin.CreateTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $("#rp_type").hide();
            $("#rt_day").hide();
            $("#rt_week").hide();
            $("#rt_month").hide();
            $("#rt_year").hide();


        });
        function OnRepeatChange(ddlFruits) {
            var selectedValue = ddlFruits.value;
            //alert("Selected Text: " + selectedText + " Value: " + selectedValue);
            //alert(selectedValue);
            $("#rt_day").hide();
            $("#rt_week").hide();
            $("#rt_month").hide();
            $("#rt_year").hide();
            if (selectedValue == "Daily") {
                //alert(selectedValue);
                $("#rt_day").show();
            }
            if (selectedValue == "Weekly") {
                $("#rt_week").show();
            }
            if (selectedValue == "Monthly") {
                $("#rt_month").show();
            }
            if (selectedValue == "Yearly") {
                $("#rt_year").show();
            }

        }

        function IsRepeatRadio() {
            var checked = $('input[name="repeatradio"]:checked').val();
            if (checked == 'on') {
                $("#rp_type").show();
            }
            else {
                $("#rp_type").hide();
            }
        }
    </script>


    <style>
        .col-sm-3 {
            margin-bottom: 18px;
        }

        .form-group.fg-float {
            margin-top: 18px;
            margin-bottom: 0px;
        }
    </style>
    <script>
        $(".CONTACT_PERSON").change(function () {
            alert();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="content" ng-app="ToDoListApp" ng-controller="ToDoListController">
        <div class="container">
            <div class="card">
                <!--<div class="card-header">
                            <h2>Input Groups <small>Extend form controls by adding text or buttons before, after, or on both sides of any text-based inputs.</small></h2>
                        </div>
                        -->
                <div class="card-body card-padding">
                    <div class="alert alert-success" role="alert" runat="server" id="divSuccess" visible="false">
                        <asp:Literal runat="server" ID="ltrSuccess"></asp:Literal>
                        <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                    </div>

                    <div class="alert alert-danger" role="alert" runat="server" id="divError" visible="false">
                        <asp:Literal runat="server" ID="ltrError"></asp:Literal>
                        <asp:Label runat="server" ID="lblError"></asp:Label>
                    </div>
                    <p class="c-black f-500 m-b-5">
                        Create Task <small style="color: red;">(*) = all fields are compulsory.</small>
                        <a href="#" class="notifications btn btn-success" data-custommessage="" style="visibility: hidden;" data-type="success">Success</a>
                    </p>
                    <hr />
                    <!--<small>Place one add-on or button on either side of an input. You may also place one on both sides of an input.</small>-->
                    <div role="tabpanel">
                        <div class="row">
                            <div class="col-sm-3">
                                <div class="form-group m-b-10">
                                    <div class="fg-line ">
                                        <label class="fg-label">Assign to <span style="color: red;">* </span></label>
                                        <asp:DropDownList runat="server" TabIndex="1" ClientIDMode="Static" ng-model="ADD_TASK.ASSIGN_TO" ID="ddlEmployee" CssClass="selectpicker ddlEmployee" data-placeholder="Please select an employee" data-live-search="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group fg-float">
                                    <div class="fg-line">
                                        <input type="text" required ng-model="ADD_TASK.SUBJECT" tabindex="2" class="form-control" />
                                    </div>
                                    <label class="fg-label">Client Name <%--(replaced in Subject)--%> <span style="color: red;">* </span></label>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group m-b-10">
                                    <div class="fg-line ">
                                        <label class="fg-label">Client Group<span style="color: red;"> </span></label>
                                        <asp:DropDownList runat="server" ClientIDMode="Static" TabIndex="3" ID="ddlClientGroup" CssClass="selectpicker CLIENT_GROUP" data-placeholder="Please select an client group" data-live-search="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-3">
                                <div class="form-group m-b-10">
                                    <div class="fg-line ">
                                        <label class="fg-label">Nature Of Work<span style="color: red;"> </span></label>
                                        <asp:DropDownList runat="server" ClientIDMode="Static" TabIndex="4" ID="ddlNatureOfWork" CssClass="selectpicker NATURE_OF_WORK" data-live-search="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="updatepnl" runat="server">
                                <ContentTemplate>
                                    <div class="col-sm-3">
                                        <div class="form-group m-b-10">
                                            <div class="fg-line ">
                                                <label class="fg-label">Contact Person<span style="color: red;">*</span></label>
                                                <asp:DropDownList runat="server" ID="ddlContactPerson" TabIndex="5" CssClass="selectpicker CONTACT_PERSON" data-placeholder="Please select an contact person" data-live-search="true" ng-change="ChangeContactPerson()" ng-model="ADD_TASK.CONTACT_PERSON">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-2">
                                        <div class="form-group fg-float">
                                            <div class="fg-line myfg">
                                                <asp:TextBox runat="server" ID="txtCONTACT_NUMBER" TabIndex="6" ClientIDMode="Static" CssClass="form-control" ng-model="ADD_TASK.CONTACT_NUMBER"></asp:TextBox>                                                
                                            </div>
                                            <label class="fg-label">Contact Number<span style="color: red;">*</span></label>
                                        </div>
                                    </div>

                                    <div class="col-sm-2">
                                        <div class="form-group fg-float">
                                            <div class="fg-line myfg">
                                                <asp:TextBox runat="server" ID="txtCONTACT_EMAIL_ID" TabIndex="7" ClientIDMode="Static" CssClass="form-control " ng-model="ADD_TASK.CONTACT_EMAIL_ID"></asp:TextBox>
                                                <%--<input type="text" class="form-control " ng-model="ADD_TASK.CONTACT_EMAIL_ID" />--%>
                                            </div>
                                            <label class="fg-label">Email ID<span style="color: red;">*</span></label>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="col-sm-3">
                                <div class="form-group m-b-10">
                                    <div class="fg-line ">
                                        <label class="fg-label">Select Financial Year/Month<span style="color: red;"> </span></label>
                                        <asp:DropDownList runat="server" ClientIDMode="Static" TabIndex="8" ID="ddlYear" CssClass="selectpicker FINANCIAL_YEAR" ng-model="ADD_TASK.FINANCIAL_YEAR" data-placeholder="Please select an year" data-live-search="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-2">
                                <div class="form-group fg-float">
                                    <div class="fg-line fg-toggled">
                                        <input type="text" id="txtASSESSMENT_YEAR" tabindex="9" class="form-control ASSESSMENT_YEAR" ng-model="ADD_TASK.ASSESSMENT_YEAR" />
                                    </div>
                                    <label class="fg-label">Assessment Year/Month</label>
                                </div>
                            </div>
                            <div class="clearfix">&nbsp;</div>


                            <div class="col-sm-2">
                                <div class="form-group fg-float">
                                    <div class="fg-line">
                                        <input type="text" id="START_DATE" tabindex="10" ng-model="ADD_TASK.START_DATE" class="form-control date-picker" />
                                    </div>
                                    <label class="fg-label">Work Recieved on<span style="color: red;"> * </span></label>
                                </div>
                            </div>

                            <div class="col-sm-3">
                                <div class="form-group fg-float">
                                    <div class="fg-line fg-targeted">
                                        <input type="text" ng-model="ADD_TASK.TARGETED_DAYS" tabindex="11" ng-change="GetTargetedDays(ADD_TASK.TARGETED_DAYS)" class="form-control" />
                                    </div>
                                    <label class="fg-label">Targeted Days for work completion<span style="color: red;"> * </span></label>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group fg-float">
                                    <div class="fg-line">
                                        <input type="text" id="DUE_DATE" tabindex="12" ng-model="ADD_TASK.DUE_DATE" class="form-control date-picker" />
                                    </div>
                                    <label class="fg-label">Targated Date of work finish<span style="color: red;"> * </span></label>
                                </div>
                            </div>
                            <div class="col-sm-2" style="display:none;">
                                <div class="form-group fg-float">
                                    <div class="fg-line">
                                        <input type="text" id="REMINDER_DAY_BEFORE" class="form-control " ng-model="ADD_TASK.REMINDER_DAY_BEFORE" />
                                    </div>
                                    <label class="fg-label">Reminder day before on </label>
                                </div>
                            </div>

                            <div class="clearfix">&nbsp;</div>
                            <div class="col-sm-3">
                                <div class="form-group ">
                                    <div class="fg-line ">
                                        <label class="fg-label">Status</label>
                                        <select name="Status" ng-model="ADD_TASK.STATUS" class="form-control">
                                            <option>Not Started</option>
                                            <option>In Progress</option>
                                            <option>Waiting for input</option>
                                            <option>Completed</option>
                                        </select>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-3">
                                <div class="form-group ">
                                    <div class="fg-line ">
                                        <label class="fg-label">Priority</label>
                                        <select name="Status" ng-model="ADD_TASK.PRIORITY" class="form-control">
                                            <option>High</option>
                                            <option>Medium</option>
                                            <option>Low</option>
                                        </select>

                                        <%--  <asp:DropDownList runat="server" ID="ddlPriority" CssClass="form-control">
                                            <asp:ListItem>High</asp:ListItem>
                                            <asp:ListItem>Low</asp:ListItem>
                                        </asp:DropDownList>--%>
                                    </div>
                                </div>
                            </div>


                            <div class="col-sm-12">
                                <div class="form-group fg-float m-t-20">
                                    <div class="fg-line">
                                        <div class="toggle-switch">
                                            <label for="ts1" class="ts-label">Repeat</label>
                                            <input onchange="IsRepeatRadio()" id="ts1" ng-model="ADD_TASK.IS_REPEAT" type="checkbox" ng-true-value="true" ng-false-value="false" name="repeatradio" hidden="hidden">
                                            <label for="ts1" class="ts-helper"></label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--start repeat portion--%>
                            <div class="row" id="rpportion" runat="server" visible="false">
                                <div class="col-sm-1">
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group fg-float">
                                        <div class="fg-line">
                                            <asp:TextBox runat="server" ID="TextBox2" class="form-control date-time-picker"></asp:TextBox>
                                        </div>
                                        <label class="fg-label">Start Date</label>
                                    </div>
                                </div>
                                <div class="col-sm-3">
                                    <div class="form-group fg-float">
                                        <div class="fg-line">
                                            <asp:TextBox runat="server" ID="TextBox1" class="form-control date-time-picker"></asp:TextBox>
                                        </div>
                                        <label class="fg-label">End Date</label>
                                    </div>
                                </div>
                                <div class="clearfix">&nbsp;</div>
                            </div>
                            <div id="rp_type">
                                <div class="row">
                                    <div class="col-sm-1">
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group ">
                                            <div class="fg-line ">
                                                <label class="fg-label">Repeat Type</label>
                                                <select name="Status" ng-model="ADD_TASK.REPEAT_TYPE" class="selectpicker REPEAT_TYPE" onchange="OnRepeatChange(this)">
                                                    <option>None</option>
                                                    <option>Daily</option>
                                                    <option>Weekly</option>
                                                    <option>Monthly</option>
                                                    <option>Yearly</option>
                                                </select>

                                                <%-- <asp:DropDownList runat="server" ID="DropDownList2" CssClass="selectpicker" onChange="OnRepeatChange(this)">
                                                <asp:ListItem>None</asp:ListItem>
                                                <asp:ListItem>Daily</asp:ListItem>
                                                <asp:ListItem>Weekly</asp:ListItem>
                                                <asp:ListItem>Monthly</asp:ListItem>
                                                <asp:ListItem>Yearly</asp:ListItem>
                                            </asp:DropDownList>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix">&nbsp;</div>
                                </div>
                                <div class="row" id="rt_day">
                                    <div class="col-sm-1">
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group fg-float">
                                            <label class="radio radio-inline m-r-20">
                                                <input type="radio" checked id="RepeatDayRadio" ng-model="ADD_TASK.IS_EVERY_DAY" name="RepeatDayRadio" ng-value="true" />
                                                <i class="input-helper"></i>
                                                Every Day
                                            </label>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group fg-float">
                                            <label class="radio radio-inline m-r-20">
                                                <input type="radio" id="RepeatDayRadio" ng-model="ADD_TASK.IS_EVERY_DAY" name="RepeatDayRadio" ng-value="false" />
                                                <i class="input-helper"></i>
                                                Repeat for every      
                                            </label>
                                            <input type="text" ng-model="ADD_TASK.REPEAT_FOR_EVERYDAY" style="width: 20px;" />
                                            <%--<asp:TextBox runat="server" Width="20" CssClass="form-inline" Text="1" ID="txtRepeatEveryWeek"></asp:TextBox>days--%>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" id="rt_week">
                                    <div class="col-sm-1">
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group fg-float">
                                            <label class="radio radio-inline m-r-20">
                                                <input checked type="radio" name="RepeatWeekRadio" value="option1" />
                                                <i class="input-helper"></i>
                                                Repeat for every            
                                            </label>
                                            <input type="text" ng-model="ADD_TASK.REPEAT_FOR_EVERYWEEK" style="width: 20px;" />
                                            week
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group ">
                                            <div class="fg-line">
                                                <select ng-model="lbCategory" id="REPEAT_WEEK_ON" multiple class="tag-select" data-placeholder="Repeat on">
                                                    <option>Sunday</option>
                                                    <option>Monday</option>
                                                    <option>Tuesday</option>
                                                    <option>Wednesday</option>
                                                    <option>Thursday</option>
                                                    <option>Friday</option>
                                                    <option>Saturday</option>
                                                </select>

                                                <%--<asp:DropDownList runat="server" ID="DropDownList1" multiple CssClass="tag-select" data-placeholder="Repeat on">
                                                <asp:ListItem>Sunday</asp:ListItem>
                                                <asp:ListItem>Monday</asp:ListItem>
                                                <asp:ListItem>Tuesday</asp:ListItem>
                                                <asp:ListItem>Wednesday</asp:ListItem>
                                                <asp:ListItem>Thursday</asp:ListItem>
                                                <asp:ListItem>Saturday</asp:ListItem>
                                            </asp:DropDownList>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row" id="rt_month">
                                    <div class="col-sm-1">
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group m-b-10">
                                            <label class="radio radio-inline">
                                                <input checked type="radio" ng-model="ADD_TASK.IS_ON_DAYWISE" ng-value="true" name="OnTypeRadio" />
                                                <i class="input-helper"></i>
                                                On Day
                                            </label>
                                            <select ng-model="ADD_TASK.MONTH_DAYS_NO" class="" data-live-search="true">
                                                <option>1</option>
                                                <option>2</option>
                                                <option>3</option>
                                                <option>4</option>
                                                <option>5</option>
                                                <option>6</option>
                                                <option>7</option>
                                                <option>8</option>
                                                <option>9</option>
                                                <option>10</option>
                                                <option>11</option>
                                                <option>12</option>
                                                <option>13</option>
                                                <option>14</option>
                                                <option>15</option>
                                                <option>16</option>
                                                <option>17</option>
                                                <option>18</option>
                                                <option>19</option>
                                                <option>20</option>
                                                <option>21</option>
                                                <option>22</option>
                                                <option>23</option>
                                                <option>24</option>
                                                <option>25</option>
                                                <option>26</option>
                                                <option>27</option>
                                                <option>28</option>
                                                <option>29</option>
                                                <option>30</option>
                                                <option>31</option>
                                            </select>
                                            Of every
                                        <input type="text" ng-model="ADD_TASK.MONTH_DAY_NO" style="width: 20px;" />
                                            <%--<asp:TextBox runat="server" Width="20" Text="1" ID="TextBox4"></asp:TextBox>--%>
                                        months
                                        </div>
                                    </div>
                                    <div class="clearfix">&nbsp;</div>
                                    <div class="col-sm-1">
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="radio radio-inline">
                                                <input type="radio" name="OnTypeRadio" ng-model="ADD_TASK.IS_ON_DAYWISE" ng-value="false" />
                                                <i class="input-helper"></i>
                                                On 
                                            </label>
                                            <select ng-model="ADD_TASK.MONTH_WEEK_SEQUENCE_TYPE" class="" data-live-search="true">
                                                <option>First</option>
                                                <option>Second</option>
                                                <option>Third</option>
                                                <option>Fourth</option>
                                                <option>Last</option>
                                            </select>

                                            <select ng-model="ADD_TASK.MONTH_WEEKSEQUENCE_DAY" data-placeholder="Repeat on">
                                                <option>Sunday</option>
                                                <option>Monday</option>
                                                <option>Tuesday</option>
                                                <option>Wednesday</option>
                                                <option>Thursday</option>
                                                <option>Friday</option>
                                                <option>Saturday</option>
                                            </select>
                                            Of every
                                        <input type="text" ng-model="ADD_TASK.MONTH_WEEKSEQUENCE_MONTH_NO" style="width: 20px;" />
                                            months
                                        </div>
                                    </div>

                                </div>

                                <div class="row" id="rt_year">
                                    <div class="col-sm-1">
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group m-b-10">
                                            <label class="radio radio-inline">
                                                <input checked type="radio" ng-model="ADD_TASK.IS_YEARLY_DAYS_ON" ng-value="false" name="onYEARLY_DAYS" />
                                                <i class="input-helper"></i>
                                                Of every
                                            </label>
                                            <select ng-model="ADD_TASK.YEARLY_DAYS_OF_MONTH" class="" data-live-search="true">
                                                <option value="1">January</option>
                                                <option value="2">February</option>
                                                <option value="3">March</option>
                                                <option value="4">April</option>
                                                <option value="5">May</option>
                                                <option value="6">June</option>
                                                <option value="7">July</option>
                                                <option value="8">August</option>
                                                <option value="9">Septemeber</option>
                                                <option value="10">October</option>
                                                <option value="11">November</option>
                                                <option value="12">December</option>
                                            </select>
                                            on 
                                        <select ng-model="ADD_TASK.YEARLY_DAYS_NO" class="" data-live-search="true">
                                            <option>1</option>
                                            <option>2</option>
                                            <option>3</option>
                                            <option>4</option>
                                            <option>5</option>
                                            <option>6</option>
                                            <option>7</option>
                                            <option>8</option>
                                            <option>9</option>
                                            <option>10</option>
                                            <option>11</option>
                                            <option>12</option>
                                            <option>13</option>
                                            <option>14</option>
                                            <option>15</option>
                                            <option>16</option>
                                            <option>17</option>
                                            <option>18</option>
                                            <option>19</option>
                                            <option>20</option>
                                            <option>21</option>
                                            <option>22</option>
                                            <option>23</option>
                                            <option>24</option>
                                            <option>25</option>
                                            <option>26</option>
                                            <option>27</option>
                                            <option>28</option>
                                            <option>29</option>
                                            <option>30</option>
                                            <option>31</option>
                                        </select>
                                        </div>
                                    </div>
                                    <div class="clearfix">&nbsp;</div>
                                    <div class="col-sm-1">
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="radio radio-inline">
                                                <input type="radio" name="onYEARLY_DAYS" ng-model="ADD_TASK.IS_YEARLY_DAYS_ON" ng-value="true" />
                                                <i class="input-helper"></i>
                                                On 
                                            </label>
                                            <select ng-model="ADD_TASK.YEARLY_WEEKSEQUENCE_TYPE" class="" data-live-search="true">
                                                <option>First</option>
                                                <option>Second</option>
                                                <option>Third</option>
                                                <option>Fourth</option>
                                                <option>Last</option>
                                            </select>

                                            <select ng-model="ADD_TASK.YEARLY_WEEKSEQUENCE_NO" data-placeholder="Repeat on">
                                                <option>Sunday</option>
                                                <option>Monday</option>
                                                <option>Tuesday</option>
                                                <option>Wednesday</option>
                                                <option>Thursday</option>
                                                <option>Friday</option>
                                                <option>Saturday</option>
                                            </select>
                                            Of
                                            <select ng-model="ADD_TASK.YEARLY_WEEKSEQUENCE_MONTH_NAME" class="" data-live-search="true">
                                                <option value="1">January</option>
                                                <option value="2">February</option>
                                                <option value="3">March</option>
                                                <option value="4">April</option>
                                                <option value="5">May</option>
                                                <option value="6">June</option>
                                                <option value="7">July</option>
                                                <option value="8">August</option>
                                                <option value="9">Septemeber</option>
                                                <option value="10">October</option>
                                                <option value="11">November</option>
                                                <option value="12">December</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-12">
                                <div class="form-group fg-float">
                                    <div class="fg-line">
                                        <textarea ng-model="ADD_TASK.DESCRIPTION" class="form-control"></textarea>
                                    </div>
                                    <label class="fg-label"><b>Remark :-</b></label>
                                </div>
                            </div>

                            <div class="col-sm-12">
                                <span class="pull-right">
                                    <button type="button" ng-disabled="btnsubmit" ng-click="AddTask(ADD_TASK)" id="btnsubmit" class="btn btn-primary btnsubmit">Submit</button>
                                    <button type="reset" class="btn btn-danger" runat="server" id="btncancel">Cancel</button>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
            </div>
        </div>
    </section>
</asp:Content>
