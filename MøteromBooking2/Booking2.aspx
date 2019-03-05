<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking2.aspx.cs" Inherits="MøteromBooking2.Booking2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">             

       <asp:Label ID="tilbakemeldingLabel" runat="Server"></asp:Label>
       <asp:Label ID="bestillingsskjema" runat="Server"></asp:Label>

       <div class="bookingskjema">
        <h2>Fyll inn bookingskjema nedenfor!</h2>
        Navn       
        <asp:TextBox ID="navn" AutoPostBack="false" placeholder="Skriv inn ditt navn..." runat="server" required></asp:TextBox><br />
        Dato valgt
        <asp:TextBox ID="datoValgt" AutoPostBack="false" Text="Ingen dato valgt" runat="Server" required></asp:TextBox>
        <br />
        Fra tid valgt 
        <asp:TextBox ID="fratidValgt" AutoPostBack="false" Text="Ingen fra tid valgt" runat="Server" required></asp:TextBox>
        <br />
        Til tid valgt
        <asp:TextBox ID="tiltidValgt" AutoPostBack="false" Text="Ingen til tid valgt valgt" runat="Server" required></asp:TextBox>
        <br />
        Romtype        
        <asp:TextBox ID="romtypeValgt" AutoPostBack="false" Text="Ingen romtype valgt" runat="Server" required></asp:TextBox>
        <br />
        <asp:Button ID="Button1" Text="Book møterom!" OnClick="SendBooking" runat="server" /><br /><br />      
        <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script>$(function () { $( "#<%= datoValgt.ClientID %>" ).datepicker({ minDate: 0, dayNamesMin: [ "Sø", "Ma", "Ti", "On", "To", "Fr", "Lø" ], firstDay: 1, dateFormat: 'dd/mm/yy', orientation: "bottom" }); });</script>
       
    </div>

    </form>


    </form>
</body>
</html>
