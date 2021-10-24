using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoTool.Utils
{
    static class CalculateOverall
    {
        public static int Overall(uint registeredPosition, uint gkReach, uint gkCatching, uint gkAwareness, uint balance, uint jump, uint heading, uint defensiveAwareness, uint tackling, uint speed, uint stamina, uint offensiveAwareness, uint ballControl, uint dribbling, uint loftedPass, uint lowPass, uint aggression, uint setPieceTaking, uint finishing, uint kickingPower)
        {
            int overall = 0;
            switch (registeredPosition)
            {
                case 0:
                    overall = checked((int)Math.Round(Math.Round(unchecked((double)(gkReach - 24) * 0.56 + (double)(gkCatching - 24) * 0.59 + (double)(gkAwareness - 24) * 0.11 + (double)(balance - 25) * 0.10 + (double)(jump - 25) * 0.13 + 7.0), MidpointRounding.AwayFromZero)));
                    break;
                case 1:
                    overall = checked((int)Math.Round(Math.Round(unchecked((double)(heading - 25) * 0.2 + (double)(defensiveAwareness - 25) * 0.27 + (double)(tackling - 25) * 0.27 + (double)(speed - 25) * 0.11 + (double)(balance - 25) * 0.21 + (double)(jump - 25) * 0.21 + (double)(stamina - 25) * 0.1 + 7.0), MidpointRounding.AwayFromZero)));
                    break;
                case 2:
                    overall = checked((int)Math.Round(Math.Round(unchecked((double)(offensiveAwareness - 25) * 0.06 + (double)(ballControl - 25) * 0.1 + (double)(dribbling - 25) * 0.15 + (double)(loftedPass - 25) * 0.15 + (double)(defensiveAwareness - 25) * 0.15 + (double)(tackling - 25) * 0.14 + (double)(speed - 25) * 0.15 + (double)(aggression - 25) * 0.15 + (double)(balance - 25) * 0.12 + (double)(jump - 25) * 0.12 + (double)(stamina - 25) * 0.13 + 8.0), MidpointRounding.AwayFromZero)));
                    break;
                case 3:
                    overall = checked((int)Math.Round(Math.Round(unchecked((double)(offensiveAwareness - 25) * 0.06 + (double)(ballControl - 25) * 0.1 + (double)(dribbling - 25) * 0.15 + (double)(loftedPass - 25) * 0.15 + (double)(defensiveAwareness - 25) * 0.15 + (double)(tackling - 25) * 0.14 + (double)(speed - 25) * 0.15 + (double)(aggression - 25) * 0.15 + (double)(balance - 25) * 0.12 + (double)(jump - 25) * 0.12 + (double)(stamina - 25) * 0.13 + 8.0), MidpointRounding.AwayFromZero)));
                    break;
                case 4:
                    overall = checked((int)Math.Round(Math.Round(unchecked((double)(offensiveAwareness - 25) * 0.07 + (double)(ballControl - 25) * 0.19 + (double)(dribbling - 25) * 0.16 + (double)(lowPass - 25) * 0.19 + (double)(loftedPass - 25) * 0.2 + (double)(setPieceTaking - 25) * 0.13 + (double)(defensiveAwareness - 25) * 0.07 + (double)(tackling - 25) * 0.03 + (double)(speed - 25) * 0.03 + (double)(aggression - 25) * 0.03 + (double)(balance - 25) * 0.14 + (double)(jump - 25) * 0.05 + (double)(stamina - 25) * 0.15 + 8.0), MidpointRounding.AwayFromZero)));
                    break;
                case 5:
                    overall = checked((int)Math.Round(Math.Round(unchecked((double)(offensiveAwareness - 25) * 0.05 + (double)(ballControl - 25) * 0.25 + (double)(dribbling - 25) * 0.25 + (double)(lowPass - 25) * 0.25 + (double)(loftedPass - 25) * 0.22 + (double)(defensiveAwareness - 25) * 0.03 + (double)(speed - 25) * 0.04 + (double)(aggression - 25) * 0.06 + (double)(balance - 25) * 0.05 + (double)(stamina - 25) * 0.18 + 7.0), MidpointRounding.AwayFromZero)));
                    break;
                case 6:
                    overall = checked((int)Math.Round(Math.Round(unchecked((double)(offensiveAwareness - 25) * 0.07 + (double)(ballControl - 25) * 0.16 + (double)(dribbling - 25) * 0.26 + (double)(lowPass - 25) * 0.07 + (double)(loftedPass - 25) * 0.13 + (double)(setPieceTaking - 25) * 0.04 + (double)(speed - 25) * 0.26 + (double)(aggression - 25) * 0.23 + (double)(stamina - 25) * 0.14 + 7.0), MidpointRounding.AwayFromZero)));
                    break;
                case 7:
                    overall = checked((int)Math.Round(Math.Round(unchecked((double)(offensiveAwareness - 25) * 0.07 + (double)(ballControl - 25) * 0.16 + (double)(dribbling - 25) * 0.26 + (double)(lowPass - 25) * 0.07 + (double)(loftedPass - 25) * 0.13 + (double)(setPieceTaking - 25) * 0.04 + (double)(speed - 25) * 0.26 + (double)(aggression - 25) * 0.23 + (double)(stamina - 25) * 0.14 + 7.0), MidpointRounding.AwayFromZero)));
                    break;
                case 8:
                    overall = checked((int)Math.Round(Math.Round(unchecked((double)(offensiveAwareness - 25) * 0.15 + (double)(ballControl - 25) * 0.23 + (double)(dribbling - 25) * 0.23 + (double)(lowPass - 25) * 0.23 + (double)(loftedPass - 25) * 0.15 + (double)(finishing - 25) * 0.18 + (double)(speed - 25) * 0.05 + (double)(aggression - 25) * 0.07 + (double)(balance - 25) * 0.05 + (double)(stamina - 25) * 0.03 + 7.0), MidpointRounding.AwayFromZero)));
                    break;
                case 9:
                    overall = checked((int)Math.Round(Math.Round(unchecked((double)(offensiveAwareness - 25) * 0.18 + (double)(ballControl - 25) * 0.22 + (double)(dribbling - 25) * 0.22 + (double)(lowPass - 25) * 0.05 + (double)(loftedPass - 25) * 0.1 + (double)(finishing - 25) * 0.12 + (double)(kickingPower - 25) * 0.05 + (double)(speed - 25) * 0.16 + (double)(aggression - 25) * 0.16 + (double)(stamina - 25) * 0.06 + (double)(stamina - 25) * 0.06 + 9.0), MidpointRounding.AwayFromZero)));
                    break;
                case 10:
                    overall = checked((int)Math.Round(Math.Round(unchecked((double)(offensiveAwareness - 25) * 0.18 + (double)(ballControl - 25) * 0.22 + (double)(dribbling - 25) * 0.22 + (double)(lowPass - 25) * 0.05 + (double)(loftedPass - 25) * 0.1 + (double)(finishing - 25) * 0.12 + (double)(kickingPower - 25) * 0.05 + (double)(speed - 25) * 0.16 + (double)(aggression - 25) * 0.16 + (double)(stamina - 25) * 0.06 + (double)(stamina - 25) * 0.06 + 9.0), MidpointRounding.AwayFromZero)));
                    break;
                case 11:
                    overall = checked((int)Math.Round(Math.Round(unchecked((double)(offensiveAwareness - 25) * 0.16 + (double)(ballControl - 25) * 0.2 + (double)(dribbling - 25) * 0.2 + (double)(lowPass - 25) * 0.1 + (double)(loftedPass - 25) * 0.1 + (double)(finishing - 25) * 0.15 + (double)(kickingPower - 25) * 0.06 + (double)(speed - 25) * 0.1 + (double)(aggression - 25) * 0.2 + (double)(stamina - 25) * 0.07 + (double)(stamina - 25) * 0.04 + 7.0), MidpointRounding.AwayFromZero)));
                    break;
                case 12:
                    overall = checked((int)Math.Round(Math.Round(unchecked((double)(offensiveAwareness - 25) * 0.4 + (double)(ballControl - 25) * 0.29 + (double)(dribbling - 25) * 0.15 + (double)(finishing - 25) * 0.37 + (double)(heading - 25) * 0.01 + (double)(speed - 25) * 0.05 + (double)(aggression - 25) * 0.05 + (double)(balance - 25) * 0.1 + (double)(jump - 25) * 0.06 + 7.0), MidpointRounding.AwayFromZero)));
                    break;
            }

            return overall;
        }

        
    }
}
