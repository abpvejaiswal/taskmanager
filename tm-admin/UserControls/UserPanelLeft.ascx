<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserPanelLeft.ascx.cs" Inherits="TaskManager.tm_admin.UserControls.UserPanelLeft" %>
<div class="pm-overview c-overflow">
    <div class="pmo-pic">
        <div class="p-relative">
            <a href="#">
                <asp:Literal runat="server" ID="ltrImage"></asp:Literal>
                
            </a>

        </div>


    </div>

    <div class="pmo-block pmo-contact hidden-xs">
        <h2>Contact</h2>

        <ul>
            <asp:Literal runat="server" ID="ltrContact"></asp:Literal>
        </ul>
    </div>


</div>
