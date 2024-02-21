<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="MyProject.SignUp" MasterPageFile="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div dir="rtl" class="login-container">
        <h1>הרשמת מתאמן</h1>
        <div class="form-group">
            <label for="MyFName">שם פרטי:</label>
            <asp:TextBox ID="MyFName" runat="server" CssClass="input-field" placeholder="שם פרטי"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="LName">שם משפחה:</label>
            <asp:TextBox ID="LName" runat="server"  CssClass="input-field" placeholder="שם משפחה"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="UName">שם משתמש:</label>
            <asp:TextBox ID="UName" runat="server" placeholder="שם משתמש" ></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Pass">סיסמה:</label>
            <asp:TextBox ID="Pass" runat="server" placeholder="סיסמה" TextMode="Password" ></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Age">גיל:</label>
            <asp:TextBox ID="Age" runat="server" placeholder="גיל" ></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Weight">משקל:</label>
            <asp:TextBox ID="Weight" runat="server" placeholder="משקל" ></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Height">גובה:</label>
            <asp:TextBox ID="Height" runat="server" placeholder="גובה" ></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="BodyFat">אחוז שומן:</label>
            <asp:TextBox ID="BodyFat" runat="server" placeholder="אחוז שומן" ></asp:TextBox>
        </div>
        <asp:Button ID="Insert" runat="server" Text="הירשם" OnClick="Insert_Click" CssClass="btn-login" />
    </div>
</asp:Content>
