<%@ Page Language="C#" MasterPageFile="~/Bidder.Master" AutoEventWireup="true" CodeBehind="my-account.aspx.cs"
    Inherits="LiveAuction.my_account1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/my-account.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- this is the breadcumbs area -->
    <section class="breadcumbs-area-sec">
         <div class="container">
             <div class="row">
                 <div class="col-md-12">
                     <div class="breadcumb">
                     <a href="#" class="incative">Home &raquo; </a><span class="current-page">My Account</span></div>
                 </div>
             </div>
         </div>
     </section>
    <!-- end of the breadcumbs area -->
    <section class="my-account-sec">
        <div class="container">
            <div class="row">
              <div class="col-md-12">
                  <div class="accrodian-section">
                    <li>
                      <h2>Account info</h2>
                      <a href="#"><i class="fa fa-angle-down" role="button" data-toggle="collapse" href="#accrodian-section1" aria-expanded="false" aria-controls="collapseExample"></i></a>
                    </li>
                    <div class="collapse in accrodian-sec-item" id="accrodian-section1">
                      <div class="row">
                        <div class="col-md-12">
                          <form class="form-horizontal crt-acnt-frm">
                          <div class="form-group clearfix no-hide">
                              <div class="col-sm-offset-2 col-sm-6">
                                <div class="alert alert-success personalInforSuccessMsg">
                                  <strong>Success!</strong> Personal info updated successfully!
                                </div>
                              </div>
                            </div>
                            <div class="form-group clearfix">
                              <label for="creat-ac-lb" class="col-sm-2 control-label">First name</label>
                              <div class="col-sm-6">
                                <input type="text" class="form-control firstname" id="creat-ac-lb" placeholder="First name" required="required" />
                              </div>
                              <p class="col-sm-3 account-frm-p">You can change your name within 10 days of creating your account</p>
                            </div>
                            <div class="form-group clearfix">
                              <label for="creat-ac-lb" class="col-sm-2 control-label">Last name</label>
                              <div class="col-sm-6">
                                <input type="text" class="form-control lastname" id="creat-ac-lb" placeholder="Last name" required="required" />
                              </div>
                            </div>
                            <div class="form-group clearfix">
                              <label for="creat-ac-lb" class="col-sm-2 control-label">Email</label>
                              <div class="col-sm-6">
                                <input type="email" class="form-control email" id="creat-ac-lb" placeholder="Email" required="required"/>
                              </div>
                            </div>
                            <div class="form-group clearfix">
                              <label for="creat-ac-lb" class="col-sm-2 control-label">Phone</label>
                              <div class="col-sm-6">
                                <input type="text" class="form-control telephone" id="creat-ac-lb" placeholder="phone" required="required"/>
                              </div>
                              <p class="col-sm-3 account-frm-p">Your phone # only used when you opt-in to receiving SMS reminders about items you are interested in bidding on.</p>
                            </div>
                            <div class="form-group clearfix">
                              <label for="creat-ac-lb" class="col-sm-2 control-label">Country</label>
                              <div class="col-sm-6 special-caret">
                                <input type="text" class="form-control country" id="creat-ac-lb" placeholder="Country" required="required" />
                                <div class="special-caret-item">
                                  <span class="caret"></span>
                                </div>
                              </div>
                            </div>
                            <%--<div class="form-group clearfix">
                              <label for="creat-ac-lb" class="col-sm-2 control-label">Time Zone</label>
                              <div class="col-sm-6 special-caret">
                                <input type="text" class="form-control" id="creat-ac-lb" placeholder="time">
                                <div class="special-caret-item">
                                  <span class="caret"></span>
                                </div>
                              </div>
                            </div>--%>
                            <div class="form-group clearfix">
                              <div class="col-sm-offset-2 col-sm-10">
                                <button type="submit" class="btn btn-default btn-danger btn-account-submit updatePersonalInfoBtn">Update</button>
                              </div>
                            </div>
                          </form>
                        </div>
                      </div>
                    </div>
                  </div> <!-- end of accrodian part -->
                  <div class="accrodian-section">
                    <li>
                      <h2>Manage credit cards</h2>
                      <a href="#"><i class="fa fa-angle-down" role="button" data-toggle="collapse" href="#accrodian-section2" aria-expanded="false" aria-controls="collapseExample"></i></a>
                    </li>
                    <div class="collapse accrodian-sec-item" id="accrodian-section2">
                      <div class="row">
                        <div class="col-md-12">
                          <div class="cr-card-frm-sec">
                            <form class="form">
                            <div class="form-group clearfix no-hide">
                              <div class=" col-sm-12">
                                <div class="alert alert-success cardInforSuccessMsg">
                                  <strong>Success!</strong> Card info updated successfully!
                                </div>
                              </div>
                            </div>
                              <div class="form-group m-card-fm-group">
                                <label class="sr-only" for="Inputcrdnumbr">card number</label>
                                <input type="text" class="form-control cardno" id="Inputcrdnumbr" placeholder="Enter Card Number" required="required" />
                              </div>
                              <div class="form-group clearfix">
                                  <div class="form-inline">
                                      <div class="form-group clearfix">
                                          <label class="" for="Inputcrdnumbr">Starting MM</label><br>
                                          <input type="text" class="form-control strtingmonth" placeholder="Starting MM" required="required"/>
                                      </div>
                                      <div class="form-group clearfix">
                                          <label class="" for="Inputcrdnumbr">Starting YY</label><br>
                                          <input type="text" class="form-control startingyear" placeholder="Starting YY" required="required"/>
                                      </div>
                                  </div>
                                  <div class="form-inline">
                                      <div class="form-group clearfix">
                                          <label class="" for="Inputcrdnumbr">Ending MM</label><br>
                                          <input type="text" class="form-control expmonth" placeholder="Ending MM" required="required"/>
                                      </div>
                                      <div class="form-group clearfix">
                                          <label class="" for="Inputcrdnumbr">Ending YY</label><br>
                                          <input type="text" class="form-control expyear" placeholder="Ending YY" required="required"/>
                                      </div>
                                  </div>
                                  <div class="form-inline">
                                  <div class="form-group clearfix">
                                          <label class="" for="Inputcrdnumbr">CCV</label><br>
                                          <input type="text" class="form-control securitycode" placeholder="CCV" required="required"/>
                                      </div>
                                      <div class="form-group clearfix">
                                          <div class="card-pic">
                                            <img src="images/cr-card2.png" alt="this is for cr-card">
                                          </div>
                                      </div>
                                  </div>
                            </div>
                              <div class="form-group clearfix m-card-fm-group">
                                <label class="sr-only" for="Inputcdholdernm">Name On The Card</label>
                                <input type="text" class="form-control cardholdername" id="Inputcdholdernm" placeholder="Name On The Card" required="required" />
                              </div>
                              <%--<div class="checkbox">
                                <label>
                                  <input type="checkbox"> Save detail for fast payment <a href="#">learn how?</a>
                                </label>
                              </div>--%>
                              <div class="card-btn">
                                <button type="submit" class="btn btn-danger btn-crd-ss updateCardInfo">Save</button>
                                <%--<button type="submit" class="btn btn-warning btn-crd-ss">Pay now</button>--%>
                              </div>
                            </form>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div> <!-- end of accrodian part -->
                  <div class="accrodian-section">
                    <li>
                      <h2>Manage address</h2>
                      <a href="#"><i class="fa fa-angle-down" role="button" data-toggle="collapse" href="#accrodian-section3" aria-expanded="false" aria-controls="collapseExample"></i></a>
                    </li>
                    <div class="collapse accrodian-sec-item" id="accrodian-section3">
                      <div class="row">
                        <div class="col-md-12">
                          <div class="address-input-frm">
                            <form class="form-horizontal">
                            <div class="form-group clearfix no-hide">
                              <div class=" col-sm-12">
                                <div class="alert alert-success addressSuccessMsg">
                                  <strong>Success!</strong> Address updated successfully!
                                </div>
                              </div>
                            </div>
                              <div class="form-group clearfix">
                                <label for="address1" class="col-sm-2 control-label">Address Line 1</label>
                                <div class="col-sm-6">
                                  <input type="text" class="form-control address" id="address1" placeholder="address line 1" required="required" />
                                </div>
                              </div>
                              <%--<div class="form-group clearfix">
                                <label for="address2" class="col-sm-2 control-label">Address Line 2</label>
                                <div class="col-sm-6">
                                  <input type="email" class="form-control" id="address2" placeholder="address line 2">
                                </div>
                              </div>--%>
                              <div class="form-group clearfix">
                                <div class="col-sm-offset-2 col-sm-10">
                                  <button type="submit" class="btn btn-danger updateAddress">Submit Address</button>
                                </div>
                              </div>
                            </form>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div> <!-- end of accrodian part -->
                  <div class="accrodian-section">
                    <li>
                      <h2>Change password</h2>
                      <a href="#"><i class="fa fa-angle-down" role="button" data-toggle="collapse" href="#accrodian-section4" aria-expanded="false" aria-controls="collapseExample"></i></a>
                    </li>
                    <div class="collapse accrodian-sec-item" id="accrodian-section4">
                      <div class="row">
                        <div class="col-md-12">
                          <div class="change-pass-my-account">
                            <form class="form-horizontal">
                            <div class="form-group clearfix no-hide">
                              <div class=" col-sm-12">
                                <div class="alert alert-success passwordSuccessMsg">
                                  <strong>Success!</strong> Password updated successfully!
                                </div>
                              </div>
                            </div>
                              <div class="form-group clearfix">
                                <label for="inputPassword1" class="col-sm-2 control-label">Old Password</label>
                                <div class="col-sm-6">
                                  <input type="password" class="form-control oldPass" id="inputPassword1" placeholder="Password">
                                </div>
                              </div>
                              <div class="form-group clearfix">
                                <label for="inputnewPassword" class="col-sm-2 control-label">New Password</label>
                                <div class="col-sm-6">
                                  <input type="password" class="form-control newPass" id="inputnewPassword" placeholder="Password">
                                </div>
                              </div>
                              <div class="form-group clearfix">
                                <label for="confirmnewpass" class="col-sm-2 control-label">Confirm Password</label>
                                <div class="col-sm-6">
                                  <input type="password" class="form-control confirmPass" id="confirmnewpass" placeholder="Password">
                                </div>
                              </div>
                              <div class="form-group clearfix">
                                <div class="col-sm-offset-2 col-sm-10">
                                  <button type="submit" class="btn btn-danger changePass">Change Password</button>
                                </div>
                              </div>
                            </form>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div> <!-- end of accrodian part -->
                  <div class="accrodian-section">
                    <li>
                      <h2>Cancel account</h2>
                      <a href="#"><i class="fa fa-angle-down" role="button" data-toggle="collapse" href="#accrodian-section5" aria-expanded="false" aria-controls="collapseExample"></i></a>
                    </li>
                    <div class="collapse accrodian-sec-item" id="accrodian-section5">
                      <div class="row">
                        <div class="col-md-10 col-md-offset-2">
                          <button type="button" class="btn btn-danger btn-account-canel ">Cancel account</button>
                        </div>
                      </div>
                    </div>
                  </div> <!-- end of accrodian part -->
              </div><!-- end of accrodian section -->
            </div>
        </div>
    </section>
</asp:Content>
