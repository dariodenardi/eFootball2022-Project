using EvoTool.Models;
using EvoTool.ZlibUnzlib;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoTool.Controllers
{
    class PlayerController
    {
        private static readonly string FILE_NAME = "/Player.bin";
        private static readonly int BLOCK = 392;

        public PlayerController()
        {
            PlayerTable = new DataTable();
            PlayerTable.Columns.Add("Index", typeof(int));
            PlayerTable.Columns.Add("Name", typeof(string));
        }

        private MemoryStream MemoryPlayer { get; set; }
        private BinaryReader ReadPlayer { get; set; }
        private BinaryWriter WritePlayer { get; set; }
        public DataTable PlayerTable { get; set; }

        private MemoryStream UnzlibFile(string patch)
        {
            MemoryStream memoryBall = null;

            byte[] file = File.ReadAllBytes(patch + FILE_NAME);
            byte[] ss1 = Unzlib.UnZlibFilePC(file);
            memoryBall = new MemoryStream(ss1);

            return memoryBall;
        }

        public int Load(string patch)
        {
            MemoryPlayer = UnzlibFile(patch);

            int playerNumber = (int)MemoryPlayer.Length / BLOCK;

            if (playerNumber == 0)
                return 0;

            string playerName;
            try
            {
                ReadPlayer = new BinaryReader(MemoryPlayer);
                long START = -68; // player name offset

                for (int i = 0; i < playerNumber; i++)
                {
                    START += BLOCK;
                    MemoryPlayer.Seek(START, SeekOrigin.Begin);
                    playerName = Encoding.UTF8.GetString(ReadPlayer.ReadBytes(61)).TrimEnd('\0');

                    PlayerTable.Rows.Add(i, playerName);
                }
                WritePlayer = new BinaryWriter(MemoryPlayer);
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public Player LoadPlayer(int index)
        {
            Player player;

            uint youthPlayerID;
            uint ownerClubID;
            uint playerID;
            //uint padding;
            uint clubID;
            uint freeKickMotion;
            uint contractDate;
            uint playingStyle;
            uint loanContractExpiryDate;
            uint nationalTeamCaps;
            uint marketValue;
            uint height;
            uint unknownBits1;
            uint setPieceTaking;
            uint goalCelebration;
            ushort nationalID1;
            ushort nationalID2;
            uint cornerKick;
            uint weight;
            uint unknownBits2;
            uint unknownBits3;
            uint unknownBits4;
            uint defensiveAwareness;
            uint kickingPower;
            uint lowPass;
            bool unknownBit1;
            bool unknownBit2;
            uint unknownBits5;
            uint unknownBits6;
            uint playableLB;
            uint speed;
            uint gkCatching;
            uint jump;
            uint heading;
            uint ballControl;
            uint playableLMF;
            uint gkAwareness;
            uint gkParrying;
            uint gkReflexes;
            uint tackling;
            uint gkReach;
            uint playableGK;
            uint offensiveAwareness;
            uint dribbling;
            uint acceleration;
            uint stamina;
            uint curl;
            bool unknownBit3;
            bool unknownBit4;
            uint loftedPass;
            uint finishing;
            uint physicalContact;
            uint aggression;
            uint balance;
            uint weakFootUsage;
            uint registeredPosition;
            uint runningArmMovement;
            uint dribblingArmMovement;
            uint tightPossession;
            uint defensiveEngangement;
            uint age;
            uint playableRB;
            uint playableLWF;
            uint playableCF;
            uint playableCB;
            uint form;
            uint playableAMF;
            uint weakFootAccuracy;
            uint playableRMF;
            uint injuryResistance;
            uint playableCMF;
            uint runningHunching;
            uint dribblingHunching;
            uint penaltyKickMotion;
            bool slidingTackle;
            bool gkPenaltySaver;
            bool penaltySpecialist;
            bool soleControl;
            bool risingShots;
            bool ballonDorWinner;
            bool marseilleTurn;
            bool gkHighPunt;
            bool headingSkills;
            bool outsideCurler;
            bool captanincy;
            bool gamasmanship;
            bool gkLowPunt;
            bool trickSter;
            bool lowLoftedPass;
            bool throughPassing;
            bool fightingSpirit;
            bool flipFlap;
            bool weightedPass;
            bool aerialSuperiority;
            bool pinpointCrossing;
            bool sombrero;
            bool earlyCross;
            bool chopTurn;
            uint dribblingMotion;
            uint playableSS;
            uint playableRWF;
            uint playableDMF;
            bool unknownBit5;
            bool strongerHand;
            bool mazingRun;
            bool unknownBit6;
            bool longBallExpert;
            bool acrobaticClear;
            bool longRangeCurler;
            bool speedingBullet;
            bool blocker;
            bool scotchMove;
            bool acrobaticFinishing;
            bool doubleTouch;
            bool gkLongThrow;
            bool longThrow;
            bool scissorsFeint;
            bool longRangeShooting;
            bool trackBack;
            bool superSub;
            bool rabona;
            bool dippingShot;
            bool stroongerFoot;
            bool knuckleShot;
            bool noLookPass;
            bool firstTimeShot;
            bool incisiveRun;
            bool unknownBit7;
            bool longRanger;
            bool oneTouchPass;
            bool chipShotControl;
            bool hellTrick;
            bool manMarking;
            bool interception;
            string japaneseName;
            string shirtName;
            string chineseName;
            string clubShirtName;
            string name;
            uint unknownBits7;
            try
            {
                ReadPlayer.BaseStream.Position = index * BLOCK;
                youthPlayerID = ReadPlayer.ReadUInt32();
                ownerClubID = ReadPlayer.ReadUInt32();
                playerID = ReadPlayer.ReadUInt32();
                ReadPlayer.ReadUInt32(); //padding
                clubID = ReadPlayer.ReadUInt32();

                uint aux1 = ReadPlayer.ReadUInt32();
                freeKickMotion = ((aux1 << 0) >> 27) + 1;
                contractDate = aux1 << 5 >> 5;

                uint aux2 = ReadPlayer.ReadUInt32();
                playingStyle = aux2 >> 27;
                loanContractExpiryDate = aux2 << 5 >> 5;

                uint aux3 = ReadPlayer.ReadUInt32();
                nationalTeamCaps = ((aux3 << 0) >> 24);
                marketValue = ((aux3 << 8) >> 8);

                uint aux4 = ReadPlayer.ReadUInt32();
                height = ((aux4 << 0) >> 24) + 100;
                unknownBits1 = ((aux4 << 8) >> 8);

                uint aux5 = ReadPlayer.ReadUInt32();
                setPieceTaking = ((aux5 << 0) >> 26) + 40;
                goalCelebration = aux5 << 6 >> 24;
                nationalID1 = (ushort) (aux5 << 14 >> 23);
                nationalID2 = (ushort) (aux5 << 23 >> 23);

                uint aux6 = ReadPlayer.ReadUInt32();
                cornerKick = ((aux6 << 0) >> 28) + 1;
                weight = (aux6 << 4 >> 25) + 30;
                unknownBits2 = aux6 << 11 >> 25;
                unknownBits3 = aux6 << 18 >> 25;
                unknownBits4 = aux6 << 25 >> 25;

                uint aux7 = ReadPlayer.ReadUInt32();
                defensiveAwareness = (aux7 << 0 >> 26) + 40;
                kickingPower = (aux7 << 6 >> 26) + 40;
                lowPass = (aux7 << 12 >> 26) + 40;
                unknownBit1 = aux7 << 18 >> 31 == 1 ? true : false;
                unknownBit2 = aux7 << 19 >> 31 == 1 ? true : false;
                unknownBits5 = aux7 << 20 >> 26;
                unknownBits6 = aux7 << 26 >> 26;

                uint aux8 = ReadPlayer.ReadUInt32();
                playableLB = ((aux8 << 0) >> 30);
                speed = ((aux8 << 2) >> 26) + 40;
                gkCatching = ((aux8 << 8) >> 26) + 40;
                jump = ((aux8 << 14) >> 26) + 40;
                heading = ((aux8 << 20) >> 26) + 40;
                ballControl = ((aux8 << 26) >> 26) + 40;

                uint aux9 = ReadPlayer.ReadUInt32();
                playableLMF = ((aux9 << 0) >> 30);
                gkAwareness = ((aux9 << 2) >> 26) + 40;
                gkParrying = ((aux9 << 8) >> 26) + 40;
                gkReflexes = ((aux9 << 14) >> 26) + 40;
                tackling = ((aux9 << 20) >> 26) + 40;
                gkReach = ((aux9 << 26) >> 26) + 40;

                uint aux10 = ReadPlayer.ReadUInt32();
                playableGK = ((aux10 << 0) >> 30);
                offensiveAwareness = ((aux10 << 2) >> 26) + 40;
                dribbling = ((aux10 << 8) >> 26) + 40;
                acceleration = ((aux10 << 14) >> 26) + 40;
                stamina = ((aux10 << 20) >> 26) + 40;
                curl = ((aux10 << 26) >> 26) + 40;

                uint aux11 = ReadPlayer.ReadUInt32();
                unknownBit3 = aux11 << 0 >> 31 == 1 ? true : false;
                unknownBit4 = aux11 << 1 >> 31 == 1 ? true : false;
                loftedPass = ((aux11 << 2) >> 26) + 40;
                finishing = ((aux11 << 8) >> 26) + 40;
                physicalContact = ((aux11 << 14) >> 26) + 40;
                aggression = ((aux11 << 20) >> 26) + 40;
                balance = ((aux11 << 26) >> 26) + 40;

                uint aux12 = ReadPlayer.ReadUInt32();
                weakFootUsage = ((aux12 << 0) >> 30);
                registeredPosition = ((aux12 << 2) >> 28);
                runningArmMovement = ((aux12 << 6) >> 28) + 1;
                dribblingArmMovement = ((aux12 << 10) >> 28) + 1;
                tightPossession = ((aux12 << 14) >> 26) + 40;
                defensiveEngangement = ((aux12 << 20) >> 26) + 40;
                age = ((aux12 << 26) >> 26) + 15;

                uint aux13 = ReadPlayer.ReadUInt32();
                playableRB = ((aux13 << 0) >> 30);
                playableLWF = ((aux13 << 2) >> 30);
                playableCF = ((aux13 << 4) >> 30);
                playableCB = ((aux13 << 6) >> 30);
                form = ((aux13 << 8) >> 30);
                playableAMF = ((aux13 << 10) >> 30);
                weakFootAccuracy = ((aux13 << 12) >> 30);
                playableRMF = ((aux13 << 14) >> 30);
                injuryResistance = ((aux13 << 16) >> 30);
                playableCMF = ((aux13 << 18) >> 30);
                unknownBits7 = ((aux13 << 20) >> 29);
                runningHunching = ((aux13 << 23) >> 29) + 1;
                dribblingHunching = ((aux13 << 26) >> 29) + 1;
                penaltyKickMotion = ((aux13 << 29) >> 29) + 1;

                uint aux14 = ReadPlayer.ReadUInt32();
                slidingTackle = (aux14 << 0) >> 31 == 1 ? true : false;
                gkPenaltySaver = (aux14 << 1) >> 31 == 1 ? true : false;
                penaltySpecialist = (aux14 << 2) >> 31 == 1 ? true : false;
                soleControl = (aux14 << 3) >> 31 == 1 ? true : false;
                risingShots = (aux14 << 4) >> 31 == 1 ? true : false;
                ballonDorWinner = (aux14 << 5) >> 31 == 1 ? true : false;
                marseilleTurn = (aux14 << 6) >> 31 == 1 ? true : false;
                gkHighPunt = (aux14 << 7) >> 31 == 1 ? true : false;
                headingSkills = (aux14 << 8) >> 31 == 1 ? true : false;
                outsideCurler = (aux14 << 9) >> 31 == 1 ? true : false;
                captanincy = (aux14 << 10) >> 31 == 1 ? true : false;
                gamasmanship = (aux14 << 11) >> 31 == 1 ? true : false;
                gkLowPunt = (aux14 << 12) >> 31 == 1 ? true : false;
                trickSter = (aux14 << 13) >> 31 == 1 ? true : false;
                lowLoftedPass = (aux14 << 14) >> 31 == 1 ? true : false;
                throughPassing = (aux14 << 15) >> 31 == 1 ? true : false;
                fightingSpirit = (aux14 << 16) >> 31 == 1 ? true : false;
                flipFlap = (aux14 << 17) >> 31 == 1 ? true : false;
                weightedPass = (aux14 << 18) >> 31 == 1 ? true : false;
                aerialSuperiority = (aux14 << 19) >> 31 == 1 ? true : false;
                pinpointCrossing = (aux14 << 20) >> 31 == 1 ? true : false;
                sombrero = (aux14 << 21) >> 31 == 1 ? true : false;
                earlyCross = (aux14 << 22) >> 31 == 1 ? true : false;
                chopTurn = (aux14 << 23) >> 31 == 1 ? true : false;
                dribblingMotion = ((aux14 << 24) >> 30) + 1;
                playableSS = ((aux14 << 26) >> 30);
                playableRWF = ((aux14 << 28) >> 30);
                playableDMF = ((aux14 << 30) >> 30);

                uint aux15 = ReadPlayer.ReadUInt32();
                unknownBit5 = (aux15 << 0) >> 31 == 1 ? true : false;
                strongerHand = (aux15 << 1) >> 31 == 1 ? true : false;
                mazingRun = (aux15 << 2) >> 31 == 1 ? true : false;
                unknownBit6 = (aux15 << 3) >> 31 == 1 ? true : false;
                longBallExpert = (aux15 << 4) >> 31 == 1 ? true : false;
                acrobaticClear = (aux15 << 5) >> 31 == 1 ? true : false;
                longRangeCurler = (aux15 << 6) >> 31 == 1 ? true : false;
                speedingBullet = (aux15 << 7) >> 31 == 1 ? true : false;
                blocker = (aux15 << 8) >> 31 == 1 ? true : false;
                scotchMove = (aux15 << 9) >> 31 == 1 ? true : false;
                acrobaticFinishing = (aux15 << 10) >> 31 == 1 ? true : false;
                doubleTouch = (aux15 << 11) >> 31 == 1 ? true : false;
                gkLongThrow = (aux15 << 12) >> 31 == 1 ? true : false;
                longThrow = (aux15 << 13) >> 31 == 1 ? true : false;
                scissorsFeint = (aux15 << 14) >> 31 == 1 ? true : false;
                longRangeShooting = (aux15 << 15) >> 31 == 1 ? true : false;
                trackBack = (aux15 << 16) >> 31 == 1 ? true : false;
                superSub = (aux15 << 17) >> 31 == 1 ? true : false;
                rabona = (aux15 << 18) >> 31 == 1 ? true : false;
                dippingShot = (aux15 << 19) >> 31 == 1 ? true : false;
                stroongerFoot = (aux15 << 20) >> 31 == 1 ? true : false;
                knuckleShot = (aux15 << 21) >> 31 == 1 ? true : false;
                noLookPass = (aux15 << 22) >> 31 == 1 ? true : false;
                firstTimeShot = (aux15 << 23) >> 31 == 1 ? true : false;
                incisiveRun = (aux15 << 24) >> 31 == 1 ? true : false;
                unknownBit7 = (aux15 << 25) >> 31 == 1 ? true : false;
                longRanger = (aux15 << 26) >> 31 == 1 ? true : false;
                oneTouchPass = (aux15 << 27) >> 31 == 1 ? true : false;
                chipShotControl = (aux15 << 28) >> 31 == 1 ? true : false;
                hellTrick = (aux15 << 29) >> 31 == 1 ? true : false;
                manMarking = (aux15 << 30) >> 31 == 1 ? true : false;
                interception = (aux15 << 31) >> 31 == 1 ? true : false;

                japaneseName = Encoding.UTF8.GetString(ReadPlayer.ReadBytes(61)).TrimEnd('\0');

                shirtName = Encoding.UTF8.GetString(ReadPlayer.ReadBytes(61)).TrimEnd('\0');

                chineseName = Encoding.UTF8.GetString(ReadPlayer.ReadBytes(61)).TrimEnd('\0');

                clubShirtName = Encoding.UTF8.GetString(ReadPlayer.ReadBytes(61)).TrimEnd('\0');

                name = Encoding.UTF8.GetString(ReadPlayer.ReadBytes(61)).TrimEnd('\0');

                player = new Player(playerID);
                player.YouthPlayerID = youthPlayerID;
                player.OwnerClubID = ownerClubID;
                player.ClubID = clubID;
                player.FreeKickMotion = freeKickMotion;
                player.ContractDate = contractDate;
                player.PlayingStyle = playingStyle;
                player.LoanContractExpiryDate = loanContractExpiryDate;
                player.NationalTeamCaps = nationalTeamCaps;
                player.MarketValue = marketValue;
                player.Height = height;
                player.UnknownBits1 = unknownBits1;
                player.SetPieceTaking = setPieceTaking;
                player.GoalCelebration = goalCelebration;
                player.NationalID1 = nationalID1;
                player.NationalID2 = nationalID2;
                player.CornerKick = cornerKick;
                player.Weight = weight;
                player.UnknownBits2 = unknownBits2;
                player.UnknownBits3 = unknownBits3;
                player.UnknownBits4 = unknownBits4;
                player.DefensiveAwareness = defensiveAwareness;
                player.KickingPower = kickingPower;
                player.LowPass = lowPass;
                player.UnknownBit1 = unknownBit1;
                player.UnknownBit2 = unknownBit2;
                player.UnknownBits5 = unknownBits5;
                player.UnknownBits6 = unknownBits6;
                player.PlayableLB = playableLB;
                player.Speed = speed;
                player.GKCatching = gkCatching;
                player.Jump = jump;
                player.Heading = heading;
                player.BallControl = ballControl;
                player.PlayableLMF = playableLMF;
                player.GKAwareness = gkAwareness;
                player.GKParrying = gkParrying;
                player.GKReflexes = gkReflexes;
                player.Tackling = tackling;
                player.GKReach = gkReach;
                player.PlayableGK = playableGK;
                player.OffensiveAwareness = offensiveAwareness;
                player.Dribbling = dribbling;
                player.Acceleration = acceleration;
                player.Stamina = stamina;
                player.Curl = curl;
                player.UnknownBit3 = unknownBit3;
                player.UnknownBit4 = unknownBit4;
                player.LoftedPass = loftedPass;
                player.Finishing = finishing;
                player.PhysicalContact = physicalContact;
                player.Aggression = aggression;
                player.Balance = balance;
                player.WeakFootUsage = weakFootUsage;
                player.RegisteredPosition = registeredPosition;
                player.RunningArmMovement = runningArmMovement;
                player.DribblingArmMovement = dribblingArmMovement;
                player.TightPossession = tightPossession;
                player.DefensiveEngangement = defensiveEngangement;
                player.Age = age;
                player.PlayableRB = playableRB;
                player.PlayableLWF = playableLWF;
                player.PlayableCF = playableCF;
                player.PlayableCB = playableCB;
                player.Form = form;
                player.PlayableAMF = playableAMF;
                player.WeakFootAccuracy = weakFootAccuracy;
                player.PlayableRMF = playableRMF;
                player.InjuryResistance = injuryResistance;
                player.PlayableCMF = playableCMF;
                player.UnknownBits7 = unknownBits7;
                player.RunningHunching = runningHunching;
                player.DribblingHunching = dribblingHunching;
                player.PenaltyKickMotion = penaltyKickMotion;
                player.SlidingTackle = slidingTackle;
                player.GKPenaltySaver = gkPenaltySaver;
                player.PenaltySpecialist = penaltySpecialist;
                player.SoleControl = soleControl;
                player.RisingShots = risingShots;
                player.BallonDorWinner = ballonDorWinner;
                player.MarseilleTurn = marseilleTurn;
                player.GKHighPunt = gkHighPunt;
                player.HeadingSkills = headingSkills;
                player.OutsideCurler = outsideCurler;
                player.Captanincy = captanincy;
                player.Gamasmanship = gamasmanship;
                player.GkLowPunt = gkLowPunt;
                player.TrickSter = trickSter;
                player.LowLoftedPass = lowLoftedPass;
                player.ThroughPassing = throughPassing;
                player.FightingSpirit = fightingSpirit;
                player.FlipFlap = flipFlap;
                player.WeightedPass = weightedPass;
                player.AerialSuperiority = aerialSuperiority;
                player.PinpointCrossing = pinpointCrossing;
                player.Sombrero = sombrero;
                player.EarlyCross = earlyCross;
                player.ChopTurn = chopTurn;
                player.DribblingMotion = dribblingMotion;
                player.PlayableSS = playableSS;
                player.PlayableRWF = playableRWF;
                player.PlayableDMF = playableDMF;
                player.UnknownBit5 = unknownBit5;
                player.StrongerHand = strongerHand;
                player.MazingRun = mazingRun;
                player.UnknownBit6 = unknownBit6;
                player.LongBallExpert = longBallExpert;
                player.AcrobaticClear = acrobaticClear;
                player.LongRangeCurler = longRangeCurler;
                player.SpeedingBullet = speedingBullet;
                player.Blocker = blocker;
                player.ScotchMove = scotchMove;
                player.AcrobaticFinishing = acrobaticFinishing;
                player.DoubleTouch = doubleTouch;
                player.GKLongThrow = gkLongThrow;
                player.LongThrow = longThrow;
                player.ScissorsFeint = scissorsFeint;
                player.LongRangeShooting = longRangeShooting;
                player.TrackBack = trackBack;
                player.SuperSub = superSub;
                player.Rabona = rabona;
                player.DippingShot = dippingShot;
                player.StroongerFoot = stroongerFoot;
                player.KnuckleShot = knuckleShot;
                player.NoLookPass = noLookPass;
                player.FirstTimeShot = firstTimeShot;
                player.IncisiveRun = incisiveRun;
                player.UnknownBit7 = unknownBit7;
                player.LongRanger = longRanger;
                player.OneTouchPass = oneTouchPass;
                player.ChipShotControl = chipShotControl;
                player.HellTrick = hellTrick;
                player.ManMarking = manMarking;
                player.Interception = interception;
                player.JapaneseName = japaneseName;
                player.ShirtName = shirtName;
                player.ChineseName = chineseName;
                player.ClubShirtName = clubShirtName;
                player.Name = name;
            }
            catch (Exception)
            {
                return null;
            }

            return player;
        }

        public int LoadPlayerByID(uint playerID)
        {
            int playerNumber = (int)MemoryPlayer.Length / BLOCK;

            ReadPlayer.BaseStream.Position = 8;
            for (int i = 0; i < playerNumber; i++)
            {
                if (playerID == ReadPlayer.ReadUInt32())
                    return i;

                ReadPlayer.BaseStream.Position += BLOCK - 4;
            }

            return -1;
        }

        public int ApplyPlayer(int index, Player player)
        {
            try
            {
                int offsetBase = BLOCK * index;
                WritePlayer.BaseStream.Position = offsetBase;
                byte zero = 0;

                WritePlayer.BaseStream.Position = offsetBase;
                WritePlayer.Write(player.YouthPlayerID);
                WritePlayer.Write(player.OwnerClubID);
                WritePlayer.Write(player.ID);
                WritePlayer.Write(0);
                WritePlayer.Write(player.ClubID);

                string value1 = "";
                value1 = Convert.ToString(player.ContractDate, 2).PadLeft(27, '0') + value1;
                value1 = Convert.ToString(player.FreeKickMotion - 1, 2).PadLeft(5, '0') + value1;
                WritePlayer.Write(Convert.ToUInt32(value1, 2));

                string value2 = "";
                value2 = Convert.ToString(player.LoanContractExpiryDate, 2).PadLeft(27, '0') + value2;
                value2 = Convert.ToString(player.PlayingStyle, 2).PadLeft(5, '0') + value2;
                WritePlayer.Write(Convert.ToUInt32(value2, 2));

                string value3 = "";
                value3 = Convert.ToString(player.MarketValue, 2).PadLeft(24, '0') + value3;
                value3 = Convert.ToString(player.NationalTeamCaps, 2).PadLeft(8, '0') + value3;
                WritePlayer.Write(Convert.ToUInt32(value3, 2));

                string value4 = "";
                value4 = Convert.ToString(0, 2).PadLeft(24, '0') + value4;
                value4 = Convert.ToString(player.Height - 100, 2).PadLeft(8, '0') + value4;
                WritePlayer.Write(Convert.ToUInt32(value4, 2));

                string value5 = "";
                value5 = Convert.ToString(player.NationalID2, 2).PadLeft(9, '0') + value5;
                value5 = Convert.ToString(player.NationalID1, 2).PadLeft(9, '0') + value5;
                value5 = Convert.ToString(player.GoalCelebration, 2).PadLeft(8, '0') + value5;
                value5 = Convert.ToString(player.SetPieceTaking - 40, 2).PadLeft(6, '0') + value5;
                WritePlayer.Write(Convert.ToUInt32(value5, 2));

                string value6 = "";
                value6 = Convert.ToString(player.UnknownBits4, 2).PadLeft(7, '0') + value6;
                value6 = Convert.ToString(player.UnknownBits3, 2).PadLeft(7, '0') + value6;
                value6 = Convert.ToString(player.UnknownBits2, 2).PadLeft(7, '0') + value6;
                value6 = Convert.ToString(player.Weight - 30, 2).PadLeft(7, '0') + value6;
                value6 = Convert.ToString(player.CornerKick - 1, 2).PadLeft(4, '0') + value6;
                WritePlayer.Write(Convert.ToUInt32(value6, 2));

                string value7 = "";
                value7 = Convert.ToString(player.UnknownBits6, 2).PadLeft(6, '0') + value7;
                value7 = Convert.ToString(player.UnknownBits5, 2).PadLeft(6, '0') + value7;
                value7 = Convert.ToString(player.UnknownBit2 ? "1" : "0") + value7;
                value7 = Convert.ToString(player.UnknownBit1 ? "1" : "0") + value7;
                value7 = Convert.ToString(player.LowPass - 40, 2).PadLeft(6, '0') + value7;
                value7 = Convert.ToString(player.KickingPower - 40, 2).PadLeft(6, '0') + value7;
                value7 = Convert.ToString(player.DefensiveAwareness - 40, 2).PadLeft(6, '0') + value7;
                WritePlayer.Write(Convert.ToUInt32(value7, 2));

                string value8 = "";
                value8 = Convert.ToString(player.BallControl - 40, 2).PadLeft(6, '0') + value8;
                value8 = Convert.ToString(player.Heading - 40, 2).PadLeft(6, '0') + value8;
                value8 = Convert.ToString(player.Jump - 40, 2).PadLeft(6, '0') + value8;
                value8 = Convert.ToString(player.GKCatching - 40, 2).PadLeft(6, '0') + value8;
                value8 = Convert.ToString(player.Speed - 40, 2).PadLeft(6, '0') + value8;
                value8 = Convert.ToString(player.PlayableLB, 2).PadLeft(2, '0') + value8;
                WritePlayer.Write(Convert.ToUInt32(value8, 2));

                string value9 = "";
                value9 = Convert.ToString(player.GKReach - 40, 2).PadLeft(6, '0') + value9;
                value9 = Convert.ToString(player.Tackling - 40, 2).PadLeft(6, '0') + value9;
                value9 = Convert.ToString(player.GKReflexes - 40, 2).PadLeft(6, '0') + value9;
                value9 = Convert.ToString(player.GKParrying - 40, 2).PadLeft(6, '0') + value9;
                value9 = Convert.ToString(player.GKAwareness - 40, 2).PadLeft(6, '0') + value9;
                value9 = Convert.ToString(player.PlayableLMF, 2).PadLeft(2, '0') + value9;
                WritePlayer.Write(Convert.ToUInt32(value9, 2));

                string value10 = "";
                value10 = Convert.ToString(player.Curl - 40, 2).PadLeft(6, '0') + value10;
                value10 = Convert.ToString(player.Stamina - 40, 2).PadLeft(6, '0') + value10;
                value10 = Convert.ToString(player.Acceleration - 40, 2).PadLeft(6, '0') + value10;
                value10 = Convert.ToString(player.Dribbling - 40, 2).PadLeft(6, '0') + value10;
                value10 = Convert.ToString(player.OffensiveAwareness - 40, 2).PadLeft(6, '0') + value10;
                value10 = Convert.ToString(player.PlayableGK, 2).PadLeft(2, '0') + value10;
                WritePlayer.Write(Convert.ToUInt32(value10, 2));

                string value11 = "";
                value11 = Convert.ToString(player.Balance - 40, 2).PadLeft(6, '0') + value11;
                value11 = Convert.ToString(player.Aggression - 40, 2).PadLeft(6, '0') + value11;
                value11 = Convert.ToString(player.PhysicalContact - 40, 2).PadLeft(6, '0') + value11;
                value11 = Convert.ToString(player.Finishing - 40, 2).PadLeft(6, '0') + value11;
                value11 = Convert.ToString(player.LoftedPass - 40, 2).PadLeft(6, '0') + value11;
                value11 = Convert.ToString(player.UnknownBit4 ? "1" : "0") + value11;
                value11 = Convert.ToString(player.UnknownBit3 ? "1" : "0") + value11;
                WritePlayer.Write(Convert.ToUInt32(value11, 2));

                string value12 = "";
                value12 = Convert.ToString(player.Age - 15, 2).PadLeft(6, '0') + value12;
                value12 = Convert.ToString(player.DefensiveEngangement - 40, 2).PadLeft(6, '0') + value12;
                value12 = Convert.ToString(player.TightPossession - 40, 2).PadLeft(6, '0') + value12;
                value12 = Convert.ToString(player.DribblingArmMovement - 1, 2).PadLeft(4, '0') + value12;
                value12 = Convert.ToString(player.RunningArmMovement - 1, 2).PadLeft(4, '0') + value12;
                value12 = Convert.ToString(player.RegisteredPosition, 2).PadLeft(4, '0') + value12;
                value12 = Convert.ToString(player.WeakFootUsage, 2).PadLeft(2, '0') + value12;
                WritePlayer.Write(Convert.ToUInt32(value12, 2));

                string value13 = "";
                value13 = Convert.ToString(player.PenaltyKickMotion - 1, 2).PadLeft(3, '0') + value13;
                value13 = Convert.ToString(player.DribblingHunching - 1, 2).PadLeft(3, '0') + value13;
                value13 = Convert.ToString(player.RunningHunching - 1, 2).PadLeft(3, '0') + value13;
                value13 = Convert.ToString(player.UnknownBits7, 2).PadLeft(3, '0') + value13;
                value13 = Convert.ToString(player.PlayableCMF, 2).PadLeft(2, '0') + value13;
                value13 = Convert.ToString(player.InjuryResistance, 2).PadLeft(2, '0') + value13;
                value13 = Convert.ToString(player.PlayableRMF, 2).PadLeft(2, '0') + value13;
                value13 = Convert.ToString(player.WeakFootAccuracy, 2).PadLeft(2, '0') + value13;
                value13 = Convert.ToString(player.PlayableAMF, 2).PadLeft(2, '0') + value13;
                value13 = Convert.ToString(player.Form, 2).PadLeft(2, '0') + value13;
                value13 = Convert.ToString(player.PlayableCB, 2).PadLeft(2, '0') + value13;
                value13 = Convert.ToString(player.PlayableCF, 2).PadLeft(2, '0') + value13;
                value13 = Convert.ToString(player.PlayableLWF, 2).PadLeft(2, '0') + value13;
                value13 = Convert.ToString(player.PlayableRB, 2).PadLeft(2, '0') + value13;
                WritePlayer.Write(Convert.ToUInt32(value13, 2));

                string value14 = "";
                value14 = Convert.ToString(player.PlayableDMF, 2).PadLeft(2, '0') + value14;
                value14 = Convert.ToString(player.PlayableRWF, 2).PadLeft(2, '0') + value14;
                value14 = Convert.ToString(player.PlayableSS, 2).PadLeft(2, '0') + value14;
                value14 = Convert.ToString(player.DribblingMotion - 1, 2).PadLeft(2, '0') + value14;
                value14 = Convert.ToString(player.ChopTurn ? "1" : "0") + value14;
                value14 = Convert.ToString(player.EarlyCross ? "1" : "0") + value14;
                value14 = Convert.ToString(player.Sombrero ? "1" : "0") + value14;
                value14 = Convert.ToString(player.PinpointCrossing ? "1" : "0") + value14;
                value14 = Convert.ToString(player.AerialSuperiority ? "1" : "0") + value14;
                value14 = Convert.ToString(player.WeightedPass ? "1" : "0") + value14;
                value14 = Convert.ToString(player.FlipFlap ? "1" : "0") + value14;
                value14 = Convert.ToString(player.FightingSpirit ? "1" : "0") + value14;
                value14 = Convert.ToString(player.ThroughPassing ? "1" : "0") + value14;
                value14 = Convert.ToString(player.LowLoftedPass ? "1" : "0") + value14;
                value14 = Convert.ToString(player.TrickSter ? "1" : "0") + value14;
                value14 = Convert.ToString(player.GkLowPunt ? "1" : "0") + value14;
                value14 = Convert.ToString(player.Gamasmanship ? "1" : "0") + value14;
                value14 = Convert.ToString(player.Captanincy ? "1" : "0") + value14;
                value14 = Convert.ToString(player.OutsideCurler ? "1" : "0") + value14;
                value14 = Convert.ToString(player.HeadingSkills ? "1" : "0") + value14;
                value14 = Convert.ToString(player.GKHighPunt ? "1" : "0") + value14;
                value14 = Convert.ToString(player.MarseilleTurn ? "1" : "0") + value14;
                value14 = Convert.ToString(player.BallonDorWinner ? "1" : "0") + value14;
                value14 = Convert.ToString(player.RisingShots ? "1" : "0") + value14;
                value14 = Convert.ToString(player.SoleControl ? "1" : "0") + value14;
                value14 = Convert.ToString(player.PenaltySpecialist ? "1" : "0") + value14;
                value14 = Convert.ToString(player.GKPenaltySaver ? "1" : "0") + value14;
                value14 = Convert.ToString(player.SlidingTackle ? "1" : "0") + value14;
                WritePlayer.Write(Convert.ToUInt32(value14, 2));

                string value15 = "";
                value15 = Convert.ToString(player.Interception ? "1" : "0") + value15;
                value15 = Convert.ToString(player.ManMarking ? "1" : "0") + value15;
                value15 = Convert.ToString(player.HellTrick ? "1" : "0") + value15;
                value15 = Convert.ToString(player.ChipShotControl ? "1" : "0") + value15;
                value15 = Convert.ToString(player.OneTouchPass ? "1" : "0") + value15;
                value15 = Convert.ToString(player.LongRanger ? "1" : "0") + value15;
                value15 = Convert.ToString(player.UnknownBit7 ? "1" : "0") + value15;
                value15 = Convert.ToString(player.IncisiveRun ? "1" : "0") + value15;
                value15 = Convert.ToString(player.FirstTimeShot ? "1" : "0") + value15;
                value15 = Convert.ToString(player.NoLookPass ? "1" : "0") + value15;
                value15 = Convert.ToString(player.KnuckleShot ? "1" : "0") + value15;
                value15 = Convert.ToString(player.StroongerFoot ? "1" : "0") + value15;
                value15 = Convert.ToString(player.DippingShot ? "1" : "0") + value15;
                value15 = Convert.ToString(player.Rabona ? "1" : "0") + value15;
                value15 = Convert.ToString(player.SuperSub ? "1" : "0") + value15;
                value15 = Convert.ToString(player.TrackBack ? "1" : "0") + value15;
                value15 = Convert.ToString(player.LongRangeShooting ? "1" : "0") + value15;
                value15 = Convert.ToString(player.ScissorsFeint ? "1" : "0") + value15;
                value15 = Convert.ToString(player.LongThrow ? "1" : "0") + value15;
                value15 = Convert.ToString(player.GKLongThrow ? "1" : "0") + value15;
                value15 = Convert.ToString(player.DoubleTouch ? "1" : "0") + value15;
                value15 = Convert.ToString(player.AcrobaticFinishing ? "1" : "0") + value15;
                value15 = Convert.ToString(player.ScotchMove ? "1" : "0") + value15;
                value15 = Convert.ToString(player.Blocker ? "1" : "0") + value15;
                value15 = Convert.ToString(player.SpeedingBullet ? "1" : "0") + value15;
                value15 = Convert.ToString(player.LongRangeCurler ? "1" : "0") + value15;
                value15 = Convert.ToString(player.AcrobaticClear ? "1" : "0") + value15;
                value15 = Convert.ToString(player.LongBallExpert ? "1" : "0") + value15;
                value15 = Convert.ToString(player.UnknownBit6 ? "1" : "0") + value15;
                value15 = Convert.ToString(player.MazingRun ? "1" : "0") + value15;
                value15 = Convert.ToString(player.StrongerHand ? "1" : "0") + value15;
                value15 = Convert.ToString(player.UnknownBit5 ? "1" : "0") + value15;
                WritePlayer.Write(Convert.ToUInt32(value15, 2));

                for (int i = 0; i <= 61; i++)
                {
                    WritePlayer.Write(zero);
                }

                WritePlayer.BaseStream.Position = offsetBase + 80;
                WritePlayer.Write(Encoding.UTF8.GetBytes(player.JapaneseName.PadRight(61, '\0')), 0, 61);

                for (int i = 0; i <= 61; i++)
                {
                    WritePlayer.Write(zero);
                }

                WritePlayer.BaseStream.Position = offsetBase + 141;
                WritePlayer.Write(Encoding.UTF8.GetBytes(player.ShirtName.PadRight(61, '\0')), 0, 61);

                for (int i = 0; i <= 61; i++)
                {
                    WritePlayer.Write(zero);
                }

                WritePlayer.BaseStream.Position = offsetBase + 202;
                WritePlayer.Write(Encoding.UTF8.GetBytes(player.ChineseName.PadRight(61, '\0')), 0, 61);

                for (int i = 0; i <= 61; i++)
                {
                    WritePlayer.Write(zero);
                }

                WritePlayer.BaseStream.Position = offsetBase + 263;
                WritePlayer.Write(Encoding.UTF8.GetBytes(player.ClubShirtName.PadRight(61, '\0')), 0, 61);

                for (int i = 0; i <= 61; i++)
                {
                    WritePlayer.Write(zero);
                }

                WritePlayer.BaseStream.Position = offsetBase + 324;
                WritePlayer.Write(Encoding.UTF8.GetBytes(player.Name.PadRight(61, '\0')), 0, 61);
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public int Save(string patch)
        {
            try
            {
                byte[] ss13 = Zlib.ZlibFilePC(MemoryPlayer.ToArray());
                File.WriteAllBytes(patch + FILE_NAME, ss13);
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public void CloseMemory()
        {
            if (MemoryPlayer != null)
            {
                MemoryPlayer.Close();
                ReadPlayer.Close();
                WritePlayer.Close();
                PlayerTable.Rows.Clear();
            }
        }
    }
}
