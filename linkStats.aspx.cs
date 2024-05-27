using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace AdversaryArchiveWeb
{
    public partial class linkStats : System.Web.UI.Page
    {
        protected void initialiseLists()
        {
            ListItem defaultNpc = new ListItem("-Select NPC-", "0");
            npcList.Items.Insert(0, defaultNpc);
            ListItem defaultStat = new ListItem("-Select Statblock", "0");
            statList.Items.Insert(0, defaultStat);
        }

        protected void clear()
        {
            npcList.SelectedValue = "0";
            statList.SelectedValue = "0";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initialiseLists();
                string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                string queryString = "SELECT txtHandle, idxNpc FROM npcTable";
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
                                            ListItem li = new ListItem(reader["txtHandle"].ToString(), reader["idxNpc"].ToString());
                                            npcList.Items.Insert(count, li);
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
                string connectionStringStat = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                string queryStringStat = "SELECT txtStatName, idxStats FROM statsTable";
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionStringStat))
                    {
                        try
                        {
                            using (SqlCommand query = new SqlCommand(queryStringStat, con))
                            {
                                try
                                {
                                    con.Open();
                                    using (SqlDataReader reader = query.ExecuteReader())
                                    {
                                        int count = 1;
                                        while (reader.Read())
                                        {
                                            ListItem li = new ListItem(reader["txtStatName"].ToString(), reader["idxStats"].ToString());
                                            statList.Items.Insert(count, li);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (statList.SelectedValue != "0" && npcList.SelectedValue != "0")
            {
                string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                string queryString = "UPDATE [dbo].[npcTable] SET idxStats = " + statList.SelectedValue + " FROM npcTable WHERE idxNpc = " + npcList.SelectedValue;
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
                                    query.Connection = con;
                                    query.ExecuteNonQuery();
                                    con.Close();
                                    clear();
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
}