<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BarberDashboard.aspx.cs" Inherits="BarberDashboard" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1 class="text-center mt-5 ">BarberDashboard</h1>

    <div class="container">
        <div class="m-auto w-75">

        <asp:Button visible="true" CssClass="btn btn-success mb-3" id="AddShopPanelToggleOn" runat="server" OnClick="AddShopPanelToggleOn_Click" Text="Add new Shop" />
        </div>
         
        <asp:Panel ID="addNewShopPanel" runat="server">

             <div>
        <section >
            <div class="container h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-lg-12 col-xl-11">
                        <div class="card text-black" style="border-radius: 25px;">
                            <div class="card-body p-md-5">
                                <asp:Button visible="false" CssClass="btn btn-danger px-3" ID="AddShopPanelToggleOff" runat="server" OnClick="AddShopPanelToggleOff_Click" Text="X" />
                                <div class="row justify-content-center">
                                    <div class="col-md-10 col-lg-6 col-xl-5 order-2 order-lg-1">

                                        <p class="text-center h1 fw-bold mb-5 mx-1 mx-md-4 mt-4">Add New Shop</p>

                                        <div class="mx-1 mx-md-4">

                                            <div class="d-flex flex-row align-items-center mb-4">
                                                <i class="fas fa-user fa-lg me-3 fa-fw"></i>
                                                <div class="form-outline flex-fill mb-0">
                                                    <input type="text" id="name" class="form-control" runat="server" />
                                                    <label class="form-label" for="name">Shop Name</label>
                                                </div>
                                            </div>

                                            <div class="d-flex flex-row align-items-center mb-4">
                                                <i class="fas fa-envelope fa-lg me-3 fa-fw"></i>
                                                <div class="form-outline flex-fill mb-0">
                                                    <input type="email" id="email" class="form-control" runat="server" />
                                                    <label class="form-label" for="email">Shop Email</label>
                                                </div>
                                            </div>


                                            <div class="d-flex flex-row align-items-center mb-4">
                                                <i class="fas fa-phone fa-lg me-3 fa-fw"></i>
                                                <div class="form-outline flex-fill mb-0">
                                                    <input type="number" id="phone" class="form-control" runat="server" />
                                                    <label class="form-label" for="phone" runat="server">Phone Number</label>
                                                </div>
                                            </div>
                                            
                                            <div class="d-flex flex-row align-items-center mb-4">
                                                <i class="fas fa-map-pin fa-lg me-3 fa-fw"></i>
                                                <div class="form-outline flex-fill mb-0">
                                                    <textarea type="text" id="address" class="form-control" runat="server" />
                                                    <label class="form-label" for="phone" runat="server">Shop Address</label>
                                                </div>
                                            </div> 
                                            <div class="row">

                                                <div class="col">

                                            <div class="d-flex flex-row align-items-center mb-4">
                                                <i class="fas fa-city fa-lg me-3 fa-fw"></i>
                                                <div class="form-outline flex-fill mb-0">
                                                    <input type="text" id="city" class="form-control" runat="server" />
                                                    <label class="form-label" for="city" runat="server">City</label>
                                                </div>
                                            </div>
                                                </div>
                                                                                            <div class="col">

                                            <div class="d-flex flex-row align-items-center mb-4">
                                                <div class="form-outline flex-fill mb-0">
                                                    <input type="text" id="state" class="form-control" runat="server" />
                                                    <label class="form-label" for="state">State</label>
                                                </div>
                                            </div>
                                                                                                </div>

                                            </div>

                                            <div class="d-flex flex-row align-items-center mb-4">
                                                <i class="fas fa-globe fa-lg me-3 fa-fw"></i>
                                                <div class="form-outline flex-fill mb-0">
                                                    <input type="text" id="country" class="form-control" runat="server" />
                                                    <label class="form-label" for="country">Country</label>
                                                </div>
                                            </div>
                                            
                                            <div class="d-flex flex-row align-items-center mb-4">
                                                <i class="fas fa-location-pin fa-lg me-3 fa-fw"></i>
                                                <div class="form-outline flex-fill mb-0">
                                                    <input type="text" id="pincode" class="form-control" runat="server" />
                                                    <label class="form-label" for="pincode">Pincode</label>
                                                </div>
                                            </div>
                                            
                                            <div class="d-flex flex-row align-items-center mb-4">
                                                <i class="fas fa-clock fa-lg me-3 fa-fw"></i>
                                                <div class="form-outline flex-fill mb-0">
                                                    <input type="text" id="opentime" class="form-control" placeholder="eg: 10:00 AM-9:00PM" runat="server" />
                                                    <label class="form-label" for="opentime">Open Time</label>
                                                </div>
                                            </div>

                                            <div class="d-flex justify-content-center mx-4 mb-3 mb-lg-4">
                                                <asp:Button class="btn btn-dark btn-lg" ID="AddShop" runat="server" OnClick="AddShop_Click" Text="Add Shop"></asp:Button>
                                            </div>

                                       

                                    </div>
                                    
                                </div>
                            </div>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

        </asp:Panel>
       
        
        <div class="m-auto text-center">
             <h3 class="w-50 m-auto" >Currently Listed Shops</h3>
        </div>
        <div class="list-group">
      
        <asp:Panel ID="ListedShopsPanel" runat="server"></asp:Panel>
        </div>
    </div>

</asp:Content>

