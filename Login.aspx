<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 215px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="height: 700px">
        <table>
            <tr>
                <td style="width:10%"><asp:Label ID="UserName" runat="server" Text="UserName:"></asp:Label>
                </td>
                <td style="width:20%">
                    <asp:TextBox ID="Usertxt" runat="server" style="width:100%;height:20px;" ></asp:TextBox>
                    
                </td>
                <td>*</td>
            </tr>
            <tr>
                <td style="width:10%"><asp:Label ID="Password" runat="server" Text="Password:"></asp:Label>
                </td>
                <td style="width:20%">
                    <asp:TextBox ID="Pwdtxt" TextMode="Password" runat="server" style="width:100%;" CssClass="txt"></asp:TextBox>
                    
                </td>
                <td style="width:80%">*</td>
            </tr>
            <tr>
                <td style="width:10%"></td>
                <td style="width:20%">
                    <asp:Button ID="Newuser" runat="server" Text="New User" CssClass="btn" OnClick="Newuser_Click" UseSubmitBehavior="false" /> &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Loginbtn" runat="server" Text="Log In" OnClick="Loginbtn_Click" CssClass="btn" />
                </td>
                <td style="width:80%">
                    <asp:Label ID="Errmsg" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <footer>
        * means mandatory
    </footer>
</asp:Content>

