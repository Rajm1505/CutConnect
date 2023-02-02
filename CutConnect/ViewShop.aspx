<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewShop.aspx.cs" Inherits="ViewShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
                            
                        </asp:Panel>

                       </div>
                </div>
                <div class="container w-75 mt-3">
                    <h2 class="text-center">Services</h2>
                    <div class="list-group mb-5">

                    <asp:Panel ID="ServicesPanel" runat="server">
                    </asp:Panel>
                        
                    <asp:Panel ID="BookServicePanel" runat="server">

                    </asp:Panel>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

