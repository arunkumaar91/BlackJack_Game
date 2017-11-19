<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             
         <asp:Panel runat="server" ID="paymentpanel" Visible="false">
             <asp:Label ID="Label1" runat="server" Text="Choose the type of card" Height="25"></asp:Label>
             &nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="visaimage" runat="server" ImageUrl="~/Images/visaindividual.png" Width="50" Height="20" OnClick="visaimage_Click" />
             &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="or" Height="25"></asp:Label>
             &nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="masterimage" runat="server" ImageUrl="~/Images/mastercard.png" Width="50" Height="20" OnClick="masterimage_Click" />
         </asp:Panel>
            <table runat="server" id="tbl_pay" visible="false">
                <tr>
                    <th style="text-align: left; width: 300px">
                        <asp:Label ID="cardlbl" runat="server" Text="Card Number"></asp:Label></th>
                    <th style="width: 50px"></th>
                    <th style="text-align: left; width: 200px" colspan="2">Security Code (CVV)</th>
                </tr>
                <tr style="padding-top: 1px; padding-bottom: 1px">
                    <td colspan="2">
                        <asp:TextBox ID="cardnotxt" runat="server" Width="400px" MaxLength="16"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="cvvtxt" runat="server" Width="50px" MaxLength="3" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Image ID="cvv" runat="server" ImageUrl="~/Images/cvv.jpg" Width="50" /></td>
                </tr>
                <tr style="padding-top: 1px; padding-bottom: 1px">
                    <td colspan="2">
                        <b>Name on Card</b>
                    </td>
                    <td colspan="2">
                        <b>Expiration date</b>
                    </td>
                </tr>
                <tr style="padding-top: 1px; padding-bottom: 1px">
                    <td colspan="2" style="text-align: left">
                        <asp:TextBox ID="nametxt" runat="server" Width="400px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="monthddl" runat="server" Width="100%"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="yearddl" runat="server" Width="100%"></asp:DropDownList>
                    </td>
                </tr>
                <tr style="padding-top: 1px; padding-bottom: 1px">
                    <td colspan="4" style="text-align: right">
                        <asp:Button ID="Proceedbtn" runat="server" Text="Proceed" CssClass="btn" OnClick="Proceedbtn_Click" />
                    </td>
                    <td> <asp:Label runat="server" Text="" ID="cautionlbl"></asp:Label></td>
                </tr>
            </table>
            
        </div>
    </form>
</body>
</html>
