<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Products management</h2>
    <span>Code</span>
    <asp:TextBox ID="textCode" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    <br />
    <br />
    <span>Name</span>
    <asp:TextBox ID="textName" runat="server"></asp:TextBox>
    <br />
    <br />
    <span>Amount</span>
    <asp:TextBox ID="textAmount" runat="server"></asp:TextBox>
    <br />
    <br />
    <span>Category</span>
    <select>
        <option value=0>Computing</option>
        <option value=1>Telephony</option>
        <option value=2>Gaming</option>
        <option value=3>Home appliances</option>
    </select>
    <br />
    <br />
    <span>Price</span>
    <asp:TextBox ID="textPrice" runat="server"></asp:TextBox>
    <br />
    <br />
    <span>Creation Date</span>
    <asp:TextBox ID="textDate" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button_Create" runat="server" Text="Create" OnClick="ButtonCreate_Click" />
    <asp:Button ID="Button_Update" runat="server" Text="Update" />
    <asp:Button ID="Button_Delete" runat="server" Text="Delete" />
    <asp:Button ID="Button_Read" runat="server" Text="Read" />
    <asp:Button ID="Button_ReadFirst" runat="server" Text="Read First" />
    <asp:Button ID="Button_ReadPrev" runat="server" Text="Read Prev" />
    <asp:Button ID="Button_ReadNext" runat="server" Text="Read Next" />
    <asp:Label ID="Label_Error" runat="server" ForeColor="Red" Visible="false"></asp:Label><br />



</asp:Content>
