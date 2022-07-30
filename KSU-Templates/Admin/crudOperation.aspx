<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="crudOperation.aspx.cs" Inherits="KSU_Templates.Admin.WebForm1" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <head>
        <title>Home Page V16</title>
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
    </head>


    <!-- Header -->
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
    <!-- Attendance Temaplate Section-->
    <section class="page-section" style="background-color: rgba(44, 62, 80,0.1);" id="attendance">

        <!-- Contact Section Heading-->
        <h2 class="page-section-heading text-center text-uppercase text-secondary">Trainee crud</h2>
        <!-- Icon Divider-->
        <div class="divider-custom">
            <div class="divider-custom-line"></div>
            <div class="divider-custom-icon">
                <i class="fas fa-star"></i></div>
            <div class="divider-custom-line"></div>
        </div>

        <div class="page-content hidden" id="editDiv" runat="server">
            <div class="form-v1-content">
                <div class="wizard-form">
                    <div class="form-register">
                        <div id="form-total">
                            <!-- SECTION 1 -->
                            <h2></h2>
                            <section>
                                <div class="inner">
                                    <div class="wizard-header">
                                        <h3 class="heading">Trainee information</h3>
                                        <p>Please enter the infomation.  </p>
                                    </div>

                                     <div class="form-row form-row-date">
                                         <div class="form-holder form-holder-2 hidden" id="userNameDiv" runat="server">
                                            <fieldset>
                                                <legend>User Name <asp:Label ID="userNameAddError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label>
                                                </legend>
                                                <asp:TextBox  type="text" class="form-control" id="userNameAdd" name="userNameAdd" placeholder="User Name" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                          <div class="form-holder form-holder-2 hidden" id="passwordDiv" runat="server">
                                            <fieldset>
                                                <legend>Password<asp:Label ID="passwordError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label>
                                                </legend>
                                                <asp:TextBox class="form-control" type="password" id="password" name="password" placeholder="password" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                
                                          </div>

                                    <asp:Label ID ="userName2" runat="server" Visible="false"></asp:Label>
                                    <div class="form-row">                                  

                                        <div class="form-holder">
                                            <fieldset>
                                                <legend>Name<asp:Label ID="nameError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label>
                                                </legend>
                                                <asp:TextBox  type="text" class="form-control" id="name" name="name" placeholder="Name" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>

                                        <div class="form-holder">
                                            <fieldset>
                                                <legend>ID<asp:Label ID="idError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label></legend>
                                                <asp:TextBox  type="text" class="form-control" id="idd" name="id" placeholder="ID" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                    </div>
                                    <div class="form-row form-holder-2">
                                            <div>          
                                                
                                                <asp:DropDownList ID="ddlMajor" runat="server" CssClass="drop form-holder-2">
                                            
                                                  </asp:DropDownList>
                                                                             
                                               </div>
                                                                                                                                                                    
                                    </div>
                             
                                      <div class="form-row form-row-date">
                                         <div class="form-holder form-holder-2">
                                            <fieldset>
                                                <legend>Trainee Email<asp:Label ID="traineeEmailError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label>
                                                </legend>
                                                <asp:TextBox  type="text" class="form-control" id="traineeEmail" name="traineeEmail" placeholder="Trainee Email" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                
                                          </div>

                                   

                                      <div class="form-row form-row-date">
                                         <div class="form-holder form-holder-2">
                                            <fieldset>
                                                <legend>Trainee Mobile<asp:Label ID="Label1" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label>
                                                </legend>
                                                <asp:TextBox  type="text" class="form-control" id="mobile" name="mobile" placeholder="Mobile" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                   
                                          </div>

                               <div class="form-row form-row-date">
                                     <div class="form-holder">
                                            <fieldset>
                                                <legend>Supervisor name<asp:Label ID="supervisorNameError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label>
                                                </legend>
                                                <asp:TextBox  type="text" class="form-control" id="supervisorName" name="supervisorName" placeholder="Supervisor name" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                    <div class="form-holder">
                                            <fieldset>
                                                <legend>Supervisor Email<asp:Label ID="supervisorEmailError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label>
                                                </legend>
                                                <asp:TextBox  type="text" class="form-control" id="supervisorEmail" name="supervisorEmail" placeholder="Supervisor Email" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>

                                   </div>

                                     <div class="form-row">
                                    <div class="container-login100-form-btn m-t-32">
                                        <asp:Button class="login100-form-btn" Text="Update" runat="server" ID="btnUpdate" OnClick="update" BorderStyle="None"></asp:Button>
                                        <asp:Button class="login100-form-btn" Text="Save" runat="server" ID="btnSave" OnClick="save" BorderStyle="None"></asp:Button>

                                    </div>
                                         </div>

                                      <br />
                                    <br />


                                </div>
                            </section>


                        </div>
                    </div>
                </div>
            </div>
        </div>

        
        <br /><br /><br />

           <!-- add trainee, export word, pdf, xcl buttons -->

        <section class="section">
                                     <div class="wizard-header">
                                        <h4 class="page-section-heading text-center text-uppercase text-secondary">View information</h4>
                                        <p>You can delete and edit any information</p>
                                    </div>


            
                                     <div class="form-row">
                                    <div class="container-login100-form-btn m-t-32">
                                        <asp:Button class="login100-form-btn" Text="Add Trainee" runat="server" ID="Button1" OnClick="addTrainee" BorderStyle="None"></asp:Button>
                                        <asp:Button class="login100-form-btn" Text="Export to Word" runat="server" ID="Button2" OnClick="exportToWord" BorderStyle="None"></asp:Button>
                                        <asp:Button class="login100-form-btn" Text="Export to Excel" runat="server" ID="Button3" OnClick="exportToExcel" BorderStyle="None"></asp:Button>
                                        <asp:Button class="login100-form-btn" Text="Export to PDF" runat="server" ID="Button4" OnClick="exportToPDF" BorderStyle="None"></asp:Button>


                                    </div>
                                         </div>


               <!-- Trainees gride view -->

            <div style="align-content:center">
             <asp:GridView ID="gvDepartments" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                        EmptyDataText="No Records Found" GridLines="both" CssClass="gv" EmptyDataRowStyle-ForeColor="Red" BorderColor="#CCCCCC" BorderStyle="None"
                       >
                        <Columns>
                            <asp:TemplateField HeaderText="trainee">
                                <ItemTemplate>
                                    <asp:Label ID="trainee" runat="server" Text='<%#Eval("trainee") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="id">
                                <ItemTemplate>
                                    <asp:Label ID="id" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="major">
                                <ItemTemplate>
                                    <asp:Label ID="major" runat="server" Text='<%#Eval("major") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="traineeMobile">
                                <ItemTemplate>
                                    <asp:Label ID="traineeMobile" runat="server" Text='<%#Eval("traineeMobile") %>' Enabled="false"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="traineeEmail">
                                <ItemTemplate>
                                    <asp:Label ID="traineeEmail" runat="server" Text='<%#Eval("traineeEmail") %>' Enabled="false"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="universitySupervisor">
                                <ItemTemplate>
                                    <asp:Label ID="universitySupervisor" runat="server" Text='<%#Eval("universitySupervisor") %>' Enabled="false"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="universitySupervisorEmail">
                                <ItemTemplate>
                                    <asp:Label ID="universitySupervisorEmail" runat="server" Text='<%#Eval("universitySupervisorEmail") %>' Enabled="false"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="/images/edit.png" OnClick="btnEdit_Click" />
                                    <asp:ImageButton ID="btnDelete" runat="server"  ImageUrl="/images/x-button.png" 
                                        OnClientClick="return confirm('Are you sure? you want to delete this trainee ?');"
                                        OnClick="btnDelete2_Click" />
                                    <asp:Label ID="userName" runat="server" Text='<%#Eval("userName") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
        </div>
            <br />
            <br />
            </section>
    </section>

    <script src="/Form_styles/js/jquery-3.3.1.min.js"></script>
    <script src="/Form_styles/js/jquery.steps.js"></script>
    <script src="/Form_styles/js/main.js"></script>

       <!-- style -->
    <style>
        .hidden {
  display: none;
}

         .gv {
            margin-top: 50px;
            width:100%;
        }

            .gv th {
                font-weight: bold;
                color: black;
                padding: 2px 10px;
            }

            .gv td {
                padding: 2px 10px;
            }

        input[type="submit"] {
            margin: 2px 10px;
            padding: 2px 20px;
            background-color: #5D7B9D;
            border-radius: 10px;
            border: solid 1px #000;
            cursor: pointer;
            color: #fff;
        }

            input[type="submit"]:hover {
                background-color: orange;
            }

        .auto-style1 {
            text-align: center;
            margin-left: 40px;
        }

        .auto-style2 {
            width: 367px;
        }

        .auto-style5 {
            width: 183px;
        }

        .auto-style6 {
            width: 184px;
        }


        .drop {
            border-color:lightgray;
            border-width:2px;
            margin:10px;
            padding-left:15px;
            padding-bottom:5px;   
            max-width:450px;
            min-width: 440px;
            max-height:100px;
            min-height:60px;
            color:#2C3E50;
            font-family:sans-serif;
        }
        

        .section {
            margin-left:50px;margin-right:50px; background-color:white; text-align: center;border-radius: 25px; padding: 40px;box-shadow: 0px 8px 20px 0px rgba(0, 0, 0, 0.15);-o-box-shadow: 0px 8px 20px 0px rgba(0, 0, 0, 0.15);-ms-box-shadow: 0px 8px 20px 0px rgba(0, 0, 0, 0.15);-moz-box-shadow: 0px 8px 20px 0px rgba(0, 0, 0, 0.15);-webkit-box-shadow: 0px 8px 20px 0px rgba(0, 0, 0, 0.15);
        }
      @media screen and (max-width: 700px) {
	.section {
		margin: 0px 0;
	}
}

 @media screen and (max-width: 750px) {
	table.myGridView th, td{
        font-size:13px;
        padding:0px;
        width: 5px;
	}
}

 @media screen and (max-width: 750px) {
	table {
       
       border-spacing: 0 0px;
	}
}



      table {
  border-collapse: separate;
  border-spacing: 0 15px;
}
     
td {
  width: 50px;
  text-align: center;
  border-bottom: 1px solid #D2D2D7;
  padding-bottom: 10px;
}

table caption {
        text-align:center;
    }

table.myGridView th
{
    padding:20px
}

    </style>
       <!-- script -->
   <script type="text/javascript">
    function removeClass() {
         $('#<%= editDiv.ClientID %>').removeClass('hidden');
       }
       function removeClassFromUserNameAndPassword() {
           $('#<%= userNameDiv.ClientID %>').removeClass('hidden');
           $('#<%= passwordDiv.ClientID %>').removeClass('hidden');
       }
       </script>
</asp:Content>

