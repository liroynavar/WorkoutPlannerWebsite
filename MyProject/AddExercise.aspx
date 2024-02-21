<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddExercise.aspx.cs" Inherits="MyProject.AddExercise" MasterPageFile="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div dir="rtl" class="login-container">
        <h1>הכנסת תרגיל</h1>
        <div class="form-group">
            שם תרגיל:
            <asp:TextBox ID="ExName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            קבוצת שריר שהתרגיל עובד עליו:
            <asp:DropDownList ID="MaName" runat="server" CssClass="form-control dropdown-style">
                <asp:ListItem ID="chest" Value="chest" runat="server">חזה</asp:ListItem>
                <asp:ListItem ID="lats" Value="lats" runat="server">רחב גבי</asp:ListItem>
                <asp:ListItem ID="traps_middle" Value="traps_middle" runat="server">טרפז</asp:ListItem>
                <asp:ListItem ID="traps" Value="traps" runat="server">טרפזים</asp:ListItem>
                <asp:ListItem ID="shoulders" Value="shoulders" runat="server">כתפיים</asp:ListItem>
                <asp:ListItem ID="biceps" Value="biceps" runat="server">יד קדמית</asp:ListItem>
                <asp:ListItem ID="triceps" Value="triceps" runat="server">יד אחורית</asp:ListItem>
                <asp:ListItem ID="forearms" Value="forearms" runat="server">אמות</asp:ListItem>
                <asp:ListItem ID="quads" Value="quads" runat="server">ארבע ראשי</asp:ListItem>
                <asp:ListItem ID="calves" Value="calves" runat="server">תאומים</asp:ListItem>
                <asp:ListItem ID="hamstrings" Value="hamstrings" runat="server">האמסטרינג</asp:ListItem>
                <asp:ListItem ID="glutes" Value="glutes" runat="server">ישבן</asp:ListItem>
                <asp:ListItem ID="lowerback" Value="lowerback" runat="server">גב תחתון</asp:ListItem>
                <asp:ListItem ID="abdominals" Value="abdominals" runat="server">בטן</asp:ListItem>
                <asp:ListItem ID="obliques" Value="obliques" runat="server">אלכסונים</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            לינק לדוגמה לתרגיל:
            <asp:TextBox ID="Link" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="Insert" runat="server" Text="הזן" OnClick="Insert_Click" CssClass="btn-login" />
    </div>
</asp:Content>
