<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShopDetails.aspx.cs" Inherits="ShopDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .card-text {
            font-size: 1.2rem;
            font-weight: bold;
            color: gray;
            margin-bottom: 0.5rem;
        }

            .card-text span {
                font-weight: normal;
                color: black;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="EditShopSM" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UP" runat="server">
        <ContentTemplate>
            <div class="container mt-5">
                <h2 class="text-center">Barber Shop Details</h2>
                <div class="card mb-3 w-50 m-auto">
                    <div class="card-body">
                        <asp:Panel ID="ShopDetailsPanel" Visible="true" runat="server">
                            <h5 class="card-title" id="nameinfo" runat="server">Shop Name</h5>
                            <p class="card-text">Email: <span id="emailinfo" runat="server">email@example.com</span></p>
                            <p class="card-text">Address: <span id="addressinfo" runat="server">email@example.com</span></p>
                            <p class="card-text">Phone: <span id="phoneinfo" runat="server">123-456-7890</span></p>
                            <p class="card-text">City State: <span id="citystateinfo" runat="server">City, State</span></p>
                            <p class="card-text">Country: <span id="countryinfo" runat="server">Country</span></p>
                            <p class="card-text">Pincode: <span id="pincodeinfo" runat="server">123456</span></p>
                            <p class="card-text">Time Open: <span id="opentimeinfo" runat="server">9:00 AM - 5:00 PM</span></p>
                            <p class="card-text">Created At: <span id="createdatinfo" runat="server">01/01/2023</span></p>
                            <div class="d-flex">
                                <div class="m-auto ">
                                    <asp:Button CssClass="btn btn-dark " ID="AddServicePanelToggleOn" Text="Add Services" OnClick="AddServicePanelToggleOn_Click" runat="server" />
                                    <asp:Button CssClass="btn btn-info " ID="EditShop" Text="Edit Shop" OnClick="EditShop_Click" runat="server" />
                                    <asp:Button CssClass="btn btn-danger " ID="DeleteShop" Text="Delete Shop" OnClick="DeleteShop_Click" runat="server" />
                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="EditShopDetailsPanel" Visible="false" runat="server">
                            <h2>Fill the Details</h2>
                            <p class="card-text">
                                Shop Name :
                                <asp:TextBox ID="name" runat="server" placeholder="Enter Shop Name" />
                            </p>
                            <p class="card-text">
                                Address :
                                <asp:TextBox ID="address" runat="server" placeholder="Enter Shop Address" />
                            </p>
                            <p class="card-text">
                                Email:
                                <asp:TextBox ID="email" runat="server" placeholder="Enter Email" />
                            </p>
                            <p class="card-text">
                                Phone:
                                <asp:TextBox ID="phone" runat="server" placeholder="Enter Phone Number" />
                            </p>
                            <p class="card-text">
                                City State:
                                <asp:TextBox ID="city" runat="server" placeholder="Enter City" />
                                <asp:TextBox ID="state" runat="server" placeholder="Enter State" />
                            </p>
                            <p class="card-text">
                                Country:
                                <asp:TextBox ID="country" runat="server" placeholder="Enter Country" />
                            </p>
                            <p class="card-text">
                                Pincode:
                                <asp:TextBox ID="pincode" runat="server" placeholder="Enter Pincode" />
                            </p>
                            <p class="card-text">
                                Time Open:
                                <asp:TextBox ID="open_time" runat="server" placeholder="Enter Time Open" />
                            </p>

                            <asp:Button CssClass="btn btn-success " ID="SaveShop" Text="Save" OnClick="SaveShop_Click" runat="server" />
                        </asp:Panel>

                        <asp:Panel ID="AddServicesPanel" Visible="false" runat="server">
                            <h2 class="mt-3">Add a Service</h2>
                            <p class="card-text">
                                Service :
                                <asp:TextBox ID="servicename" runat="server" placeholder="Example - Haircut" />
                            </p>
                            <p class="card-text">
                                Price :
                                <asp:TextBox ID="price" runat="server" placeholder="Eg - 60" />
                            </p>
                            <asp:Button CssClass="btn btn-success " ID="AddServiceButton" Text="Add" OnClick="AddServiceButton_Click" runat="server" />

                        </asp:Panel>
                    </div>

                </div>
                <div class="container w-75 mt-3">
                    <h2 class="text-center">Services</h2>
                    <div class="list-group mb-5">

                    <asp:Panel ID="ServicesPanel" runat="server">
                    </asp:Panel>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

