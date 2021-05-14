<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserPanel.Master" AutoEventWireup="true" CodeBehind="PlanningPage.aspx.cs" Inherits="PartyTime.User.PlanningPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/planningPageStyle.css" rel="stylesheet" />
    <!-- Preventing the content form hiding-->   
    <style>        
        .content {          
            min-height: calc(100vh - 70px);       
            padding:10px;   
        }  
    </style>
    <script src="../js/infoMessages.js"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@10"></script>
    <%-- Script for color changing-Square! --%>    
    <script src="https://ajax.googleapis.com/ajax/libs/prototype/1.7.1/prototype.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
     <center>

        <!-- Header-->
    <h1><asp:Label ID="wlcLabel" runat="server"></asp:Label></h1>
        <hr />
    <h2>Planning page!</h2>

         <div class="bg-dark all">
       <!-- Content-->
      <span class="color-picker"></span>
     <br/><br/>

<span class="custom-dropdown big">
Typ av fest:
    <asp:DropDownList ID="partyTypeDrop1" runat="server"></asp:DropDownList>
</span>



<span class="custom-dropdown big">
Dekorationsförslag:
     <asp:DropDownList ID="decorationSuggestionsDrop1" runat="server"></asp:DropDownList>
</span>

<span class="custom-dropdown big">
Specialkost/mat:
<asp:DropDownList ID="foodTypeDrop1" runat="server"></asp:DropDownList>
</span>
<br />
<span class="custom big">
    Antalet gäster:
    <br />
    <div class="age"> 
     <input type="number" min="0" id="childNumber" runat="server" placeholder="Antalet barn"/>
    <input type="number" min="0" id="adulNumber" runat="server" placeholder="Antalet vuxna"/>       
    </div>
 </span>
        <br />
         <button class="btn" runat="server" id="doneBtn">Klar</button>
              </div>
       </center>
        </div>
    <!-- Script for color chagning-->
       <script type="text/javascript">
           var colors = ['1abc9c', '2c3e50', '2980b9', '7f8c8d', 'f1c40f', 'd35400', '27ae60', 'e8b5cf'];

           colors.each(function (color) {
               $$('.color-picker')[0].insert(
                   '<div class="square" style="background: #' + color + '"></div>'
               );
           });

           $$('.color-picker')[0].on('click', '.square', function (event, square) {
               background = square.getStyle('background');
               $$('.custom-dropdown select').each(function (dropdown) {
                   dropdown.setStyle({ 'background': background });
               });
               $$('.age').each(function (dropdown) {
                   dropdown.setStyle({ 'background': background });
               });
               $$('.btn').each(function (dropdown) {
                   dropdown.setStyle({ 'background': background });
               });
           });

       </script>
</asp:Content>
