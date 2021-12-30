using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvoTool.Controllers;
using EvoTool.Models;
using EvoTool.Utils;

namespace EvoTool
{
    public partial class Stats : Form
    {
        private Player player;
        private PlayerController playerController;
        private TeamController teamController;
        private CountryController countryController;

        public Stats(Player player, PlayerController playerController, TeamController teamController, CountryController countryController)
        {
            InitializeComponent();
            this.player = player;
            this.playerController = playerController;
            this.teamController = teamController;
            this.countryController = countryController;
        }

        private void Giocatore_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;

            NationalityComboBox.DataSource = countryController.CountryTable;
            NationalityComboBox.DisplayMember = "Name";
            NationalityComboBox.ValueMember = "Index";

            SecondNationalityComboBox.BindingContext = new BindingContext();
            SecondNationalityComboBox.DataSource = countryController.CountryTable;
            SecondNationalityComboBox.DisplayMember = "Name";
            SecondNationalityComboBox.ValueMember = "Index";

            YouthClubComboBox.DataSource = teamController.TeamTable;
            YouthClubComboBox.DisplayMember = "Name";
            YouthClubComboBox.ValueMember = "Index";

            PlayingStyleComboBox.Items.Add("None");
            PlayingStyleComboBox.Items.Add("Goal Poacher");
            PlayingStyleComboBox.Items.Add("Dummy Runner");
            PlayingStyleComboBox.Items.Add("Fox in the Box");
            PlayingStyleComboBox.Items.Add("Prolific Winger");
            PlayingStyleComboBox.Items.Add("Classic No. 10");
            PlayingStyleComboBox.Items.Add("Hole Player");
            PlayingStyleComboBox.Items.Add("Box-To-Box");
            PlayingStyleComboBox.Items.Add("Anchor Man");
            PlayingStyleComboBox.Items.Add("The Destroyer");
            PlayingStyleComboBox.Items.Add("Extra Frontman");
            PlayingStyleComboBox.Items.Add("Offensive Full-Back");
            PlayingStyleComboBox.Items.Add("Defensive Full-Back");
            PlayingStyleComboBox.Items.Add("Deep-Lying Forward");
            PlayingStyleComboBox.Items.Add("Creative Playmaker");
            PlayingStyleComboBox.Items.Add("Build Up");
            PlayingStyleComboBox.Items.Add("Offensive Goalkeeper");
            PlayingStyleComboBox.Items.Add("Defensive Goalkeeper");
            PlayingStyleComboBox.Items.Add("Roaming Flank");
            PlayingStyleComboBox.Items.Add("Cross Specialist");
            PlayingStyleComboBox.Items.Add("Orchestrator");
            PlayingStyleComboBox.Items.Add("Full-back Finisher");
            PlayingStyleComboBox.Items.Add("Target Man");

            StrongFootComboBox.Items.Add("Right");
            StrongFootComboBox.Items.Add("Left");

            StrongHandComboBox.Items.Add("Right");
            StrongHandComboBox.Items.Add("Left");

            FormComboBox.Items.Add("Inconsistent");
            FormComboBox.Items.Add("Standard");
            FormComboBox.Items.Add("Unwavering");

            WeAccComboBox.Items.Add("Slightly Low");
            WeAccComboBox.Items.Add("Medium");
            WeAccComboBox.Items.Add("High");
            WeAccComboBox.Items.Add("Very High");

            WeUsageComboBox.Items.Add("Slightly Low");
            WeUsageComboBox.Items.Add("Medium");
            WeUsageComboBox.Items.Add("High");
            WeUsageComboBox.Items.Add("Very High");

            InjuryComboBox.Items.Add("Low");
            InjuryComboBox.Items.Add("Medium");
            InjuryComboBox.Items.Add("High");

            PositionComboBox.Items.Add("GK");
            PositionComboBox.Items.Add("CB");
            PositionComboBox.Items.Add("LB");
            PositionComboBox.Items.Add("RB");
            PositionComboBox.Items.Add("DMF");
            PositionComboBox.Items.Add("CMF");
            PositionComboBox.Items.Add("LMF");
            PositionComboBox.Items.Add("RMF");
            PositionComboBox.Items.Add("AMF");
            PositionComboBox.Items.Add("LWF");
            PositionComboBox.Items.Add("RWF");
            PositionComboBox.Items.Add("SS");
            PositionComboBox.Items.Add("CF");

