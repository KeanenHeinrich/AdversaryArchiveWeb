using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AdversaryArchiveWeb
{
    public partial class addNPC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    ListItem defaultOrg = new ListItem("-Select Organisation-", "0");
                    organisationList.Items.Insert(0, defaultOrg);
                    string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                    string queryString = "SELECT txtNameOrganisation, idxOrganisation FROM organisationTable";
                    try
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            try
                            {
                                using (SqlCommand query = new SqlCommand(queryString, con))
                                {
                                    try
                                    {
                                        con.Open();
                                        using (SqlDataReader reader = query.ExecuteReader())
                                        {
                                            int count = 1;
                                            while (reader.Read())
                                            {
                                                ListItem li = new ListItem(reader["txtNameOrganisation"].ToString(), reader["idxOrganisation"].ToString());
                                                organisationList.Items.Insert(count, li);
                                                count += 1;
                                            }
                                            con.Close();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        errorLabel.Text = "error 3: " + ex;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                errorLabel.Text = "error 2: " + ex;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errorLabel.Text = "error 1: " + ex;
                    }
                }
            }
        }
        
        protected void clear()
        {
            txtAge.Text = "";
            txtBio.Text = "";
            txtFName.Text = "";
            txtGender.Text = "";
            txtHandle.Text = "";
            txtLocation.Text = "";
            txtOccupation.Text = "";
            txtRelationship.Text = "";
            txtSName.Text = "";
            txtTier.Text = "";
            txtType.Text = "";
            boolAlive.Checked = false;
            errorLabel.Text = "";
            organisationList.SelectedValue = "0";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string org = "NULL";
            if (organisationList.SelectedValue != "0")
            {
                org = organisationList.SelectedValue;
            }
            string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
            string queryString = "INSERT INTO [dbo].[npcTable] VALUES ('" + txtHandle.Text + "','" + txtFName.Text + "','" + txtSName.Text + "','" + txtGender.Text + "','" + txtAge.Text + "','" + txtOccupation.Text + "','" + txtTier.Text + "','" + txtType.Text + "','" + txtRelationship.Text + "'," + org + ",'" + txtLocation.Text + "'," + "NULL" + "," + "1" + ",'" + txtBio.Text + "', GETDATE())";
            try
            { 
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        using (SqlCommand query = new SqlCommand(queryString, con))
                        {
                            try
                            {
                                if (txtHandle.Text != "")
                                {
                                    con.Open();
                                    query.Connection = con;
                                    query.ExecuteNonQuery();
                                    con.Close();
                                    clear();
                                }
                            }
                            catch(Exception ex)
                            {
                                errorLabel.Text = "Error: " + ex;
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        errorLabel.Text = "Error: " + ex;
                    }
                }
            }
            catch(Exception ex)
            {
                errorLabel.Text = "Error: " + ex;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}