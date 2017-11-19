<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AfterLogin.aspx.cs" Inherits="AfterLogin" Theme="Style" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="div" style="height:50px">
   <table>
       <tr>
           <td style="width:145%;text-align:left">
                  <asp:Label runat="server" ID="lbl"> </asp:Label>
           </td>
           <td>
                <asp:Button ID="Button1" runat="server" Text="Log Out" CssClass="btn" OnClick="Button1_Click"  />
           </td>
       </tr>
     
       </table>
    </div>
        <div style="height:50px" >
            
            <asp:Button ID="btn_play" runat="server" Text="Play Now" CssClass="btn" OnClick="btn_play_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_profile" runat="server" Text="User Profile" CssClass="btn" OnClick="btn_profile_Click" />
            <br />
            <asp:Label ID="lbl_err" runat="server" Text=""></asp:Label>
             
          
        </div>
        <div>
            Top Performers of the Day.<br />
           <asp:GridView ID="ScoreGrid" runat="server"></asp:GridView>
        </div>
     </form>
</body>
</html>
