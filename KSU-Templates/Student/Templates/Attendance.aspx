<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="KSU_Templates.Student.Templates.WebForm1" %>
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

        <!-- attendance Section Heading-->
        <h2 class="page-section-heading text-center text-uppercase text-secondary">Attendance Form</h2>
        <!-- Icon Divider-->
        <div class="divider-custom">
            <div class="divider-custom-line"></div>
            <div class="divider-custom-icon">
                <i class="fas fa-star"></i></div>
            <div class="divider-custom-line"></div>
        </div>

        <div class="page-content">
            <div class="form-v1-content">
                <div class="wizard-form">
                    <div class="form-register">
                        <div id="form-total">
                            <!-- SECTION 1 -->
                            <h2></h2>
                            <section>
                                <div class="inner">
                                    <div class="wizard-header">
                                        <h3 class="heading">Trainee's information</h3>
                                        <p>Please enter your infomation.  </p>
                                    </div>
                                   
                                    <%--trainee information (student)--%>

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
                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <fieldset>
                                                <legend>Institution<asp:Label ID="institutionError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label></legend>
                                                <input type="text" name="institution" id="institution" class="form-control" placeholder="Institution" readonly runat="server" style="background-color:white">
                                            </fieldset>
                                        </div>
                                    </div>
                               
                                    <div class="form-row form-row-date">
                                        <div class="form-holder form-holder-2">
                                            <fieldset>
                                                 <legend>Starting Date <asp:Label ID="startDateError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label></legend>
						<asp:TextBox class="input100" textmode="Date" type="text" name="startingDate" id="startingDate" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                    </div>

                                <%--Attendance information--%>

                                    <div class="wizard-header">
                                        <h3 class="heading">Attendance</h3>  
                                        <p>Please enter your infomation.  </p>
                                    </div>

                                     <div class="form-row">
                                        <div class="form-holder">
                                            
                                               
                                                  <select id="week" runat="server">
                                                <option value="Week" disabled selected>Week</option>
                                                <option value="1">1</option>
                                                <option value="2">2</option>
                                                <option value="3">3</option>
                                                <option value="4">4</option>
                                                <option value="5">5</option>
                                                <option value="6">6</option>
                                                <option value="7">7</option>
                                                <option value="8">8</option>
                                                      </select>
                                          
                                        </div>
                           <asp:Label ID="weekError" runat="server" Text=" *" style="color:red; font-size:16px" Visible="false"></asp:Label>

                                        <div class="form-holder">
                                            
                                                 <asp:DropDownList ID="ddlDay" runat="server">
                                                      <Items>
                                                          
                                                          <asp:ListItem Text="Day" Value="Day" Selected="True" />
                                                          <asp:ListItem>Sunday</asp:ListItem>
                                                          <asp:ListItem>Monday</asp:ListItem>
                                                          <asp:ListItem>Tuesday</asp:ListItem>
                                                          <asp:ListItem>Wednesday</asp:ListItem>
                                                          <asp:ListItem>Thursday</asp:ListItem>

                                                      </Items>
                                                  </asp:DropDownList>
                                            
                                                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KSU_Templates_ConStr %>" SelectCommand="SELECT * FROM [day]"></asp:SqlDataSource>
                                            
                                        </div>
                     <asp:Label ID="dayError" runat="server" Text=" *" style="color:red; font-size:16px" Visible="false"></asp:Label>
 
                                    </div>
                                     <div class="form-row">
                                     <div class="form-holder form-holder-2"">
                                            <fieldset>
                                                <legend>Date <asp:Label ID="dateError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label>
</legend>
						<asp:TextBox class="input100" textmode="Date" type="text" name="attendanceDate" id="attendanceDate" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>
                                         </div>
                                 <div class="form-row">
                                            <div class="form-holder">
                                            <fieldset>
                                                <legend>Time in <asp:Label ID="timeInError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label>
