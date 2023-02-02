<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Home</title>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet">
  <style>
    body {
      background-size: cover;
      background-repeat: no-repeat;
      font-family: 'Open Sans', sans-serif;
    }
    .header {
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;
      height: 100vh;
      text-align: center;
    }
    h1 {
      font-size: 3rem;
      color: white;
      text-shadow: 1px 1px black;
      margin-bottom: 1rem;
    }
    p {
      font-size: 1.2rem;
      color: white;
      text-shadow: 1px 1px black;
      margin-bottom: 3rem;
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="header bg-dark">
    <h1>Find Your Perfect Barber</h1>
    <p>Discover top-rated barbers in your area</p>
    <div class="d-flex justify-content-center ">
      <a href="BarberDashboard.aspx" class="btn btn-primary mx-3">Are you a Barber?</a>
      <a href="CustomerDashboard.aspx" class="btn btn-primary mx-3">Are you a Customer?</a>
    </div>
  </div>
</asp:Content>

