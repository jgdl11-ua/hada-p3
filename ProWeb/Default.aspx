<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Products management</h2>
    <span>Code</span>
    <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    <br />
    <br />
    <span>Name</span>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <br />
    <span>Amount</span>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
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
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <br />
    <br />
    <span>Creation Date</span>
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Create" />
    <asp:Button ID="Button2" runat="server" Text="Update" />
    <asp:Button ID="Button3" runat="server" Text="Delete" />
    <asp:Button ID="Button4" runat="server" Text="Read" />
    <asp:Button ID="Button5" runat="server" Text="Read First" />
    <asp:Button ID="Button6" runat="server" Text="Read Prev" />
    <asp:Button ID="Button7" runat="server" Text="Read Next" />



</asp:Content>
