<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="KSU_Templates.Admin.AdminHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <head>
        <title>Home Page V16</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <!--===============================================================================================-->
        <link rel="icon" type="image/png" href="../images/icons/favicon.ico" />
        <!--===============================================================================================-->

        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="../fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="../vendor/animate/animate.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="../vendor/css-hamburgers/hamburgers.min.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="../vendor/animsition/css/animsition.min.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="../vendor/select2/select2.min.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="../vendor/daterangepicker/daterangepicker.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="../css/util.css">
        <link rel="stylesheet" type="text/css" href="../css/main.css">
        <!--===============================================================================================-->
    </head>

    <!-- Header -->
    <div class="limiter">
        <div class="container-login100" style="background-image: url('../images/bg-01.jpg');">
            <div class="container d-flex align-items-center flex-column">
                <!-- Header Heading -->
                <h1 class="masthead-heading text-uppercase mb-0" style="color: #ffffff; font-size: 70px">KSU Templetes</h1>
                <!-- Icon Divider -->
                <div class="divider-custom divider-light">
                    <div class="divider-custom-line"></div>
                    <div class="divider-custom-icon"><i class="fas fa-star"></i></div>
                    <div class="divider-custom-line"></div>
                </div>
                <!-- header Subheading -->
                <p class="masthead-subheading font-weight-light mb-0" style="color: #ffffff; font-size: x-large">Effective Date Notice - Trainee Attendance - Follow up Form</p>
            </div>
        </div>
    </div>

    <!-- Admin Dashboard Section -->
    <section class="page-section portfolio" id="portfolio">
        <div class="container">
            <!-- Admin Dashboard Section Heading -->
            <h2 class="page-section-heading text-center text-uppercase text-secondary mb-0">Admin Dashboard</h2>
            <!-- Icon Divider-->
            <div class="divider-custom">
                <div class="divider-custom-line"></div>
                <div class="divider-custom-icon"><i class="fas fa-star"></i></div>
                <div class="divider-custom-line"></div>
            </div>
        </div>
        <!-- Admin Dashboard -->
        <div class="row justify-content-center">
            <!--Update information -->
            <div class="col-md-6 col-lg-4 mb-5">
                <a href="/About.aspx">
                    <div class="portfolio-item mx-auto" data-bs-toggle="modal">
                        <div class="portfolio-item-caption d-flex align-items-center justify-content-center h-100 w-100">
                            <div class="portfolio-item-caption-content text-center text-white"><i class="fas fa-plus fa-3x"></i></div>
                        </div>
                        <img class="img-fluid" src="/images/Component 10.png" alt="..." />
                    </div>
                </a>
            </div>
            <!-- Templates Generation -->
            <div class="col-md-6 col-lg-4 mb-5">
                <a href="/About.aspx">
                    <div class="portfolio-item mx-auto" data-bs-toggle="modal">
                        <div class="portfolio-item-caption d-flex align-items-center justify-content-center h-100 w-100">
                            <div class="portfolio-item-caption-content text-center text-white"><i class="fas fa-plus fa-3x"></i></div>
                        </div>
                        <img class="img-fluid" src="/images/Component 11.png" alt="..." />
                    </div>
                </a>
            </div>
            <!-- CRUD -->
            <div class="col-md-6 col-lg-4 mb-5">
                <a href="/Admin/crudOperation.aspx">
                    <div class="portfolio-item mx-auto" data-bs-toggle="modal">
                        <div class="portfolio-item-caption d-flex align-items-center justify-content-center h-100 w-100">
                            <div class="portfolio-item-caption-content text-center text-white"><i class="fas fa-plus fa-3x"></i></div>
                        </div>
                        <img class="img-fluid" src="/images/Component 12.png" alt="..." />
                    </div>
                </a>
            </div>
        </div>
    </section>
</asp:Content>