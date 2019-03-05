<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MøteromBooking2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>Book møterom her!</h1>
        <br />
        <br />
        <asp:TextBox type="text" name="dato" ID="dato" placeholder="Trykk for å velge dato..." runat="server"></asp:TextBox>
        <asp:TextBox type="text" name="fratid" ID="fratid" placeholder="Trykk for å velge fra tid..." runat="server"></asp:TextBox>
        <asp:TextBox type="text" name="tiltid" ID="tiltid" placeholder="Trykk for å velge til tid..." runat="server"></asp:TextBox> 
       <asp:Button ID="button" name="button" Text="Se ledige rom" OnClick="SjekkRom" runat="server" />
    </div>

        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-timepicker/1.8.1/jquery.timepicker.min.css"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-timepicker/1.8.1/jquery.timepicker.min.js"></script>
        <script src="http://jonthornton.github.io/jquery-timepicker/jquery.timepicker.js"></script>
        <script src="Scripts/jquery.timepicker.min.js"></script>
        <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script>$(function () { $( "#<%= dato.ClientID %>" ).datepicker({ minDate: 0, dayNamesMin: [ "Sø", "Ma", "Ti", "On", "To", "Fr", "Lø" ], firstDay: 1, dateFormat: 'dd/mm/yy', orientation: "bottom" }); });</script>
        <script>
        $(document).ready(function () {
            $("#<%= fratid.ClientID %>").timepicker();
            $("#<%= tiltid.ClientID %>").timepicker();
        });
    </script>
    <asp:Label ID="Feilmelding" Runat="Server"></asp:Label>
    <br />
    <br />
    <h1>Søk etter bookinger her!</h1><br />
    <asp:TextBox type="text" name="sokestreng" ID="sokestreng" placeholder="Skriv inn navn..." runat="server"></asp:TextBox>
    <asp:Button ID="button2" name="button2" Text="Søk" OnClick="SokRom" runat="server" />
    <div style="overflow-x:auto;">
    <asp:Table Class="tabell" ID="table" runat="server">
            <asp:TableHeaderRow runat="server">
                <asp:TableHeaderCell Text="Booking ID"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Rom ID"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Navn"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Dato"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Fra tid"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Til tid"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Status"></asp:TableHeaderCell>
            </asp:TableHeaderRow>
         <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        </div>
</asp:Content>
