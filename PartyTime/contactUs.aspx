3<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contactUs.aspx.cs" Inherits="PartyTime.contactUs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <!- såhär komenterar vi-->

     <title>Party Time-contact us</title>
    <!-- basic -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- mobile metas -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="viewport" content="initial-scale=1, maximum-scale=1">
    <!-- site metas -->
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
    <%--<style>
        h1{
            color:blue;
        }
    </style>--%>
</head>
<body class="main-layout contact-page">
    <form id="form1" runat="server">
     <!-- loader  -->
    <div class="loader_bg">
        <div class="loader"><img src="images/loading.gif" alt="#" /></div>
    </div>
    <!-- end loader -->
     <!-- header -->
        <header>
            <!-- header inner -->
            <div class="header">
                <div class="container">
                    <div class="row">
                        <div class="col-xl-2 col-lg-2 col-md-2 col-sm-2 col logo_section">
                            <div class="full">
                                <div class="center-desk">
                                    <div class="logo">
                                        <a href="index.html">
                                            <img src="images/logo.jpg" alt="logo" /></a>
                                         <%-- <a href="index.aspx">Party Time</a>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-8 col-lg-8 col-md-10 col-sm-10">
                            <div class="menu-area">
                                <div class="limit-box">
                                    <nav class="main-menu">
                                        <ul class="menu-area-main">
                                            <li><a href="index.aspx">Start menu</a></li>
                                            <li><a href="aboutUs.aspx">About us</a></li>
                                            <li class="active"><a href="KontaktaOss.aspx">Contact us</a></li>
                                            <li> <a href="logIn.aspx">Log in</a> </li>
                                             <li> <a href="signUp.aspx">Sign Up</a> </li>
                                        </ul>
                                    </nav>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <!-- end header inner -->
        </header>
     <!-- end header -->
    <!-- Start Contact us Title-->
         <div class="contactbg">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="contacttitlepage">
                        <h2>Contact us</h2>
                    </div>
                </div>
            </div>
        </div>
             </div>
          <!-- End Contact us Title-->
<!-- Start Contact form-->
            <div class="container">
        <div class="row">
            <div class=" col-md-6 offset-md-3">
                <div class="address">

                    <form>
                        <div class="row">
                            <div class="col-sm-12">
                                <input id="name" runat="server" class="contactus" placeholder="Name" type="text" name="Name"> 
                               
                            </div>
                            <div class="col-sm-12">
                                <input id="phone" runat="server" class="contactus" placeholder="Phone number" type="text" name="Email">
                            </div>
                            <div class="col-sm-12">
                                <input id="email" runat="server" class="contactus" placeholder="E-mail" type="text" name="Email">
                            </div>
                            <div class="col-sm-12">
                                <textarea id="message" runat="server" class="textarea" placeholder="Message" type="text" name="Message"></textarea>
                            </div>
                            <div class="col-sm-12">
                                <button id="send_btn" runat="server" class="send">Send</button>
                            </div>
                            
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
        <!-- End Contact form-->
     <br />
         <!--  footer -->
        <footer id="footer_with_contact">
            <div class="footer">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12 width">
                            <div class="address">
                                ´                           
                                <ul class="locarion_icon">
                                    <li>
                                        <img src="icon/1.png" alt="icon" />Malmö</li>
                                    <li>
                                        <img src="icon/2.png" alt="icon" />Phone: ( +46 768307878 )</li>
                                    <li>
                                        <img src="icon/3.png" alt="icon" />Email : demo@email.com</li>

                                </ul>

                            </div>
                        </div>


                        <div class="col-lg-5 col-md-5 col-sm-5 ">
                            <div class="address">
                                <h3>Party Time</h3>
                              </div>
                        </div>
                     </div>
                </div>
                <div class="copyright">
                    <p>© 2021 All Rights Reserved. Party Time</p>
                </div>
            </div>
        </footer>
        <!-- end footer -->
           <!-- Javascript files-->
    <script src="js/jquery.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.bundle.min.js"></script>
    <script src="js/jquery-3.0.0.min.js"></script>
    <script src="js/plugin.js"></script>
    <!-- sidebar -->
    <script src="js/jquery.mCustomScrollbar.concat.min.js"></script>
    <script src="js/custom.js"></script>
    <script src="https:cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.min.js"></script>
    <script>
        $(document).ready(function() {
            $(".fancybox").fancybox({
                openEffect: "none",
                closeEffect: "none"
            });

            $(".zoom").hover(function() {

                $(this).addClass('transition');
            }, function() {

                $(this).removeClass('transition');
            });
        });
    </script>
        
         </form>
</body>
</html>
