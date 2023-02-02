<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerDashboard.aspx.cs" Inherits="CustomerDashboard1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container mt-5">


        <div class="d-block w-75 m-auto">

            <h1 class="text-center ">Customer Dashboard</h1>
            <div class="d-flex align-items-center text-light text-end p-2 rounded  mt-5 bg-secondary" style="width: auto">

                <div class="me-auto">
                    <span class="float-start my-auto" id="SelectedCity" runat="server"></span>
                </div>

                <div class="ms-auto">

                    <asp:DropDownList CssClass="align-middle" ID="CityList" runat="server" DataSourceID="SqlDataSource1" DataTextField="city" DataValueField="city">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cutconnectConnectionString %>" ProviderName="<%$ ConnectionStrings:cutconnectConnectionString.ProviderName %>" SelectCommand="select distinct city from shop"></asp:SqlDataSource>

                    
                    <asp:Button CssClass="btn btn-dark" ID="BtnFilterCity" Text="Filter City" OnClick="BtnFilterCity_Click" runat="server" />
                </div>
            </div>
        </div>

        <div class="mt-3">
            <div class="text-center">
            <asp:Label CssClass="text-light bg-danger p-1 px-3 rounded-2 h5 mt-5" ID="FailMessage" runat="server"></asp:Label>
            </div>
            <asp:Panel ID="ShopsInCityPanel" runat="server"></asp:Panel>
        </div>
    </div>
</asp:Content>

