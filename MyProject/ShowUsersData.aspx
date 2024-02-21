<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowUsersData.aspx.cs" Inherits="MyProject.ShowUsersData" EnableEventValidation="true"  MasterPageFile="~/Master.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <center>
    <div class="container mt-5">
            <h1>Users' Plans</h1>
            <hr />
                <asp:DataList ID="dataorg" runat="server" RepeatLayout="Table">
                    <HeaderTemplate>
                        <table>
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Trainer Name</th>
                                    <th>User ID</th>
                                    <th>Exercises</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <td><%# Eval("TrainerName") %></td>
                            <td><%# Eval("UserID") %></td>
                            <td><%# Eval("Exercises") %></td>
                            <td>
                                <asp:Button ID="delBtn" Text="Delete" runat="server" OnClick="delBtn1_Click" CommandArgument='<%# Eval("UserID") %>' />
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