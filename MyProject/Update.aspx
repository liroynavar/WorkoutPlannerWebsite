<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="MyProject.Update" MasterPageFile="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div dir="rtl" class="login-container">
            <h1>עדכון פרטים</h1>
            <div class="form-group">
                <label for="MyFName">שם פרטי:</label>
                <asp:TextBox ID="MyFName" runat="server" CssClass="input-field" Text='<%# Eval("MyFName") %>'></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="LName">שם משפחה:</label>
                <asp:TextBox ID="LName" runat="server" CssClass="input-field" Text='<%# Eval("MyLName") %>'></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="UName">שם משתמש:</label>
                <asp:TextBox ID="UName" runat="server" Text='<%# Eval("MyUName") %>'></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="Pass">סיסמה:</label>
                <asp:TextBox ID="Pass" runat="server" Text='<%# Eval("MyPass") %>'></asp:TextBox>
            </div>


            <div class="form-group">
                <label for="Age">גיל:</label>
                <asp:TextBox ID="Age" runat="server" Text='<%# Eval("MyAge") %>'></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="Weight">משקל:</label>
                <asp:TextBox ID="Weight" runat="server" Text='<%# Eval("MyWeight") %>'></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="Height">גובה:</label>
                <asp:TextBox ID="Height" runat="server" Text='<%# Eval("MyHeight") %>'></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="BodyFat">אחוז שומן:</label>
                <asp:TextBox ID="BodyFat" runat="server" Text='<%# Eval("MyBodyFat") %>'></asp:TextBox>
            </div>
            <asp:Button ID="UpdateBtn" runat="server" Text="עדכן" OnClick="UpdateBtn_Click" CssClass="btn-login" />
        </div>
    </center>
</asp:Content>
