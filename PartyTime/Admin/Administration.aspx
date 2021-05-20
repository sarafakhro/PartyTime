<%@ Page Title="Administration" Language="C#" MasterPageFile="~/Admin/AdminPanel.Master" AutoEventWireup="true" CodeBehind="Administration.aspx.cs" Inherits="PartyTime.Admin.Administration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/planningPageStyle.css" rel="stylesheet" />
      <!--Preventing the content form hiding-->
    <style>
        .content {
            min-height: calc(100vh - 70px);
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
     <center>

        <!-- Start Header-->
    <h1><asp:Label ID="wlcLabel" runat="server"></asp:Label></h1>
        <hr />

          <!-- End Header-->

         <!-- Start content-->
         <!-- Add decor-->
       <div class="bg-dark all">
       <br/><br/>
<h1>Add decor:</h1>
<span class="custom-dropdown big">
Dekorationsnamn:
     <asp:DropDownList ID="decorationSuggestionsDrop" runat="server"></asp:DropDownList>
</span>
<span class="custom big">
BildNamnet:
 <input type="text" id="imageName" runat="server" placeholder="Bildensnamn"/>
</span>
<br />
<span class="custom big">
   Bilden:
    <br />
    <div class="age"> 
     <label class="control-label small" for="file_img">Produktens bild (jpg/png):</label>
     <input runat="server" id="fileUploader" type="file" name="file_img">
    </div>
 </span>
        <br />
         <button class="btn" runat="server" id="addDecotdBtn">Klar</button>
         </div>
   <br />
[12:33 PM]
</center>
        </div>
</asp:Content>
