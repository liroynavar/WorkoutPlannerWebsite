<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ShowMyData.aspx.cs" Inherits="MyProject.ShowMyData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <center>
        <div class="container mt-5">
            <h1>My Data</h1>
            <hr />
            <asp:DataList ID="dataorg2" runat="server" RepeatLayout="Table">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th></th>
                                <th>User ID</th>
                                <th>User First Name</th>
                                <th>User Last Name</th>
                                <th>UserName</th>
                                <th>User Password</th>
                                <th>User Weight</th>
                                <th>User Body Fat</th>
                                <th>User Height</th>
                                <th>User Age</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                        <td><%# Eval("MyID") %></td>
                        <td><%# Eval("MyFName") %></td>
                        <td><%# Eval("MyLName") %></td>
                        <td><%# Eval("MyUName") %></td>
                        <td><%# Eval("MyPass") %></td>
                        <td><%# Eval("MyWeight") %></td>
                        <td><%# Eval("MyBodyFat") %></td>
                        <td><%# Eval("MyHeight") %></td>
                        <td><%# Eval("MyAge") %></td>
                        <td>
                            <asp:Button ID="delBtn" Text="Delete" runat="server" OnClick="delBtn1_Click" CommandArgument='<%# Eval("MyID") %>' />
                        </td>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </table>
                </FooterTemplate>
            </asp:DataList>
        </div>
    </center>

</asp:Content>
