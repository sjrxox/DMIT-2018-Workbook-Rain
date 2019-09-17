<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCategories.aspx.cs" Inherits="WebAppCRUD.Admin.ViewCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Categories</h1>

    <asp:Repeater ID="CategoryRepeater" runat="server" DataSourceID="CategoryDataSource" ItemType="WestWindSystem.Entities.Category">
        <HeaderTemplate><ul></HeaderTemplate>
        <ItemTemplate>
            <li><%# Item.CategoryName %></li>
        </ItemTemplate>
        <SeparatorTemplate></SeparatorTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>

    <asp:ObjectDataSource ID="CategoryDatSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListCategories" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>

</asp:Content>
