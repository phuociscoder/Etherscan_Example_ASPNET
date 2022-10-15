<%@ Page Title="Coin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Coin.aspx.cs" Inherits="EtherscanExample.Coin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Content/Apps/token.css" rel="stylesheet" type="text/css" />
    <div class="container">

        <h3>Save / Update Token</h3>


        <div class="row">
            <div class="col-sm-2">
                <asp:HiddenField ID="txtId" runat="server" />
                <asp:Label ID="lName" runat="server" Text="Name"></asp:Label>
            </div>
            <div class="col-sm-10 col-md-5">
                <asp:TextBox CssClass="form-control" ID="txtName" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <asp:Label ID="lSymbol" runat="server" Text="Symbol"></asp:Label>
            </div>
            <div class="col-sm-10 col-md-5">
                <asp:TextBox CssClass="form-control" ID="txtSymbol" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <asp:Label ID="lContractAddress" runat="server" Text="Contract Address"></asp:Label>
            </div>
            <div class="col-sm-10 col-md-5">
                <asp:TextBox CssClass="form-control" ID="txtContractAddress" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <asp:Label ID="lTotalSupply" runat="server" Text="Total Supply"></asp:Label>
            </div>
            <div class="col-sm-10 col-md-5">
                <asp:TextBox CssClass="form-control" ID="txtTotalSupply" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <asp:Label ID="lTotalHolders" runat="server" Text="Total Holders"></asp:Label>
            </div>
            <div class="col-sm-10 col-md-5">
                <asp:TextBox CssClass="form-control" ID="txtTotalHolders" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnReset" CssClass="btn btn-info" runat="server" Text="Reset" OnClick="btnReset_Click" />
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <asp:GridView ID="grdToken" CellSpacing="5" runat="server" OnPageIndexChanging="grdToken_PageIndexChanging" Width="100%" class="hoverTable" AutoGenerateColumns="false" EmptyDataText="No Data " ShowFooter="True" AllowSorting="True" CellPadding="5" AllowPaging="True" ShowHeaderWhenEmpty="True" PagerSettings-NextPageText="Next" PagerStyle-CssClass="grd-panigation">
                    <Columns>
                        <asp:TemplateField HeaderText="Rank" ItemStyle-CssClass="grd-cell" ItemStyle-Width="100">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                <asp:HiddenField ID="hiddenId" Value='<%# Eval("id")%>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField ItemStyle-CssClass="grd-cell" HeaderStyle-CssClass="grd-header" HeaderText="Symbol" DataField="symbol" ItemStyle-Width="100px" />
                        <asp:BoundField ItemStyle-CssClass="grd-cell" HeaderText="Name" DataField="name" />
                        <asp:BoundField ItemStyle-CssClass="grd-cell" HeaderText="Contract Address" DataField="contract_address" ItemStyle-Width="300px" />
                        <asp:BoundField ItemStyle-CssClass="grd-cell" HeaderText="Total Holders" DataField="total_holders" />
                        <asp:BoundField ItemStyle-CssClass="grd-cell" HeaderText="Total Supply" DataField="total_supply" />
                        <asp:BoundField ItemStyle-CssClass="grd-cell" HeaderText="Total Supply %" DataField="total_supply_percent" DataFormatString="{0:0.00}%" ItemStyle-Width="200px" />
                        <asp:TemplateField ItemStyle-CssClass="grd_cell">
                            <ItemTemplate>
                                <asp:LinkButton ID="lEdit" runat="server" ForeColor="#3333FF" OnCommand="lEdit_Command" CommandArgument='<%# Eval("id")%>'>Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>
