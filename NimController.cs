using System;
using SlightLibrary.Extensions;
using SlightLibrary.Helpers;

namespace Nim {

    class NimController {

        public Player Player1 {
            get;
            private set;
        }

        public Player Player2 {
            get;
            private set;
        }

        public Player PlayerCurrent {
            get;
            private set;
        }

        public NimStateStore StateStore {
            get;
            private set;
        }

        public NimController() {

            StateStore = new NimStateStore();
        }

        public void Start() {

            "Welcome To nim, his name is Fred.".ToConsole();

            while (true) {

                "Game Mode?".ToConsole();
                "1) PvP".ToConsole();
                "2) PvE (You First)".ToConsole();
                "3) PvE (AI First)".ToConsole();
                "4) EvE".ToConsole();
                "5) Train".ToConsole();
                "6) Exit".ToConsole();

                int roundsToPlay = 1;

                switch (IOHelper.PromptForInputInt("Option?", 1, 6)) {
                    case 1:
                        Player1 = new HumanPlayer("Player 1");
                        Player2 = new HumanPlayer("Player 2");
                        break;
                    case 2:
                        Player1 = new HumanPlayer("Player 1");
                        Player2 = new AIPlayer("Player 2", StateStore);
                        break;
                    case 3:
                        Player1 = new HumanPlayer("Player 1");
                        Player2 = new AIPlayer("Player 2", StateStore);
                        break;
                    case 4:
                        roundsToPlay = IOHelper.PromptForInputInt("Number of rounds to play?", 1);
                        Player1 = new AIPlayer("Player 1", StateStore);
                        Player2 = new AIPlayer("Player 2", StateStore);
                        break;
                    case 5:
                        roundsToPlay = IOHelper.PromptForInputInt("Number of rounds to train?", 1);
                        Player1 = new AIPlayer("Player 1", StateStore);
                        Player2 = new AIPlayer("Player 2", StateStore);
                        while (roundsToPlay-- >= 1)
                            DoGame();
                        roundsToPlay = 0;
                        break;
                    default:
                        return;
                }

                Console.WriteLine();

                while (roundsToPlay-- >= 1) {

                    ("\nGame Winner is: " + DoGame()).ToConsole();
                    IOHelper.Pause();
                    Console.WriteLine();
                }

                ("Database weight is now: " + StateStore.GetWeight()).ToConsole();
                "And again we player...".ToConsole();
                Console.WriteLine();
            }
        }

        private Player DoGame() {

            NimState state = NimStateHelper.StartingNimState.Clone();
            PlayerCurrent = Player1;

            while (!state.IsNextLossing() && state.HasValidMoves()) {

                ("Current Player: " + PlayerCurrent).ToConsole();
                ("Current State is: " + state).ToConsole();
                PlayerCurrent.History.Add(state.Clone());
                state = PlayerCurrent.GetNextState(state.Clone());

                if (state.HasValidMoves())
                    TogglePlayer();
            }

            // loosing player
            PlayerCurrent.History.Add(state.Clone());
            PlayerCurrent.PushHistory(StateStore, false);
            TogglePlayer();

            // winner
            PlayerCurrent.History.Add(new NimState());
            PlayerCurrent.PushHistory(StateStore, true);

            return PlayerCurrent;
        }

        private void TogglePlayer() {

            PlayerCurrent = (PlayerCurrent.Equals(Player1)) ? Player2 : Player1;
        }
    }
}
