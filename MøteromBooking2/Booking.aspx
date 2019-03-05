<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="MøteromBooking2.Booking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="boooking">
        <asp:Label ID="AvailableRoomList" runat="Server"></asp:Label>
        <asp:Label ID="LitenLabel" runat="Server"></asp:Label>
        <table>
            <tr>
                <th>
                    <asp:Label ID="Label1" runat="Server"></asp:Label></th>
                <th>
                    <asp:Literal runat="server" Text="Antall rom igjen: " ID="litenAntall" EnableViewState="false" /></th>
            </tr>
        </table>
        <br />
        <asp:Button ID="Liten" runat="server" OnClick="Liten_Click" Text="Velg Liten Rom" />
        <asp:Label ID="MediumLabel" runat="Server"></asp:Label>
        <table>
            <tr>
                <th>
                    <asp:Label ID="Label2" runat="Server"></asp:Label></th>
                <th>
                    <asp:Literal runat="server" Text="Antall rom igjen: " ID="mediumAntall" EnableViewState="false" /></th>
            </tr>
        </table>
        <br />
        <asp:Button ID="Medium" Class="btn btn-primary btn-lg" runat="server" OnClick="Medium_Click" Text="Velg Medium Rom'" />
        <asp:Label ID="StorLabel" runat="Server"></asp:Label>
        <table>
            <tr>
                <th>
                    <asp:Label ID="Label3" runat="Server"></asp:Label></th>
                <th>
                    <asp:Literal runat="server" Text="Antall rom igjen: " ID="storAntall" EnableViewState="false" /></th>
            </tr>
        </table>
        <br />
        <asp:Button ID="Stor" Class="btn btn-primary btn-lg" runat="server" Text="Velg Stor rom" OnClick="Stor_Click" />       
    </div>

        <asp:Literal ID="sID" runat="Server"></asp:Literal>
        <asp:Literal ID="mID" runat="Server"></asp:Literal>
        <asp:Literal ID="bID" runat="Server"></asp:Literal>


    </form>
</body>
</html>
