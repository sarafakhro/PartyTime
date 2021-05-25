<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserPanel.Master" AutoEventWireup="true" CodeBehind="MyPlanning.aspx.cs" Inherits="PartyTime.User.MyPlanning" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <!-- Info messages scripts-->
     <script src="../js/infoMessages.js"></script>
     <script src="//cdn.jsdelivr.net/npm/sweetalert2@10"></script>

     <!--Preventing the content form hiding-->
    <style>
        .content {
            min-height: calc(100vh - 70px);
         }
        .btnS{
            background-color:bisque;
            padding:10px;
             border: 2px solid black;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="content">
         <center>
         <!-- Start Header-->
    <h1>Your data:</h1>
        <hr />
          <asp:GridView ID="userParamGridView" AutoGenerateColumns="false" runat="server" BackColor="WhiteSmoke" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
              <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

              <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

              <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

              <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

              <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

              <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

              <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

              <SortedDescendingHeaderStyle BackColor="#242121"></SortedDescendingHeaderStyle>
              <Columns>
                     <asp:BoundField DataField="id" HeaderText="Id" />
                     <asp:BoundField DataField="partyType" HeaderText="Party type" />
                     <asp:BoundField DataField="decorationSuggestion" HeaderText="Decor type" />
                     <asp:BoundField DataField="foodType" HeaderText="Food type" />
                     <asp:BoundField DataField="childNumber" HeaderText="Child number" />
                     <asp:BoundField DataField="adulNumber" HeaderText="Adult number" />
                 </Columns>
          </asp:GridView>
          <hr />
          <br />
             <br />
       <center>
           <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Height="600px" Width="100%">
               <LocalReport ReportPath="MyPlanning.rdlc">
                   <DataSources>
                       <rsweb:ReportDataSource Name ="DataSet1" DataSourceId ="SqlDataSource1" />
                   </DataSources>
               </LocalReport>
</rsweb:ReportViewer>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:partyTimeConnectionString %>' SelectCommand="sp_getGenerated" SelectCommandType="StoredProcedure"><SelectParameters>
<asp:SessionParameter SessionField="user" Name="userName" Type="String"></asp:SessionParameter>
</SelectParameters>
</asp:SqlDataSource>
       </center>
             </center>
          </div>
</asp:Content>