</legend>
                                                <asp:TextBox textmode="Time" format="HH:mm" type="text" class="form-control" id="timeInField" name="TimeInField" placeholder="Time in" runat="server"></asp:TextBox>
                                            </fieldset>
                                                </div>
                                                <div class="form-holder">
                                            <fieldset>
                                                <legend>Time out <asp:Label ID="timeOutError" runat="server" Text="  *" style="color:red; font-size:16px" Visible="false"></asp:Label>
</legend>
                                                <asp:TextBox textmode="Time" format="HH:mm" type="text" class="form-control" id="timeOutField" name="TimeOutField" placeholder="Time in" runat="server"></asp:TextBox>
                                            </fieldset>
                                        </div>                                      
                                    </div>

                               
                                    <div class="form-row">
                                        <div class="form-holder form-holder-2">
                                            <label class="special-label">Comments:</label>
                                            <textarea name="comments" id="comments" class="form-control" placeholder="Write your comments here..." runat="server" ></textarea>

                                        </div>
                                    </div>

                                <%--Signature upload--%>
                                    <div class="wizard-header">
                                        <h3 class="heading">Signature upload</h3>
                                        <p>Please upload your Signature </p>

                                        <br />
                                        <asp:FileUpload id="FileUpload1" runat="server" onchange="ImagePreview(this);" BackColor="#2c3e50" ForeColor="White" BorderColor="#2c3e50e" />
                                    </div>

                                  <div class="wizard-header" id="imageDiv">
                                      <asp:Image ID="oldSignature" Visible="false" runat="server" Height="200" Width="200" />
                                    <asp:Image ID="newSignature" style="display:none"  runat="server" Height="120px" Width="117px" />
                                        </div>
                               
                                    <%--Submit--%>
                

                                     <div class="form-row">
                                    <div class="container-login100-form-btn m-t-32">
                                        <asp:Button class="login100-form-btn" Text="Submit" runat="server" ID="btnSubmit" OnClick="submit"></asp:Button>
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

        <section class="section">
                                     <div class="wizard-header">
                                        <h4 class="page-section-heading text-center text-uppercase text-secondary">View attendance information</h4>
                                        <p>You can delete any attendance information and resubmit it again</p>
                                    </div>
            <br /><br />

                                            <%--Week 1 Gride view --%>

                                    <div id="dropDownSelect1">
        <asp:GridView Class="myGridView" Caption="Week1" CaptionAlign="Top" width="100%" ID="gvUsers" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="false" OnRowDeleting="deleteW1" >
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle  Font-Bold="True" ForeColor="black" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
            <Columns>

                    <asp:BoundField DataField ="week" HeaderText ="Week" />    
                    <asp:BoundField DataField ="day" HeaderText ="Day" />    
                    <asp:BoundField DataField ="date" HeaderText ="Date" />    
                    <asp:BoundField DataField ="timeIn" HeaderText ="Time In" />    
                    <asp:BoundField DataField ="timeOut" HeaderText ="Time Out" />    
                    <asp:BoundField DataField ="comment" HeaderText ="Comment" />    
                      <asp:ButtonField runat="server" CausesValidation="false" 
                         CommandName="delete" Text="Delete" ItemStyle-ForeColor="Red" ImageUrl="/images/x-button.png" ButtonType="Image" ItemStyle-CssClass="buttonStyle"/>
            </Columns>
        </asp:GridView>
    </div>
<br /><br />
                                     <%--Week 2 Gride view --%>

              <div id="dropDownSelect2">
        <asp:GridView Class="myGridView" Caption="Week2" CaptionAlign="Top" width="100%" ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="false" OnRowDeleting="deleteW2" >
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle  Font-Bold="True" ForeColor="black" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
            <Columns>

                    <asp:BoundField DataField ="week" HeaderText ="Week" />    
                    <asp:BoundField DataField ="day" HeaderText ="Day" />    
                    <asp:BoundField DataField ="date" HeaderText ="Date" />    
                    <asp:BoundField DataField ="timeIn" HeaderText ="Time In" />    
                    <asp:BoundField DataField ="timeOut" HeaderText ="Time Out" />    
                    <asp:BoundField DataField ="comment" HeaderText ="Comment" />    
                      <asp:ButtonField runat="server" CausesValidation="false" 
                         CommandName="delete" Text="Delete" ItemStyle-ForeColor="Red" ImageUrl="/images/x-button.png" ButtonType="Image" ItemStyle-CssClass="buttonStyle"/>
            </Columns>
        </asp:GridView>
    </div>

