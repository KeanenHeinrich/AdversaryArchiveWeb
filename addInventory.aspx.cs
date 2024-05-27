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
    public partial class addInventory : System.Web.UI.Page
    {
        protected void initialiseLists()
        {
            ListItem defaultNPC = new ListItem("-Select NPC-", "0");
            npcList.Items.Insert(0, defaultNPC);
            ListItem defaultType = new ListItem("-Select Item Type-", "0");
            typeList.Items.Insert(0, defaultType);
            ListItem defaultItem = new ListItem("-Select Item-", "0");
            itemList.Items.Insert(0, defaultItem);
            ListItem defaultAmmo = new ListItem("-Select Ammo Type-", "0");
            ammoList.Items.Insert(0, defaultAmmo);
            ListItem defaultAttach1 = new ListItem("-Select Attachment #1-", "0");
            attachment1.Items.Insert(0, defaultAttach1);
            ListItem defaultAttach2 = new ListItem("-Select Attachment #2-", "0");
            attachment2.Items.Insert(0, defaultAttach2);
            ListItem defaultAttach3 = new ListItem("-Select Attachment #3-", "0");
            attachment3.Items.Insert(0, defaultAttach3);

            ListItem type1 = new ListItem("Grafting", "1");
            typeList.Items.Insert(1, type1);
            ListItem type2 = new ListItem("Armour", "2");
            typeList.Items.Insert(2, type2);
            ListItem type3 = new ListItem("Equipment", "3");
            typeList.Items.Insert(3, type3);
            ListItem type4 = new ListItem("Weapon", "4");
            typeList.Items.Insert(4, type4);
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
            }
        }

        protected void itemReset()
        {
            itemList.Items.Clear();
            ListItem defaultItem = new ListItem("-Select Item-", "0");
            itemList.Items.Insert(0, defaultItem);

            qualityList.Items.Clear();
            ListItem defaultQuality = new ListItem("Standard Quality", "0");
            qualityList.Items.Insert(0, defaultQuality);

            ammoList.Items.Clear();
            ListItem defaultAmmo = new ListItem("-Select Ammo Type-", "0");
            ammoList.Items.Insert(0, defaultAmmo);

            attachment1.Items.Clear();
            attachment2.Items.Clear();
            attachment3.Items.Clear();
            ListItem defaultAttach1 = new ListItem("-Select Attachment #1-", "0");
            ListItem defaultAttach2 = new ListItem("-Select Attachment #2-", "0");
            ListItem defaultAttach3 = new ListItem("-Select Attachment #3-", "0");
            attachment1.Items.Insert(0, defaultAttach1);
            attachment2.Items.Insert(0, defaultAttach2);
            attachment3.Items.Insert(0, defaultAttach3);

            qualityList.Visible = false;
            ammoList.Visible = false;
            txtAmmo.Visible = false;
            attachment1.Visible = false;
            attachment2.Visible = false;
            attachment3.Visible = false;
        }

        protected void typeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(typeList.SelectedValue == "1")
            {
                itemReset();
                string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                string queryString = "SELECT txtNameGrafting, idxGrafting FROM graftingTable";
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
                                            ListItem li = new ListItem(reader["txtNameGrafting"].ToString(), reader["idxGrafting"].ToString());
                                            itemList.Items.Insert(count, li);
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
            if (typeList.SelectedValue == "2")
            {
                itemReset();
                string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                string queryString = "SELECT txtName, txtLocation, idxArmour FROM armourTable";
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
                                            ListItem li = new ListItem("[" + reader["txtLocation"].ToString() + "] " + (reader["txtName"].ToString()), reader["idxArmour"].ToString());
                                            itemList.Items.Insert(count, li);
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
            if (typeList.SelectedValue == "3")
            {
                itemReset();
                string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                string queryString = "SELECT txtNameEquipment, idxEquipment FROM equipmentTable";
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
                                            ListItem li = new ListItem(reader["txtNameEquipment"].ToString(), reader["idxEquipment"].ToString());
                                            itemList.Items.Insert(count, li);
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
            if (typeList.SelectedValue == "4")
            {
                itemReset();
                string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                string queryString = "SELECT txtNameWeapon, idxWeapons FROM weaponTable";
                qualityList.Visible = true;
                ammoList.Visible = true;
                txtAmmo.Visible = true;
                attachment1.Visible = true;
                attachment2.Visible = true;
                attachment3.Visible = true;
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
                                            ListItem li = new ListItem(reader["txtNameWeapon"].ToString(), reader["idxWeapons"].ToString());
                                            itemList.Items.Insert(count, li);
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
                string connectionStringAmmo = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                string queryStringAmmo = "SELECT txtNameAmmo, idxAmmo FROM ammoTable";
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionStringAmmo))
                    {
                        try
                        {
                            using (SqlCommand query = new SqlCommand(queryStringAmmo, con))
                            {
                                try
                                {
                                    con.Open();
                                    using (SqlDataReader reader = query.ExecuteReader())
                                    {
                                        int count = 1;
                                        while (reader.Read())
                                        {
                                            ListItem li = new ListItem(reader["txtNameAmmo"].ToString(), reader["idxAmmo"].ToString());
                                            ammoList.Items.Insert(count, li);
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
                string connectionStringAttach = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
                string queryStringAttach = "SELECT txtNameAttachment, idxAttachment FROM attachmentTable";
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionStringAttach))
                    {
                        try
                        {
                            using (SqlCommand query = new SqlCommand(queryStringAttach, con))
                            {
                                try
                                {
                                    con.Open();
                                    using (SqlDataReader reader = query.ExecuteReader())
                                    {
                                        int count = 1;
                                        while (reader.Read())
                                        {
                                            ListItem li = new ListItem(reader["txtNameAttachment"].ToString(), reader["idxAttachment"].ToString());
                                            attachment1.Items.Insert(count, li);
                                            attachment2.Items.Insert(count, li);
                                            attachment3.Items.Insert(count, li);
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

                ListItem excellent = new ListItem("Excellent Quality", "1");
                qualityList.Items.Insert(1, excellent);
                ListItem poor = new ListItem("Poor Quality", "-1");
                qualityList.Items.Insert(2, poor);

            }
            if (typeList.SelectedValue == "0")
            {
                itemReset();
            }
        }

        protected string createRecord()
        {
            string npc = npcList.SelectedValue;
            string grafting = "NULL";
            string armour = "NULL";
            string equipment = "NULL";
            string weapon = "NULL";
            string quality = "NULL";
            string ammo = "NULL";
            string ammoCount = "NULL";
            string attach1 = "NULL";
            string attach2 = "NULL";
            string attach3 = "NULL";
            switch(typeList.SelectedValue)
            {
                case "1":
                    grafting = itemList.SelectedValue;
                    break;
                case "2":
                    armour = itemList.SelectedValue;
                    break;
                case "3":
                    equipment = itemList.SelectedValue;
                    break;
                case "4":
                    weapon = itemList.SelectedValue;
                    quality = qualityList.SelectedValue;
                    if (ammoList.SelectedValue != "0")
                    {
                        ammo = ammoList.SelectedValue;
                    }
                    try
                    {
                        if (Convert.ToInt32(txtAmmo.Text) > 0)
                        {
                            ammoCount = txtAmmo.Text;
                        }
                    }
                    catch(Exception ex)
                    {
                        errorLabel.Text = "Invalid Ammo Count";
                    }
                    if (attachment1.SelectedValue != "0")
                    {
                        attach1 = attachment1.SelectedValue;
                    }
                    if (attachment2.SelectedValue != "0")
                    {
                        attach2 = attachment2.SelectedValue;
                    }
                    if (attachment3.SelectedValue != "0")
                    {
                        attach3 = attachment3.SelectedValue;
                    }
                    break;
            }
            string queryString = "INSERT INTO [dbo].[inventoryTable] VALUES (" + npc + "," + grafting + "," + equipment + "," + armour + "," + weapon + "," + quality + "," + ammo + "," + ammoCount + "," + attach1 + "," + attach2 + "," + attach3 + ", GETDATE())";
            return (queryString);
        }

        protected void clear()
        {
            itemReset();
            typeList.SelectedValue = "0";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source =.\\sqlexpress; Initial Catalog = Campaign; Persist Security Info = True; User ID = sa; Password = remote;";
            string queryString = createRecord();
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
                                if (npcList.SelectedValue != "0")
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
            try
            {
                clear();
            }
            catch(Exception ex)
            {
                errorLabel.Text = "Error: " + ex;
            }
        }
    }
}