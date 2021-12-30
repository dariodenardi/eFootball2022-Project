﻿using EvoTool.Controllers;
using EvoTool.Models;
using EvoTool.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvoTool
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private string path;
        private CountryController countryController;
        private PlayerController playerController;
        private TeamController teamController;
        private CoachController coachController;
        private StadiumController stadiumController;
        private BallController ballController;
        private BootController bootController;
        private GloveController gloveController;

        private void Home_Load(object sender, EventArgs e)
        {
            countryController = new CountryController();
            playerController = new PlayerController();
            teamController = new TeamController();
            coachController = new CoachController();
            stadiumController = new StadiumController();
            ballController = new BallController();
            bootController = new BootController();
            gloveController = new GloveController();
            FormBorderStyle = FormBorderStyle.FixedSingle;

            toolStripTextBox1.Text = "Welcome " + System.Environment.MachineName;
        }

        private void Open_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                CloseMemory();
                ResetField();
                path = fbd.SelectedPath;
                OpenDatabase(path);

                EnableStrip();
            }
        }

        private void CloseMemory()
        {
            countryController.CloseMemory();
            playerController.CloseMemory();
            coachController.CloseMemory();
            stadiumController.CloseMemory();
            ballController.CloseMemory();
            bootController.CloseMemory();
            gloveController.CloseMemory();
        }

        private void EnableStrip()
        {
            // enable buttons
            // if there are files found
            if (playerController.PlayerTable.Rows.Count != 0 || teamController.TeamTable.Rows.Count != 0 || coachController.CoachTable.Rows.Count != 0 || stadiumController.StadiumTable.Rows.Count != 0 || ballController.BallTable.Rows.Count != 0 || bootController.BootTable.Rows.Count != 0 || gloveController.GloveTable.Rows.Count != 0)
            {
                tabControl1.Enabled = true;
                Save.Enabled = true;
                reload.Enabled = true;
            }
        }

        private void ResetField()
        {
            //UtilGUI.resetField();

            tabControl1.Enabled = false;
            addNewBallStrip.Enabled = false;
            addNewGloveStrip.Enabled = false;
            addNewBootStrip.Enabled = false;
            addNewStadiumStrip.Enabled = false;
            addNewDerbyStrip.Enabled = false;
            addNewCoachStrip.Enabled = false;

            GloveListBox.Enabled = false;
            GloveGroupBox1.Enabled = false;
            GloveApplyButton.Enabled = false;
            GloveSearchTextBox.Enabled = false;
            addNewGloveStrip.Enabled = false;
            exportGloveToolStripMenuItem.Enabled = false;
            importGloveToolStripMenuItem.Enabled = false;
            GlovePictureBox1.Enabled = false;

            BootGroupBox1.Enabled = false;
            BootListBox.Enabled = false;
            BootSearchTextBox.Enabled = false;
            BootApplyButton.Enabled = false;
            addNewBootStrip.Enabled = false;
            exportBootToolStripMenuItem.Enabled = false;
            importBootToolStripMenuItem.Enabled = false;
            BootPictureBox1.Enabled = false;

            ballController.BallTable.Clear();
            BallCondGroupBox1.Enabled = false;
            exportBallCondToolStripMenuItem.Enabled = false;
            importBallCondToolStripMenuItem.Enabled = false;

            BallGroupBox1.Enabled = false;
            BallListBox.Enabled = false;
            BallSearchTextBox.Enabled = false;
            BallApplyButton.Enabled = false;
            BallPictureBox1.Enabled = false;
            addNewBallStrip.Enabled = false;
            exportBallToolStripMenuItem.Enabled = false;
            importBallToolStripMenuItem.Enabled = false;

            StadiumListBox.Enabled = false;
            StadiumGroupBox1.Enabled = false;
            stadiumGroupBox2.Enabled = false;
            StadiumSearchTextBox.Enabled = false;
            StadiumApplyButton.Enabled = false;
            teamStadiumComboBox.Enabled = false;
            addNewStadiumStrip.Enabled = false;
            importStadiumToolStripMenuItem.Enabled = false;
            exportStadiumToolStripMenuItem.Enabled = false;
            StadiumPictureBox1.Enabled = false;

            stadiumOrderConfGroupBox1.Enabled = false;
            stadiumOrderGroupBox1.Enabled = false;

            derbyDataGridView.Enabled = false;
            derbyApplyButton.Enabled = false;
            derbyGroupBox1.Enabled = false;

            coachGroupBox1.Enabled = false;
            CoachApplyButton.Enabled = false;
            CoachSearchTextBox.Enabled = false;
            CoachListBox.Enabled = false;
            teamCoachComboBox.Enabled = false;
            CoachPictureBox1.Enabled = false;

            TeamListBox.Enabled = false;
            teamSearchTextBox.Enabled = false;
            teamGroupBox1.Enabled = false;
            teamGroupBox2.Enabled = false;
            teamGroupBox3.Enabled = false;
            teamGroupBox4.Enabled = false;
            teamGroupBox5.Enabled = false;
            teamGroupBox6.Enabled = false;
            globGroupBox1.Enabled = false;
            globGroupBox2.Enabled = false;
            globGroupBox3.Enabled = false;
            globGroupBox4.Enabled = false;
            teamPictureBox1.Enabled = false;
            addNewClubStrip.Enabled = false;
            addNewNationalStrip.Enabled = false;

            BallCondListBox.Items.Clear();
            BallCondCompComboBox.Items.Clear();
            StadiumCountryComboBox.DataSource = null;
            StadiumCountryComboBox.Items.Clear();
            PlayerListBox.DataSource = null;
            PlayerListBox.Items.Clear();
            teamBox1.Items.Clear();
            teamBox2.Items.Clear();
            competitionsBox.Items.Clear();
            PlayerNationalityComboBox.DataSource = null;
            PlayerNationalityComboBox.Items.Clear();
            teamCountryComboBox.Items.Clear();
            CoachNationalityComboBox.DataSource = null;
            CoachNationalityComboBox.Items.Clear();
            derbyDataGridView.Rows.Clear();
            derbyTeam1ComboBox.Items.Clear();
            derbyTeam2ComboBox.Items.Clear();
            competitionsKind.Items.Clear();
            ListBox_comp_reg.Items.Clear();
            stadiumOrderDataGridView.Rows.Clear();
            stadiumOrderConfDataGridView.Rows.Clear();
            DataGridView1.Rows.Clear();
            DataGridView1_orig.Rows.Clear();
            competitionEntryBox.Items.Clear();
            teamCoachComboBox.Items.Clear();
            teamStadiumComboBox.Items.Clear();
            teamFeederId.Items.Clear();
            teamParentTeamId.Items.Clear();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            // save file
            if (playerController.PlayerTable.Rows.Count != 0)
            {
                int status = playerController.Save(path);
                if (status != 0)
                    MessageBox.Show("Error saved Player.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (coachController.CoachTable.Rows.Count != 0)
            {
                int status = coachController.Save(path);
                if (status != 0)
                    MessageBox.Show("Error saved Coach.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (stadiumController.StadiumTable.Rows.Count != 0)
            {
                int status = stadiumController.Save(path);
                if (status != 0)
                    MessageBox.Show("Error saved Stadium.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (ballController.BallTable.Rows.Count != 0)
            {
                int status = ballController.Save(path);
                if (status != 0)
                    MessageBox.Show("Error saved Ball.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (bootController.BootTable.Rows.Count != 0)
            {
                int status = bootController.Save(path);
                if (status != 0)
                    MessageBox.Show("Error saved Boots.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (gloveController.GloveTable.Rows.Count != 0)
            {
                int status = gloveController.Save(path);
                if (status != 0)
                    MessageBox.Show("Error saved Glove.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenDatabase(string folder)
        {
            this.Text = "EvoTool 2022 - Pc Mode";

            // if there are Country.bin
            int countrystatus = countryController.Load(folder);
            // if there are Player.bin
            int openplayer = playerController.Load(folder);
            if (openplayer == 0 && countrystatus == 0)
            {
                PlayerNationalityComboBox.DataSource = countryController.CountryTable;
                PlayerNationalityComboBox.DisplayMember = "Name";
                PlayerNationalityComboBox.ValueMember = "Index";

                PlayerListBox.SelectedValue = -1; // if I load database a second time, the first items isn't selected, so I must deselect and then select first item
                PlayerListBox.DataSource = playerController.PlayerTable;
                PlayerListBox.DisplayMember = "Name";
                PlayerListBox.ValueMember = "Index";

                PlayerPanel1.Enabled = true;
                PlayerPanel2.Enabled = true;
                PlayerListBox.Enabled = true;

                PlayerListBox.SelectedValue = 0;
            }
            // if there are Team.bin
            int openteam = teamController.Load(folder);
            if (openteam == 0 && countrystatus == 0)
            {
                TeamListBox.SelectedValue = -1; // if I load database a second time, the first items isn't selected, so I must deselect and then select first item
                TeamListBox.DataSource = teamController.TeamTable;
                TeamListBox.DisplayMember = "Name";
                TeamListBox.ValueMember = "Index";

                TeamListBox.Enabled = true;

                TeamListBox.SelectedValue = 0;
            }
            // if there are Coach.bin
            int opencoach = coachController.Load(folder);
            if (opencoach == 0 && countrystatus == 0)
            {
                CoachNationalityComboBox.BindingContext = new BindingContext();
                CoachNationalityComboBox.DataSource = countryController.CountryTable;
                CoachNationalityComboBox.DisplayMember = "Name";
                CoachNationalityComboBox.ValueMember = "Index";

                CoachListBox.SelectedValue = -1; // if I load database a second time, the first items isn't selected, so I must deselect and then select first item
                CoachListBox.DataSource = coachController.CoachTable;
                CoachListBox.DisplayMember = "Name";
                CoachListBox.ValueMember = "Index";

                coachGroupBox1.Enabled = true;
                CoachListBox.Enabled = true;
                CoachSearchTextBox.Enabled = true;
                CoachApplyButton.Enabled = true;
                CoachPictureBox1.Enabled = true;

                CoachListBox.SelectedValue = 0;
            }
            // if there are Stadium.bin
            int openstadium = stadiumController.Load(folder);
            if (openstadium == 0 && countrystatus == 0)
            {
                StadiumCountryComboBox.SelectedValue = -1;
                StadiumCountryComboBox.BindingContext = new BindingContext();
                StadiumCountryComboBox.DataSource = countryController.CountryTable;
                StadiumCountryComboBox.DisplayMember = "Name";
                StadiumCountryComboBox.ValueMember = "Index";

                StadiumListBox.SelectedValue = -1; // if I load database a second time, the first items isn't selected, so I must deselect and then select first item
                StadiumListBox.DataSource = stadiumController.StadiumTable;
                StadiumListBox.DisplayMember = "Name";
                StadiumListBox.ValueMember = "Index";

                StadiumGroupBox1.Enabled = true;
                StadiumListBox.Enabled = true;
                StadiumSearchTextBox.Enabled = true;
                StadiumApplyButton.Enabled = true;
                StadiumPictureBox1.Enabled = true;

                StadiumListBox.SelectedValue = 0;
            }
            // if there are Ball.bin
            int ballstatus = ballController.Load(folder);
            if (ballstatus == 0)
            {
                BallListBox.SelectedValue = -1; // if I load database a second time, the first items isn't selected, so I must deselect and then select first item
                BallListBox.DataSource = ballController.BallTable;
                BallListBox.DisplayMember = "Name";
                BallListBox.ValueMember = "Index";

                BallGroupBox1.Enabled = true;
                BallListBox.Enabled = true;
                BallSearchTextBox.Enabled = true;
                BallApplyButton.Enabled = true;
                BallPictureBox1.Enabled = true;

                //addNewBallStrip.Enabled = true;
                //exportBallToolStripMenuItem.Enabled = true;
                //importBallToolStripMenuItem.Enabled = true;

                BallListBox.SelectedValue = 0;
            }
            // if there are Boots.bin
            int bootstatus = bootController.Load(folder);
            if (bootstatus == 0)
            {
                BootListBox.SelectedValue = -1; // if I load database a second time, the first items isn't selected, so I must deselect and then select first item
                BootListBox.DataSource = bootController.BootTable;
                BootListBox.DisplayMember = "Name";
                BootListBox.ValueMember = "Index";

                BootGroupBox1.Enabled = true;
                BootListBox.Enabled = true;
                BootSearchTextBox.Enabled = true;
                BootApplyButton.Enabled = true;
                BootPictureBox1.Enabled = true;

                //addNewBootStrip.Enabled = true;
                //exportBootToolStripMenuItem.Enabled = true;
                //importBootToolStripMenuItem.Enabled = true;

                BootListBox.SelectedValue = 0;
            }
            // if there are Glove.bin
            int glovestatus = gloveController.Load(folder);
            if (glovestatus == 0)
            {
                GloveListBox.SelectedValue = -1; // if I load database a second time, the first items isn't selected, so I must deselect and then select first item
                GloveListBox.DataSource = gloveController.GloveTable;
                GloveListBox.DisplayMember = "Name";
                GloveListBox.ValueMember = "Index";

                GloveGroupBox1.Enabled = true;
                GloveListBox.Enabled = true;
                GloveSearchTextBox.Enabled = true;
                GloveApplyButton.Enabled = true;
                GlovePictureBox1.Enabled = true;

                //addNewGloveStrip.Enabled = true;
                //exportGloveToolStripMenuItem.Enabled = true;
                //importGloveToolStripMenuItem.Enabled = true;

                GloveListBox.SelectedValue = 0;
            }

            toolStripTextBox1.Text = playerController.PlayerTable.Rows.Count + " Players | " + teamController.TeamTable.Rows.Count + " Teams | " + coachController.CoachTable.Rows.Count + " Coaches | "
                + stadiumController.StadiumTable.Rows.Count + " Stadiums | " + ballController.BallTable.Rows.Count + " Balls | " + bootController.BootTable.Rows.Count + " Boots | " + gloveController.GloveTable.Rows.Count + " Gloves";
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you really want to quit?", Application.ProductName.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).Equals(DialogResult.No))
                e.Cancel = true;
            else
            {
                e.Cancel = false;
                CloseMemory();
                //SplashScreen._SplashScreen.Close();
            }
        }

        // ball
        private void BallListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // reset field
            BallNameTextBox.Text = "";
            BallIDTextBox.Text = "";
            BallOrderTextBox.Text = "";
            BallCondListBox.Items.Clear();
            BallPictureBox1.Image = null;

            if (BallListBox.SelectedItem == null)
                return;

            int index = int.Parse(((DataRowView)BallListBox.SelectedItem).Row[0].ToString());

            Ball ball = ballController.LoadBall(index);
            BallIDTextBox.Text = ball.ID.ToString();
            BallNameTextBox.Text = ball.Name;
            BallOrderTextBox.Text = ball.Order.ToString();
        }

        private void BallApplyButton_Click(object sender, EventArgs e)
        {
            if (BallListBox.SelectedItem == null)
                return;

            int index = int.Parse(((DataRowView)BallListBox.SelectedItem).Row[0].ToString());

            // check id
            if (ushort.Parse(BallIDTextBox.Text) > 65535)
            {
                MessageBox.Show("Number exceeds the allowed range!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Ball temp = ballController.LoadBall(index);
            if (ushort.Parse(BallIDTextBox.Text) != temp.ID)
            {
                if (ballController.LoadBallByID(ushort.Parse(BallIDTextBox.Text)) != -1)
                {
                    MessageBox.Show("Ball's already present in the database!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            temp.ID = ushort.Parse(BallIDTextBox.Text);
            temp.Name = BallNameTextBox.Text;
            temp.Order = byte.Parse(BallOrderTextBox.Text);
            int status = ballController.ApplyBall(index, temp);
            if (status != 0)
                MessageBox.Show("Error apply " + temp.Name, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            // update listbox
            ballController.BallTable.Rows[index].SetField("Name", BallNameTextBox.Text);
        }

        // search ball
        private void BallSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            (BallListBox.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", BallSearchTextBox.Text);

            BallListBox.ClearSelected();
            if (BallListBox.Items.Count > 0)
                BallListBox.SelectedIndex = 0;
        }

        private void BallSearchTextBox_Click(object sender, EventArgs e)
        {
            BallSearchTextBox.SelectAll();
            BallSearchTextBox.Focus();
        }

        private void BallCharButton_Click(object sender, EventArgs e)
        {
            Process.Start("charmap.exe");
        }

        // glove
        private void GloveListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // reset field
            GloveName.Text = "";
            GloveIdTextBox.Text = "";
            GloveOrderTextBox.Text = "";
            GlovePictureBox1.Image = null;

            if (GloveListBox.SelectedItem == null)
                return;

            int index = int.Parse(((DataRowView)GloveListBox.SelectedItem).Row[0].ToString());

            Glove glove = gloveController.LoadGlove(index);
            GloveIdTextBox.Text = glove.ID.ToString();
            GloveName.Text = glove.Name;
            GloveOrderTextBox.Text = glove.Order.ToString();
        }

        private void GloveApplyButton_Click(object sender, EventArgs e)
        {
            if (GloveListBox.SelectedItem == null)
                return;

            int index = int.Parse(((DataRowView)GloveListBox.SelectedItem).Row[0].ToString());

            // check id
            if (ushort.Parse(GloveIdTextBox.Text) > 65535)
            {
                MessageBox.Show("Number exceeds the allowed range!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Glove temp = gloveController.LoadGlove(index);
            if (ushort.Parse(GloveIdTextBox.Text) != temp.ID)
            {
                if (gloveController.LoadGloveByID(ushort.Parse(GloveIdTextBox.Text)) != -1)
                {
                    MessageBox.Show("Glove's already present in the database!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            temp.ID = ushort.Parse(GloveIdTextBox.Text);
            temp.Name = GloveName.Text;
            temp.Order = byte.Parse(GloveOrderTextBox.Text);
            int status = gloveController.ApplyGlove(index, temp);
            if (status != 0)
                MessageBox.Show("Error apply " + temp.Name, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            // update listbox
            gloveController.GloveTable.Rows[index].SetField("Name", GloveName.Text);
        }

        private void GloveSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            (GloveListBox.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", GloveSearchTextBox.Text);

            GloveListBox.ClearSelected();
            if (GloveListBox.Items.Count > 0)
                GloveListBox.SelectedIndex = 0;
        }

        private void GloveSearchTextBox_Click(object sender, EventArgs e)
        {
            GloveSearchTextBox.SelectAll();
            GloveSearchTextBox.Focus();
        }

        private void GloveCharButton_Click(object sender, EventArgs e)
        {
            Process.Start("charmap.exe");
        }

        // boot
        private void BootListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // reset field
            BootNameTextBox.Text = "";
            BootIDTextBox.Text = "";
            BootOrderTextBox.Text = "";
            BootPictureBox1.Image = null;

            if (BootListBox.SelectedItem == null)
                return;

            int index = int.Parse(((DataRowView)BootListBox.SelectedItem).Row[0].ToString());

            Boot boot = bootController.LoadBoot(index);
            BootIDTextBox.Text = boot.ID.ToString();
            BootNameTextBox.Text = boot.Name;
            BootOrderTextBox.Text = boot.Order.ToString();
        }

        private void BootApplyButton_Click(object sender, EventArgs e)
        {
            if (BootListBox.SelectedItem == null)
                return;

            int index = int.Parse(((DataRowView)BootListBox.SelectedItem).Row[0].ToString());

            // check id
            if (ushort.Parse(BootIDTextBox.Text) > 65535)
            {
                MessageBox.Show("Number exceeds the allowed range!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Boot temp = bootController.LoadBoot(index);
            if (ushort.Parse(BootIDTextBox.Text) != temp.ID)
            {
                if (bootController.LoadBootByID(ushort.Parse(BootIDTextBox.Text)) != -1)
                {
                    MessageBox.Show("Boots already present in the database!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            temp.ID = ushort.Parse(BootIDTextBox.Text);
            temp.Name = BootNameTextBox.Text;
            temp.Order = byte.Parse(BootOrderTextBox.Text);
            int status = bootController.ApplyBoot(index, temp);
            if (status != 0)
                MessageBox.Show("Error apply " + temp.Name, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            // update listbox
            bootController.BootTable.Rows[index].SetField("Name", BootNameTextBox.Text);
        }

        private void BootSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            (BootListBox.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", BootSearchTextBox.Text);

            BootListBox.ClearSelected();
            if (BootListBox.Items.Count > 0)
                BootListBox.SelectedIndex = 0;
        }

        private void BootSearchTextBox_Click(object sender, EventArgs e)
        {
            BootSearchTextBox.SelectAll();
            BootSearchTextBox.Focus();
        }

        private void BootCharButton_Click(object sender, EventArgs e)
        {
            Process.Start("charmap.exe");
        }

        // coaches
        private void CoachListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // reset field
            CoachNameTextBox.Text = "";
            CoachChineseTextBox.Text = "";
            CoachJapTextBox.Text = "";
            CoachIdTextBox.Text = "";

            if (CoachListBox.SelectedItem == null)
                return;

            int index = int.Parse(((DataRowView)CoachListBox.SelectedItem).Row[0].ToString());

            Coach coach = coachController.LoadCoach(index);
            CoachIdTextBox.Text = coach.ID.ToString();
            CoachNameTextBox.Text = coach.Name;
            CoachChineseTextBox.Text = coach.ChineseName;
            CoachJapTextBox.Text = coach.JapaneseName;
            CoachNationalityComboBox.SelectedIndex = countryController.LoadCountryByID(coach.Nationality);
        }

        private void CoachApplyButton_Click(object sender, EventArgs e)
        {
            if (CoachListBox.SelectedItem == null)
                return;

            int index = int.Parse((((DataRowView)CoachListBox.SelectedItem).Row[0]).ToString());

            if (uint.Parse(CoachIdTextBox.Text) > 1048575)
            {
                MessageBox.Show("Number exceeds the allowed range!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check id
            Coach coach = coachController.LoadCoach(index);
            if (uint.Parse(CoachIdTextBox.Text) != coach.ID)
            {
                if (coachController.LoadCoachByID(uint.Parse(CoachIdTextBox.Text)) != -1)
                {
                    MessageBox.Show("Coach's already present in the database!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //controller.replaceTeamCoachPersister(coach.Id, uint.Parse(CoachIdTextBox.Text));
            }

            coach.ID = uint.Parse(CoachIdTextBox.Text);
            coach.Name = CoachNameTextBox.Text;
            coach.JapaneseName = CoachJapTextBox.Text;
            coach.ChineseName = CoachChineseTextBox.Text;
            coach.Nationality = countryController.LoadCountry(CoachNationalityComboBox.SelectedIndex).ID;
            coachController.ApplyCoach(index, coach);

            // update listbox
            coachController.CoachTable.Rows[index].SetField("Name", CoachNameTextBox.Text);
            //teamCoachComboBox.Items[CoachListBox.SelectedIndex] = coachNameTextBox.Text;
        }

        private void CoachSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            (CoachListBox.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", CoachSearchTextBox.Text);

            CoachListBox.ClearSelected();
            if (CoachListBox.Items.Count > 0)
                CoachListBox.SelectedIndex = 0;
        }

        private void CoachSearchTextBox_Click(object sender, EventArgs e)
        {
            CoachSearchTextBox.SelectAll();
            CoachSearchTextBox.Focus();
        }

        private void CoachCharButton_Click(object sender, EventArgs e)
        {
            Process.Start("charmap.exe");
        }

        // stadium
        private void StadiumListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // reset field
            StadiumNameTextBox.Text = "";
            StadiumIdTextBox.Text = "";
            StadiumJapTextBox.Text = "";
            StadiumPictureBox1.Image = null;

            if (StadiumListBox.SelectedItem == null)
                return;

            int index = int.Parse((((DataRowView)StadiumListBox.SelectedItem).Row[0]).ToString());

            Stadium stadium = stadiumController.LoadStadium(index);
            StadiumNameTextBox.Text = stadium.Name;
            StadiumIdTextBox.Text = stadium.ID.ToString();
            StadiumJapTextBox.Text = stadium.JapaneseName;
            StadiumCapacityTextBox.Text = stadium.Capacity.ToString();
            StadiumCountryComboBox.SelectedIndex = countryController.LoadCountryByID(stadium.Country);
        }

        private void StadiumApplyButton_Click(object sender, EventArgs e)
        {
            if (StadiumListBox.SelectedItem == null)
                return;

            int index = int.Parse((((DataRowView)StadiumListBox.SelectedItem).Row[0]).ToString());

            //nuovo id
            if (ushort.Parse(StadiumIdTextBox.Text) > 65535)
            {
                MessageBox.Show("Number exceeds the allowed range!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Stadium stadium = stadiumController.LoadStadium(index);
            if (ushort.Parse(StadiumIdTextBox.Text) != stadium.ID)
            {
                if (stadiumController.LoadStadiumByID(ushort.Parse(StadiumIdTextBox.Text)) != -1)
                {
                    MessageBox.Show("Stadium's already present in the database!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //controller.replaceTeamStadiumPersister(temp.getId(), ushort.Parse(stadiumIdTextBox.Text));
                //controller.replaceStadiumOrderStadiumPersister(temp.getId(), ushort.Parse(stadiumIdTextBox.Text));
                //controller.replaceStadiumOrderConfStadiumPersister(temp.getId(), ushort.Parse(stadiumIdTextBox.Text));
            }

            stadium.ID = ushort.Parse(StadiumIdTextBox.Text);
            stadium.Capacity = ushort.Parse(StadiumCapacityTextBox.Text);
            stadium.Country = countryController.LoadCountry(StadiumCountryComboBox.SelectedIndex).ID;
            stadium.JapaneseName = StadiumJapTextBox.Text;
            stadium.Name = StadiumNameTextBox.Text;
            stadiumController.ApplyStadium(index, stadium);

            // update listbox
            stadiumController.StadiumTable.Rows[index].SetField("Name", StadiumNameTextBox.Text);
            //teamStadiumComboBox.Items[index] = stadiumNameTextBox.Text;
        }

        private void StadiumSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            (StadiumListBox.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", StadiumSearchTextBox.Text);

            StadiumListBox.ClearSelected();
            if (StadiumListBox.Items.Count > 0)
                StadiumListBox.SelectedIndex = 0;
        }

        private void StadiumSearchTextBox_Click(object sender, EventArgs e)
        {
            StadiumSearchTextBox.SelectAll();
            StadiumSearchTextBox.Focus();
        }

        private void StadiumCharButton_Click(object sender, EventArgs e)
        {
            Process.Start("charmap.exe");
        }

        // player
        private void ReadPlayer(Player player)
        {
            PlayerNameTextBox.Text = player.Name;
            PlayerShirtNameTextBox.Text = player.ShirtName;
            PlayerIDLabel.Text = player.ID.ToString();
            //PlayerTypeLabel.Text = player.getStringFake();
            PlayerAgeLabel.Text = player.Age.ToString();
            PlayerWeightLabel.Text = player.Weight.ToString();
            PlayerHeightLabel.Text = player.Height.ToString();
            PlayerFormLabel.Text = ((Player.PlayerForm)(player.Form)).ToString();
            PlayerAccLabel.Text = ((Player.WeakFoot)(player.WeakFootAccuracy)).ToString().Replace('_', ' ');
            PlayerUseLabel.Text = ((Player.WeakFoot)(player.WeakFootUsage)).ToString().Replace('_', ' ');
            PlayerInjuryLabel.Text = ((Player.InjuryRes)(player.InjuryResistance)).ToString();

            OffensiveProwessValueLabel.Text = player.OffensiveAwareness.ToString();
            BallControlValueLabel.Text = player.BallControl.ToString();
            DribblingValueLabel.Text = player.Dribbling.ToString();
            TightPossessionValueLabel.Text = player.TightPossession.ToString();
            LowPassValueLabel.Text = player.LowPass.ToString();
            LoftedPassValueLabel.Text = player.LoftedPass.ToString();
            FinishingValueLabel.Text = player.Finishing.ToString();
            HeadingValueLabel.Text = player.Heading.ToString();
            SetPieceTakingValueLabel.Text = player.SetPieceTaking.ToString();
            CurlValueLabel.Text = player.Curl.ToString();
            SpeedValueLabel.Text = player.Speed.ToString();
            AccelerationValueLabel.Text = player.Acceleration.ToString();
            KickingPowerValueLabel.Text = player.KickingPower.ToString();
            JumpValueLabel.Text = player.Jump.ToString();
            PhysicalContactValueLabel.Text = player.PhysicalContact.ToString();
            BalanceValueLabel.Text = player.Balance.ToString();
            StaminaValueLabel.Text = player.Stamina.ToString();
            DefensiveAwarenessValueLabel.Text = player.DefensiveAwareness.ToString();
            TacklingValueLabel.Text = player.Tackling.ToString();
            DefensiveEngangementValueLabel.Text = player.DefensiveEngangement.ToString();
            AggressionValueLabel.Text = player.Aggression.ToString();
            GKAwarenessValueLabel.Text = player.GKAwareness.ToString();
            GKCatchingValueLabel.Text = player.GKCatching.ToString();
            GKParryingValueLabel.Text = player.GKParrying.ToString();
            GKReflexesValueLabel.Text = player.GKReflexes.ToString();
            GKReachValueLabel.Text = player.GKReach.ToString();
            PlayerFootLabel.Text = player.StroongerFoot ? "Left" : "Right";
            PlayerHandLabel.Text = player.StrongerHand ? "Left" : "Right";
            //giocatoreSquadra.Text = controller.getStringClubTeamOfPlayer(player.getId(), 0);
            //giocatoreNazionale.Text = controller.getStringClubTeamOfPlayer(player.getId(), 1);
            PlayerNationalityComboBox.SelectedIndex = countryController.LoadCountryByID(player.NationalityID1);
            PlayerRankLabel.Text = CalculateOverall.Overall(player.RegisteredPosition, player.GKReach, player.GKCatching, player.GKAwareness, player.Balance, player.Jump, player.Heading, player.DefensiveAwareness, player.Tackling, player.Speed, player.Stamina, player.OffensiveAwareness, player.BallControl, player.Dribbling, player.LoftedPass, player.LowPass, player.Aggression, player.SetPieceTaking, player.Finishing, player.KickingPower).ToString();
            UtilGUI.ChangeBackColorLabel(PlayerRankLabel);

            //controllerFm
            //controllerFm.setPlayer(temp);
        }

        private void PlayerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlayerNationalTextBox.Text = "";
            PlayerClubTextBox.Text = "";
            PlayerNumberTextBox.Text = "";

            if (PlayerListBox.SelectedItem == null)
                return;

            ReadPlayer(playerController.LoadPlayer(PlayerListBox.SelectedIndex));
        }

        // Change color Label
        private void OffensiveProwessLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(OffensiveProwessValueLabel);
        }

        private void BallControlLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(BallControlValueLabel);
        }

        private void DribblingLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(DribblingValueLabel);
        }

        private void TightPossessionLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(TightPossessionValueLabel);
        }

        private void LowPassLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(LowPassValueLabel);
        }

        private void LoftedPassLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(LoftedPassValueLabel);
        }

        private void FinishingLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(FinishingValueLabel);
        }

        private void HeadingLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(HeadingValueLabel);
        }

        private void SetPieceTakingLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(SetPieceTakingValueLabel);
        }

        private void CurlLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(CurlValueLabel);
        }

        private void SpeedLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(SpeedValueLabel);
        }

        private void AccelerationLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(AccelerationValueLabel);
        }

        private void KickingPowerLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(KickingPowerValueLabel);
        }

        private void JumpLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(JumpValueLabel);
        }

        private void PhysicalContactLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(PhysicalContactValueLabel);
        }

        private void BalanceLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(BalanceValueLabel);
        }

        private void StaminaLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(StaminaValueLabel);
        }

        private void DefensiveAwarenessLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(DefensiveAwarenessValueLabel);
        }

        private void TacklingLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(TacklingValueLabel);
        }

        private void DefensiveEngangementLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(DefensiveEngangementValueLabel);
        }

        private void AggressionLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(AggressionValueLabel);
        }

        private void GKAwarenessLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(GKAwarenessValueLabel);
        }

        private void GKCatchingLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(GKCatchingValueLabel);
        }

        private void GKParryingLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(GKParryingValueLabel);
        }

        private void GKReflexesLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(GKReflexesValueLabel);
        }

        private void GKReachLabel_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeColorLabel(GKReachValueLabel);
        }

        // change player name
        private void PlayerNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int index = playerController.LoadPlayerByID(uint.Parse(PlayerIDLabel.Text));
                Player player = playerController.LoadPlayer(index);
                player.Name = PlayerNameTextBox.Text;
                playerController.ApplyPlayer(index, player);
                //UpdateTeamView(player.getId(), player.getId(), name);
                // update listbox
                playerController.PlayerTable.Rows[index].SetField("Name", PlayerNameTextBox.Text);
            }
        }

        // change shirt name
        private void PlayerShirtTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int index = playerController.LoadPlayerByID(uint.Parse(PlayerIDLabel.Text));
                Player player = playerController.LoadPlayer(index);
                player.ShirtName = PlayerShirtNameTextBox.Text;
                playerController.ApplyPlayer(index, player);
            }
        }

        // change nationality
        private void PlayerNationalityComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int index = playerController.LoadPlayerByID(uint.Parse(PlayerIDLabel.Text));
            Player player = playerController.LoadPlayer(index);
            player.NationalityID1 = countryController.LoadCountry(PlayerNationalityComboBox.SelectedIndex).ID;
            playerController.ApplyPlayer(index, player);
        }

        private void PlayerListBox_MouseDown(object sender, MouseEventArgs e)
        {
            //Doppio clicco
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks >= 2)
                {
                    int index = playerController.LoadPlayerByID(uint.Parse(PlayerIDLabel.Text));
                    Stats s = new Stats(playerController.LoadPlayer(index), playerController, teamController, countryController);
                    s.ShowDialog();
                }
            }
        }
    }
}
