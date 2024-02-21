<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="MyProject.Statistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="statistics-container">
        <div class="statistic-box" onmouseover="highlightBox(this)" onmouseout="unhighlightBox(this)">
            <div class="statistic-icon">
                <i class="fas fa-users"></i>
            </div>
            <div class="statistic-info">
                <span class="statistic-label">TrainersInfo:</span>
                <asp:Label ID="lblTrainersCount" runat="server" CssClass="statistic-value"></asp:Label>
            </div>
        </div>
        <div class="statistic-box" onmouseover="highlightBox(this)" onmouseout="unhighlightBox(this)">
            <div class="statistic-icon">
                <i class="fas fa-user"></i>
            </div>
            <div class="statistic-info">
                <span class="statistic-label">UsersInfo:</span>
                <asp:Label ID="lblUsersCount" runat="server" CssClass="statistic-value"></asp:Label>
            </div>
        </div>
        <div class="statistic-box" onmouseover="highlightBox(this)" onmouseout="unhighlightBox(this)">
            <div class="statistic-icon">
                <i class="fas fa-dumbbell"></i>
            </div>
            <div class="statistic-info">
                <span class="statistic-label">ExercisesInfo:</span>
                <asp:Label ID="lblExercisesCount" runat="server" CssClass="statistic-value"></asp:Label>
            </div>
        </div>
        <div class="statistic-box" onmouseover="highlightBox(this)" onmouseout="unhighlightBox(this)">
            <div class="statistic-icon">
                <i class="fas fa-clipboard-list"></i>
            </div>
            <div class="statistic-info">
                <span class="statistic-label">Plans:</span>
                <asp:Label ID="lblPlansCount" runat="server" CssClass="statistic-value"></asp:Label>
            </div>
        </div>
    </div>

    <hr />

    <div class="statistic-box" onmouseover="highlightBox(this)" onmouseout="unhighlightBox(this)">
        <div class="statistic-info">
            <div id="exerciseContainer" runat="server">
                <span class="statistic-label">Top Exercise Uses:</span>
                <asp:Label ID="lblTopExerciseUses" runat="server" CssClass="statistic-value"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
