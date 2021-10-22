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

        public MemoryStream MemoryPlayer { get; set; }
        public BinaryReader ReadPlayer { get; set; }
        public BinaryWriter WritePlayer { get; set; }
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
                    playerName = Encoding.UTF8.GetString(ReadPlayer.ReadBytes(44)).TrimEnd('\0');

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

        public Player LoadBall(int index)
        {
            Player player;

            uint youthPlayerId;
            uint ownerClub;
            uint playerId;
            uint padding;
            uint clubId;
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
            uint nationalId1;
            uint nationalId2;
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
            string name;
            uint unknownBits7;
            try
            {
                ReadPlayer.BaseStream.Position = index * BLOCK;
                youthPlayerId = ReadPlayer.ReadUInt32();
                ownerClub = ReadPlayer.ReadUInt32();
                playerId = ReadPlayer.ReadUInt32();
                padding = ReadPlayer.ReadUInt32();
                clubId = ReadPlayer.ReadUInt32();

                uint aux1 = ReadPlayer.ReadUInt32();
                freeKickMotion = ((aux1 << 0) >> 27) + 1;
                contractDate = aux1 << 5 >> 5;

                uint aux2 = ReadPlayer.ReadUInt32();
                playingStyle = aux2 >> 27;
                loanContractExpiryDate = aux2 << 5 >> 5;

                uint aux3 = ReadPlayer.ReadUInt32();
                nationalTeamCaps = ((aux3 << 0) >> 24); ;
                marketValue = ((aux3 << 8) >> 8);

                uint aux4 = ReadPlayer.ReadUInt32();
                height = ((aux4 << 0) >> 24);
                unknownBits1 = ((aux4 << 8) >> 8);

                uint aux5 = ReadPlayer.ReadUInt32();
                setPieceTaking = ((aux5 << 0) >> 26);
                goalCelebration = aux5 << 6 >> 24;
                nationalId1 = aux5 << 14 >> 23;
                nationalId2 = aux5 << 23 >> 23;

                uint aux6 = ReadPlayer.ReadUInt32();
                cornerKick = ((aux6 << 0) >> 28) + 1;
                weight = aux6 << 4 >> 25;
                unknownBits2 = aux6 << 11 >> 25;
                unknownBits3 = aux6 << 18 >> 25;
                unknownBits4 = aux6 << 25 >> 25;

                uint aux7 = ReadPlayer.ReadUInt32();
                defensiveAwareness = aux7 << 0 >> 26;
                kickingPower = aux7 << 6 >> 26;
                lowPass = aux7 << 12 >> 26;
                unknownBit1 = aux7 << 18 >> 31 == 1 ? true : false;
                unknownBit2 = aux7 << 19 >> 31 == 1 ? true : false;
                unknownBits5 = aux7 << 20 >> 26;
                unknownBits6 = aux7 << 26 >> 26;

                uint aux8 = ReadPlayer.ReadUInt32();
                playableLB = ((aux8 << 0) >> 30);
                speed = ((aux8 << 2) >> 26);
                gkCatching = ((aux8 << 8) >> 26);
                jump = ((aux8 << 14) >> 26);
                heading = ((aux8 << 20) >> 26);
                ballControl = ((aux8 << 26) >> 26);

                uint aux9 = ReadPlayer.ReadUInt32();
                playableLMF = ((aux9 << 0) >> 30);
                gkAwareness = ((aux9 << 2) >> 26);
                gkParrying = ((aux9 << 8) >> 26);
                gkReflexes = ((aux9 << 14) >> 26);
                tackling = ((aux9 << 20) >> 26);
                gkReach = ((aux9 << 26) >> 26);

                uint aux10 = ReadPlayer.ReadUInt32();
                playableGK = ((aux10 << 0) >> 30);
                offensiveAwareness = ((aux10 << 2) >> 26);
                dribbling = ((aux10 << 8) >> 26);
                acceleration = ((aux10 << 14) >> 26);
                stamina = ((aux10 << 20) >> 26);
                curl = ((aux10 << 26) >> 26);

                uint aux11 = ReadPlayer.ReadUInt32();
                unknownBit3 = aux11 << 0 >> 31 == 1 ? true : false;
                unknownBit4 = aux11 << 1 >> 31 == 1 ? true : false;
                loftedPass = ((aux11 << 2) >> 26);
                finishing = ((aux11 << 8) >> 26);
                physicalContact = ((aux11 << 14) >> 26);
                aggression = ((aux11 << 20) >> 26);
                balance = ((aux11 << 26) >> 26);

                uint aux12 = ReadPlayer.ReadUInt32();
                weakFootUsage = ((aux12 << 0) >> 30);
                registeredPosition = ((aux12 << 2) >> 28);
                runningArmMovement = ((aux12 << 6) >> 28) + 1;
                dribblingArmMovement = ((aux12 << 10) >> 28) + 1;
                tightPossession = ((aux12 << 14) >> 26);
                defensiveEngangement = ((aux12 << 20) >> 26);
                age = ((aux12 << 26) >> 26);

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

                name = Encoding.UTF8.GetString(ReadPlayer.ReadBytes(61)).TrimEnd('\0');

                player = new Player(playerId);
                player.YouthPlayerId = youthPlayerId;
                player.OwnerClub = ownerClub;
                player.Id = playerId;
                player.Padding = padding;
                player.ClubId = clubId;
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
                player.NationalId1 = nationalId1;
                player.NationalId2 = nationalId2;
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
                player.Name = name;
            }
            catch (Exception)
            {
                return null;
            }

            return player;
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
