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

        public Stats(Player player, PlayerController playerController)
        {
            InitializeComponent();
            this.player = player;
            this.playerController = playerController;
        }

        private void Giocatore_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;

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

            StrongFootComboBox.Items.Add("Right");
            StrongFootComboBox.Items.Add("Left");

            StrongHandComboBox.Items.Add("Right");
            StrongHandComboBox.Items.Add("Left");

            FormComboBox.Items.Add("Inconsistent");
            FormComboBox.Items.Add("Standard");
            FormComboBox.Items.Add("Unwavering");

            InjuryComboBox.Items.Add("Low");
            InjuryComboBox.Items.Add("Medium");
            InjuryComboBox.Items.Add("High");

            WeAccComboBox.Items.Add("Slightly Low");
            WeAccComboBox.Items.Add("Medium");
            WeAccComboBox.Items.Add("High");
            WeAccComboBox.Items.Add("Very High");

            WeUsageComboBox.Items.Add("Slightly Low");
            WeUsageComboBox.Items.Add("Medium");
            WeUsageComboBox.Items.Add("High");
            WeUsageComboBox.Items.Add("Very High");

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
            
            PlayingStyleComboBox.Text = ((Player.PlayStyle)(player.PlayingStyle)).ToString().Replace("___", ". ").Replace("__", "-").Replace('_', ' ');
            AgeTextBox.Text = player.Age.ToString();
            HeightTextBox.Text = player.Height.ToString();
            WeightTextBox.Text = player.Weight.ToString();
            StrongFootComboBox.Text = player.StroongerFoot ? "Left" : "Right";
            StrongHandComboBox.Text = player.StrongerHand ? "Left" : "Right";
            FormComboBox.Text = ((Player.PlayerForm)(player.Form)).ToString();
            WeAccComboBox.Text = ((Player.WeakFoot)(player.WeakFootAccuracy)).ToString().Replace('_', ' ');
            WeUsageComboBox.Text = ((Player.WeakFoot)(player.WeakFootUsage)).ToString().Replace('_', ' ');
            InjuryComboBox.Text = ((Player.InjuryRes)(player.InjuryResistance)).ToString();
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
            GKComboBox.Text = ((Player.PlayerPosition)(player.PlayableGK)).ToString();
            CBComboBox.Text = ((Player.PlayerPosition)(player.PlayableCB)).ToString();
            LBComboBox.Text = ((Player.PlayerPosition)(player.PlayableLB)).ToString();
            RBComboBox.Text = ((Player.PlayerPosition)(player.PlayableRB)).ToString();
            DMFComboBox.Text = ((Player.PlayerPosition)(player.PlayableDMF)).ToString();
            CMFComboBox.Text = ((Player.PlayerPosition)(player.PlayableCMF)).ToString();
            LMFComboBox.Text = ((Player.PlayerPosition)(player.PlayableLMF)).ToString();
            AMFComboBox.Text = ((Player.PlayerPosition)(player.PlayableAMF)).ToString();
            RMFComboBox.Text = ((Player.PlayerPosition)(player.PlayableRMF)).ToString();
            LWFComboBox.Text = ((Player.PlayerPosition)(player.PlayableLWF)).ToString();
            RWFComboBox.Text = ((Player.PlayerPosition)(player.PlayableRWF)).ToString();
            SSComboBox.Text = ((Player.PlayerPosition)(player.PlayableSS)).ToString();
            CFComboBox.Text = ((Player.PlayerPosition)(player.PlayableCF)).ToString();

            //PlayerHandLabel.Text = player.StrongerHand ? "Left" : "Right";
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
            DefensiveAwarenessTextBox.Text = "40";
            AggressionTextBox.Text = "40";
            GKAwarenessTextBox.Text = "40";
            GKCatchingTextBox.Text = "40";
            GKParryingTextBox.Text = "40";
            GKReflexesTextBox.Text = "40";
            GKReachTextBox.Text = "40";
        }
    }
}
