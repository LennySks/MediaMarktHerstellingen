<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HerstellingWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <header>
        <div id="demo" class="carousel slide" data-ride="carousel">

            <!-- Indicators -->
            <ul class="carousel-indicators">
                <li data-target="#demo" data-slide-to="0" class="active"></li>
                <li data-target="#demo" data-slide-to="1"></li>
                <li data-target="#demo" data-slide-to="2"></li>
            </ul>

            <!-- The slideshow -->
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="./img/Img/MM1.PNG"style="height: 980px; width: 100%;"/>
                </div>
                <div class="carousel-item">
                    <img src="./img/Img/Capture.PNG" style="height: 980px; width: 100%;"/>
                </div>
                <div class="carousel-item">
                    <img src="./img/Img/capture3.PNG"style="height: 980px; width: 100%;"/>
                </div>
            </div>

            <!-- Left and right controls -->
            <a class="carousel-control-prev" href="#demo" data-slide="prev">
                <span class="carousel-control-prev-icon"></span>
            </a>
            <a class="carousel-control-next" href="#demo" data-slide="next">
                <span class="carousel-control-next-icon"></span>
            </a>

        </div>
    </header>

    <!-- Page Content -->
    <div class="container">
        <div class="Welkom" id="welkom">
            <br/><br/>
            <h1 class="my-4">Welkom bij Media Markt </h1>
            <!-- Features Section -->
            <div class="row">
                <div class="container">
                    <p>Wij zijn een zeer populair elektronicawinkel verspreid in heel Europa!<br/> Momenteel zitten we in meer dan 14 landen.<br/> Klik <a href="https://www.mediamarkt.be/nl/marketselection.html">hier</a> om het dichtstbijzijnde Media Markt winkel te vinden.</p>
                    <p>Wij verkopen onder andere; </p>
                    <ul>
                        <li>Bruingoed</li>
                        <li>Witgoed</li>
                        <li>Computer & Multimedia</li>
                        <li>Televisie & Audio</li>
                        <li>En veel meer!</li>
                    </ul>
                    <p>Bekijk onze <a href="https://www.mediamarkt.be/nl/marketselection.html">website</a> om je lievelingsartikel te vinden en deze aan te schaffen!</p>
                    
                    <img src="img/Img/Mmlocation.png" alt="MediaMarkt Location" style ="border-radius: 20%; width: 500px; margin-top: -350px; margin-left: 60%;"/>
                </div>
            </div>
        </div>
        
        <div class="About" id="about">
            <h1 class="my-4"> Over Mij </h1>
            <p style="text-align: center;">
                Ik ben David Pietrzak en ik ben 18 jaar oud. Ik studeer dit jaar af in de richting Informaticabeheer de Secundaire Handelsschool Sint-Lodewijk. 
                <br/>
                Voor mijn eindproject moest ik een web-applicatie maken dat bedoeld is om klanten met hun toestellingen toe te voegen en daarmee een herstellingen kunnen aanmaken. 
                <br/><br/><br/>
                Om deze web-applicatie te gebruiken, hoeft u zich alleen in te loggen door de blauwe knop "Login" rechtsboven te drukken.
            </p>

            <br/><br/><br/><br/><br/><br/>
            <div class="text-center">
            <img src="img/Img/David.png" alt="Avatar" style="border-radius: 50%; width: 200px; margin-top: -100px;  border: 5px solid black;"/>
            </div>

        </div>
        <!-- /.row -->

        <hr>

        <!-- Call to Action Section -->
    </div>
</asp:Content>