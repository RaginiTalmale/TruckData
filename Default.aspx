<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TruckData._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
        </section>

        <div class="row">
             <section class="row" aria-labelledby="truckManagementTitle">
            <h2 id="truckManagementTitle">Truck Management</h2>
            <p>
                Manage your fleet of trucks by adding, updating, or deleting truck records.
            </p>
            <p>
                <a class="btn btn-primary" href="TruckManagement.aspx">Go to Truck Management &raquo;</a>
            </p>
        </section>
        </div>
    </main>

</asp:Content>