            GKComboBox.Items.Add("C");
            GKComboBox.Items.Add("B");
            GKComboBox.Items.Add("A");
            CBComboBox.Items.Add("C");
            CBComboBox.Items.Add("B");
            CBComboBox.Items.Add("A");
            LBComboBox.Items.Add("C");
            LBComboBox.Items.Add("B");
            LBComboBox.Items.Add("A");
            RBComboBox.Items.Add("C");
            RBComboBox.Items.Add("B");
            RBComboBox.Items.Add("A");
            DMFComboBox.Items.Add("C");
            DMFComboBox.Items.Add("B");
            DMFComboBox.Items.Add("A");
            CMFComboBox.Items.Add("C");
            CMFComboBox.Items.Add("B");
            CMFComboBox.Items.Add("A");
            LMFComboBox.Items.Add("C");
            LMFComboBox.Items.Add("B");
            LMFComboBox.Items.Add("A");
            AMFComboBox.Items.Add("C");
            AMFComboBox.Items.Add("B");
            AMFComboBox.Items.Add("A");
            RMFComboBox.Items.Add("C");
            RMFComboBox.Items.Add("B");
            RMFComboBox.Items.Add("A");
            LWFComboBox.Items.Add("C");
            LWFComboBox.Items.Add("B");
            LWFComboBox.Items.Add("A");
            RWFComboBox.Items.Add("C");
            RWFComboBox.Items.Add("B");
            RWFComboBox.Items.Add("A");
            SSComboBox.Items.Add("C");
            SSComboBox.Items.Add("B");
            SSComboBox.Items.Add("A");
            CFComboBox.Items.Add("C");
            CFComboBox.Items.Add("B");
            CFComboBox.Items.Add("A");

            AdjustTextBox.Text = "1";

            for (int i = 1; i <= 20; i++)
                FreeKickMotionComboBox.Items.Add(i.ToString());

            for (int i = 1; i <= 5; i++)
                DribHunchingComboBox.Items.Add(i.ToString());

            for (int i = 1; i <= 10; i++)
                DribArmMoveComboBox.Items.Add(i.ToString());

            for (int i = 1; i <= 5; i++)
                RunHunchingComboBox.Items.Add(i.ToString());

            for (int i = 1; i <= 10; i++)
                RunArmMoveComboBox.Items.Add(i.ToString());

            for (int i = 1; i <= 7; i++)
                PenaltyKickMotionComboBox.Items.Add(i.ToString());

            for (int i = 1; i <= 10; i++)
                CornerKickMotionComboBox.Items.Add(i.ToString());

            for (int i = 1; i <= 4; i++)
                DribblingMotionComboBox.Items.Add(i.ToString());

            for (int i = 0; i <= 176; i++)
                GoalCelebComboBox.Items.Add(i.ToString());

            this.Text = "Player: " + player.Name;
            IDTextBox.Text = player.ID.ToString();
            //typeTextBox.Text = player.getStringFake();
            //if (typeTextBox.Text == "Fake")
            //    fakeButton.Visible = true;
            //else
            //    fakeButton.Visible = false;
            NameTextBox.Text = player.Name;
            JapaneseTextBox.Text = player.JapaneseName;
            ChineseNameTextBox.Text = player.ChineseName;
            ShirtNameClubTextBox.Text = player.ClubShirtName;
            ShirtNameNationalTextBox.Text = player.ShirtName;
            
            PlayingStyleComboBox.Text = ((Player.PlayStyle)player.PlayingStyle).ToString().Replace("___", ". ").Replace("__", "-").Replace('_', ' ');
            NationalityComboBox.SelectedIndex = countryController.LoadCountryByID(player.NationalityID1);
            SecondNationalityComboBox.SelectedIndex = countryController.LoadCountryByID(player.NationalityID2);
            AgeTextBox.Text = player.Age.ToString();
            HeightTextBox.Text = player.Height.ToString();
            WeightTextBox.Text = player.Weight.ToString();
            StrongFootComboBox.Text = player.StroongerFoot ? "Left" : "Right";
            StrongHandComboBox.Text = player.StrongerHand ? "Left" : "Right";
            FormComboBox.Text = ((Player.PlayerForm)player.Form).ToString();
            WeAccComboBox.Text = ((Player.WeakFoot)player.WeakFootAccuracy).ToString().Replace('_', ' ');
            WeUsageComboBox.Text = ((Player.WeakFoot)player.WeakFootUsage).ToString().Replace('_', ' ');
            InjuryComboBox.Text = ((Player.InjuryRes)player.InjuryResistance).ToString();
            WinnerGoldenBallCheckBox.Checked = player.BallonDorWinner;

