<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PartyTime.Index" %>

 <%-- Created by: Mohanad Oweidat --%>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
     <title>Party Time-Home</title>
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
            height: 100%;
            background-color: black;
            }
       </style>

</head>
<body class="main-layout">
    <form id="form1" runat="server">
          <!-- loader  -->
    <div class="loader_bg">
        <div class="loader"><img src="images/loading.gif" alt="#" /></div>
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
                                    <a href="index.aspx"><img height="50" src="images/logo.png" alt="logo" /></a>
                                </div>
                            </div>
                        </div>
                    </div>
                   
                    <div class="col-xl-8 col-lg-8 col-md-10 col-sm-10">
                        <div class="menu-area">
                            <div class="limit-box">
                                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                                <nav class="main-menu">
                                    <ul class="menu-area-main">
                                        <li class="active"> <a href="index.aspx">Home</a> </li>
                                        <li><a href="aboutUs.aspx">About us</a> </li>
                                          <li><a href="contactUs.aspx">Contact us</a> </li>
                                        &nbsp
                                        &nbsp
                                        &nbsp
                                        &nbsp
                                        &nbsp
                                        &nbsp
                                        <li> 
                                            <center><button class="btnDesign" runat="server" id="logInBtn">LOG IN</button></center>
                                            <center><button runat="server" id="dashBtn" class="btnDesign hideBtn">PANEL</button></center>
                                        </li>
                                        &nbsp
                                        &nbsp
                                        &nbsp
                                         <li> 
                                             <center><button runat="server" id="signUpBtn" class="btnDesign">SIGN UP</button></center>
                                             <center><button runat="server" id="logOutBtn" class="btnDesign hideBtn">LOG OUT</button></center>
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
        <section class="banner_section">
            <div class="banner-main">
                <img src="images/banner2.jpg" />
                <div class="container">
                     <div class="text-bg relative">
                        <h1>Party Time<br>
                            <span class="Perfect">The perfect tool for planning your event</span>
                            <br>
                            Welcome!
                         </h1>
                         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                         <ContentTemplate>
                          <button runat="server" id="planBtn"><a>Start planning</a></button>
                         </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </section>

         <!-- Albums -->
        <div id="screenshot" class="Albums">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="titlepage">
                            <h2>Planning example:</h2>
                        </div>
                    </div>
                </div>
                 <div class="row">
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 margin">
                        <div class="Albums-box">
                            <figure>
                                <a href="images/children.jpg">
                                    <img src="images/children.jpg">
                                </a>
                                <span class="hoverle">
                                    <a href="images/children.jpg">
                                        <img src="images/search.png"></a>
                                </span>
                            </figure>
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 margin">
                        <div class="Albums-box">
                            <figure>
                                <a href="images/wedding.jpg">
                                    <img src="images/wedding.jpg">
                                </a>
                                <span class="hoverle">
                                    <a href="images/wedding.jpg">
                                        <img src="images/search.png"></a>
                                </span>
                            </figure>
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 margin">
                        <div class="Albums-box">
                            <figure>
                                <a href="images/conferance.jpg">
                                    <img src="images/conferance.jpg">
                                </a>
                                <span class="hoverle">
                                    <a href="images/conferance.jpg">
                                        <img src="images/search.png"></a>
                                </span>
                            </figure>
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 margin">
                        <div class="Albums-box">
                            <figure>
                                <a href="images/conferance2.jpg">
                                    <img src="images/conferance2.jpg">
                                </a>
                                <span class="hoverle">
                                    <a href="images/conferance2.jpg">
                                        <img src="images/search.png"></a>
                                </span>
                            </figure>
                        </div>
                    </div>
                 </div>
            </div>
        </div>
        <!-- end Albums -->

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
        <!-- Javascript files-->
        <script src="js/jquery.min.js"></script>
        <script src="js/custom.js"></script>

     
      <%-- Make the navbar resizble --%>
        <script src="js/plugin.js"></script>
   
      </form>
</body>
</html>
