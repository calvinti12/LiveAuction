<%@ Page Language="C#" MasterPageFile="~/Bidder.Master" AutoEventWireup="true" CodeBehind="payment-service.aspx.cs" Inherits="LiveAuction.payment_service" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/PaymentService.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="creat-account-sec payment-section">
        <div class="container">
            <div class="row">
              <div class="col-md-12">
              <div class="cr-accnt">
                <div class="col-md-12">
                    <div class="account-creat-title">
                        <h2>Create your auction account</h2>
                    </div>
                </div>
                <div class="col-md-12">
                  <div class="payment-tab">
                    <div class="bs-example bs-example-tabs" data-example-id="togglable-tabs">
                      <div class="row">
                        <div class="col-md-4">
                          <ul class="nav nav-pills nav-stacked list-unstyled" id="myTabs" role="tablist">
                            <li role="presentation" class="active"><a href="#craditCard" id="home-tab" role="tab" data-toggle="tab" aria-controls="craditCard" aria-expanded="false">Cradit Card</a></li>
                            <li role="presentation" class=""><a href="#netBanking" role="tab" id="netBanking-tab" data-toggle="tab" aria-controls="netBanking" aria-expanded="true">Net Banking</a></li>
                            <li role="presentation" class=""><a href="#dabitCard" role="tab" id="dabitCard-tab" data-toggle="tab" aria-controls="dabitCard" aria-expanded="false">Dabit Card</a></li>
                          </ul>
                        </div>
                        <div class="col-md-8">
                          <div class="tab-content" id="myTabContent">
                            <div class="tab-pane fade active in" role="tabpanel" id="craditCard" aria-labelledby="craditCard-tab">
                              <div class="craditCard-sec">
                                 <div class="form-group">
                                    <div class="col-sm-9">
                                      <p class="sq-pyinfo"><b>Secure Payment Info</b></p>
                                    </div>
                                  </div>
                                  <div class="form-group">
                                    <div class="col-sm-9">
                                      <div class="radio-line">
                                        <img src="images/accept-card-pay.png" alt="this for all dabit card" class="img-responsive">
                                      </div>
                                    </div>
                                  </div>
                                  <div class="form-group">
                                    <div class="col-sm-9">
                                      <p class="text-success">Name (as its appear on the card)</p>
                                      <input type="text" class="form-control fullName " value="456- 2589-333" disabled>
                                    </div>
                                  </div>
                                  <div class="form-group">
                                    <div class="col-sm-9">
                                      <p class="text-success">Card No (no dashes or spaces)</p>
                                      <input type="text" class="form-control cardNo" value="20135987436" disabled>
                                    </div>
                                  </div>
                                  <div class="form-group clearfix">
                                    <div class="col-sm-9">
                                      <p class="text-success">Expiration Date</p>
                                      <div class="row">
                                        <div class="col-sm-6">
                                          <input type="text" class="form-control month" placeholder="start date" value="04-16" disabled>
                                        </div>
                                        <div class="col-sm-6">
                                          <input type="text" class="form-control year" placeholder="end date" value="04-18" disabled>
                                        </div>
                                      </div>
                                    </div>
                                  </div>
                                  <div class="form-group clearfix">
                                    <div class="col-sm-3">
                                      <p class="text-success">Security Code(cvv)</p>
                                      <input type="text" class="form-control securityCode">
                                    </div>
                                  </div>
                                  <div class="form-group">
                                    <div class="col-sm-8">
                                      <button type="submit" class="btn btn-primary makePayment">Submit</button>
                                    </div>
                                  </div>
                              </div>
                            </div>
                            <div class="tab-pane fade" role="tabpanel" id="netBanking" aria-labelledby="netBanking-tab">
                              <div class="netbanking-sec">
                                <div class="form-gorup">
                                  <select class="form-control">
                                    <option>HSBC</option>
                                    <option>Royal Bank of Scotland Group</option>
                                    <option>Lloyds Banking Group</option>
                                    <option>Barclays</option>
                                    <option>Standard Chartered</option>
                                  </select>
                                </div>
                              </div>
                            </div>
                            <div class="tab-pane fade" role="tabpanel" id="dabitCard" aria-labelledby="dabitCard-tab">
                              <div class="craditCard-sec">
                                 <div class="form-group">
                                    <div class="col-sm-9">
                                      <p class="sq-pyinfo"><b>Secure Payment Info</b></p>
                                    </div>
                                  </div>
                                  <div class="form-group">
                                    <div class="col-sm-9">
                                      <div class="radio-line">
                                        <img src="images/accept-card-pay.png" alt="this for all dabit card" class="img-responsive">
                                      </div>
                                    </div>
                                  </div>
                                  <div class="form-group">
                                    <div class="col-sm-9">
                                      <p class="text-success">Name (as its appear on the card)</p>
                                      <input type="text" class="form-control" value="456- 2589-333" disabled>
                                    </div>
                                  </div>
                                  <div class="form-group">
                                    <div class="col-sm-9">
                                      <p class="text-success">Card No (no dashes or spaces)</p>
                                      <input type="text" class="form-control" value="20135987436" disabled>
                                    </div>
                                  </div>
                                  <div class="form-group clearfix">
                                    <div class="col-sm-9">
                                      <p class="text-success">Expiration Date</p>
                                      <div class="row">
                                        <div class="col-sm-6">
                                          <input type="text" class="form-control" placeholder="start date" value="04-16" disabled>
                                        </div>
                                        <div class="col-sm-6">
                                          <input type="text" class="form-control" placeholder="end date" value="04-18" disabled>
                                        </div>
                                      </div>
                                    </div>
                                  </div>
                                  <div class="form-group clearfix">
                                    <div class="col-sm-3">
                                      <p class="text-success">Security Code(cvv)</p>
                                      <input type="text" class="form-control">
                                    </div>
                                  </div>
                                  <div class="form-group">
                                    <div class="col-sm-8">
                                      <button type="submit" class="btn btn-primary">Submit</button>
                                    </div>
                                  </div>
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>

                    </div><!-- end of tab content -->
                  </div> <!-- end of payment tab -->



                </div>
              </div>
              </div>
            </div>
        </div>
    </section>
</asp:Content>
