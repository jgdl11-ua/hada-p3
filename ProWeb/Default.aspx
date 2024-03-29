<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Products management</h2>
    <span>Code</span>
    <asp:TextBox ID="textCode" runat="server"></asp:TextBox>
    <br />
    <br />
    <span>Name </span>
    <asp:TextBox ID="textName" runat="server"></asp:TextBox>
    <br />
    <br />
    <span>Amount </span>
    <asp:TextBox ID="textAmount" runat="server"></asp:TextBox>
    <br />
    <br />
    <span>Category </span>
    <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
    <br />
    <br />
    <span>Price </span>
    <asp:TextBox ID="textPrice" runat="server"></asp:TextBox>
    <br />
    <br />
    <span>Creation Date </span>
    <asp:TextBox ID="textDate" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label_Error" runat="server" ForeColor="Red" Visible="false"></asp:Label><br />
    <br />
    <asp:Button ID="Button_Create" runat="server" Text="Create" OnClick="ButtonCreate_Click" />
    <asp:Button ID="Button_Update" runat="server" Text="Update" OnClick="ButtonUpdate_Click"/>
    <asp:Button ID="Button_Delete" runat="server" Text="Delete" OnClick="ButtonDelete_Click"/>
    <asp:Button ID="Button_Read" runat="server" Text="Read" OnClick="ButtonRead_Click"/>
    <asp:Button ID="Button_ReadFirst" runat="server" Text="Read First" OnClick="ButtonReadFirst_Click"/>
    <asp:Button ID="Button_ReadPrev" runat="server" Text="Read Prev" OnClick="ButtonReadPrev_Click"/>
    <asp:Button ID="Button_ReadNext" runat="server" Text="Read Next" OnClick="ButtonReadNext_Click"/>

    <br />
</asp:Content>
