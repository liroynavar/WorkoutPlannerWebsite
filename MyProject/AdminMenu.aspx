<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminMenu.aspx.cs" Inherits="MyProject.AdminMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="admin-menu">
        <h1>Admin Menu</h1>
        <ul class="menu-list">
            <li><a href="AddExercise.aspx">
                <h3>Add An Exercise</h3>
            </a></li>
            <li><a href="ShowTrainers.aspx">
                <h3>Show Trainers</h3>
            </a></li>
            <li><a href="ShowUsers.aspx">
                <h3>Show Users</h3>
            </a></li>
            <li><a href="ShowUsersData.aspx">
                <h3>Show Users Plans</h3>
            </a></li>
            <li><a href="TrainProgram.aspx">
                <h3>Build A Train Program</h3>
            </a></li>
            <li><a href="Statistics.aspx">
                <h3>Statistics</h3>
            </a></li>
        </ul>
    </div>
</asp:Content>
