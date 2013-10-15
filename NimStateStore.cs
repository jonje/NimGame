using System.Collections.Generic;

namespace Nim {
    public class NimStateStore {

        public Dictionary<NimState, NimScore> Scores {
            get;
            private set;
        }

        public NimStateStore() {

            Scores = new Dictionary<NimState, NimScore>();
        }

        public double GetScore(NimState state) {

            NimScore score;
            return (Scores.TryGetValue(state, out score)) ? score.Score : 0;
        }

        public void AddScore(NimState state, double rawScore) {

            NimScore score;
            if (Scores.TryGetValue(state, out score)) {

                score.Add(rawScore);
            } else {

                score = new NimScore();
                score.Add(rawScore);
                Scores.Add(state, score);
            }
        }

        public float GetWeight() {

            double consensus = 0;
            short count = 0;
            foreach (KeyValuePair<NimState, NimScore> keyValuePair in Scores) {
                consensus += keyValuePair.Value.Score;
                count++;
            }
            consensus /= count;
            return (float) (consensus);
        }
    }
}
