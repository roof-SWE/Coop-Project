<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="KSU_Templates.Login_and_Register.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!DOCTYPE html>
<html>
<head>
	<title>Login V16</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="../images/icons/favicon.ico"/>
<!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="../fonts/font-awesome-4.7.0/css/font-awesome.min.css">
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
<body>
	<br />
	<div class="limiter">
       
		<div class="container-login100" style="background-image: url('../images/bg-01.jpg');">
			<div class="wrap-login100 p-t-30 p-b-50">
				<span class="login100-form-title p-b-41">
					Sign up 
				</span>
				<form class="login100-form validate-form p-b-33 p-t-5">

					<div class="wrap-input100 validate-input" data-validate = "Enter username" id="userError" runat="server">
						<asp:TextBox class="input100" type="text" name="username" placeholder="User name" id="userName" runat="server"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xe82a;"></span>
					</div>

                     <div class="wrap-input100 validate-input" data-validate="Enter email" id="emailError" runat="server">
						<asp:TextBox class="input100" type="text" name="email" placeholder="Email" id="email" runat="server"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xe818;"></span>
					</div>

					<div class="wrap-input100 validate-input" data-validate="Enter password" id="passwordError" runat="server">
						<asp:TextBox class="input100" type="password" name="pass" placeholder="Password" id="password" runat="server"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xe80f;"></span>
					</div>

                    <div class="wrap-input100 validate-input" data-validate="Enter confirm password" id="confirmPasswordError" runat="server">
						<asp:TextBox class="input100" type="password" name="pass" placeholder="Confirm password" id="confirmPassword" runat="server"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xe80f;"></span>
					</div>

					<div class="container-login100-form-btn m-t-32">
						<asp:Button class="login100-form-btn" Text="Sign up" onClick="submit" runat="server" >
							
						</asp:Button>
					</div>

				</form>
			</div>
		</div>
	</div>
	

	<div id="dropDownSelect1"></div>
	
<!--===============================================================================================-->
	<script src="../vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="../vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="../vendor/bootstrap/js/popper.js"></script>
	<script src="../vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="../vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="../vendor/daterangepicker/moment.min.js"></script>
	<script src="../vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="../vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="../Scripts/main.js"></script>


     <script>

      
        $('#<%= userName.ClientID %>').focus(function(){
           hideValidate(this);
        });

         
        $('#<%= email.ClientID %>').focus(function(){
           hideValidate(this);
         });

         
        $('#<%= password.ClientID %>').focus(function(){
           hideValidate(this);
         });

         
        $('#<%= confirmPassword.ClientID %>').focus(function(){
           hideValidate(this);
        });
          function hideValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).removeClass('alert-validate');
        }

    </script>

</body>
</html>
</asp:Content>
