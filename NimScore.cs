namespace Nim {
    public class NimScore {

        public int Count {
            get;
            private set;
        }
        public double Score {
            get;
            private set;
        }

        public void Add(double newScore) {

            double fullScore = Count * Score;
            fullScore += newScore;
            fullScore /= ++Count;
            Score = fullScore;
        }

        public override string ToString() {

            return "" + Score;
        }

        protected bool Equals(NimScore other) {
            return Score.Equals(other.Score);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((NimScore) obj);
        }

        public override int GetHashCode() {
            return Score.GetHashCode();
        }
    }
}
