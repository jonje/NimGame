using System.Collections.Generic;

namespace Nim {

    public static class NimStateHelper {

        public static readonly NimState StartingNimState = new NimState(3, 5, 7);

        public static bool IsCompatibleWith(this NimState from, NimState to) {

            return GetDiff(from, to) == 1;
        }

        public static int GetDiff(this NimState from, NimState to) {

            int diff = 0;
            if (from.X == to.X)
                diff++;
            if (from.Y == to.Y)
                diff++;
            if (from.Z == to.Z)
                diff++;
            return diff;
        }

        public static List<NimState> GetPossibleStates(this NimState state) {

            List<NimState> states = new List<NimState>();

            for (int i = 1; i <= state.XReal; i++) {

                NimState tempState = state.Clone();
                tempState.XReal -= i;
                if (tempState.HasValidMoves())
                    states.Add(tempState);
            }

            for (int i = 1; i <= state.YReal; i++) {

                NimState tempState = state.Clone();
                tempState.YReal -= i;
                if (tempState.HasValidMoves())
                    states.Add(tempState);
            }

            for (int i = 1; i <= state.ZReal; i++) {

                NimState tempState = state.Clone();
                tempState.ZReal -= i;
                if (tempState.HasValidMoves())
                    states.Add(tempState);
            }

            return states;
        }
    }
}
