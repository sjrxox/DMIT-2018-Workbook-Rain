﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSuppliers.aspx.cs" Inherits="WebAppCRUD.Admin.ViewSuppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Suppliers</h1>

    <asp:ListView ID="SupplierLisView" runat="server" DataSourceID="SupplierDataSource" ItemType="WestWindSystem.Entities.Supplier">
        <LayoutTemplate>
            <table class="table table-hover table-condensed">
                <thead>
                    <tr>
                        <th>Supplier</th>
                        <th>Company Name</th>
                        <th>Contact Name</th>
                        <th>Contact Title</th>
                        <th>Email</th>
                        <th>Address</th>
                        <th>Phone</th>
                        <th>Fax</th>
                    </tr>
                </thead>
                <tbody>
                    <div id="itemPlaceholder" runat="server"></div>
                </tbody>
            </table>
        </LayoutTemplate>

        <ItemTemplate>
            <tr>
                <td><%# Item.SupplierID%></td>
                <td><%# Item.CompanyName %></td>
                <td><%# Item.ContactName %></td>
                <td><%# Item.ContactTitle %></td>
                <td><%# Item.Email %></td>
                <td><%# Item.AddressID %></td>
                <td><%# Item.Phone %></td>
                <td><%# Item.Fax %></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

    <asp:ObjectDataSource ID="SupplierDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>
