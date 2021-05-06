<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserPanel.Master" AutoEventWireup="true" CodeBehind="MyPlanning.aspx.cs" Inherits="PartyTime.User.myPlanning" %>
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
             </center>
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
          <h1>Generated Suggestion</h1>
          <hr />
          <asp:GridView ID="generatedGridView" AutoGenerateColumns="false" runat="server" BackColor="WhiteSmoke" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Both">
              <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

              <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

              <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

              <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

              <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

              <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

              <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

              <SortedDescendingHeaderStyle BackColor="#242121"></SortedDescendingHeaderStyle>
              <Columns>
            <asp:BoundField DataField="Party_type" HeaderText="Party type" />
            <asp:BoundField DataField="FoodName" HeaderText="Food name" />
            <asp:BoundField DataField="ImageName" HeaderText="Image name" />
            <asp:TemplateField HeaderText="Decoration image">
            <ItemTemplate>
            <asp:Image ID="Image1" runat="server" Height="300" Width="300" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("DecorImage")) %>'></asp:Image>
            </ItemTemplate>
          </asp:TemplateField>
      </Columns>
          </asp:GridView>
          <%--breakline (enter)--%>
          <br />
          <button id="exportBtn" class="btnS" runat="server">Export to PDF</button>
          <br />
          </div>
</asp:Content>
