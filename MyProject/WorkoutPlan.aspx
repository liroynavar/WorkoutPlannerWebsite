<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkoutPlan.aspx.cs" Inherits="MyProject.WorkoutPlan" EnableEventValidation="false" MasterPageFile="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="container">
            <h1>Chosen Exercise</h1>
            <table>
                <thead>
                    <tr>
                        <th>Trainer Name</th>
                        <th>Name of Exercise</th>
                        <th>Muscle</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:DataList ID="dataorg" runat="server" RepeatLayout="Table">
                        <ItemTemplate>
                            <td><%# Eval("TName") %></td>
                            <td><%# Eval("ExName") %></td>
                            <td><%# Eval("ExMuscle") %></td>
                            <td>
                                <asp:Button ID="delBtn" Text="Delete" CssClass="delete-button" runat="server" OnClick="delBtn_Click" CommandArgument='<%# Eval("ExName") + ";" + Eval("TName") %>' />
                            </td>
                        </ItemTemplate>
                    </asp:DataList>
                </tbody>
            </table>
            <div class="search-container">
                <asp:TextBox ID="searchBox" runat="server" placeholder="Enter ID"></asp:TextBox>
                <asp:Button ID="SubmitBtn" runat="server" Text="בנה תוכנית" OnClick="SubmitBtn_Click" CssClass="submit-button" />
            </div>
        </div>
    </center>
</asp:Content>
