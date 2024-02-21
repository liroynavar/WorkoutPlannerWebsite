<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowTrainers.aspx.cs" Inherits="MyProject.ShowTrainers"  MasterPageFile="~/Master.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div class="container mt-5">
            <h1>Trainers</h1>
            <hr />
                <asp:DataList ID="dataorg1" runat="server" RepeatLayout="Table">
                    <HeaderTemplate>
                        <table>
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Trainer ID</th>
                                    <th>Trainer First Name</th>
                                    <th>Trainer Last Name</th>
                                    <th>Trainer Username</th>
                                    <th>Trainer Password</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        
                            <td><%# Eval("TrainerID") %></td>
                            <td><%# Eval("TFName") %></td>
                            <td><%# Eval("TLName") %></td>
                            <td><%# Eval("TUName") %></td>
                            <td><%# Eval("TPass") %></td>
                            <td>
                                <asp:Button ID="delBtn" Text="Delete" runat="server" OnClick="delBtn1_Click" CommandArgument='<%# Eval("TrainerID") %>' />
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
