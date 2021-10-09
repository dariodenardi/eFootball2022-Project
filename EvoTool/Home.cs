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
        private int bitRecognized = 0;
        private BallController ballController;
        private GloveController gloveController;

        private void Home_Load(object sender, EventArgs e)
        {
            ballController = new BallController();
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
                ballController.CloseMemory();
                gloveController.CloseMemory();
                ResetField();
                path = fbd.SelectedPath;
                OpenDatabase(path);

                EnableStrip();
            }
        }

        private void EnableStrip()
        {
            // enable buttons
            // if there are files found
            if (ballController.BallTable.Rows.Count != 0)
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

            gloveListBox.Enabled = false;
            gloveGroupBox1.Enabled = false;
            gloveApplyButton.Enabled = false;
            gloveSearchTextBox.Enabled = false;
            addNewGloveStrip.Enabled = false;
            exportGloveToolStripMenuItem.Enabled = false;
            importGloveToolStripMenuItem.Enabled = false;
            glovePictureBox1.Enabled = false;

            bootGroupBox1.Enabled = false;
            bootListBox.Enabled = false;
            bootSearchTextBox.Enabled = false;
            bootApplyButton.Enabled = false;
            addNewBootStrip.Enabled = false;
            exportBootToolStripMenuItem.Enabled = false;
            importBootToolStripMenuItem.Enabled = false;
            bootPictureBox1.Enabled = false;

            ballController.BallTable.Clear();
            ballCondGroupBox1.Enabled = false;
            exportBallCondToolStripMenuItem.Enabled = false;
            importBallCondToolStripMenuItem.Enabled = false;

            ballGroupBox1.Enabled = false;
            BallListBox.Enabled = false;
            BallSearchTextBox.Enabled = false;
            BallApplyButton.Enabled = false;
            ballPictureBox1.Enabled = false;
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
            coachApplyButton.Enabled = false;
            coachSearchTextBox.Enabled = false;
            coachListBox.Enabled = false;
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

            ballCondListBox.Items.Clear();
            ballCondCompComboBox.Items.Clear();
            stadiumCountryComboBox.Items.Clear();
            playersBox.Items.Clear();
            teamBox1.Items.Clear();
            teamBox2.Items.Clear();
            competitionsBox.Items.Clear();
            giocatoreNationality.Items.Clear();
            teamCountryComboBox.Items.Clear();
            coachNationalityComboBox.Items.Clear();
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
            //salvo file
            if (ballController.BallTable.Rows.Count != 0)
            {
                int status = ballController.Save(path, bitRecognized);
                if (status != 0)
                    MessageBox.Show("Error saved Ball.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (gloveController.GloveTable.Rows.Count != 0)
            {
                int status = gloveController.Save(path, bitRecognized);
                if (status != 0)
                    MessageBox.Show("Error saved Glove.bin", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenDatabase(string folder)
        {
            if (bitRecognized == 0)
                this.Text = "EvoTool 2022 - Pc Mode";
            else if (bitRecognized == 1)
                this.Text = "EvoTool 2022 - Xbox Mode";
            else if (bitRecognized == 2)
                this.Text += "EvoTool 2022 - Ps3 Mode";

            int status = ballController.Load(folder, bitRecognized);
            // if there are Ball.bin
            if (status == 0)
            {
                BallListBox.DataSource = ballController.BallTable;
                BallListBox.DisplayMember = "Name";
                BallListBox.ValueMember = "Index";

                ballGroupBox1.Enabled = true;
                BallListBox.Enabled = true;
                BallSearchTextBox.Enabled = true;
                BallApplyButton.Enabled = true;
                ballPictureBox1.Enabled = true;

                //addNewBallStrip.Enabled = true;
                //exportBallToolStripMenuItem.Enabled = true;
                //importBallToolStripMenuItem.Enabled = true;
            }
            int glovestatus = gloveController.Load(folder, bitRecognized);
            // if there are Glove.bin
            if (glovestatus == 0)
            {
                gloveListBox.DataSource = gloveController.GloveTable;
                gloveListBox.DisplayMember = "Name";
                gloveListBox.ValueMember = "Index";

                gloveGroupBox1.Enabled = true;
                gloveListBox.Enabled = true;
                gloveSearchTextBox.Enabled = true;
                gloveApplyButton.Enabled = true;
                glovePictureBox1.Enabled = true;

                //addNewGloveStrip.Enabled = true;
                //exportGloveToolStripMenuItem.Enabled = true;
                //importGloveToolStripMenuItem.Enabled = true;
            }

            toolStripTextBox1.Text = playersBox.Items.Count + " Players | " + 0 + " Teams | " + 0 + " Coaches | "
                + 0 + " Stadiums | " + ballController.BallTable.Rows.Count + " Balls | " + 0 + " Boots | " + gloveController.GloveTable.Rows.Count + " Gloves";
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ball
        private void BallListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // reset field
            BallNameTextBox.Text = "";
            BallIDTextBox.Text = "";
            BallOrderTextBox.Text = "";
            ballCondListBox.Items.Clear();
            ballPictureBox1.Image = null;

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
                if (ballController.LoadBallById(ushort.Parse(BallIDTextBox.Text)) != 0)
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

        //glove
        private void gloveListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // reset field
            gloveName.Text = "";
            gloveIdTextBox.Text = "";
            gloveOrderTextBox.Text = "";
            ballCondListBox.Items.Clear();
            glovePictureBox1.Image = null;

            if (gloveListBox.SelectedItem == null)
                return;

            int index = int.Parse(((DataRowView)gloveListBox.SelectedItem).Row[0].ToString());

            Glove glove = gloveController.LoadGlove(index);
            gloveIdTextBox.Text = glove.Id.ToString();
            gloveName.Text = glove.Name;
            gloveOrderTextBox.Text = glove.Order.ToString();
        }

        private void gloveApplyButton_Click(object sender, EventArgs e)
        {
            if (gloveListBox.SelectedItem == null)
                return;

            int index = int.Parse(((DataRowView)gloveListBox.SelectedItem).Row[0].ToString());

            // check id
            if (ushort.Parse(gloveIdTextBox.Text) > 65535)
            {
                MessageBox.Show("Number exceeds the allowed range!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Glove temp = gloveController.LoadGlove(index);
            if (ushort.Parse(gloveIdTextBox.Text) != temp.Id)
            {
                if (gloveController.LoadGloveById(ushort.Parse(gloveIdTextBox.Text)) != 0)
                {
                    MessageBox.Show("Glove's already present in the database!", Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            temp.Id = ushort.Parse(gloveIdTextBox.Text);
            temp.Name = gloveName.Text;
            temp.Order = byte.Parse(gloveOrderTextBox.Text);
            int status = gloveController.ApplyGlove(index, temp);
            if (status != 0)
                MessageBox.Show("Error apply " + temp.Name, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            // update listbox
            gloveController.GloveTable.Rows[index].SetField("Name", gloveName.Text);
        }

        private void gloveSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            (gloveListBox.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", gloveSearchTextBox.Text);

            gloveListBox.ClearSelected();
            if (gloveListBox.Items.Count > 0)
                gloveListBox.SelectedIndex = 0;
        }

        private void gloveSearchTextBox_Click(object sender, EventArgs e)
        {
            gloveSearchTextBox.SelectAll();
            gloveSearchTextBox.Focus();
        }
    }
}