            OffensiveProwessTextBox.Text = player.OffensiveAwareness.ToString();
            BallControlTextBox.Text = player.BallControl.ToString();
            DribblingTextBox.Text = player.Dribbling.ToString();
            TightPossessionTextBox.Text = player.TightPossession.ToString();
            LowPassTextBox.Text = player.LowPass.ToString();
            LoftedPassTextBox.Text = player.LoftedPass.ToString();
            FinishingTextBox.Text = player.Finishing.ToString();
            HeadingTextBox.Text = player.Heading.ToString();
            SetPieceTakingTextBox.Text = player.SetPieceTaking.ToString();
            CurlTextBox.Text = player.Curl.ToString();
            SpeedTextBox.Text = player.Speed.ToString();
            AccelerationTextBox.Text = player.Acceleration.ToString();
            KickingPowerTextBox.Text = player.KickingPower.ToString();
            JumpTextBox.Text = player.Jump.ToString();
            PhysicalContactTextBox.Text = player.PhysicalContact.ToString();
            BalanceTextBox.Text = player.Balance.ToString();
            StaminaTextBox.Text = player.Stamina.ToString();
            DefensiveAwarenessTextBox.Text = player.DefensiveAwareness.ToString();
            TacklingTextBox.Text = player.Tackling.ToString();
            DefensiveEngangementTextBox.Text = player.DefensiveEngangement.ToString();
            AggressionTextBox.Text = player.Aggression.ToString();
            GKAwarenessTextBox.Text = player.GKAwareness.ToString();
            GKCatchingTextBox.Text = player.GKCatching.ToString();
            GKParryingTextBox.Text = player.GKParrying.ToString();
            GKReflexesTextBox.Text = player.GKReflexes.ToString();
            GKReachTextBox.Text = player.GKReach.ToString();

            RunArmMoveComboBox.Text = player.RunningArmMovement.ToString();
            RunHunchingComboBox.Text = player.RunningHunching.ToString();
            CornerKickMotionComboBox.Text = player.CornerKickMotion.ToString();
            PenaltyKickMotionComboBox.Text = player.PenaltyKickMotion.ToString();
            FreeKickMotionComboBox.Text = player.FreeKickMotion.ToString();
            DribArmMoveComboBox.Text = player.DribblingArmMovement.ToString();
            DribHunchingComboBox.Text = player.DribblingHunching.ToString();
            GoalCelebComboBox.Text = player.GoalCelebration.ToString();
            DribblingMotionComboBox.Text = player.DribblingMotion.ToString();

            PositionComboBox.Text = ((Player.PlayerRegisteredPosition)(player.RegisteredPosition)).ToString();
            GKComboBox.Text = ((Player.PlayerPosition)player.PlayableGK).ToString();
            CBComboBox.Text = ((Player.PlayerPosition)player.PlayableCB).ToString();
            LBComboBox.Text = ((Player.PlayerPosition)player.PlayableLB).ToString();
            RBComboBox.Text = ((Player.PlayerPosition)player.PlayableRB).ToString();
            DMFComboBox.Text = ((Player.PlayerPosition)player.PlayableDMF).ToString();
            CMFComboBox.Text = ((Player.PlayerPosition)player.PlayableCMF).ToString();
            LMFComboBox.Text = ((Player.PlayerPosition)player.PlayableLMF).ToString();
            AMFComboBox.Text = ((Player.PlayerPosition)player.PlayableAMF).ToString();
            RMFComboBox.Text = ((Player.PlayerPosition)player.PlayableRMF).ToString();
            LWFComboBox.Text = ((Player.PlayerPosition)player.PlayableLWF).ToString();
            RWFComboBox.Text = ((Player.PlayerPosition)player.PlayableRWF).ToString();
            SSComboBox.Text = ((Player.PlayerPosition)player.PlayableSS).ToString();
            CFComboBox.Text = ((Player.PlayerPosition)player.PlayableCF).ToString();

            SoleControlCheckBox.Checked = player.SoleControl ? true : false;
        }

