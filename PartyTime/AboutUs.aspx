<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="PartyTime.AboutUs" %>

 <%-- Created by: Sara Bakdach Fakhro --%>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <!-- basic -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- mobile metas -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <!-- site metas -->
    <title>Party Time-Om oss</title>
    <meta name="keywords" content="">
    <meta name="description" content="">
    <meta name="author" content="">
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

    <style>
        .btnDesign{
            color:#808080;
            background-color:black;
            font-size:x-large;
            padding:10px;
            text-shadow:2px 2px 10px #FF0000;

        }
        .btnDesign:hover{
            color:white;
        }

        .hideBtn{
            display:none;
        }
        /*It will keep the footer at the bottom of the page*/
           .egen {
            background-color: black;
            position:absolute;
            width:100%;
            bottom:0;
            }

           .content{
               min-height: calc(100vh - 70px);
           }

    </style>
</head>
<body class="main-layout about-page">
    <form id="form1" runat="server">
         <!-- loader  -->
        <div class="loader_bg">
            <div class="loader">
                <img src="images/loading.gif" alt="#" /></div>
        </div>
        <!-- end loader -->

            <!-- Start header -->
    <header>
        <!-- header inner -->
        <div class="header">
            <div class="container">
                <div class="row">
                    <div class="col-xl-2 col-lg-2 col-md-2 col-sm-2 col logo_section">
                        <div class="full">
                            <div class="center-desk">
                                <div class="logo">
                                    <a href="index.aspx"><img src="images/logo.png" alt="logo" /></a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--updatepanel finns i asp. all kod som finns här kommer inte att laddas om--%>
                    <div class="col-xl-8 col-lg-8 col-md-10 col-sm-10">
                        <div class="menu-area">
                            <div class="limit-box">
                                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                                <nav class="main-menu">
                                    <ul class="menu-area-main">
                                        <li> <a href="index.aspx">HOME</a> </li>
                                        <li class="active"> <a href="aboutUs.aspx">ABOUT US</a> </li>
                                          <li> <a href="contactUs.aspx">CONTACT US</a> </li>
                                      <%--  mellanslag vertikalt--%>
                                        &nbsp
                                        &nbsp
                                        &nbsp
                                        &nbsp
                                        &nbsp
                                        &nbsp
                                        <li>
                                        <center><button class = "btnDesign" runat = "server" id = "logInBtn">LOG IN</button></center>
                                            <center><button runat = "server" id = "dashBtn" class ="btnDesign hideBtn">PANEL</button></center>
                                            </li>
                                        &nbsp
                                        &nbsp
                                        &nbsp
                                            <li> 
                                             <center><button runat = "server" id = "signUpBtn" class = "btnDesign">SIGN UP</button></center>
                                             <center><button runat = "server" id = "logOutBtn" class = "btnDesign hideBtn" >LOG OUT</button></center>
                                             </li>
                                    </ul>
                                </nav>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                  </div>
            </div>
            </div>
            <!-- end header inner -->
     </header>
    <!-- end header -->
        
           <!-- Start About Title-->
          <div class="aboutbg">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="abouttitlepage">
                        <h2>About us</h2>
                    </div>
                </div>
            </div>
        </div>
     </div>
         <!-- End About Title-->
           <br />
        <!-- Start content-->
        <div class="container">
            <div class="row">
                 <div class="col-md-12">
                    <div class="titlepage">
                        <h2>Who are we?</h2>
                            <span>
                               This project is developed by three students who are in their first year studying System developing at Malmo university. Our task was to develop a website that can help people plan their parties, wedding, conferences and many more events. We are glad that we have made this project come to life. 
                             </span>
                     </div>
                    <div class="titlepage">
                        <h2>
                            <br />What is our goal?</h2>
                            <span>Our goal is to offer you the best planning tool can help them make their planning easier without stress. We will do the hard job for you. We know that it can be stressful to arrange a party, but we are here to help you. The website is designed to make it easy for you to plan for your party or event. . You do not need to be an expert to use our website. Party time is a user-friendly website which is very easy to understand both for beginners and for the experienced ones. Good luck with your planning!
                                <br/>Sincerely PartyTime team.
                            </span>    
                    </div>
                </div>
            </div>
        </div>
        <!-- End content-->
    <!-- Start Footer -->
 <footer class=" text-white egen">
   <!-- Start Grid container -->
  <div class="container p-4">
    <!-- Start section: Text -->
    <section class="mb-4">
       <ul class="locarion_icon">
          <li><img src="../icon/1.png" alt="icon" />Malmö</li>
          <li><img src="../icon/3.png" alt="icon" />Email : partytimemau21@gmail.com</li>
        </ul>
    </section>
    <!-- End section: Text -->
  </div>
  <!-- End grid container -->

  <!--Start Copyright -->
  <div class="text-center" style="background-color: rgba(0, 0, 0, 0.2)">
      <h2 style="color:white">
     © 2021 All Rights Reserved. Party Time
      </h2>
  </div>
  <!-- End Copyright -->
 </footer>

        

         
    
        <!-- Javascript files-->
        <script src="js/jquery.min.js"></script>
        <script src="js/custom.js"></script>

    <%-- Make the navbar resizble --%>
        <script src="js/plugin.js"></script>

      </form>
</body>
</html>


      