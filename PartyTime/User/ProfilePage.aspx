<%@ Page Title="Profile" Language="C#" MasterPageFile="~/User/UserPanel.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="PartyTime.User.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Preventing the content form hiding-->
    <style>
        .Content{
            min-height:calc(100vh - 70px);

        }
        .all{
            width:100%;
            height:90%;
            padding:20px;
        }
        .gr{
            color:grey;
        }
        
    </style>
    <!-- Info messages scripts-->
    <script src="../js/infoMessages.js"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@10"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container bootstrap snippet content">
         <div class="row">
            <!--Right col-->
     	<div class="col-sm-9">
             <div class="text-center">
                   <h1><asp:Label ID="loggedUser" runat="server"></asp:Label></h1>
             </div>
             <div class="bg-dark all">
              <div class="tab-content">
                    <form class="form">
                         <%-- Username--%>
                      <div class="form-group">
                           <div class="col-xs-12">
                              <label for="first_name"><h4 class="gr">Username</h4></label>
                              <input type="text" runat="server" id="username" class="form-control" name="username"  placeholder="username" title="Your username">
                          </div>
                      </div>
                       
                       <%-- Email--%>
                       <div class="form-group">
                           <div class="col-xs-12">
                                <br />
                              <label for="email"><h4 class="gr">Email</h4></label>
                               <input type="email" runat="server" id="email" class="form-control" name="email"  placeholder="you@email.com" title="enter your email.">
                          </div>
                      </div>
                     
                       <%-- Password--%>
                       <div class="form-group">
                           <div class="col-xs-12">
                                <br />
                              <label for="password"><h4 class="gr">Password</h4></label>
                              <input   runat="server" id="password" class="form-control" name="password"  placeholder="password" title="enter your password.">
                          </div>
                      </div>
                       <%-- Buttons--%>
                       <div class="form-group">
                           <div class="col-xs-12">
                               <br />
                               	<button class="btn btn-lg btn-success" runat="server" id="saveBtn" type="submit"><i class="glyphicon glyphicon-ok-sign"></i> Save</button>
                               	<button class="btn btn-lg gr" runat="server" id="resetBtn" type="reset"><i class="glyphicon glyphicon-repeat"></i> Reset</button>
                            </div>
                      </div>
                         <%-- Ino label--%>
                         <div class="form-group">
                           <div class="col-xs-12">
                               <br />
                               <asp:Label ID="infoLabel" Font-Size="Larger" Font-Bold="true" runat="server"></asp:Label>
                             </div>
                      </div>
               	</form>
              </div> 
           </div>
          </div> 
        </div>
    </div>
</asp:Content>
