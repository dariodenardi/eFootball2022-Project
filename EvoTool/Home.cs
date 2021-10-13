using EvoTool.Controllers;
using EvoTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private BallController ballController;
        private GloveController gloveController;
        private BootController bootController;
        private CoachController coachController;

        private void Home_Load(object sender, EventArgs e)
        {
            countryController = new CountryController();
            ballController = new BallController();
            gloveController = new GloveController();
            bootController = new BootController();
            coachController = new CoachController();
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
            ballController.CloseMemory();
            gloveController.CloseMemory();
            bootController.CloseMemory();
            coachController.CloseMemory();
        }

        private void EnableStrip()
        {
            // enable buttons
            // if there are files found
            if (ballController.BallTable.Rows.Count != 0 || gloveController.GloveTable.Rows.Count != 0 || bootController.BootTable.Rows.Count != 0 || coachController.CoachTable.Rows.Count != 0)
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

            stadiumListBox.Enabled = false;
            stadiumGroupBox1.Enabled = false;
            stadiumGroupBox2.Enabled = false;
            stadiumSearchTextBox.Enabled = false;
            stadiumApplyButton.Enabled = false;
            teamStadiumComboBox.Enabled = false;
            addNewStadiumStrip.Enabled = false;
            importStadiumToolStripMenuItem.Enabled = false;
            exportStadiumToolStripMenuItem.Enabled = false;
            stadiumPictureBox1.Enabled = false;

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
            coachPictureBox1.Enabled = false;

            teamListBox.Enabled = false;
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
            stadiumCountryComboBox.Items.Clear();
            playersBox.Items.Clear();
            teamBox1.Items.Clear();
            teamBox2.Items.Clear();
            competitionsBox.Items.Clear();
            giocatoreNationality.Items.Clear();
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
            if (ballController.BallTable.Rows.Count != 0)
            {
                int status = ballController.Save(path);
                if (status != 0)
                    MessageBox.Show("Error saved Ball.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (gloveController.GloveTable.Rows.Count != 0)
            {
                int status = gloveController.Save(path);
                if (status != 0)
                    MessageBox.Show("Error saved Glove.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (bootController.BootTable.Rows.Count != 0)
            {
                int status = bootController.Save(path);
                if (status != 0)
                    MessageBox.Show("Error saved Boots.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenDatabase(string folder)
        {
            this.Text = "EvoTool 2022 - Pc Mode";

            int countrystatus = countryController.Load(folder);
            // if there are Country.bin
            int ballstatus = ballController.Load(folder);
            // if there are Ball.bin
            if (ballstatus == 0)
            {
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
            }
            int glovestatus = gloveController.Load(folder);
            // if there are Glove.bin
            if (glovestatus == 0)
            {
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
            }
            int bootstatus = bootController.Load(folder);
            // if there are Boots.bin
            if (bootstatus == 0)
            {
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
            }
            int opencoach = coachController.Load(folder);
            if (opencoach == 0 && countrystatus == 0)
            {
                CoachNationalityComboBox.DataSource = countryController.CountryTable;
                CoachNationalityComboBox.DisplayMember = "Name";
                CoachNationalityComboBox.ValueMember = "Index";

                CoachListBox.DataSource = coachController.CoachTable;
                CoachListBox.DisplayMember = "Name";
                CoachListBox.ValueMember = "Index";

                coachGroupBox1.Enabled = true;
                CoachListBox.Enabled = true;
                CoachSearchTextBox.Enabled = true;
            }

            toolStripTextBox1.Text = playersBox.Items.Count + " Players | " + 0 + " Teams | " + coachController.CoachTable.Rows.Count + " Coaches | "
                + 0 + " Stadiums | " + ballController.BallTable.Rows.Count + " Balls | " + bootController.BootTable.Rows.Count + " Boots | " + gloveController.GloveTable.Rows.Count + " Gloves";
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
            BallIDTextBox.Text = ball.Id.ToString();
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
            if (ushort.Parse(BallIDTextBox.Text) != temp.Id)
            {
                if (ballController.LoadBallById(ushort.Parse(BallIDTextBox.Text)) != -1)
                {
                    MessageBox.Show("Ball's already present in the database!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            temp.Id = ushort.Parse(BallIDTextBox.Text);
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
            GloveIdTextBox.Text = glove.Id.ToString();
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
            if (ushort.Parse(GloveIdTextBox.Text) != temp.Id)
            {
                if (gloveController.LoadGloveById(ushort.Parse(GloveIdTextBox.Text)) != -1)
                {
                    MessageBox.Show("Glove's already present in the database!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            temp.Id = ushort.Parse(GloveIdTextBox.Text);
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
        //boot
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
            BootIDTextBox.Text = boot.Id.ToString();
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
            if (ushort.Parse(BootIDTextBox.Text) != temp.Id)
            {
                if (bootController.LoadBootById(ushort.Parse(BootIDTextBox.Text)) != 0)
                {
                    MessageBox.Show("Boots already present in the database!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            temp.Id = ushort.Parse(BootIDTextBox.Text);
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
            CoachIdTextBox.Text = coach.Id.ToString();
            CoachNameTextBox.Text = coach.Name;
            CoachChineseTextBox.Text = coach.ChineseName;
            CoachJapTextBox.Text = coach.JapaneseName;
            CoachNationalityComboBox.SelectedIndex = countryController.LoadCountryById(coach.Nationality);
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
    }
}
