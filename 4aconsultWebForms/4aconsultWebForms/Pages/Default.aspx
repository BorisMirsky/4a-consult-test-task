<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    MasterPageFile="~/Site.Master" 
    Inherits="_4aconsultWebForms.Pages.Default" %>




<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <br /><br /><br />
        <h2>List Of Books</h2>
        <br /><br /><br />
        <asp:GridView ID="GridView1" 
            runat="server" 
            Width="70%">

            <HeaderStyle 
                BackColor="Gray" 
                Font-Bold="True" 
                ForeColor="White" 
            />


        </asp:GridView>
        <br /><br /><br />


</asp:Content>

