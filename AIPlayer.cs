using System.Collections.Generic;
using SlightLibrary.Extensions;

namespace Nim {
    class AIPlayer : Player {

        private readonly NimStateStore _store;

        public AIPlayer(string playerName, NimStateStore store)
            : base(playerName) {

            _store = store;
        }

        public override NimState GetNextState(NimState state) {

            NimState bestState = new NimState(0, 0, 1);
            double bestScore = -1;
            List<NimState> states = state.GetPossibleStates();

            foreach (NimState nimState in states) {

                double tempScore = _store.GetScore(nimState.Clone());

                if (tempScore > bestScore) {

                    bestScore = tempScore;
                    bestState = nimState.Clone();
                }
            }

            ("Of the " + states.Count + " States, Move: " + bestState + " decided, confidence: " + ((float) bestScore)).ToConsole();

            return bestState;
        }
    }
}
