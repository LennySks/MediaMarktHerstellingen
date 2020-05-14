<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HerstellingWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
    <main class="login-form" style="margin-left: auto; margin-right: auto; width: 50%;">
        <fieldset class="cotainer">
            <div class="row justify-content-center">
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-header">Inloggen</div>
                        <div class="card-body">
                            
                            <div class="alert alert-warning alert-dismissible" id="error" runat="server" visible="false" enableviewstate="true">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong>Warning! 
                                <asp:Literal ID="message" runat="server"></asp:Literal>
                            </strong> 
                            </div>

                            <div class="form-group row">
                                <label for="gebruikersnaam" class="col-form-label text-md-right text-center" style="text-align: right;">Gebruikersnaam</label>
                            </div>
                            <div class="text-center">
                                <input class="form-control" type="text" required="required" placeholder="Gebruikersnaam" ID="gebruikersnaam" runat="server"/>
                            </div>
                            <br/>
                            <div class="form-group row">
                                <label for="paswoord" class="col-form-label text-md-right">Paswoord</label>
                            </div>
                            <div class="text-center">
                                <input class="form-control" type="password" required="required" placeholder="Paswoord" ID="paswoord" runat="server"/>
                            </div>

                            <div class="form-group" style="margin-top: 25px">
                                <asp:Label ID="lblFoutboodschap" EnableViewState="False" runat="server"
                                           Visible="false" CssClass="alert alert-danger justify-content-center">
                                </asp:Label>

                                <div class="text-center">
                                    <asp:Button ID="btnAanmelden" runat="server" Text="Aanmelden" CssClass="btn btn-outline-primary" OnClick="btnAanmelden_Click"/>
                                    <br/><br/>
                                    <asp:Button ID="btnTerug" runat="server" Text="Terug" CssClass="btn btn-outline-danger" OnClick="btnTerug_Click"/>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </fieldset>
    </main>

    <br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
</asp:Content>