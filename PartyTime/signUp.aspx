<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="PartyTime.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<%-- Created by: Sarkis Baghdasarian --%>
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <title>Party Time-Sign up</title>
    <!-- basic -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- mobile metas -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
      <!-- bootstrap css -->
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <!-- style css -->
    <link rel="stylesheet" href="css/style.css">
    <!-- Responsive-->
    <link rel="stylesheet" href="css/responsive.css">
    <!-- fevicon -->
    <link rel="icon" href="images/fevicon.png" type="image/gif" />
    <!-- Scrollbar Custom CSS -->
    <link rel="stylesheet" href="css/jquery.mCustomScrollbar.min.css">
    <!-- Tweaks for older IEs-->
    <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.min.css" media="screen">
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script><![endif]-->

        <!-- Info messages scripts-->
     <script src="js/infoMessages.js"></script>
     <script src="//cdn.jsdelivr.net/npm/sweetalert2@10"></script>

     <!-- Footer style- put it at the bottom-->
    <style>
.egen {
    position: fixed;
    bottom: 0;
    width: 100%;
}
.buttons{
  position: page;
  left:0;
   transform: translateY(50%);
}
    </style>
   </head>
<body>
    <form id="form1" runat="server">
        <!-- Start Signup  Title-->
         <div class="contactbg">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="contacttitlepage">
                        <h2>Create an account:</h2>
                    </div>
                </div>
            </div>
              <div class="row">
                <div class="col-md-12">
                      <div class="contacttitlepage">
                         <button class="send buttons"><a href="index.aspx">Home Page</a></button>
                    </div>
                </div>
            </div>
             </div>
             </div>
         <!-- End Signup  Title-->

            <!-- Start Signup form-->
            <div class="container">
        <div class="row">
            <div class=" col-md-6 offset-md-3">
                <div class="address">
                      <h2>Please enter a username, password and an email to create an account!</h2>
                      <form>
                        <div class="row">
                            <div class="col-sm-12">
                                <input runat="server" id="userName" class="contactus" placeholder="Username" type="text" name="username">
                            </div>
                             <div class="col-sm-12">
                                <input runat="server" id="pass" class="contactus" placeholder="Password" type="password" name="pass">
                            </div>
                             <div class="col-sm-12">
                                <input runat="server" id="email" class="contactus" placeholder="E-post" type="email" name="email">
                            </div>
                           
                            <div class="col-sm-12">
                                  <button class="send"><a href="LogIn.aspx">You alredy have an account? Login!</a></button>
                              </div>
                            <div class="col-sm-12">
                                <button runat="server" id="signUpBtm" class="send">Create an account</button>
                            </div>
                         </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
        <!-- End Signup form-->
         <!--  footer -->
                  <div class="copyright egen">
                    <p style="background-color:orangered">© 2021 All Rights Reserved. Party Time</p>
                </div>
          <!-- end footer -->

    </form>
</body>
</html>
