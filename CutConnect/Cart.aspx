<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">
        <div class="list-group">

        <asp:Panel ID="CartItemsPanel" runat="server">
        </asp:Panel>
            <div class="list-group-item w-75 m-auto mt-5" >
                <div class="align-items-center d-flex">
                    <p class="me-auto h3 ">Total</p>
                    <p class="h4 ms-auto text-success opacity-75" id="TotalCartPrice" visible="false" runat="server"></p><p>Rs</p>
                </div>
  
            </div>

        </div>
        <div class="d-flex">
        <asp:Button CssClass="btn btn-dark me-auto mt-5"  ID="BookServicesBtn" Text="Book these now" OnClick="BookServicesBtn_Click" runat="server" />
        <asp:Button CssClass="btn btn-danger me-auto mt-5 " Visible="false" ID="CloseBookServicesBtn" Text="X" OnClick="CloseBookServicesBtn_Click" runat="server" />
        </div>
        <div class="container d-flex m-auto">

        <asp:Panel ID="BookingFormPanel" Visible="false" runat="server">

                            <h2>Fill the Details</h2>
                            <p class="card-text">
                                Appointment Date and Time :
                                <input ID="appointmentdatetime"  type="datetime-local" runat="server"  required/>
                            </p>
                            
                            
                            <asp:Button CssClass="btn btn-success " ID="ConfirmBookingBtn" Text="Confirm Booking" OnClick="ConfirmBookingBtn_Click" runat="server" />
                        

        </asp:Panel>
                        </div>

</div>
</asp:Content>

