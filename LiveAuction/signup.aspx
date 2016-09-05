<%@ Page Language="C#" MasterPageFile="~/Bidder.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs"
    Inherits="LiveAuction.signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function validate() {
            if (RequiredTxt('ContentPlaceHolder1_txtEmail', 'Email is required')) {
                return false;
            }
            if (ValEMail('ContentPlaceHolder1_txtEmail', 'Invalid  Email')) {
                return false;
            }
            if (RequiredTxt('ContentPlaceHolder1_txtPassword', 'Password is required')) {
                return false;
            }
            if (RequiredMatch('ContentPlaceHolder1_txtPassword', 'ContentPlaceHolder1_txtCnfPassword', 'Password mismatch')) {
                return false;
            }
            return true;
            if (RequiredTxt('firstName', 'First name is required')) {
                return false;
            }
        }
    </script>
    <script language="javascript" type="text/javascript">
        function trG(str) {
            jAlert('<b style="color:green;font-size:1.0em;">' + str + '</b>');
        }

        function trR(str) {
            jAlert('<b style="color:red;font-size:1.0em;">' + str + '</b>');
        }
    </script>
    <link type="text/css" rel="stylesheet" href="css/normalize.css" />
    <link type="text/css" rel="stylesheet" href="css/main.css" />
    <link type="text/css" rel="stylesheet" href="css/jquery.steps.css" />
    <!--<script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>-->
    <script src="js/signup.js" type="text/javascript"></script>
    <script src="js/modernizr-2.6.2.min.js" type="text/javascript"></script>
    <script src="js/jquery.cookie-1.3.1.js" type="text/javascript"></script>
    <script src="js/jquery.steps.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-datepicker-calendar
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- this is the breadcumbs area -->
    <section class="breadcumbs-area-sec">
			<div class="container">
				<div class="row">
					<div class="col-md-12">
						<div class="breadcumb">
							<a href="#" class="incative">Home &raquo; </a><a href="#" class="incative">Live Auctions &raquo; </a><span class="current-page">Registration</span></div>
					</div>
				</div>
			</div>
	</section>
    <!-- end of breadcumbs area -->
    <section class="creat-account-sec">
			<div class="container">
				<div class="row">
					<div class="col-md-12">
						<div class="cr-accnt">
							<div class="col-md-12">
								<div class="account-creat-title">
									<h2>Create your auction account</h2>
								</div>
		<!--===============  steps div ==================== -->
            <%--<div class="bs-wizard clearfix"> 
                
                <div class="col-xs-3 bs-wizard-step complete">
                  <div class="text-center bs-wizard-stepnum">Step 1</div>
                  <div class="progress"><div class="progress-bar"></div></div>
                  <a href="#" class="bs-wizard-dot"></a>
                  <div class="bs-wizard-info text-center">
                    <div class="form-horizontal crt-acnt-frm">
                        
                    </div>
                  </div>
                </div>
                
                <div class="col-xs-3 bs-wizard-step complete"><!-- complete -->
                  <div class="text-center bs-wizard-stepnum">Step 2</div>
                  <div class="progress"><div class="progress-bar"></div></div>
                  <a href="#" class="bs-wizard-dot"></a>
                  <div class="bs-wizard-info text-center">Card Info</div>
                </div>
                
                <div class="col-xs-3 bs-wizard-step active"><!-- complete -->
                  <div class="text-center bs-wizard-stepnum">Step 3</div>
                  <div class="progress"><div class="progress-bar"></div></div>
                  <a href="#" class="bs-wizard-dot"></a>
                  <div class="bs-wizard-info text-center">Info3</div>
                </div>
                
                <div class="col-xs-3 bs-wizard-step disabled"><!-- active -->
                  <div class="text-center bs-wizard-stepnum">Step 4</div>
                  <div class="progress"><div class="progress-bar"></div></div>
                  <a href="#" class="bs-wizard-dot"></a>
                  <div class="bs-wizard-info text-center"> Confirm</div>
                </div>
            </div>--%>
	    <!--===============  steps div ==================== -->
							</div>
							<div class="col-md-8">
								<div class="form-horizontal crt-acnt-frm">
									<div class="form-group">
										<label for="creat-ac-lb" class="col-sm-3 control-label">Email</label>
										<div class="col-sm-9">
											<%--<input type="email" class="form-control" id="creat-ac-lb" placeholder="Email">--%>
												<asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
										</div>
									</div>
									<div class="form-group">
										<label for="creat-pswrd-lb" class="col-sm-3 control-label">Password</label>
										<div class="col-sm-9">
											<%--<input type="password" class="form-control" id="creat-pswrd-lb" placeholder="Password">--%>
												<asp:TextBox ID="txtPassword" runat="server" class="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
										</div>
									</div>
									<div class="form-group">
										<label for="creat-pswrd-lb-re" class="col-sm-3 control-label">Confirm password</label>
										<div class="col-sm-9">
											<%--<input type="password" class="form-control" id="creat-pswrd-lb-re" placeholder="Password">--%>
												<asp:TextBox ID="txtCnfPassword" runat="server" class="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
										</div>
									</div>
									<%--<div class="form-group">
                        <label for="creat-pswrd-lb-re" class="col-sm-3 control-label">User Type</label>
                        <div class="col-sm-9" style="padding: 5px 0 0 15px;">
                         <asp:RadioButtonList ID="rdbtnlistUserType" runat="server" RepeatDirection="Horizontal"
                                    Font-Bold="false">
                                    <asp:ListItem Text="Bidder" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Seller" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                        </div>
                      </div>--%>
				<div class="form-group">
					<label for="kk" class="col-sm-3"></label>
					<div class="form-group">
						<label for="" class="col-sm-3"></label>
					</div>
				</div>

				<!-- personal details sections -->
				<div class="form-group">
					<div class="col-sm-9">
						<p class="text-success">Title</p>
						<select class="form-control">
                          <option>Mr</option>
                          <option>Mrs</option>
                          <option>Ms</option>
                        </select>
					</div>
				</div>
				<div class="form-group">
					<label for="" class="col-sm-3"></label>
					<div class="col-sm-9">
						<p class="text-success">First Name</p>
						<asp:TextBox ID="firstName" runat="server" class="form-control" placeholder="First Name" required="required"></asp:TextBox>
					</div>
				</div>
				<div class="form-group">
					<label for="" class="col-sm-3"></label>
					<div class="col-sm-9">
						<p class="text-success">Last Name</p>
						<asp:TextBox ID="lastName" runat="server" class="form-control" placeholder="Last Name" required="required"></asp:TextBox>
					</div>
				</div>
				<div class="form-group">
					<label for="" class="col-sm-3"></label>
					<div class="col-sm-9">
						<p class="text-success">Address1</p>
						<asp:TextBox ID="address1" runat="server" class="form-control" placeholder="Address 1" required="required"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Address required" ForeColor="Red" ControlToValidate="address1" ValidationGroup="signup" EnableClientScript="true"></asp:RequiredFieldValidator>
					</div>
				</div>
			<%--<div class="form-group">
                <label for="" class="col-sm-3"></label>
                <div class="col-sm-9">
                    <p class="text-success">Address2</p>
                    <input type="text" class="form-control">
                </div>
                </div>--%>
				<div class="form-group">
					<label for="" class="col-sm-3"></label>
					<div class="col-sm-9">
						<p class="text-success">Town/City</p>
						<asp:TextBox ID="town" runat="server" class="form-control" placeholder="Town/City" required="required"></asp:TextBox>
					</div>
				</div>
				<div class="form-group">
					<label for="" class="col-sm-3"></label>
					<div class="col-sm-9">
						<p class="text-success">Postcode</p>
						<asp:TextBox ID="postcode" runat="server" class="form-control" placeholder="Postcode" required="required"></asp:TextBox>
					</div>
				</div>
				<div class="form-group">
					<label for="" class="col-sm-3"></label>
					<div class="col-sm-9">
						<p class="text-success">Telephone</p>
						<asp:TextBox ID="telephone" runat="server" class="form-control" placeholder="Telephone" required="required"></asp:TextBox>
					</div>
				</div>
				<!-- this is for payment getway -->
				<div class="form-group">
					<label for="kk" class="col-sm-3"></label>
					<div class="col-sm-9">
						<p class="sq-pyinfo"><b>Secure Payment Info</b></p>
					</div>
				</div>
				<div class="form-group">
					<label for="kk" class="col-sm-3"></label>
					<div class="col-sm-9">
						<div class="radio-line">
							<!-- <label class="radio-inline">
                                <input type="radio" name="inlineRadioOptions" id="inlineRadio1" value="option1">
                            </label>
                            <label class="radio-inline">
                                <input type="radio" name="inlineRadioOptions" id="inlineRadio2" value="option2"><img src="images/accept-card-pay.png" alt="this for all dabit card" class="img-responsive">
                            </label> -->
							<img src="images/accept-card-pay.png" alt="this for all dabit card" class="img-responsive">
						</div>
					</div>
				</div>
				<div class="form-group">
					<label for="" class="col-sm-3"></label>
					<div class="col-sm-9">
						<p class="text-success">Name (as its appear on the card)</p>
						<asp:TextBox ID="cardHolderName" runat="server" class="form-control" placeholder="Name" required="required"></asp:TextBox>
					</div>
				</div>
				<div class="form-group">
					<label for="" class="col-sm-3"></label>
					<div class="col-sm-9">
						<p class="text-success">Card No (no dashes or spaces)</p>
						<asp:TextBox ID="cardNo" runat="server" class="form-control" placeholder="Card no" required="required"></asp:TextBox>
					</div>
				</div>
				<div class="form-group">
					<label for="" class="col-sm-3"></label>
					<div class="col-sm-9">
						<p class="text-success">Starting Date</p>
						<div class="row">
							<div class="col-sm-5">
								<asp:TextBox ID="startingMonth" runat="server" class="form-control" placeholder="MM" required="required"></asp:TextBox>
							</div>
							<div class="col-sm-5">
								<asp:TextBox ID="startingYear" runat="server" class="form-control" placeholder="YYYY" required="required"></asp:TextBox>
							</div>
							<div class="col-sm-2">
								<img src="images/calendar-128.png" style="width:53%" class="StartDatePicker" />
							</div>
						</div>
					</div>
				</div>
				<div class="form-group">
					<label for="" class="col-sm-3"></label>
					<div class="col-sm-9">
						<p class="text-success">Expiration Date</p>
						<div class="row">
							<div class="col-sm-5">
								<asp:TextBox ID="ExpMonth" runat="server" class="form-control" placeholder="MM" required="required"></asp:TextBox>
							</div>
							<div class="col-sm-5">
								<asp:TextBox ID="ExpYear" runat="server" class="form-control" placeholder="YYYY" required="required"></asp:TextBox>
							</div>
							<div class="col-sm-2">
								<img src="images/calendar-128.png" style="width:53%" class="ExpDatePicker" />
							</div>
						</div>
					</div>
				</div>
				<div class="form-group">
					<label for="" class="col-sm-3"></label>
					<div class="col-sm-3">
						<p class="text-success">Security Code(cvv)</p>
						<asp:TextBox ID="cvv" runat="server" class="form-control" placeholder="CVV Code" required="required"></asp:TextBox>
					</div>
				</div>
				<div class="form-group">
					<div class="col-sm-offset-3 col-sm-9">
						<div class="check-top-para">Tell us what you are interested in and will tailor our emails to you</div>
					</div>
				</div>
				<div class="form-group">
					<div class="col-sm-offset-3 col-sm-9">
						<div class="checkbox crt-ac-ck">
							<label>
    <input type="checkbox" id="chkAgree" runat="server"> I have read and agree to  Unified <a href="#">User Agreement</a> and <a href="#">Privacy Policy</a>. 
</label>
						</div>
					</div>
				</div>
				<div class="form-group">
					<div class="col-sm-offset-3 col-sm-9">
						<asp:Button runat="server" ID="btnCreateAcc" class="btn btn-default btn-danger" Text="Create my account now" OnClientClick="return validate();" OnClick="btnCreateAcc_Click" />
						<%--<button type="submit" class="btn btn-default btn-danger" >Create my account now</button>--%>
					</div>
				</div>
								</div>
							</div>
							<div class="col-md-4">
								<div class="why-creat-sec">
									<div class="why-ct-icon pull-left">
										<p class="text-center">?</p>
									</div>
									<div class="why-ct-txt">
										This gets you access to features like auction alarts and adding items to your watch list
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
<%--</div>--%>
	</section>
</asp:Content>
