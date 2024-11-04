using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using TruckData.DataAccess;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using TruckData.Models;

namespace TruckData
{
    public partial class TruckManagement : Page
        {
            private readonly TruckDAL truckDAL = new TruckDAL();

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    BindTruckData();
                }
            }

            protected void BindTruckData()
            {
                var trucks = truckDAL.GetAllTrucks();
                gvTrucks.DataSource = trucks;
                gvTrucks.DataBind();
            }
        protected void gvTrucks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditTruck")
            {
                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvTrucks.Rows[rowIndex];

                
                int truckId = Convert.ToInt32(gvTrucks.DataKeys[rowIndex].Value);

                
                LoadTruckForEditing(truckId);
            }
            else if (e.CommandName == "DeleteTruck")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int truckId = Convert.ToInt32(gvTrucks.DataKeys[rowIndex].Value);

                
                truckDAL.DeleteTruck(truckId);
                BindTruckData(); 
            }
        }

        private void LoadTruckForEditing(int truckId)
        {
            var truck = truckDAL.GetTruckById(truckId);
            if (truck != null)
            {
                txtCode.Text = truck.Code;
                txtName.Text = truck.Name;
                ddlStatus.SelectedValue = truck.Status;
                txtDescription.Text = truck.Description;
                ViewState["TruckId"] = truckId; 
                btnSave.Text = "Update Truck";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
            {
                var truck = new Truck
                {
                    Code = txtCode.Text.Trim(),
                    Name = txtName.Text.Trim(),
                    Status = ddlStatus.SelectedValue,
                    Description = txtDescription.Text.Trim()
                };

                if (ViewState["TruckId"] != null)
                {
                    truck.TruckId = Convert.ToInt32(ViewState["TruckId"]);
                    var existingTruck = truckDAL.GetTruckById(truck.TruckId);

                    if (existingTruck == null)
                    {
                        lblMessage.Text = "Truck not found.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    if (!ValidateStatusChange(existingTruck.Status, truck.Status))
                    {
                        lblMessage.Text = "Invalid status transition.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    truckDAL.UpdateTruck(truck);
                    lblMessage.Text = "Truck updated successfully!";
                }
                else
                {
                    truckDAL.CreateTruck(truck);
                    lblMessage.Text = "Truck added successfully!";
                }

                lblMessage.ForeColor = System.Drawing.Color.Green;
                BindTruckData();
                ClearFields(); 
            }

            private bool ValidateStatusChange(string currentStatus, string newStatus)
            {
                var validTransitions = new Dictionary<string, string[]>
            {
                { "Out Of Service", new[] { "Loading" } },
                { "Loading", new[] { "To Job" } },
                { "To Job", new[] { "At Job" } },
                { "At Job", new[] { "Returning" } },
                { "Returning", new[] { "Loading" } }
            };

                return validTransitions.ContainsKey(currentStatus) && Array.Exists(validTransitions[currentStatus], s => s == newStatus);
            }

            protected void ClearFields()
            {
                txtCode.Text = string.Empty;
                txtName.Text = string.Empty;
                ddlStatus.SelectedIndex = 0;
                txtDescription.Text = string.Empty;
                ViewState["TruckId"] = null;
                btnSave.Text = "Add Truck";
            }
            protected void btnClear_Click(object sender, EventArgs e)
            {
                ClearFields(); 
            }
    }
}