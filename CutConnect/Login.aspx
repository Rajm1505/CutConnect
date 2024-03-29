﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div>
        <section class="vh-100" style="background-color: #eee;">
            <div class="container h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-lg-12 col-xl-11">
                        <div class="card text-black" style="border-radius: 25px;">
                            <div class="card-body p-md-5">
                                <div class="row justify-content-center">
                                    <div class="col-md-10 col-lg-6 col-xl-5 order-2 order-lg-1">

                                        <p class="text-center h1 fw-bold mb-3 mx-1 mx-md-4 mt-4">Login</p>
                                                                                        <asp:Label CssClass="text-danger mb-5 mt-0 ms-5"  ID="faillabel" runat="server" Text=""></asp:Label>

                                        <div class="mx-1 mx-md-4">



                                            <div class="d-flex flex-row align-items-center mb-4 mt-3">
                                                <i class="fas fa-envelope fa-lg me-3 fa-fw"></i>
                                                <div class="form-outline flex-fill mb-0">
                                                    <input type="email" id="email" class="form-control" value="raj@gmail.com" runat="server" required/>
                                                    <label class="form-label" for="email">Your Email</label>
                                                    
                                                </div>
                                                
                                            </div>


                                            <div class="d-flex flex-row align-items-center mb-4">
                                                <i class="fas fa-lock fa-lg me-3 fa-fw"></i>
                                                <div class="form-outline flex-fill mb-0">
                                                    <input type="password" id="password" value="raj123" class="form-control" runat="server" required/>
                                                    <label class="form-label" for="password"  runat="server">Password</label>
                                                </div>
                                            </div>




                                            <div class="form-check d-flex justify-content-center mb-5">
                                                <label class="form-check-label" for="form2Example3">
                                                    Not a member?<a href="#">Register</a>
                                                </label>
                                            </div>

                                            <div class="d-flex justify-content-center mx-4 mb-3 mb-lg-4">
                                                
                                                <asp:Button  class="btn btn-dark btn-lg" id="btn_login" runat="server" onclick="Btn_Login_Click" Text="Login"></asp:Button>
                                            </div>

                                        </div>

                                    </div>
                                    <div class=" col-xl-7 d-flex align-items-center order-1 order-lg-2 pe-0 me-0">

                                        <img src="https://previews.123rf.com/images/farhad73/farhad731908/farhad73190800053/128902354-barber-shop-poster-banner-template-with-hipster-face-vector-illustration.jpg"
                                            class="img-fluid ms-5" width="400" height="300" alt="Sample image">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

