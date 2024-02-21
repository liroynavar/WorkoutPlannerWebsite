<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyProject.Login" MasterPageFile="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div dir="rtl" class="login-container">
        <h1>התחברות</h1>
        <div class="form-group">
            <label for="UName">שם משתמש:</label>
            <asp:TextBox ID="UName" runat="server" placeholder="שם משתמש"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Pass">סיסמה:</label>
            <asp:TextBox ID="Pass" runat="server" TextMode="Password" placeholder="סיסמה"></asp:TextBox>
        </div>
        <asp:Button ID="LoginBtn" runat="server" Text="כניסה" OnClick="LoginBtn_Click" CssClass="btn-login" />
    </div>
</asp:Content>
