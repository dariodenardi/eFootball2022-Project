using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvoTool.Controllers;
using EvoTool.Models;

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
                FreeKickComboBox.Items.Add(i.ToString());

            for (int i = 1; i <= 5; i++)
                DribHunchingComboBox.Items.Add(i.ToString());

            for (int i = 1; i <= 10; i++)
                DribArmMoveComboBox.Items.Add(i.ToString());

            for (int i = 1; i <= 5; i++)
                RunHunchingComboBox.Items.Add(i.ToString());

            for (int i = 1; i <= 10; i++)
                RunArmMoveComboBox.Items.Add(i.ToString());

            for (int i = 1; i <= 7; i++)
                PenaltyKickComboBox.Items.Add(i.ToString());

            for (int i = 1; i <= 10; i++)
                CornerKickComboBox.Items.Add(i.ToString());

            for (int i = 1; i <= 176; i++)
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

            /*dribHunchComboBox.Text = temp.getDriblingH().ToString();
            dribArmMoveComboBox.Text = temp.getDriblingArm().ToString();
            runHunchComboBox.Text = temp.getRunningH().ToString();
            runArmMoveComboBox.Text = temp.getRunningArm().ToString();
            ckMotionComboBox.Text = temp.getCornerKick().ToString();
            fkMotionComboBox.Text = temp.getFreeKick().ToString();
            pkMotionComboBox.Text = temp.getPenaltyKick().ToString();
            driblMotionComboBox.Text = temp.getDriblingMotion().ToString();
            goalCelebComboBox.Text = temp.getGoalCelebrate().ToString();
            playAttitudeComboBox.Text = temp.getPlayingAttitude().ToString();

            positionComboBox.Text = player.getStringPosition();
            gkComboBox.Text = player.getStringGK();
            cbComboBox.Text = player.getStringGB();
            lbComboBox.Text = player.getStringLB();
            rbComboBox.Text = player.getStringRB();
            dmfComboBox.Text = player.getStringDMF();
            cmfComboBox.Text = temp.getStringCMF();
            lmfComboBox.Text = temp.getStringLMF();
            amfComboBox.Text = temp.getStringAMF();
            rmfComboBox.Text = temp.getStringRMF();
            lwfComboBox.Text = temp.getStringLWF();
            rwfComboBox.Text = temp.getStringRWF();
            ssComboBox.Text = temp.getStringSS();
            cfComboBox.Text = temp.getStringCF();*/
        }

        // don't enter a letters
        private void NoLetterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) & (!char.IsNumber(e.KeyChar.ToString(), 0)))
                e.Handled = true;
        }
    }
}