<br /><br />
                                  <%--Week 3 Gride view --%>

              <div id="dropDownSelect3">
        <asp:GridView Class="myGridView" Caption="Week3" CaptionAlign="Top" width="100%" ID="GridView3" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="false" OnRowDeleting="deleteW3" >
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle  Font-Bold="True" ForeColor="black" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
            <Columns>

                    <asp:BoundField DataField ="week" HeaderText ="Week" />    
                    <asp:BoundField DataField ="day" HeaderText ="Day" />    
                    <asp:BoundField DataField ="date" HeaderText ="Date" />    
                    <asp:BoundField DataField ="timeIn" HeaderText ="Time In" />    
                    <asp:BoundField DataField ="timeOut" HeaderText ="Time Out" />    
                    <asp:BoundField DataField ="comment" HeaderText ="Comment" />    
                      <asp:ButtonField runat="server" CausesValidation="false" 
                         CommandName="delete" Text="Delete" ItemStyle-ForeColor="Red" ImageUrl="/images/x-button.png" ButtonType="Image" ItemStyle-CssClass="buttonStyle"/>
            </Columns>
        </asp:GridView>
    </div>
<br /><br />
                                            <%--Week 4 Gride view --%>

              <div id="dropDownSelect4">
        <asp:GridView Class="myGridView" Caption="Week4" CaptionAlign="Top" width="100%" ID="GridView4" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="false" OnRowDeleting="deleteW4" >
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle  Font-Bold="True" ForeColor="black" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
            <Columns>

                    <asp:BoundField DataField ="week" HeaderText ="Week" />    
                    <asp:BoundField DataField ="day" HeaderText ="Day" />    
                    <asp:BoundField DataField ="date" HeaderText ="Date" />    
                    <asp:BoundField DataField ="timeIn" HeaderText ="Time In" />    
                    <asp:BoundField DataField ="timeOut" HeaderText ="Time Out" />    
                    <asp:BoundField DataField ="comment" HeaderText ="Comment" />    
                      <asp:ButtonField runat="server" CausesValidation="false" 
                         CommandName="delete" Text="Delete" ItemStyle-ForeColor="Red" ImageUrl="/images/x-button.png" ButtonType="Image" ItemStyle-CssClass="buttonStyle"/>
            </Columns>
        </asp:GridView>
    </div>

             <asp:Label ID="emptyGrideViews" runat="server" Text="You do not have any attendance yet" style="color:dimgrey; font-size:16px" Visible="false"></asp:Label>
<br /><br />
                                        <%--Week 5 Gride view --%>

              <div id="dropDownSelect5">
        <asp:GridView Class="myGridView" Caption="Week5" CaptionAlign="Top" width="100%" ID="GridView5" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="false" OnRowDeleting="deleteW5" >
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle  Font-Bold="True" ForeColor="black" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
            <Columns>

                    <asp:BoundField DataField ="week" HeaderText ="Week" />    
                    <asp:BoundField DataField ="day" HeaderText ="Day" />    
                    <asp:BoundField DataField ="date" HeaderText ="Date" />    
                    <asp:BoundField DataField ="timeIn" HeaderText ="Time In" />    
                    <asp:BoundField DataField ="timeOut" HeaderText ="Time Out" />    
                    <asp:BoundField DataField ="comment" HeaderText ="Comment" />    
                      <asp:ButtonField runat="server" CausesValidation="false" 
                         CommandName="delete" Text="Delete" ItemStyle-ForeColor="Red" ImageUrl="/images/x-button.png" ButtonType="Image" ItemStyle-CssClass="buttonStyle"/>
            </Columns>
        </asp:GridView>
    </div>

