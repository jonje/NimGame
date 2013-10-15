using System;
using SlightLibrary.Extensions;
using SlightLibrary.Helpers;

namespace Nim {
    class HumanPlayer : Player {

        public HumanPlayer(string playerName)
            : base(playerName) {
        }

        public override NimState GetNextState(NimState state) {

            ("1) " + state.XReal).ToConsole();
            ("2) " + state.YReal).ToConsole();
            ("3) " + state.ZReal).ToConsole();

            int option = 0;

            bool goodRow = false;

            while (!goodRow) {

                option = IOHelper.PromptForInputInt("Which Row to Edit?", 1, 3);

                switch (option) {
                    case 1:
                        goodRow = state.XReal > 0;
                        break;
                    case 2:
                        goodRow = state.YReal > 0;
                        break;
                    case 3:
                        goodRow = state.ZReal > 0;
                        break;
                }

                if (!goodRow)
                    "Bad Row".ToConsole();
            }

            int numberToRemove = IOHelper.PromptForInputInt("Number to Remove?", 1);

            switch (option) {
                case 1:
                    state.XReal -= numberToRemove;
                    break;
                case 2:
                    state.YReal -= numberToRemove;
                    break;
                case 3:
                    state.ZReal -= numberToRemove;
                    break;
            }

            Console.WriteLine();

            return state;
        }
    }
}
