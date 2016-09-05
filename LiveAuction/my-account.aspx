<%@ Page Language="C#" MasterPageFile="~/Bidder.Master" AutoEventWireup="true" CodeBehind="my-account.aspx.cs"
    Inherits="LiveAuction.my_account1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                            <div class="form-group">
                              <label for="creat-ac-lb" class="col-sm-2 control-label">Name</label>
                              <div class="col-sm-6">
                                <input type="text" class="form-control" id="creat-ac-lb" placeholder="Name">
                              </div>
                              <p class="col-sm-3 account-frm-p">You can change your name within 10 days of creating 
your account</p>
                            </div>
                            <div class="form-group">
                              <label for="creat-ac-lb" class="col-sm-2 control-label">Email</label>
                              <div class="col-sm-6">
                                <input type="email" class="form-control" id="creat-ac-lb" placeholder="Email">
                              </div>
                            </div>
                            <div class="form-group">
                              <label for="creat-ac-lb" class="col-sm-2 control-label">Phone</label>
                              <div class="col-sm-6">
                                <input type="email" class="form-control" id="creat-ac-lb" placeholder="phone">
                              </div>
                              <p class="col-sm-3 account-frm-p">Your phone # only used when you opt-in to receiving SMS reminders about items you are interested in bidding on.</p>
                            </div>
                            <div class="form-group">
                              <label for="creat-ac-lb" class="col-sm-2 control-label">Country</label>
                              <div class="col-sm-6 special-caret">
                                <input type="text" class="form-control" id="creat-ac-lb" placeholder="Country">
                                <div class="special-caret-item">
                                  <span class="caret"></span>
                                </div>
                              </div>
                            </div>
                            <div class="form-group">
                              <label for="creat-ac-lb" class="col-sm-2 control-label">Time Zone</label>
                              <div class="col-sm-6 special-caret">
                                <input type="text" class="form-control" id="creat-ac-lb" placeholder="time">
                                <div class="special-caret-item">
                                  <span class="caret"></span>
                                </div>
                              </div>
                            </div>
                            <div class="form-group">
                              <div class="col-sm-offset-2 col-sm-10">
                                <button type="submit" class="btn btn-default btn-danger btn-account-submit">Update</button>
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
                              <div class="form-group m-card-fm-group">
                                <label class="sr-only" for="Inputcrdnumbr">card number</label>
                                <input type="text" class="form-control" id="Inputcrdnumbr" placeholder="Enter Card Number">
                              </div>
                              <div class="form-group">
                                  <div class="form-inline">
                                      <div class="form-group">
                                          <label class="" for="Inputcrdnumbr">MM</label><br>
                                          <input type="text" class="form-control" placeholder="MM"/>
                                      </div>
                                      <div class="form-group">
                                          <label class="" for="Inputcrdnumbr">YY</label><br>
                                          <input type="text" class="form-control" placeholder="YY"/>
                                      </div>
                                      <div class="form-group">
                                          <label class="" for="Inputcrdnumbr">CCV</label><br>
                                          <input type="text" class="form-control" placeholder="CCV"/>
                                      </div>
                                      <div class="form-group">
                                          <div class="card-pic">
                                            <img src="images/cr-card2.png" alt="this is for cr-card">
                                          </div>
                                      </div>
                                  </div>
                            </div>
                              <div class="form-group m-card-fm-group">
                                <label class="sr-only" for="Inputcdholdernm">Name On The Card</label>
                                <input type="text" class="form-control" id="Inputcdholdernm" placeholder="Name On The Card">
                              </div>
                              <div class="checkbox">
                                <label>
                                  <input type="checkbox"> Save detail for fast payment <a href="#">learn how?</a>
                                </label>
                              </div>
                              <div class="card-btn">
                                <button type="submit" class="btn btn-danger btn-crd-ss">Cancel</button>
                                <button type="submit" class="btn btn-warning btn-crd-ss">Pay now</button>
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
                              <div class="form-group">
                                <label for="address1" class="col-sm-2 control-label">Address Line 1</label>
                                <div class="col-sm-6">
                                  <input type="email" class="form-control" id="address1" placeholder="address line 1">
                                </div>
                              </div>
                              <div class="form-group">
                                <label for="address2" class="col-sm-2 control-label">Address Line 2</label>
                                <div class="col-sm-6">
                                  <input type="email" class="form-control" id="address2" placeholder="address line 2">
                                </div>
                              </div>
                              <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                  <button type="submit" class="btn btn-danger">Submit Address</button>
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
                              <div class="form-group">
                                <label for="inputPassword1" class="col-sm-2 control-label">Old Password</label>
                                <div class="col-sm-6">
                                  <input type="password" class="form-control" id="inputPassword1" placeholder="Password">
                                </div>
                              </div>
                              <div class="form-group">
                                <label for="inputnewPassword" class="col-sm-2 control-label">New Password</label>
                                <div class="col-sm-6">
                                  <input type="password" class="form-control" id="inputnewPassword" placeholder="Password">
                                </div>
                              </div>
                              <div class="form-group">
                                <label for="confirmnewpass" class="col-sm-2 control-label">Confirm Password</label>
                                <div class="col-sm-6">
                                  <input type="password" class="form-control" id="confirmnewpass" placeholder="Password">
                                </div>
                              </div>
                              <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                  <button type="submit" class="btn btn-danger">Change Password</button>
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