<br /><br />
                                             <%--Week 6 Gride view --%>

              <div id="dropDownSelect6">
        <asp:GridView Class="myGridView" Caption="Week6" CaptionAlign="Top" width="100%" ID="GridView6" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="false" OnRowDeleting="deleteW6" >
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle  Font-Bold="True" ForeColor="black" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
            <Columns>

                    <asp:BoundField DataField ="week" HeaderText ="Week" />    
                    <asp:BoundField DataField ="day" HeaderText ="Day" />    
                    <asp:BoundField DataField ="date" HeaderText ="Date" />    
                    <asp:BoundField DataField ="timeIn" HeaderText ="Time In" />    
                    <asp:BoundField DataField ="timeOut" HeaderText ="Time Out" />    
                    <asp:BoundField DataField ="comment" HeaderText ="Comment" />    
                      <asp:ButtonField runat="server" CausesValidation="false" 
                         CommandName="delete" Text="Delete" ItemStyle-ForeColor="Red" ImageUrl="/images/x-button.png" ButtonType="Image" ItemStyle-CssClass="buttonStyle"/>
            </Columns>
        </asp:GridView>
    </div>
<br /><br />
                                         <%--Week 7 Gride view --%>

              <div id="dropDownSelect7">
        <asp:GridView Class="myGridView" Caption="Week7" CaptionAlign="Top" width="100%" ID="GridView7" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="false" OnRowDeleting="deleteW7" >
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle  Font-Bold="True" ForeColor="black" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
            <Columns>

                    <asp:BoundField DataField ="week" HeaderText ="Week" />    
                    <asp:BoundField DataField ="day" HeaderText ="Day" />    
                    <asp:BoundField DataField ="date" HeaderText ="Date" />    
                    <asp:BoundField DataField ="timeIn" HeaderText ="Time In" />    
                    <asp:BoundField DataField ="timeOut" HeaderText ="Time Out" />    
                    <asp:BoundField DataField ="comment" HeaderText ="Comment" />    
                      <asp:ButtonField runat="server" CausesValidation="false" 
                         CommandName="delete" Text="Delete" ItemStyle-ForeColor="Red" ImageUrl="/images/x-button.png" ButtonType="Image" ItemStyle-CssClass="buttonStyle"/>
            </Columns>
        </asp:GridView>
    </div>

<br /><br />
                                            <%--Week 8 Gride view --%>

              <div id="dropDownSelect8">
        <asp:GridView Class="myGridView" Caption="Week8" CaptionAlign="Top" width="100%" ID="GridView8" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="false" OnRowDeleting="deleteW8" >
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle  Font-Bold="True" ForeColor="black" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
            <Columns>

                    <asp:BoundField DataField ="week" HeaderText ="Week" />    
                    <asp:BoundField DataField ="day" HeaderText ="Day" />    
                    <asp:BoundField DataField ="date" HeaderText ="Date" />    
                    <asp:BoundField DataField ="timeIn" HeaderText ="Time In" />    
                    <asp:BoundField DataField ="timeOut" HeaderText ="Time Out" />    
                    <asp:BoundField DataField ="comment" HeaderText ="Comment" />    
                      <asp:ButtonField runat="server" CausesValidation="false" 
                         CommandName="delete" Text="Delete" ItemStyle-ForeColor="Red" ImageUrl="/images/x-button.png" ButtonType="Image" ItemStyle-CssClass="buttonStyle"/>
            </Columns>
        </asp:GridView>
    </div>
            </section>
    </section>

    <script src="/Form_styles/js/jquery-3.3.1.min.js"></script>
    <script src="/Form_styles/js/jquery.steps.js"></script>
    <script src="/Form_styles/js/main.js"></script>

                                             <%-- style --%>
    <style>
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

.buttonStyle {
                padding-top: 15px;
            }

    </style>

          <%-- script --%>

   <script type="text/javascript">
    function ConfirmBox() {
      if (confirm("Are you sure you want to delete this?")) {
          alert("Yes");
        } else {
            alert("No");
     }
       }

       function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                     $('#<%=oldSignature.ClientID%>').hide();
                    $('#<%=newSignature.ClientID%>').show();
                    $('#<%=newSignature.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(200);
                };
                reader.readAsDataURL(input.files[0]);
                }
       }

       </script>

</asp:Content>

