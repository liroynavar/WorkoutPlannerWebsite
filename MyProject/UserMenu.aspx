<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UserMenu.aspx.cs" Inherits="MyProject.UserMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="admin-menu">
        <h1>User Menu</h1>
        <ul class="menu-list">
            <li><a href="ShowMyData.aspx">
                <h3>Show My Data</h3>
            </a></li>
            <li><a href="ShowWorkoutPlan.aspx">
                <h3>Show My Workout Plan</h3>
            </a></li> 
            <li><a href="Update.aspx">
                <h3>Update Details</h3>
            </a></li>
            <li><a href="CheckPlan.aspx">
                <h3>Check Plan</h3>
            </a></li>
        </ul>
    </div>
</asp:Content>
