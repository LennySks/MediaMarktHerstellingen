<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Klant.aspx.cs" Inherits="HerstellingWeb.Users.Klant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/><br/><br/><br/><br/><br/>

    <div class="card-body" CssClass="col-sm-12" Style="margin: auto; width: 50%;">
        <div style = "margin-left: -20px;">
            <h4>Nieuwe Klant toevoegen</h4>
        </div>
        
        <div class="input-group">
            <div class="input-group-prepend">
                <span class="input-group-text input-group-btn.input-space" style="margin-left: -20px;">Naam</span>
                <br/>
            </div>
            <input type="text" runat="server" class="form-control" id="iptNaam"/>


            <div class="input-group-prepend">
                <span class="input-group-text input-group-btn.input-space" style="margin-left: 20px;">Telefoonnummer</span>
                <br/>
            </div>
            <input type="text" runat="server" class="form-control" id="iptTelefoonnummer"/>


            <div class="input-group-append">
                <asp:LinkButton ID="btnToestelKlant" runat="server" style="margin-left: 20px; margin-right: -20px;" CssClass="btn btn-outline-danger" Text="Toevoegen" OnClick="btnToevoegenKlant"></asp:LinkButton>
            </div>
        </div>
    </div>

    <div class="table table-borderless table-hover table-responsive">
        <asp:GridView ID="grvKlanten" CssClass="col-sm-12" Style="margin: auto; width: 50%;" runat="server" AutoGenerateColumns="False" OnRowUpdating="grvKlanten_OnRowUpdating" OnRowDeleting="grvKlanten_RowDeleting" DataKeyNames="Id" OnRowCancelingEdit="grvKlanten_RowCancelingEdit" OnRowEditing="grvKlanten_RowEditing" OnSelectedIndexChanged="grvKlanten_SelectedIndexChanged">

            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True">
                    <ItemStyle Width="20%"/>
                    <HeaderStyle BackColor="#1d1d1b" ForeColor="White"/>
                </asp:BoundField>

                <asp:BoundField DataField="Naam" HeaderText="Naam">
                    <ItemStyle Width="40%"/>
                    <HeaderStyle BackColor="#1d1d1b" ForeColor="White"/>
                </asp:BoundField>

                <asp:BoundField DataField="Telefoonnummer" HeaderText="Telefoonnummer">
                    <ItemStyle Width="40%"/>
                    <HeaderStyle BackColor="#1d1d1b" ForeColor="White"/>
                </asp:BoundField>

                <asp:CommandField ButtonType="Button" ShowSelectButton="True">
                    <ControlStyle CssClass="btn btn-danger rounded-pill"/>
                    <HeaderStyle BackColor="#1d1d1b">
                    </HeaderStyle>
                </asp:CommandField>

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

            <EmptyDataTemplate>
                <h5>Er zijn geen klanten beschikbaar.</h5>
            </EmptyDataTemplate>
        </asp:GridView>
        <br/><br/>
    </div>
    <div style="margin-left: auto; margin-right: auto; text-align: center;">
    <asp:Label runat="server" ID="foutboodschap1" EnableViewState="False" Visible="False" CssClass="alert alert-danger center"/>
    <br /><br /><br />
    <asp:Label runat="server" ID="foutboodschap2" EnableViewState="False" Visible="False" CssClass="alert alert-danger center"/>
    <br /><br /><br />
    </div>
</asp:Content>