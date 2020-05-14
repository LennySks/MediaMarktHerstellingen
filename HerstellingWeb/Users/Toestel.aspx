<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeFile="Toestel.aspx.cs" Inherits="HerstellingWeb.Users.Toestel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/><br/><br/><br/><br/><br/>

    <div class="card-body" CssClass="col-sm-12" Style="margin: auto; width: 50%;">
        <div style ="margin-left: -20px;">
        <h4>Nieuw Toestel toevoegen</h4>
        </div>
        <div class="input-group">

            <div class="input-group-prepend">
                <span class="input-group-text "style="margin-left: -20px;">Omschrijving</span>
                <br/>
            </div>
            <input id="iptOmschrijving" runat="server" class="form-control" type="text"/>
            <div class="input-group-append">
                <asp:LinkButton ID="btnToestelArtikel" runat="server" style="margin-left: 20px; margin-right: -20px;" CssClass="btn btn-outline-danger" Text="Toevoegen" OnClick="btnToevoegenToestel"></asp:LinkButton>
            </div>
        </div>
    </div>

    <div class="table table-borderless table-hover table-responsive">
        <asp:GridView ID="grvToestel" CssClass="col-sm-12" Style="margin: auto; width: 50%;" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowEditing="grvToestel_RowEditing" OnRowCancelingEdit="grvToestel_RowCancelingEdit" OnRowDeleting="grvToestel_RowDeleting" OnRowUpdating="grvToestel_RowUpdating">
            <Columns>

                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True">
                    <ItemStyle Width="10%"/>
                    <HeaderStyle BackColor="#1d1d1b" ForeColor="White"/>
                </asp:BoundField>

                <asp:BoundField DataField="Omschrijving" HeaderText="Omschrijving">
                    <ItemStyle Width="80%"/>
                    <HeaderStyle BackColor="#1d1d1b" ForeColor="White"/>
                </asp:BoundField>
                
                <asp:CommandField ButtonType="Button" ShowEditButton="True">
                    <ControlStyle CssClass="btn btn-danger rounded-pill"/>
                    <HeaderStyle BackColor="#1d1d1b">
                    </HeaderStyle>
                </asp:CommandField>

                <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                    <ControlStyle CssClass="btn btn-danger rounded-pill"/>
                    <HeaderStyle BackColor="#1d1d1b">
                    </HeaderStyle>
                </asp:CommandField>

            </Columns>
        </asp:GridView>
    </div>
    <br/>
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label runat="server" ID="foutboodschap" EnableViewState="False" Visible="False" CssClass="alert alert-danger center"></asp:Label>
    </div>
    <br/><br/><br/>
</asp:Content>