<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSuppliers.aspx.cs" Inherits="WebAppCRUD.Admin.ViewSuppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Suppliers</h1>

    <asp:ListView ID="SupplierLisView" runat="server" DataSourceID="SupplierDataSource" ItemType="WestWindSystem.Entities.Supplier">
        <LayoutTemplate>
            <blockquote>
                <div id="itemPlaceholder" runat="server"></div>
            </blockquote>
        </LayoutTemplate>
    </asp:ListView>

    <asp:ObjectDataSource ID="SupplierDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>
