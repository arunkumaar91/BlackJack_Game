<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Blackjack.aspx.cs" Inherits="Blackjack" Theme="Style" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div style="height: 50%; text-align: center;" id="Dealer">
            <table>
                <tr>
                    <td style="width: 100%;"></td>
                    <td style="text-align: right">
                        <asp:Button ID="Button1" runat="server" Text="Log Out" CssClass="btn" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:Label runat="server" Text="" ID="lbl_dealer"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 100%">
                        <asp:Panel ID="DealerPanel" runat="server">
                        </asp:Panel>
                    </td>

                </tr>
            </table>

            <asp:Label runat="server" ID="lbl_dealerscore" Visible="false" Text=""></asp:Label>
        </div>

        <div style="width: 50%">
            <asp:Label runat="server" ID="lbl_msg" Text=""></asp:Label>
        </div>

        <div style="height: 50%; text-align: center; vertical-align: bottom" id="Player"><br />
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lbl_player" Text=""></asp:Label></td>
                </tr>
            </table>
        <table>
            <tr>
                <td>
                     <asp:Panel ID="PlayerPanel" runat="server">
                    </asp:Panel>
                </td>
            </tr>
        </table>
        </div>

        <div style="text-align: center">
            <table>
                <tr>
                    <td style="text-align: left">
                        <asp:Label runat="server" ID="lbl_playerscore" Text=""></asp:Label></td>
                    <td colspan="4" style="text-align: right">
                        <asp:Label runat="server" ID="lbl_raisebet" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lbl_cashavail" runat="server" Text="" CssClass="lbl"></asp:Label>
                        <asp:Button ID="Stand" runat="server" OnClick="Stand_Click" Text="Stand" CssClass="btn" Enabled="false"></asp:Button>
                    </td>
                    <td style="text-align: right"></td>
                    <td style="text-align: left">
                        <asp:Button ID="btn_hit" runat="server" Text="Hit" CssClass="btn" OnClick="btn_hit_Click" Enabled="false"></asp:Button>
                    </td>
                    <td>
                        <asp:Button ID="btn_deal" Text="Deal" runat="server" CssClass="btn" OnClick="btn_deal_Click" Enabled="false" />
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btn_bet" Text="Add Bet" CssClass="btn" OnClick="btn_bet_Click" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" Visible="false" ID="txt_bet" Width="58px"></asp:TextBox>
                        <asp:Label runat="server" ID="lbl_caution"></asp:Label>
                        <asp:Button ID="playagain" runat="server" Text="Play Again" Visible="false" CssClass="btn" OnClick="playagain_Click" />
                    </td>
                </tr>
            </table>

        </div>
        <asp:HiddenField ID="hdn_point_dealer" runat="server" Value="0" />
        <asp:HiddenField ID="hdn_point_player" runat="server" Value="0" />
        <asp:HiddenField ID="hdn_check" runat="server" Value="0" />
        <asp:HiddenField ID="hdn_card" runat="server" Value="" />
        <asp:HiddenField ID="hdn_dealer_check" runat="server" Value="0" />
        <asp:HiddenField ID="hdn_count" runat="server" Value="52" />
    </form>
</body>
</html>
