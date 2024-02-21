<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowExercise.aspx.cs" Inherits="MyProject.ShowExercise" MasterPageFile="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="h1-container">
        <h1>Exercise For <%= Request.QueryString["muscle"].ToString() %></h1>
    </div>
    <asp:DataList ID="ExerciseList" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
        <ItemTemplate>
            <div class="card mb-3">
                <img src='<%# Eval("ExampleLink") %>' class="card-img-top" alt='<%# Eval("ExerciseName") %>'>
                <div class="card-body">
                    <h5 class="card-title" dir="rtl"><%# Eval("ExerciseName") %></h5>
                    <asp:Button ID="SelectButton" runat="server" Text="Select" OnCommand="AddToBasket" CommandArgument='<%# Eval("ExerciseName") %>' CssClass="btn-add" />
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:content>
