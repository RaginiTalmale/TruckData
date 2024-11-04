<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TruckManagement.aspx.cs" Inherits="TruckData.TruckManagement" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Truck Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Truck Management</h2>
            
            <div class="card p-4 mb-4">
                <div class="form-group">
                    <label for="txtCode">Truck Code:</label>
                    <asp:TextBox ID="txtCode" runat="server" CssClass="form-control" Placeholder="Enter Truck Code"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCode" ErrorMessage="Truck Code is required." Display="Dynamic" CssClass="text-danger" />
                </div>
                <br />
              
                <div class="form-group">
                    <label for="txtName">Truck Name:</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Placeholder="Enter Truck Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Truck Name is required." Display="Dynamic" CssClass="text-danger" />
                </div>
                <br />

           <div class="form-group">
                    <label for="ddlStatus">Status:</label>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Out Of Service" Value="Out Of Service" />
                        <asp:ListItem Text="Loading" Value="Loading" />
                        <asp:ListItem Text="To Job" Value="To Job" />
                        <asp:ListItem Text="At Job" Value="At Job" />
                        <asp:ListItem Text="Returning" Value="Returning" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddlStatus" ErrorMessage="Status is required." Display="Dynamic" CssClass="text-danger" />
                </div>
                <br />

                <div class="form-group">
                    <label for="txtDescription">Description:</label>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" Placeholder="Enter Description (optional)"></asp:TextBox>
                </div>
                <br />

             <div class="form-group">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary mr-2" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn btn-secondary" />
                </div>
            </div>
            <br />

            <hr />
            <asp:GridView ID="gvTrucks" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" OnRowCommand="gvTrucks_RowCommand" DataKeyNames="TruckId">
    <Columns>
        <asp:BoundField DataField="Code" HeaderText="Truck Code" />
        <asp:BoundField DataField="Name" HeaderText="Truck Name" />
        <asp:BoundField DataField="Status" HeaderText="Status" />
        <asp:BoundField DataField="Description" HeaderText="Description" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-sm btn-warning" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-sm btn-danger" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
        </div>
    </form>
</body>
</html>
