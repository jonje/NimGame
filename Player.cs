namespace Nim {
    public abstract class Player {

        public abstract NimState GetNextState(NimState state);

        public string Name {
            get;
            set;
        }

        public NimStateHistory History {
            get;
            private set;
        }

        protected Player(string playerName) {

            Name = playerName;
            History = new NimStateHistory();
        }

        public override string ToString() {
            return Name;
        }

        public void PushHistory(NimStateStore store, bool winner) {

            History.StoreResults(winner, store);
            History.Reset();
        }
    }
}
