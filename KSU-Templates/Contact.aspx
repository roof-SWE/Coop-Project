<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="KSU_Templates.Contact" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <head>
        <title>Contact V16</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <!--===============================================================================================-->
        <link rel="icon" type="image/png" href="/images/icons/favicon.ico" />
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="/vendor/animate/animate.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="/vendor/css-hamburgers/hamburgers.min.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="/vendor/animsition/css/animsition.min.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="/vendor/select2/select2.min.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="/vendor/daterangepicker/daterangepicker.css">
        <!--===============================================================================================-->
        <link rel="stylesheet" type="text/css" href="/css/util.css">
        <link rel="stylesheet" type="text/css" href="/css/main.css">
        <!--===============================================================================================-->
        <!-- Font-->
        <link rel="stylesheet" type="text/css" href="/Form_styles/css/opensans-font.css">
        <link rel="stylesheet" type="text/css" href="/Form_styles/fonts/material-design-iconic-font/css/material-design-iconic-font.min.css">
        <!-- Main Style Css -->
        <link rel="stylesheet" href="/Form_styles/css/style.css" />

        <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>

    </head>
      <div class="limiter">
        <div class="container-login100" style="background-image: url('/images/bg-01.jpg');">
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
                <p class="masthead-subheading font-weight-light mb-0" style="color: #ffffff; font-size: x-large">Effective Date Notice - Trainee Attendance - Follow Up form</p>
            </div>
        </div>
    </div>
       <section class="page-section" style="background-color: rgba(44, 62, 80,0.1);" id="follow-up">

        <!-- Contact Section Heading-->
        <h2 class="page-section-heading text-center text-uppercase text-secondary">Contact</h2>
        <!-- Icon Divider-->
        <div class="divider-custom">
            <div class="divider-custom-line"></div>
            <div class="divider-custom-icon">
                <i class="fas fa-star"></i>
            </div>
            <div class="divider-custom-line"></div>
        </div>

               <div class="page-content">
            <div class="form-v1-content">
                <div class="wizard-form">
                    <div class="form-register">
                        <div id="form-total">
                            <h2></h2>
                            <section>
                                <div class="inner">
                                    <div class="wizard-header">
                                        <h3 class="heading">Contact Us</h3>
                                        <p>If you have any questions, just fill in the contact form and we will answer you shortly. </p>
                                    </div>
                                      <%--From field--%>
                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <fieldset>
                                                <legend>From:<asp:Label ID="fromError" runat="server" Text="  *" Style="color: red; font-size: 16px" Visible="false"></asp:Label></legend>
                                                <input type="text" name="from" id="txtFrom" class="form-control" placeholder="Example@gmail.com" runat="server" style="background-color: white">
                                            </fieldset>
                                        </div>
                                    </div>
                                     <%--Subject field--%>
                                     <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <fieldset>
                                                <legend>Subject:<asp:Label ID="subjectError" runat="server" Text="  *" Style="color: red; font-size: 16px" Visible="false"></asp:Label></legend>
                                                <input type="text" name="subject" id="txtSubject" class="form-control" placeholder="Subject" runat="server" style="background-color: white">
                                            </fieldset>
                                        </div>
                                    </div>
                                      <%--Attachement field--%>
                                     <div class="form-row">
                                        <div class="form-holder form-holder-2" style="margin-bottom:0px;padding-bottom:0px">
                                        
                                                <label class="special-label">Attachements: 
                                               </label>   </div></div>
                                                <asp:FileUpload ID="FileUpload1" runat="server"  AllowMultiple="true" BackColor="#2c3e50" ForeColor="White" BorderColor="#2c3e50e" />

                                    <br />  <br />
                                     <%-- Message field--%>
                                       <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <label class="special-label">Message:
                                                <asp:Label ID="messageError" runat="server" Text=" *" Style="color: red; font-size: 16px" Visible="false"></asp:Label></label>

                                            <asp:TextBox ID="txtMessage" TextMode="MultiLine" class="form-control" placeholder="Write your message here..." runat="server"></asp:TextBox>

                                        </div>
                                    </div>

                                     <%--Send button--%>
                                    <div class="form-row">
                                        <div class="container-login100-form-btn m-t-32">
                                            <asp:Button class="login100-form-btn" Text="Send" runat="server" ID="btnSend" OnClick="btnSend_Click"></asp:Button>
                                        </div>
                                    </div>
                                    <br />

                                    <br />
                                    <br />
                                </div>
                            </section>

                        </div>
                    </div>
                </div>
            </div>
        </div>

       </section>
      <script src="/Form_styles/js/jquery-3.3.1.min.js"></script>
        <script src="/Form_styles/js/jquery.steps.js"></script>
        <script src="/Form_styles/js/main.js"></script>
</asp:Content>
