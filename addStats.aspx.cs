using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdversaryArchiveWeb
{
    public partial class addStats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        static class globalVariables
        {
            public static int checkCount = 0;
        }

        protected void boolAutofire_CheckedChanged(object sender, EventArgs e)
        {
            if (boolAutofire.Checked == true)
            {
                if (globalVariables.checkCount < 2)
                {
                    txtAutofire.Visible = true;
                    globalVariables.checkCount += 1;
                }
                else
                {
                    boolAutofire.Checked = false;
                }
            }
            else
            {
                txtAutofire.Visible = false;
                txtAutofire.Text = "";
                globalVariables.checkCount -= 1;
            }
        }

        protected void boolMartialArts_CheckedChanged(object sender, EventArgs e)
        {
            if (boolMartialArts.Checked == true)
            {
                if (globalVariables.checkCount < 2)
                {
                    txtMartialArts.Visible = true;
                    globalVariables.checkCount += 1;
                }
                else
                {
                    boolMartialArts.Checked = false;
                }
            }
            else
            {
                txtMartialArts.Visible = false;
                txtMartialArts.Text = "";
                globalVariables.checkCount -= 1;
            }

        }

        protected void boolHeavyWeapons_CheckedChanged(object sender, EventArgs e)
        {
            if (boolHeavyWeapons.Checked == true)
            {
                if (globalVariables.checkCount < 2)
                {
                    txtHeavyWeapons.Visible = true;
                    globalVariables.checkCount += 1;
                }
                else
                {
                    boolHeavyWeapons.Checked = false;
                }
            }
            else
            {
                txtHeavyWeapons.Visible = false;
                txtHeavyWeapons.Text = "";
                globalVariables.checkCount -= 1;
            }
        }

        protected void boolAthletics_CheckedChanged(object sender, EventArgs e)
        {
            if (boolAthletics.Checked == true)
            {
                if (globalVariables.checkCount < 2)
                {
                    txtAthletics.Visible = true;
                    globalVariables.checkCount += 1;
                }
                else
                {
                    boolAthletics.Checked = false;
                }
            }
            else
            {
                txtAthletics.Visible = false;
                txtAthletics.Text = "";
                globalVariables.checkCount -= 1;
            }

        }

        protected void clear()
        {
            txtAthletics.Text = "";
            boolAthletics.Checked = false;
            txtAutofire.Text = "";
            boolAutofire.Checked = false;
            txtBODY.Text = "";
            txtBrawling.Text = "";
            txtConcentration.Text = "";
            txtEMP.Text = "";
            txtEvasion.Text = "";
            txtFacedown.Text = "";
            txtHeavyWeapons.Text = "";
            boolHeavyWeapons.Checked = false;
            txtHP.Text = "";
            txtInitiative.Text = "";
            txtInsight.Text = "";
            txtLUCK.Text = "";
            txtMartialArts.Text = "";
            boolMartialArts.Checked = false;
            txtMelee.Text = "";
            txtMOVE.Text = "";
            txtName.Text = "";
            txtPerception.Text = "";
            txtRanged.Text = "";
            txtResistTD.Text = "";
            txtRole.Text = "";
            txtRoleLvl.Text = "";
            txtSocial.Text = "";
            txtStealth.Text = "";
            errorLabel.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string autofire;
            if (boolAutofire.Checked == false)
            {
                autofire = "NULL";
            }
            else
            {
                autofire = txtAutofire.Text;
            }

            string martialArts;
            if (boolMartialArts.Checked == false)
            {
                martialArts = "NULL";
            }
            else
            {
                martialArts = txtMartialArts.Text;
            }

            string heavyWeapons;
            if (boolHeavyWeapons.Checked == false)
            {
                heavyWeapons = "NULL";
            }
            else
            {
                heavyWeapons = txtHeavyWeapons.Text;
            }

            string athletics;
            if(boolAthletics.Checked == false)
            {
                athletics = "NULL";
            }
            else
            {
                athletics = txtAthletics.Text;
            }

            string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
            string queryString = "INSERT INTO [dbo].[statsTable] VALUES ('" + txtName.Text + "'," + txtHP.Text + "," + txtInitiative.Text + "," + txtFacedown.Text + "," + txtMOVE.Text + "," + txtBODY.Text + "," + txtEMP.Text + "," + txtLUCK.Text + ",'" + txtRole.Text + "'," + txtRoleLvl.Text + "," + txtMelee.Text + "," + txtRanged.Text + "," + autofire + "," + martialArts + "," + heavyWeapons + "," + athletics + "," + txtBrawling.Text + "," + txtEvasion.Text + "," + txtResistTD.Text + "," + txtConcentration.Text + "," + txtPerception.Text + "," + txtStealth.Text + "," + txtSocial.Text + "," + txtInsight.Text + "," + "GETDATE())";
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
                                if (txtName.Text != "")
                                {
                                    con.Open();
                                    query.Connection = con;
                                    query.ExecuteNonQuery();
                                    con.Close();
                                    clear();
                                }
                            }
                            catch (Exception ex)
                            {
                                errorLabel.Text = "Error: " + ex;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errorLabel.Text = "Error: " + ex;
                    }
                }
            }
            catch (Exception ex)
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