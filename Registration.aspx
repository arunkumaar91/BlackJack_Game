<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height:700px">  <table>
        <tr>
            <td>UserName:
            </td>
            <td>
                <asp:TextBox ID="Usertxt" runat="server" CssClass="txt" ></asp:TextBox>
                *
            </td>
        </tr>
        <tr>
            <td>Password:
            </td>
            <td>
                <asp:TextBox ID="Pwd1txt" CssClass="txt" runat="server" TextMode="Password" ></asp:TextBox>
                *
            </td>
        </tr>
        <tr>
            <td>Re-enter Password:
            </td>
            <td>
                <asp:TextBox ID="Pwd2txt"  TextMode="Password"  CssClass="txt" runat="server"></asp:TextBox>
                * 
                
            </td>
            <td>
                <asp:Label runat="server" Visible="false" ID="ErrMsg"> </asp:Label>
            </td>
        </tr>
        <tr>

            <td colspan="2" style="text-align: right">
                <asp:Button ID="Registerbtn" runat="server" Text="Register" OnClick="Registerbtn_Click"  CssClass="btn" />
            </td>
            <td>
                <asp:Label ID="Regislabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
        </div>
    <footer>
        * means mandatory
    </footer>
</asp:Content>

