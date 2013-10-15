using System.Collections.Generic;

namespace Nim {
    public class NimStateHistory {

        public List<NimState> History {
            get;
            private set;
        }

        public NimStateHistory() {

            Reset();
        }

        public void Reset() {

            History = new List<NimState>();
        }

        public void Add(NimState state) {

            History.Add(state);
        }

        public void StoreResults(bool isWinner, NimStateStore stateStore) {

            int multi = (!isWinner) ? 1 : -1;
            for (int i = 0; i < History.Count; i++)
                stateStore.AddScore(History[i], ((double) (multi * (i + 1))) / History.Count);
        }
    }
}
