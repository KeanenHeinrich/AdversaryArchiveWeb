using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace AdversaryArchiveWeb
{
    static class globalVariables
    {
        public static bool woundedIgnore = false;
        public static bool wounded = false;
        public static int maxPenalty = 0;
    }
    public partial class StatDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem defaultItem = new ListItem("-Select NPC-", "0");
                handleList.Items.Insert(0, defaultItem);
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
                                            handleList.Items.Insert(count, li);
                                            count += 1;
                                        }
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
            try
            {
                txtRank.Text = "";
                txtType.Text = "";
                txtInitiative.Text = "";
                txtFacedown.Text = "";
                txtRole.Text = "";
                txtMOVE.Text = "";
                txtBODY.Text = "";
                txtEMP.Text = "";
                txtLUCK.Text = "";
                txtCombat1.Text = "";
                txtCombat2.Text = "";
                txtDefensive1.Text = "";
                txtDefensive2.Text = "";
                txtDefensive3.Text = "";
                txtDefensive4.Text = "";
                txtUtility1.Text = "";
                txtUtility2.Text = "";
                txtUtility3.Text = "";
                txtUtility4.Text = "";
                txtCombat3.Text = "";
                txtCombat3Label.Text = "";
                txtCombat3.Visible = false;
                txtCombat4.Text = "";
                txtCombat4Label.Text = "";
                txtCombat4.Visible = false;
                txtWeapon1.Text = "";
                txtWeapon1.Visible = false;
                txtWeapon11.Text = "";
                txtWeapon11.Visible = false;
                txtWeapon12.Text = "";
                txtWeapon12.Visible = false;
                txtWeapon2.Text = "";
                txtWeapon2.Visible = false;
                txtWeapon21.Text = "";
                txtWeapon21.Visible = false;
                txtWeapon22.Text = "";
                txtWeapon22.Visible = false;
                txtWeapon3.Text = "";
                txtWeapon3.Visible = false;
                txtWeapon31.Text = "";
                txtWeapon31.Visible = false;
                txtWeapon32.Text = "";
                txtWeapon32.Visible = false;
                txtHP.Text = "";
                txtHPTotal.Text = "";
                txtSPBody.Text = "";
                txtSPBodyTotal.Text = "";
                txtSPHead.Text = "";
                txtSPHeadTotal.Text = "";
                graftings1.Items.Clear();
                equipment1.Items.Clear();
                globalVariables.wounded = false;
                globalVariables.wounded = false;
                globalVariables.maxPenalty = 0;
            }
            catch(Exception ex)
            {
                errorLabel.Text = "error 4: " + ex;
            }
        }

        protected void checkCombatSpecial(SqlDataReader reader)
        {
            try
            {
                if (reader["intHeavyWeapons"].ToString() != "")
                {
                    txtCombat3.Text = reader["intHeavyWeapons"].ToString();
                    txtCombat3Label.Text = "Heavy Weapons";
                    txtCombat3.Visible = true;
                }
                if (reader["intMartialArts"].ToString() != "")
                {
                    if (txtCombat3Label.Text == "")
                    {
                        txtCombat3Label.Text = "Martial Arts";
                        txtCombat3.Text = reader["intMartialArts"].ToString();
                        txtCombat3.Visible = true;
                    }
                    else
                    {
                        txtCombat4Label.Text = "Martial Arts";
                        txtCombat4.Text = reader["intMartialArts"].ToString();
                        txtCombat4.Visible = true;
                    }
                }
                if (reader["intAthletics"].ToString() != "")
                {
                    if (txtCombat3Label.Text == "")
                    {
                        txtCombat3Label.Text = "Athletics";
                        txtCombat3.Text = reader["intAthletics"].ToString();
                        txtCombat3.Visible = true;
                    }
                    else
                    {
                        txtCombat4Label.Text = "Athletics";
                        txtCombat4.Text = reader["intAthletics"].ToString();
                        txtCombat4.Visible = true;
                    }
                }
                if (reader["intAutofire"].ToString() != "")
                {
                    if (txtCombat3Label.Text == "")
                    {
                        txtCombat3Label.Text = "Autofire";
                        txtCombat3.Text = reader["intAutofire"].ToString();
                        txtCombat3.Visible = true;
                    }
                    else
                    {
                        txtCombat4Label.Text = "Autofire";
                        txtCombat4.Text = reader["intAutofire"].ToString();
                        txtCombat4.Visible = true;
                    }
                }
            }
            catch(Exception ex)
            {
                errorLabel.Text = "error 3.5: " + ex;
            }
        }

        protected void armourRead()
        {
            try
            {
                string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                string queryString = "SELECT aTbl.* FROM inventoryTable iTbl " +
                                     "INNER JOIN npcTable nTbl ON nTbl.idxNpc = iTbl.idxNpc " +
                                     "INNER JOIN armourTable aTbl ON aTbl.idxArmour = iTbl.idxArmour " +
                                     "WHERE nTbl.idxNpc = " + handleList.SelectedValue;

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
                                        txtSPBody.Text = "0";
                                        txtSPBodyTotal.Text = "0";
                                        txtSPHead.Text = "0";
                                        txtSPHeadTotal.Text = "0";
                                        while (reader.Read())
                                        {
                                            if (reader["txtLocation"].ToString() == "Head")
                                            {
                                                if (Convert.ToInt32(txtSPHeadTotal.Text) < Convert.ToInt32(reader["intSP"].ToString()))
                                                {
                                                    txtSPHead.Text = reader["intSP"].ToString();
                                                    txtSPHeadTotal.Text = reader["intSP"].ToString();
                                                }
                                                if (globalVariables.maxPenalty < Convert.ToInt32(reader["intPenalty"].ToString()))
                                                {
                                                    globalVariables.maxPenalty = Convert.ToInt32(reader["intPenalty"].ToString());
                                                }
                                            }
                                            if (reader["txtLocation"].ToString() == "Body")
                                            {
                                                if (Convert.ToInt32(txtSPBodyTotal.Text) < Convert.ToInt32(reader["intSP"].ToString()))
                                                {
                                                        txtSPBody.Text = reader["intSP"].ToString();
                                                        txtSPBodyTotal.Text = reader["intSP"].ToString();
                                                }
                                                if (globalVariables.maxPenalty < Convert.ToInt32(reader["intPenalty"].ToString()))
                                                {
                                                    globalVariables.maxPenalty = Convert.ToInt32(reader["intPenalty"].ToString());
                                                }
                                            }
                                        }
                                        txtMOVE.Text = (Convert.ToInt32(txtMOVE.Text) - globalVariables.maxPenalty).ToString();
                                        txtInitiative.Text = "+" + (Convert.ToInt32(txtInitiative.Text) - globalVariables.maxPenalty).ToString();
                                        txtCombat1.Text = (Convert.ToInt32(txtCombat1.Text) - globalVariables.maxPenalty).ToString();
                                        txtCombat2.Text = (Convert.ToInt32(txtCombat2.Text) - globalVariables.maxPenalty).ToString();
                                        if (txtCombat3.Text != "")
                                        {
                                            txtCombat3.Text = (Convert.ToInt32(txtCombat3.Text) - globalVariables.maxPenalty).ToString();
                                        }
                                        if (txtCombat4.Text != "")
                                        {
                                            txtCombat4.Text = (Convert.ToInt32(txtCombat4.Text) - globalVariables.maxPenalty).ToString();
                                        }
                                        txtDefensive1.Text = (Convert.ToInt32(txtDefensive1.Text) - globalVariables.maxPenalty).ToString();
                                        txtDefensive2.Text = (Convert.ToInt32(txtDefensive2.Text) - globalVariables.maxPenalty).ToString();
                                        txtUtility2.Text = (Convert.ToInt32(txtUtility2.Text) - globalVariables.maxPenalty).ToString();
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
            catch (Exception ex)
            {
                errorLabel.Text = "error 0" + ex;
            }
        }

        protected void weaponRead()
        {
            try
            {
                string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                string queryString = "SELECT wTbl.*, iTbl.* FROM inventoryTable iTbl " +
                                     "INNER JOIN npcTable nTbl ON nTbl.idxNpc = iTbl.idxNpc " +
                                     "INNER JOIN weaponTable wTbl ON wTbl.idxWeapons = iTbl.idxWeapons " +
                                     "WHERE nTbl.idxNpc = " + handleList.SelectedValue;

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
                                        while (reader.Read())
                                        {
                                            if (txtWeapon1.Text == "") {
                                                txtWeapon1.Text = reader["txtNameWeapon"].ToString();
                                                txtWeapon11.Text = reader["txtType"].ToString() + "(" + reader["txtRangeType"].ToString() + "), " + reader["intDamageDice"].ToString() + "d6, ROF" + reader["intROF"].ToString();
                                                txtWeapon1.Visible = true;
                                                txtWeapon11.Visible = true;
                                                if (reader["txtMiscDetails"].ToString() != "") {
                                                    txtWeapon12.Visible = true;
                                                    txtWeapon12.Text = reader["txtMiscDetails"].ToString();
                                                }
                                                if (reader["txtQuality"].ToString() == "1")
                                                {
                                                    txtWeapon1.Text = "Excellent " + txtWeapon1.Text;
                                                }
                                                else if (reader["txtQuality"].ToString() == "-1")
                                                {
                                                    txtWeapon1.Text = "Poor " + txtWeapon1.Text;
                                                }
                                            }
                                            else if (txtWeapon2.Text == "")
                                            {
                                                txtWeapon2.Text = reader["txtNameWeapon"].ToString();
                                                txtWeapon21.Text = reader["txtType"].ToString() + "(" + reader["txtRangeType"].ToString() + "), " + reader["intDamageDice"].ToString() + "d6, ROF" + reader["intROF"].ToString();
                                                txtWeapon2.Visible = true;
                                                txtWeapon21.Visible = true;
                                                if (reader["txtMiscDetails"].ToString() != "")
                                                {
                                                    txtWeapon22.Visible = true;
                                                    txtWeapon22.Text = reader["txtMiscDetails"].ToString();
                                                }
                                                if (reader["txtQuality"].ToString() == "1")
                                                {
                                                    txtWeapon2.Text = "Excellent " + txtWeapon2.Text;
                                                }
                                                else if (reader["txtQuality"].ToString() == "-1")
                                                {
                                                    txtWeapon2.Text = "Poor " + txtWeapon2.Text;
                                                }
                                            }
                                            else if (txtWeapon3.Text == "")
                                            {
                                                txtWeapon3.Text = reader["txtNameWeapon"].ToString();
                                                txtWeapon31.Text = reader["txtType"].ToString() + "(" + reader["txtRangeType"].ToString() + "), " + reader["intDamageDice"].ToString() + "d6, ROF" + reader["intROF"].ToString();
                                                txtWeapon3.Visible = true;
                                                txtWeapon31.Visible = true;
                                                if (reader["txtMiscDetails"].ToString() != "")
                                                {
                                                    txtWeapon32.Visible = true;
                                                    txtWeapon32.Text = reader["txtMiscDetails"].ToString();
                                                }
                                                if (reader["txtQuality"].ToString() == "1")
                                                {
                                                    txtWeapon3.Text = "Excellent " + txtWeapon3.Text;
                                                }
                                                else if (reader["txtQuality"].ToString() == "-1")
                                                {
                                                    txtWeapon3.Text = "Poor " + txtWeapon3.Text;
                                                }
                                            }
                                        }
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
            catch (Exception ex)
            {
                errorLabel.Text = "error 0" + ex;
            }
        }

        protected void graftingApply(string name)
        {
            switch (name)
            {
                case "Centaur":
                    txtMOVE.Text = (Convert.ToInt32(txtMOVE.Text) + 2).ToString();
                    break;
                case "Giant":
                    if (Convert.ToInt32(txtBODY.Text)<12)
                    {
                        if (Convert.ToInt32(txtHPTotal.Text) % 10 == 0)
                        {
                            txtHPTotal.Text = (Convert.ToInt32(txtHPTotal.Text) + 5 * ((12 - Convert.ToInt32(txtBODY.Text)) / 2 + 1)).ToString();
                        }
                        else
                        {
                            txtHPTotal.Text = (Convert.ToInt32(txtHPTotal.Text) + 5 * ((12 - Convert.ToInt32(txtBODY.Text)) / 2)).ToString();
                        }
                        txtHP.Text = txtHPTotal.Text;
                        txtBODY.Text = "12";
                    }
                    break;
                case "Titan":
                    if (Convert.ToInt32(txtBODY.Text) < 14)
                    {
                        if (Convert.ToInt32(txtHPTotal.Text) % 10 == 0)
                        {
                            txtHPTotal.Text = (Convert.ToInt32(txtHPTotal.Text) + 5 * ((14 - Convert.ToInt32(txtBODY.Text)) / 2)).ToString();
                        }
                        else
                        {
                            txtHPTotal.Text = (Convert.ToInt32(txtHPTotal.Text) + 5 * ((14 - Convert.ToInt32(txtBODY.Text)) / 2 + 1)).ToString();
                        }
                        txtHP.Text = txtHPTotal.Text;
                        txtBODY.Text = "14";
                    }
                    break;
                case "Skitter":
                    txtInitiative.Text = "+" + (Convert.ToInt32(txtInitiative.Text) + 2);
                    break;
                case "Adrenaline":
                    globalVariables.woundedIgnore = true;
                    break;
                case "Supportive Frame":
                    txtMOVE.Text = (Convert.ToInt32(txtMOVE.Text) + (globalVariables.maxPenalty * 0.5)).ToString();
                    txtInitiative.Text = "+" + (Convert.ToInt32(txtInitiative.Text) + (globalVariables.maxPenalty * 0.5)).ToString();
                    txtCombat1.Text = (Convert.ToInt32(txtCombat1.Text) + (globalVariables.maxPenalty * 0.5)).ToString();
                    txtCombat2.Text = (Convert.ToInt32(txtCombat2.Text) + (globalVariables.maxPenalty * 0.5)).ToString();
                    if (txtCombat3.Text != "")
                    {
                        txtCombat3.Text = (Convert.ToInt32(txtCombat3.Text) + (globalVariables.maxPenalty * 0.5)).ToString();
                    }
                    if (txtCombat4.Text != "")
                    {
                        txtCombat4.Text = (Convert.ToInt32(txtCombat4.Text) + (globalVariables.maxPenalty * 0.5)).ToString();
                    }
                    txtDefensive1.Text = (Convert.ToInt32(txtDefensive1.Text) + (globalVariables.maxPenalty * 0.5)).ToString();
                    txtDefensive2.Text = (Convert.ToInt32(txtDefensive2.Text) + (globalVariables.maxPenalty * 0.5)).ToString();
                    txtUtility2.Text = (Convert.ToInt32(txtUtility2.Text) + (globalVariables.maxPenalty * 0.5)).ToString();
                    break;
            }
        }

        protected void graftingRead()
        {
            try
            {
                string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                string queryString = "SELECT gTbl.txtNameGrafting FROM inventoryTable iTbl " +
                                     "INNER JOIN npcTable nTbl ON nTbl.idxNpc = iTbl.idxNpc " +
                                     "INNER JOIN graftingTable gTbl on gTbl.idxGrafting = iTbl.idxGrafting " +
                                     "WHERE nTbl.idxNpc = " + handleList.SelectedValue;
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
                                        int count = 0;
                                        while (reader.Read())
                                        {
                                            ListItem li = new ListItem(reader["txtNameGrafting"].ToString());
                                            graftingApply(reader["txtNameGrafting"].ToString());
                                            graftings1.Items.Insert(count, li);
                                            count += 1;
                                        }
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
            catch (Exception ex)
            {
                errorLabel.Text = "error 0" + ex;
            }
        }

        protected void equipmentRead()
        {
            try
            {
                string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                string queryString = "SELECT eTbl.txtNameEquipment FROM inventoryTable iTbl " +
                                     "INNER JOIN npcTable nTbl ON nTbl.idxNpc = iTbl.idxNpc " +
                                     "INNER JOIN equipmentTable eTbl on eTbl.idxEquipment = iTbl.idxEquipment " +
                                     "WHERE nTbl.idxNpc = " + handleList.SelectedValue;

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
                                        int count = 0;
                                        while (reader.Read())
                                        {
                                            ListItem li = new ListItem(reader["txtNameEquipment"].ToString());
                                            equipment1.Items.Insert(count, li);
                                            count += 1;
                                        }
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
            catch (Exception ex)
            {
                errorLabel.Text = "error 0" + ex;
            }
        }

        protected void handleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clear();
                string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                string queryString = "SELECT nTbl.txtHandle, nTbl.idxNpc, nTbl.txtType, nTbl.txtTier, sTbl.*, CONCAT(sTbl.txtRole, ' ', sTbl.txtRoleLvl) AS RoleTotal FROM npcTable nTbl " +
                                     "INNER JOIN statsTable sTbl ON sTbl.idxStats = nTbl.idxStats " +
                                     "WHERE nTbl.idxNpc = " + handleList.SelectedValue;

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
                                        while (reader.Read())
                                        {
                                            txtHP.Text = reader["intHP"].ToString();
                                            txtHPTotal.Text = reader["intHP"].ToString();
                                            txtRank.Text = reader["txtTier"].ToString();
                                            txtType.Text = reader["txtType"].ToString();
                                            txtInitiative.Text = "+" + reader["intInitiative"].ToString();
                                            txtFacedown.Text = "+" + reader["intFacedown"].ToString();
                                            txtRole.Text = reader["RoleTotal"].ToString();
                                            txtMOVE.Text = reader["intMOVE"].ToString();
                                            txtBODY.Text = reader["intBODY"].ToString();
                                            txtEMP.Text = reader["intEMP"].ToString();
                                            txtLUCK.Text = reader["intLUCK"].ToString();
                                            txtCombat1.Text = reader["intMeleeSkill"].ToString();
                                            txtCombat2.Text = reader["intRangedSkill"].ToString();
                                            txtDefensive1.Text = reader["intBrawling"].ToString();
                                            txtDefensive2.Text = reader["intEvasion"].ToString();
                                            txtDefensive3.Text = reader["intResistTD"].ToString();
                                            txtDefensive4.Text = reader["intConcentration"].ToString();
                                            txtUtility1.Text = reader["intPerception"].ToString();
                                            txtUtility2.Text = reader["intStealth"].ToString();
                                            txtUtility3.Text = reader["intSocial"].ToString();
                                            txtUtility4.Text = reader["intInsight"].ToString();
                                            checkCombatSpecial(reader);
                                            armourRead();
                                            weaponRead();
                                            graftingRead();
                                            equipmentRead();
                                        }
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
            catch (Exception ex)
            {
                errorLabel.Text = "error 0" + ex;
            }
        }

        protected void txtHP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ((Convert.ToInt16(txtHP.Text) <= 0.5 * (Convert.ToInt16(txtHPTotal.Text))) && globalVariables.woundedIgnore == false
                    && globalVariables.wounded == false)
                {
                    globalVariables.wounded = true;
                    txtInitiative.Text = "+" + (Convert.ToInt16(txtInitiative.Text) - 2).ToString();
                    txtFacedown.Text = "+" + (Convert.ToInt16(txtFacedown.Text) - 2).ToString();
                    txtCombat1.Text = (Convert.ToInt16(txtCombat1.Text) - 2).ToString();
                    txtCombat2.Text = (Convert.ToInt16(txtCombat2.Text) - 2).ToString();
                    txtDefensive1.Text = (Convert.ToInt16(txtDefensive1.Text) - 2).ToString();
                    txtDefensive2.Text = (Convert.ToInt16(txtDefensive2.Text) - 2).ToString();
                    txtDefensive3.Text = (Convert.ToInt16(txtDefensive3.Text) - 2).ToString();
                    txtDefensive4.Text = (Convert.ToInt16(txtDefensive4.Text) - 2).ToString();
                    txtUtility1.Text = (Convert.ToInt16(txtUtility1.Text) - 2).ToString();
                    txtUtility2.Text = (Convert.ToInt16(txtUtility2.Text) - 2).ToString();
                    txtUtility3.Text = (Convert.ToInt16(txtUtility3.Text) - 2).ToString();
                    txtUtility4.Text = (Convert.ToInt16(txtUtility4.Text) - 2).ToString();
                    if (txtCombat3.Text != "")
                    {
                        txtCombat3.Text = (Convert.ToInt16(txtCombat3.Text) - 2).ToString();
                    }
                    if (txtCombat4.Text != "")
                    {
                        txtCombat4.Text = (Convert.ToInt16(txtCombat4.Text) - 2).ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                errorLabel.Text = "error HP: " + ex;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtDamage.Text) > Convert.ToInt32(txtSPBody.Text))
                {
                    int dmgHold = Convert.ToInt32(txtDamage.Text) - Convert.ToInt32(txtSPBody.Text);
                    txtHP.Text = (Convert.ToInt32(txtHP.Text) - dmgHold).ToString();
                    if (txtSPBody.Text != "0")
                    {
                        txtSPBody.Text = (Convert.ToInt32(txtSPBody.Text) - 1).ToString();
                    }
                    txtDamage.Text = "";
                    txtHP_TextChanged(txtHP, e);
                }
            }
            catch(Exception ex)
            {
                errorLabel.Text = "error: " + ex;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtDamage.Text) > Convert.ToInt32(txtSPHead.Text))
                {
                    int dmgHold = (Convert.ToInt32(txtDamage.Text) - Convert.ToInt32(txtSPHead.Text)) * 2;
                    txtHP.Text = (Convert.ToInt32(txtHP.Text) - dmgHold).ToString();
                    if (txtSPHead.Text != "0")
                    {
                        txtSPHead.Text = (Convert.ToInt32(txtSPHead.Text) - 1).ToString();
                    }
                    txtDamage.Text = "";
                    txtHP_TextChanged(txtHP, e);
                }
            }
            catch (Exception ex)
            {
                errorLabel.Text = "error: " + ex;
            }
        }
    }
}