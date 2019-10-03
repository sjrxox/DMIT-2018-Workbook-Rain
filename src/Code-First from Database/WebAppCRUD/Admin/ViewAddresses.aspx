﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAddresses.aspx.cs" Inherits="WebAppCRUD.Admin.ViewAddresses" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Address CRUD</h1>

    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

    <asp:ListView ID="AddressLstView" runat="server" DataSourceID="AddressDataSource" DataKeyNames="AddressID" InsertItemPosition="FirstItem">

        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                    <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                </td>

                <td>
                    <asp:TextBox Text='<%# Bind("Address1") %>' runat="server" ID="Address1TextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("City") %>' runat="server" ID="CityTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Region") %>' runat="server" ID="RegionTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("PostalCode") %>' runat="server" ID="PostalCodeTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Country") %>' runat="server" ID="CountryTextBox" /></td>

            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                    <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                </td>

                <td>
                    <asp:TextBox Text='<%# Bind("Address1") %>' runat="server" ID="Address1TextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("City") %>' runat="server" ID="CityTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Region") %>' runat="server" ID="RegionTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("PostalCode") %>' runat="server" ID="PostalCodeTextBox" /></td>
                <td>
                    <asp:TextBox Text='<%# Bind("Country") %>' runat="server" ID="CountryTextBox" /></td>

            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                </td>

                <td>
                    <asp:Label Text='<%# Eval("Address1") %>' runat="server" ID="Address1Label" /></td>
                <td>
                    <asp:Label Text='<%# Eval("City") %>' runat="server" ID="CityLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Region") %>' runat="server" ID="RegionLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("PostalCode") %>' runat="server" ID="PostalCodeLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("Country") %>' runat="server" ID="CountryLabel" /></td>

            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table runat="server" id="itemPlaceholderContainer" class="table table-hover table-condensed">
                            <tr runat="server" style="">
                                <th runat="server">Address1</th>
                                <th runat="server">City</th>
                                <th runat="server">Region</th>
                                <th runat="server">PostalCode</th>
                                <th runat="server">Country</th>
                            </tr>
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="">
                        <asp:DataPager runat="server" ID="DataPager1" PageSize="7">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>

    </asp:ListView>

    <asp:ObjectDataSource ID="AddressDataSource" runat="server" DataObjectTypeName="WestWindSystem.Entities.Address" DeleteMethod="DeleteAddress" 
        InsertMethod="AddAddress" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAddresses" TypeName="WestWindSystem.BLL.CRUDController" UpdateMethod="UpdateAddress"
         OnInserted="CheckForExceptions" OnUpdated="CheckForExceptions" OnDeleted="CheckForExceptions"> 

    </asp:ObjectDataSource>

</asp:Content>
