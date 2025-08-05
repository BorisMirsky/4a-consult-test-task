<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="NewBook.aspx.cs" 
    MasterPageFile="~/Site.Master" 
    Inherits="_4aconsultWebForms.Pages.NewBook" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <br /><br /><br />
        <h2>New Book</h2>
        <br /><br /><br />
    <table>
            <tr>
                <td>
                    Book Name</td>
                <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Author</td>
                <td>
                    <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Price</td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td>
                    Year</td>
                <td>
                    <asp:TextBox ID="txtYear" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Add Book" OnClick="btnAdd_Click" /><br />
        <br />
        <asp:Label ID="lblMsg" runat="server" EnableViewState="False"></asp:Label><br />
        <br /><br /><br />


</asp:Content>
