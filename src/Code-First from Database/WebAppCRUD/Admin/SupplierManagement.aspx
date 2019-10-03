﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplierManagement.aspx.cs" Inherits="WebAppCRUD.Admin.SupplierManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Supplier Management System</h1>
    <h2>Supplier Summary</h2>

    <asp:Repeater ID="SupplierSummaryRepeater" runat="server" DataSourceID="SupplierSummaryDataSource"></asp:Repeater>
    <asp:ObjectDataSource ID="SupplierSummaryDataSource" runat="server"></asp:ObjectDataSource>
</asp:Content>
