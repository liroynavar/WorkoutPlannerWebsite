<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ShowWorkoutPlan.aspx.cs" Inherits="MyProject.ShowWorkoutPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="container mt-5">
            <h1>Users' Plans</h1>
            <hr />

            <asp:DataList ID="MyPlan" runat="server" RepeatLayout="Table">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th></th>
                                <th>Trainer Name</th>
                                <th>User ID</th>
                                <th>Exercises</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                        <td><%# Eval("TrainerName") %></td>
                        <td><%# Eval("UserID") %></td>
                        <td><%# Eval("Exercises") %></td>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
    </table>
                </FooterTemplate>
            </asp:DataList>

        </div>
    </center>
</asp:Content>
