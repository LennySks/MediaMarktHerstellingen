<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Herstelling.aspx.cs" Inherits="HerstellingWeb.Herstelling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/><br/><br/><br/><br/><br/>
    <div class="card-body" CssClass="col-sm-12" Style="margin: auto; width: 70%;">
        <div style ="margin-left: -20px;">
        <h4>Nieuwe Herstelling toevoegen</h4>
        </div>
        <div class="input-group" style="">

            <div class="input-group-prepend">
                <span class="input-group-text" style ="margin-left: -20px;">Klant</span>
                <br/>
            </div>  
            <asp:DropDownList ID="ddlKlantId" runat="server"></asp:DropDownList>

            <div class="input-group-prepend" >
                <span class="input-group-text" style="margin-left: 15px;">Toestel</span>
                <br/>
            </div>
            <asp:DropDownList ID="ddlToestelId" runat="server"></asp:DropDownList>

            <div class="input-group-prepend">
                <span class="input-group-text" style="margin-left: 15px;">Datum Binnen</span>
                <br/>
            </div>
            <input type="text" runat="server" class="form-control" id="iptDatumbinnen" placeholder="YYYY/MM/DD"/>


            <div class="input-group-prepend">
                <span class="input-group-text" style="margin-left: 15px;">Datum Klaar</span>
                <br/>
            </div>
            <input type="text" runat="server" class="form-control" id="iptDatumklaar" placeholder="YYYY/MM/DD"/>


            <div class="input-group-prepend">
                <span class="input-group-text" style="margin-left: 15px;">Kostprijs</span>
                <br/>
            </div>

            <input type="text" runat="server" class="form-control" id="iptKostprijs"/>


            <div class="input-group-append">
                <asp:LinkButton ID="btnHerstelling" style="float: left; margin-left: 20px; margin-right: -20px;" CssClass="btn btn-outline-danger" runat="server" Text="Toevoegen" OnClick="btnToevoegenHerstelling"></asp:LinkButton>
            </div>

        </div>
    </div>
    
    <div class="modal fade" id="NotificationModal" tabindex="-1" role="dialog" aria-labelledby="NotificationModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="NotificationLabel">Notification!</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Ok</button>
                </div>
            </div>
        </div>
    </div>
    <script>
        function Notify() {
            $("#NotificationModal").text();
        }
    </script>
    
    

    <div class="table table-borderless table-hover table-responsive">
        <asp:GridView ID="grvHerstellingen" runat="server" CssClass="col-sm-12" Style="margin: auto; width: 70%;" AutoGenerateColumns="False" OnRowDeleting="grvHerstellingen_RowDeleting" OnRowUpdating="grvHerstellingen_RowUpdating" OnRowEditing="grvHerstellingen_RowEditing" OnRowCancelingEdit="grvHerstellingen_RowCancelingEdit">
            <Columns>
                <asp:BoundField DataField="Klant.Naam" HeaderText="Klant" ReadOnly="True">
                    <ItemStyle Width="15%"/>
                    <HeaderStyle BackColor="#1d1d1b" ForeColor="White"/>
                </asp:BoundField>

                <asp:BoundField DataField="Toestel.Omschrijving" HeaderText="Toestel" ReadOnly="True">
                    <ItemStyle Width="20%"/>
                    <HeaderStyle BackColor="#1d1d1b" ForeColor="White"/>
                </asp:BoundField>

                <asp:BoundField DataField="DatumBinnen" HeaderText="Datum binnen" DataFormatString="{0:yyyy/MM/dd}">
                    <HeaderStyle BackColor="#1d1d1b" ForeColor="White"/>

                </asp:BoundField>

                <asp:BoundField DataField="DatumKlaar" HeaderText="Datum klaar" DataFormatString="{0:yyyy/MM/dd}">
                    <HeaderStyle BackColor="#1d1d1b" ForeColor="White"/>
                </asp:BoundField>

                <asp:BoundField DataField="Kostprijs" HeaderText="Kostprijs" DataFormatString="{0:c}">
                    <HeaderStyle BackColor="#1d1d1b" ForeColor="White"/>
                    <ItemStyle Width="10%"/>
                </asp:BoundField>

                <asp:CommandField ButtonType="Button" ShowEditButton="True">
                    <ItemStyle Width="5%"/>
                    <ControlStyle CssClass="btn btn-danger rounded-pill"/>
                    <HeaderStyle BackColor="#1d1d1b" ForeColor="White"/>
                </asp:CommandField>

                <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                    <ItemStyle Width="5%"/>
                    <ControlStyle CssClass="btn btn-danger rounded-pill"/>
                    <HeaderStyle BackColor="#1d1d1b" ForeColor="White"/>
                </asp:CommandField>

            </Columns>
        </asp:GridView>
        <br/><br/>
    </div>
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label runat="server" ID="foutboodschap1" EnableViewState="False" Visible="False" CssClass="alert alert-danger center"/>
    <br/><br/><br/>
    <asp:Label runat="server" ID="foutboodschap2" EnableViewState="False" Visible="False" CssClass="alert alert-danger center"/>
    <br/><br/><br/>
    <asp:Label runat="server" ID="foutboodschap3" EnableViewState="False" Visible="False" CssClass="alert alert-danger center"/>
    <br /><br/><br/>
    </div>
</asp:Content>