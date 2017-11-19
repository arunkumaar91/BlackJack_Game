<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" Theme="Style" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="ScoreCard" runat="server" Text=" Score card" OnClick="Button1_Click" CssClass="btn" UseSubmitBehavior="false" /></td>
                    <td>
                        <asp:Button ID="ChangePassword" runat="server" Text="Change Password" OnClick="Button2_Click" CssClass="btn" UseSubmitBehavior="false" />
                    </td>
                    <td>
                         <asp:Button ID="Payment" runat="server" Text="Wallet" OnClick="Payment_Click" CssClass="btn" />
                    </td>
                    <td>
                        <asp:Button ID="play" runat="server" Text="Play Now" cssClass="btn" visible="false" OnClick="play_Click" />
                    </td>
                    <td style="width:105%;text-align:right">
                          <asp:Button ID="Button1" runat="server" Text="Log Out" CssClass="btn" OnClick="Button1_Click1" />
                    </td>
                </tr>
            </table>

           </div>
           
            <div style="height: 50px">
            </div>

            <table runat="server" visible="false" id="tbl_sc" style="border: solid; border-width: 1px">
                <tr style="border: solid; border-width: 1px">
                    <th style="border: solid; border-width: 1px">UserName
                    </th>
                    <th style="border: solid; border-width: 1px">Played
                    </th>
                    <th style="border: solid; border-width: 1px">Won
                    </th>
                    <th style="border: solid; border-width: 1px">Lost
                    </th>
                    <th style="border: solid; border-width: 1px">BlackJack
                    </th>
                    <th style="border: solid; border-width: 1px">Push
                    </th>
                </tr>
                <tr style="border: solid; border-width: 1px">
                    <td style="border: solid; border-width: 1px">
                        <asp:Label ID="usernamelbl" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="border: solid; border-width: 1px">
                        <asp:Label ID="playedlbl" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="border: solid; border-width: 1px">
                        <asp:Label ID="wonlbl" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="border: solid; border-width: 1px">
                        <asp:Label ID="lostlbl" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="border: solid; border-width: 1px">
                        <asp:Label ID="blackjacklbl" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="border: solid; border-width: 1px">
                        <asp:Label ID="puslbl" runat="server" Text=""></asp:Label>
                    </td>

                </tr>
            </table>

            <table runat="server" visible="false" id="tbl_cp">
                <tr>
                    <td>Existing Password :
                    </td>
                    <td>
                        <asp:TextBox ID="oldpwdtxt" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>Enter New Password :
                    </td>

                    <td>
                        <asp:TextBox ID="newpwdtxt" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>Re-enter Password :
                    </td>
                    <td>
                        <asp:TextBox ID="repwdtxt" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right">
                        <asp:Button ID="changepwdbtn" runat="server" Text="Change Password" OnClick="changepwdbtn_Click" CssClass="btn" UseSubmitBehavior="false" />
                    </td>
                    <td>
                        <asp:Label ID="msglbl" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>

            <table runat="server" id="tbl_bal" visible="false">
                <tr>
                    <td style="text-align: right">UserName :</td>
                    <td style="text-align: left; border-width: thin; border-style: solid">
                        <asp:Label ID="lbl_username" runat="server" Text=""></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align: right">Cash Available :
                    </td>
                    <td style="text-align: left; border-width: thin; border-style: solid">
                        <asp:Label ID="bal_lbl" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="err_lbl" runat="server" Text="$"></asp:Label></td>

                </tr>
                <tr>
                    <td style="text-align: right">Add More Cash :
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txt_amt" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Caution" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right">
                        <asp:Button ID="AddCash" runat="server" Text="Add Cash" CssClass="btn" OnClick="AddCash_Click" />
                    </td>
                    <td>
                        <asp:Label ID="Successlbl" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
        
    </form>
</body>
</html>
