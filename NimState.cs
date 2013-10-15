using System;

namespace Nim {
    public class NimState {

        private int _zReal;
        private int _yReal;
        private int _xReal;

        public int XReal {
            get {
                return _xReal;
            }
            set {
                _xReal = (value >= 0) ? value : 0;
                Refresh();
            }
        }

        public int YReal {
            get {
                return _yReal;
            }
            set {
                _yReal = (value >= 0) ? value : 0;
                Refresh();
            }
        }

        public int ZReal {
            get {
                return _zReal;
            }
            set {
                _zReal = (value >= 0) ? value : 0;
                Refresh();
            }
        }

        public int X {
            get;
            private set;
        }

        public int Y {
            get;
            private set;
        }

        public int Z {
            get;
            private set;
        }

        public NimState(int x = 0, int y = 0, int z = 0) {

            XReal = x;
            YReal = y;
            ZReal = z;
        }

        private void Refresh() {

            int[] list = { XReal, YReal, ZReal };
            Array.Sort(list);
            X = list[0];
            Y = list[1];
            Z = list[2];
        }

        public NimState Clone() {

            return new NimState(XReal, YReal, ZReal);
        }

        public bool IsNextLossing() {

            return X == 0 && Y == 0 && Z == 1;
        }

        public bool HasValidMoves() {

            return !(X == 0 && Y == 0 && Z == 0);
        }

        protected bool Equals(NimState other) {
            return Z == other.Z && Y == other.Y && X == other.X;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((NimState) obj);
        }

        public override int GetHashCode() {
            unchecked {
                int hashCode = Z;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ X;
                return hashCode;
            }
        }

        public override string ToString() {

            return "" + XReal + "," + YReal + "," + ZReal;
        }
    }
}