        // don't enter a letters
        private void NoLetterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) & (!char.IsNumber(e.KeyChar.ToString(), 0)))
                e.Handled = true;
        }

        // Change color textBox
        private void OffensiveProwessTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(OffensiveProwessTextBox);
        }

        private void BallControlTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(BallControlTextBox);
        }

        private void DribblingTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(DribblingTextBox);
        }

        private void TightPossessionTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(TightPossessionTextBox);
        }

        private void LowPassTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(LowPassTextBox);
        }

        private void LoftedPassTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(LoftedPassTextBox);
        }

        private void FinishingTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(FinishingTextBox);
        }

        private void HeadingTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(HeadingTextBox);
        }

        private void SetPieceTakingTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(SetPieceTakingTextBox);
        }

        private void CurlTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(CurlTextBox);
        }

        private void SpeedTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(SpeedTextBox);
        }

        private void AccelerationTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(AccelerationTextBox);
        }

        private void KickingPowerTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(KickingPowerTextBox);
        }

        private void JumpTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(JumpTextBox);
        }

        private void PhysicalContactTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(PhysicalContactTextBox);
        }

        private void BalanceTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(BalanceTextBox);
        }

        private void StaminaTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(StaminaTextBox);
        }

        private void DefensiveAwarenessTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(DefensiveAwarenessTextBox);
        }

        private void TacklingTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(TacklingTextBox);
        }

        private void DefensiveEngangementTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(DefensiveEngangementTextBox);
        }

        private void AggressionTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(AggressionTextBox);
        }

        private void GKAwarenessTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(GKAwarenessTextBox);
        }

        private void GKCatchingTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(GKCatchingTextBox);
        }

        private void GKParryingTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(GKParryingTextBox);
        }

        private void GKReflexesTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(GKReflexesTextBox);
        }

        private void GKReachTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(GKReachTextBox);
        }

        private void CharButton_Click(object sender, EventArgs e)
        {
            Process.Start("charmap.exe");
        }

        // adjust stats
        private void AdjustTextBox_TextChanged(object sender, EventArgs e)
        {
            UtilGUI.ChangeBackColorTextBox(AdjustTextBox);
        }

        private void AdjustEqualButton_Click(object sender, EventArgs e)
        {
            OffensiveProwessTextBox.Text = "40";
            BallControlTextBox.Text = "40";
            DribblingTextBox.Text = "40";
            TightPossessionTextBox.Text = "40";
            LowPassTextBox.Text = "40";
            LoftedPassTextBox.Text = "40";
            FinishingTextBox.Text = "40";
            HeadingTextBox.Text = "40";
            SetPieceTakingTextBox.Text = "40";
            CurlTextBox.Text = "40";
            SpeedTextBox.Text = "40";
            AccelerationTextBox.Text = "40";
            KickingPowerTextBox.Text = "40";
            JumpTextBox.Text = "40";
            PhysicalContactTextBox.Text = "40";
            BalanceTextBox.Text = "40";
            StaminaTextBox.Text = "40";
            DefensiveAwarenessTextBox.Text = "40";
            TacklingTextBox.Text = "40";
            DefensiveEngangementTextBox.Text = "40";
            AggressionTextBox.Text = "40";
            GKAwarenessTextBox.Text = "40";
            GKCatchingTextBox.Text = "40";
            GKParryingTextBox.Text = "40";
            GKReflexesTextBox.Text = "40";
            GKReachTextBox.Text = "40";
        }

        private void CheckField()
        {
            if (int.Parse(OffensiveProwessTextBox.Text) < 40)
                OffensiveProwessTextBox.Text = "40";
            if (int.Parse(BallControlTextBox.Text) < 40)
                BallControlTextBox.Text = "40";
            if (int.Parse(DribblingTextBox.Text) < 40)
                DribblingTextBox.Text = "40";
            if (int.Parse(TightPossessionTextBox.Text) < 40)
                TightPossessionTextBox.Text = "40";
            if (int.Parse(LowPassTextBox.Text) < 40)
                LowPassTextBox.Text = "40";
            if (int.Parse(LoftedPassTextBox.Text) < 40)
                LoftedPassTextBox.Text = "40";
            if (int.Parse(FinishingTextBox.Text) < 40)
                FinishingTextBox.Text = "40";
            if (int.Parse(HeadingTextBox.Text) < 40)
                HeadingTextBox.Text = "40";
            if (int.Parse(SetPieceTakingTextBox.Text) < 40)
                SetPieceTakingTextBox.Text = "40";
            if (int.Parse(CurlTextBox.Text) < 40)
                CurlTextBox.Text = "40";
            if (int.Parse(SpeedTextBox.Text) < 40)
                SpeedTextBox.Text = "40";
            if (int.Parse(AccelerationTextBox.Text) < 40)
                AccelerationTextBox.Text = "40";
            if (int.Parse(KickingPowerTextBox.Text) < 40)
                KickingPowerTextBox.Text = "40";
            if (int.Parse(JumpTextBox.Text) < 40)
                JumpTextBox.Text = "40";
            if (int.Parse(PhysicalContactTextBox.Text) < 40)
                PhysicalContactTextBox.Text = "40";
            if (int.Parse(BalanceTextBox.Text) < 40)
                BalanceTextBox.Text = "40";
            if (int.Parse(StaminaTextBox.Text) < 40)
                StaminaTextBox.Text = "40";
            if (int.Parse(DefensiveAwarenessTextBox.Text) < 40)
                DefensiveAwarenessTextBox.Text = "40";
            if (int.Parse(TacklingTextBox.Text) < 40)
                TacklingTextBox.Text = "40";
            if (int.Parse(DefensiveEngangementTextBox.Text) < 40)
                DefensiveEngangementTextBox.Text = "40";
            if (int.Parse(AggressionTextBox.Text) < 40)
                AggressionTextBox.Text = "40";
            if (int.Parse(GKAwarenessTextBox.Text) < 40)
                GKAwarenessTextBox.Text = "40";
            if (int.Parse(GKCatchingTextBox.Text) < 40)
                GKCatchingTextBox.Text = "40";
            if (int.Parse(GKParryingTextBox.Text) < 40)
                GKParryingTextBox.Text = "40";
            if (int.Parse(GKReflexesTextBox.Text) < 40)
                GKReflexesTextBox.Text = "40";
            if (int.Parse(GKReachTextBox.Text) < 40)
                GKReachTextBox.Text = "40";

            if (int.Parse(OffensiveProwessTextBox.Text) > 99)
                OffensiveProwessTextBox.Text = "99";
            if (int.Parse(BallControlTextBox.Text) > 99)
                BallControlTextBox.Text = "99";
            if (int.Parse(DribblingTextBox.Text) > 99)
                DribblingTextBox.Text = "99";
            if (int.Parse(TightPossessionTextBox.Text) > 99)
                TightPossessionTextBox.Text = "99";
            if (int.Parse(LowPassTextBox.Text) > 99)
                LowPassTextBox.Text = "99";
            if (int.Parse(LoftedPassTextBox.Text) > 99)
                LoftedPassTextBox.Text = "99";
            if (int.Parse(FinishingTextBox.Text) > 99)
                FinishingTextBox.Text = "99";
            if (int.Parse(HeadingTextBox.Text) > 99)
                HeadingTextBox.Text = "99";
            if (int.Parse(SetPieceTakingTextBox.Text) > 99)
                SetPieceTakingTextBox.Text = "99";
            if (int.Parse(CurlTextBox.Text) > 99)
                CurlTextBox.Text = "99";
            if (int.Parse(SpeedTextBox.Text) > 99)
                SpeedTextBox.Text = "99";
            if (int.Parse(AccelerationTextBox.Text) > 99)
                AccelerationTextBox.Text = "99";
            if (int.Parse(KickingPowerTextBox.Text) > 99)
                KickingPowerTextBox.Text = "99";
            if (int.Parse(JumpTextBox.Text) > 99)
                JumpTextBox.Text = "99";
            if (int.Parse(PhysicalContactTextBox.Text) > 99)
                PhysicalContactTextBox.Text = "99";
            if (int.Parse(BalanceTextBox.Text) > 99)
                BalanceTextBox.Text = "99";
            if (int.Parse(StaminaTextBox.Text) > 99)
                StaminaTextBox.Text = "99";
            if (int.Parse(DefensiveAwarenessTextBox.Text) > 99)
                DefensiveAwarenessTextBox.Text = "99";
            if (int.Parse(TacklingTextBox.Text) > 99)
                TacklingTextBox.Text = "99";
            if (int.Parse(DefensiveEngangementTextBox.Text) > 99)
                DefensiveEngangementTextBox.Text = "99";
            if (int.Parse(AggressionTextBox.Text) > 99)
                AggressionTextBox.Text = "99";
            if (int.Parse(GKAwarenessTextBox.Text) > 99)
                GKAwarenessTextBox.Text = "99";
            if (int.Parse(GKCatchingTextBox.Text) > 99)
                GKCatchingTextBox.Text = "99";
            if (int.Parse(GKParryingTextBox.Text) > 99)
                GKParryingTextBox.Text = "99";
            if (int.Parse(GKReflexesTextBox.Text) > 99)
                GKReflexesTextBox.Text = "99";
            if (int.Parse(GKReachTextBox.Text) > 99)
                GKReachTextBox.Text = "99";
        }

        private void AdjustPlusButton_Click(object sender, EventArgs e)
        {
            OffensiveProwessTextBox.Text = (int.Parse(OffensiveProwessTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            BallControlTextBox.Text = (int.Parse(BallControlTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            DribblingTextBox.Text = (int.Parse(DribblingTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            TightPossessionTextBox.Text = (int.Parse(TightPossessionTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            LowPassTextBox.Text = (int.Parse(LowPassTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            LoftedPassTextBox.Text = (int.Parse(LoftedPassTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            FinishingTextBox.Text = (int.Parse(FinishingTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            HeadingTextBox.Text = (int.Parse(HeadingTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            SetPieceTakingTextBox.Text = (int.Parse(SetPieceTakingTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            CurlTextBox.Text = (int.Parse(CurlTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            SpeedTextBox.Text = (int.Parse(SpeedTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            AccelerationTextBox.Text = (int.Parse(AccelerationTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            KickingPowerTextBox.Text = (int.Parse(KickingPowerTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            JumpTextBox.Text = (int.Parse(JumpTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            PhysicalContactTextBox.Text = (int.Parse(PhysicalContactTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            BalanceTextBox.Text = (int.Parse(BalanceTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            StaminaTextBox.Text = (int.Parse(StaminaTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            DefensiveAwarenessTextBox.Text = (int.Parse(DefensiveAwarenessTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            TacklingTextBox.Text = (int.Parse(TacklingTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            DefensiveEngangementTextBox.Text = (int.Parse(DefensiveEngangementTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            AggressionTextBox.Text = (int.Parse(AggressionTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            GKAwarenessTextBox.Text = (int.Parse(GKAwarenessTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            GKCatchingTextBox.Text = (int.Parse(GKCatchingTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            GKParryingTextBox.Text = (int.Parse(GKParryingTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            GKReflexesTextBox.Text = (int.Parse(GKReflexesTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();
            GKReachTextBox.Text = (int.Parse(GKReachTextBox.Text) + int.Parse(AdjustTextBox.Text)).ToString();

            CheckField();
        }

        private void AdjustLessButton_Click(object sender, EventArgs e)
        {
            OffensiveProwessTextBox.Text = (int.Parse(OffensiveProwessTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            BallControlTextBox.Text = (int.Parse(BallControlTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            DribblingTextBox.Text = (int.Parse(DribblingTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            TightPossessionTextBox.Text = (int.Parse(TightPossessionTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            LowPassTextBox.Text = (int.Parse(LowPassTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            LoftedPassTextBox.Text = (int.Parse(LoftedPassTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            FinishingTextBox.Text = (int.Parse(FinishingTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            HeadingTextBox.Text = (int.Parse(HeadingTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            SetPieceTakingTextBox.Text = (int.Parse(SetPieceTakingTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            CurlTextBox.Text = (int.Parse(CurlTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            SpeedTextBox.Text = (int.Parse(SpeedTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            AccelerationTextBox.Text = (int.Parse(AccelerationTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            KickingPowerTextBox.Text = (int.Parse(KickingPowerTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            JumpTextBox.Text = (int.Parse(JumpTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            PhysicalContactTextBox.Text = (int.Parse(PhysicalContactTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            BalanceTextBox.Text = (int.Parse(BalanceTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            StaminaTextBox.Text = (int.Parse(StaminaTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            DefensiveAwarenessTextBox.Text = (int.Parse(DefensiveAwarenessTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            TacklingTextBox.Text = (int.Parse(TacklingTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            DefensiveEngangementTextBox.Text = (int.Parse(DefensiveEngangementTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            AggressionTextBox.Text = (int.Parse(AggressionTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            GKAwarenessTextBox.Text = (int.Parse(GKAwarenessTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            GKCatchingTextBox.Text = (int.Parse(GKCatchingTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            GKParryingTextBox.Text = (int.Parse(GKParryingTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            GKReflexesTextBox.Text = (int.Parse(GKReflexesTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();
            GKReachTextBox.Text = (int.Parse(GKReachTextBox.Text) - int.Parse(AdjustTextBox.Text)).ToString();

            CheckField();
        }

        private void AdjustLessPercButton_Click(object sender, EventArgs e)
        {
            decimal primo = Math.Round((decimal)((int.Parse(OffensiveProwessTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo1 = (decimal)int.Parse(OffensiveProwessTextBox.Text) - primo;
            OffensiveProwessTextBox.Text = primo1.ToString();
            
            decimal primo2 = Math.Round((decimal)((int.Parse(BallControlTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo3 = (decimal)int.Parse(BallControlTextBox.Text) - primo2;
            BallControlTextBox.Text = primo3.ToString();
            
            decimal primo4 = Math.Round((decimal)((int.Parse(DribblingTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo5 = (decimal)int.Parse(DribblingTextBox.Text) - primo4;
            DribblingTextBox.Text = primo5.ToString();
            
            decimal primo6 = Math.Round((decimal)((int.Parse(TightPossessionTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo7 = (decimal)int.Parse(TightPossessionTextBox.Text) - primo6;
            TightPossessionTextBox.Text = primo7.ToString();
            
            decimal primo8 = Math.Round((decimal)((int.Parse(LowPassTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo9 = (decimal)int.Parse(LowPassTextBox.Text) - primo8;
            LowPassTextBox.Text = primo9.ToString();
            
            decimal primo10 = Math.Round((decimal)((int.Parse(LoftedPassTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo11 = (decimal)int.Parse(LoftedPassTextBox.Text) - primo10;
            LoftedPassTextBox.Text = primo11.ToString();
            
            decimal primo12 = Math.Round((decimal)((int.Parse(FinishingTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo13 = (decimal)int.Parse(FinishingTextBox.Text) - primo12;
            FinishingTextBox.Text = primo13.ToString();
            
            decimal primo14 = Math.Round((decimal)((int.Parse(HeadingTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo15 = (decimal)int.Parse(HeadingTextBox.Text) - primo14;
            HeadingTextBox.Text = primo15.ToString();
            
            decimal primo16 = Math.Round((decimal)((int.Parse(SetPieceTakingTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo17 = (decimal)int.Parse(SetPieceTakingTextBox.Text) - primo16;
            SetPieceTakingTextBox.Text = primo17.ToString();
            
            decimal primo18 = Math.Round((decimal)((int.Parse(CurlTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo19 = (decimal)int.Parse(CurlTextBox.Text) - primo18;
            CurlTextBox.Text = primo19.ToString();
            
            decimal primo20 = Math.Round((decimal)((int.Parse(SpeedTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo21 = (decimal)int.Parse(SpeedTextBox.Text) - primo20;
            SpeedTextBox.Text = primo21.ToString();
            
            decimal primo22 = Math.Round((decimal)((int.Parse(AccelerationTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo23 = (decimal)int.Parse(AccelerationTextBox.Text) - primo22;
            AccelerationTextBox.Text = primo23.ToString();
            
            decimal primo24 = Math.Round((decimal)((int.Parse(KickingPowerTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo25 = (decimal)int.Parse(KickingPowerTextBox.Text) - primo24;
            KickingPowerTextBox.Text = primo25.ToString();
            
            decimal primo26 = Math.Round((decimal)((int.Parse(JumpTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo27 = (decimal)int.Parse(JumpTextBox.Text) - primo26;
            JumpTextBox.Text = primo27.ToString();
            
            decimal primo28 = Math.Round((decimal)((int.Parse(PhysicalContactTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo29 = (decimal)int.Parse(PhysicalContactTextBox.Text) - primo28;
            PhysicalContactTextBox.Text = primo29.ToString();
            
            decimal primo44 = Math.Round((decimal)((int.Parse(BalanceTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo45 = (decimal)int.Parse(BalanceTextBox.Text) - primo44;
            BalanceTextBox.Text = primo45.ToString();
            
            decimal primo30 = Math.Round((decimal)((int.Parse(StaminaTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo31 = (decimal)int.Parse(StaminaTextBox.Text) - primo30;
            StaminaTextBox.Text = primo31.ToString();
            
            decimal primo32 = Math.Round((decimal)((int.Parse(DefensiveAwarenessTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo33 = (decimal)int.Parse(DefensiveAwarenessTextBox.Text) - primo32;
            DefensiveAwarenessTextBox.Text = primo33.ToString();
            
            decimal primo34 = Math.Round((decimal)((int.Parse(TacklingTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo35 = (decimal)int.Parse(TacklingTextBox.Text) - primo34;
            TacklingTextBox.Text = primo35.ToString();

            decimal primo50 = Math.Round((decimal)((int.Parse(DefensiveEngangementTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo51 = (decimal)int.Parse(DefensiveEngangementTextBox.Text) - primo34;
            DefensiveEngangementTextBox.Text = primo51.ToString();

            decimal primo36 = Math.Round((decimal)((int.Parse(AggressionTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo37 = (decimal)int.Parse(AggressionTextBox.Text) - primo36;
            AggressionTextBox.Text = primo37.ToString();
            
            decimal primo38 = Math.Round((decimal)((int.Parse(GKAwarenessTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo39 = (decimal)int.Parse(GKAwarenessTextBox.Text) - primo38;
            GKAwarenessTextBox.Text = primo39.ToString();
            
            decimal primo40 = Math.Round((decimal)((int.Parse(GKCatchingTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo41 = (decimal)int.Parse(GKCatchingTextBox.Text) - primo40;
            GKCatchingTextBox.Text = primo41.ToString();
            
            decimal primo42 = Math.Round((decimal)((int.Parse(GKParryingTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo43 = (decimal)int.Parse(GKParryingTextBox.Text) - primo42;
            GKParryingTextBox.Text = primo43.ToString();

            decimal primo46 = Math.Round((decimal)((int.Parse(GKReflexesTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo47 = (decimal)int.Parse(GKReflexesTextBox.Text) - primo42;
            GKReflexesTextBox.Text = primo43.ToString();

            decimal primo48 = Math.Round((decimal)((int.Parse(GKReachTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo49 = (decimal)int.Parse(GKReachTextBox.Text) - primo42;
            GKReachTextBox.Text = primo43.ToString();

            CheckField();
        }

        private void AdjustPlusPercButton_Click(object sender, EventArgs e)
        {
            decimal primo = Math.Round((decimal)((int.Parse(OffensiveProwessTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo1 = (decimal)int.Parse(OffensiveProwessTextBox.Text) + primo;
            OffensiveProwessTextBox.Text = primo1.ToString();

            decimal primo2 = Math.Round((decimal)((int.Parse(BallControlTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo3 = (decimal)int.Parse(BallControlTextBox.Text) + primo2;
            BallControlTextBox.Text = primo3.ToString();

            decimal primo4 = Math.Round((decimal)((int.Parse(DribblingTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo5 = (decimal)int.Parse(DribblingTextBox.Text) + primo4;
            DribblingTextBox.Text = primo5.ToString();

            decimal primo6 = Math.Round((decimal)((int.Parse(TightPossessionTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo7 = (decimal)int.Parse(TightPossessionTextBox.Text) + primo6;
            TightPossessionTextBox.Text = primo7.ToString();

            decimal primo8 = Math.Round((decimal)((int.Parse(LowPassTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo9 = (decimal)int.Parse(LowPassTextBox.Text) + primo8;
            LowPassTextBox.Text = primo9.ToString();

            decimal primo10 = Math.Round((decimal)((int.Parse(LoftedPassTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo11 = (decimal)int.Parse(LoftedPassTextBox.Text) + primo10;
            LoftedPassTextBox.Text = primo11.ToString();

            decimal primo12 = Math.Round((decimal)((int.Parse(FinishingTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo13 = (decimal)int.Parse(FinishingTextBox.Text) + primo12;
            FinishingTextBox.Text = primo13.ToString();

            decimal primo14 = Math.Round((decimal)((int.Parse(HeadingTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo15 = (decimal)int.Parse(HeadingTextBox.Text) + primo14;
            HeadingTextBox.Text = primo15.ToString();

            decimal primo16 = Math.Round((decimal)((int.Parse(SetPieceTakingTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo17 = (decimal)int.Parse(SetPieceTakingTextBox.Text) + primo16;
            SetPieceTakingTextBox.Text = primo17.ToString();

            decimal primo18 = Math.Round((decimal)((int.Parse(CurlTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo19 = (decimal)int.Parse(CurlTextBox.Text) + primo18;
            CurlTextBox.Text = primo19.ToString();

            decimal primo20 = Math.Round((decimal)((int.Parse(SpeedTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo21 = (decimal)int.Parse(SpeedTextBox.Text) + primo20;
            SpeedTextBox.Text = primo21.ToString();

            decimal primo22 = Math.Round((decimal)((int.Parse(AccelerationTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo23 = (decimal)int.Parse(AccelerationTextBox.Text) + primo22;
            AccelerationTextBox.Text = primo23.ToString();

            decimal primo24 = Math.Round((decimal)((int.Parse(KickingPowerTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo25 = (decimal)int.Parse(KickingPowerTextBox.Text) + primo24;
            KickingPowerTextBox.Text = primo25.ToString();

            decimal primo26 = Math.Round((decimal)((int.Parse(JumpTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo27 = (decimal)int.Parse(JumpTextBox.Text) + primo26;
            JumpTextBox.Text = primo27.ToString();

            decimal primo28 = Math.Round((decimal)((int.Parse(PhysicalContactTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo29 = (decimal)int.Parse(PhysicalContactTextBox.Text) + primo28;
            PhysicalContactTextBox.Text = primo29.ToString();

            decimal primo44 = Math.Round((decimal)((int.Parse(BalanceTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo45 = (decimal)int.Parse(BalanceTextBox.Text) + primo44;
            BalanceTextBox.Text = primo45.ToString();

            decimal primo30 = Math.Round((decimal)((int.Parse(StaminaTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo31 = (decimal)int.Parse(StaminaTextBox.Text) + primo30;
            StaminaTextBox.Text = primo31.ToString();

            decimal primo32 = Math.Round((decimal)((int.Parse(DefensiveAwarenessTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo33 = (decimal)int.Parse(DefensiveAwarenessTextBox.Text) + primo32;
            DefensiveAwarenessTextBox.Text = primo33.ToString();

            decimal primo34 = Math.Round((decimal)((int.Parse(TacklingTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo35 = (decimal)int.Parse(TacklingTextBox.Text) + primo34;
            TacklingTextBox.Text = primo35.ToString();

            decimal primo50 = Math.Round((decimal)((int.Parse(DefensiveEngangementTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo51 = (decimal)int.Parse(DefensiveEngangementTextBox.Text) + primo34;
            DefensiveEngangementTextBox.Text = primo51.ToString();

            decimal primo36 = Math.Round((decimal)((int.Parse(AggressionTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo37 = (decimal)int.Parse(AggressionTextBox.Text) + primo36;
            AggressionTextBox.Text = primo37.ToString();

            decimal primo38 = Math.Round((decimal)((int.Parse(GKAwarenessTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo39 = (decimal)int.Parse(GKAwarenessTextBox.Text) + primo38;
            GKAwarenessTextBox.Text = primo39.ToString();

            decimal primo40 = Math.Round((decimal)((int.Parse(GKCatchingTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo41 = (decimal)int.Parse(GKCatchingTextBox.Text) + primo40;
            GKCatchingTextBox.Text = primo41.ToString();

            decimal primo42 = Math.Round((decimal)((int.Parse(GKParryingTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo43 = (decimal)int.Parse(GKParryingTextBox.Text) + primo42;
            GKParryingTextBox.Text = primo43.ToString();

            decimal primo46 = Math.Round((decimal)((int.Parse(GKReflexesTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo47 = (decimal)int.Parse(GKReflexesTextBox.Text) + primo46;
            GKReflexesTextBox.Text = primo47.ToString();

            decimal primo48 = Math.Round((decimal)((int.Parse(GKReachTextBox.Text) * int.Parse(AdjustTextBox.Text)) / 100));
            decimal primo49 = (decimal)int.Parse(GKReachTextBox.Text) + primo48;
            GKReachTextBox.Text = primo49.ToString();

            CheckField();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {

        }
    }
}
