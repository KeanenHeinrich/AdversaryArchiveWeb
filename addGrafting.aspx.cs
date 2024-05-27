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
    public partial class addItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem defaultType = new ListItem("-Select Type-", "0");
                typeList.Items.Insert(0, defaultType);
                string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                string queryString = "SELECT txtNameType, idxGraftingType FROM graftingTypeTable";
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
                                            ListItem li = new ListItem(reader["txtNameType"].ToString(), reader["idxGraftingType"].ToString());
                                            typeList.Items.Insert(count, li);
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

        protected void clear()
        {

        }

        protected void typeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}