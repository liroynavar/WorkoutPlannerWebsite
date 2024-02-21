<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainerSignUp.aspx.cs" Inherits="MyProject.TrainerSignUp" MasterPageFile="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div dir="rtl" class="login-container">
        <h1>הרשמת מאמן</h1>
        <div class="form-group">
            <label for="FName">שם פרטי:</label>
            <asp:TextBox ID="FName" runat="server"  CssClass="input-field" placeholder="שם פרטי"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="LName">שם משפחה:</label>
            <asp:TextBox ID="LName" runat="server"  CssClass="input-field" placeholder="שם משפחה"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="UName">שם משתמש:</label>
            <asp:TextBox ID="UName" runat="server"  CssClass="input-field" placeholder="שם משתמש"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Pass">סיסמה:</label>
            <asp:TextBox ID="Pass" runat="server"  CssClass="input-field" TextMode="Password" placeholder="סיסמה"></asp:TextBox>
        </div>
        <asp:Button ID="Insert" runat="server" Text="הירשם" OnClick="Insert_Click" CssClass="btn-login" />
    </div>
</asp:Content>
