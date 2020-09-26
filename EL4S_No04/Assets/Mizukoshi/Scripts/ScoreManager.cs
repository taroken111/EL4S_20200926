using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mizukoshi {
    public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
    {

        private int score = 0;

        private void Start()
        {
            // シーンが切り替わっても残り続ける
            DontDestroyOnLoad(this);
        }

        public void ScoreReset()
        {
            score = 0;
        }

        public void AddScore(int value)
        {
            // 0以下にはしない
            score = Mathf.Max(score + value, 0);
        }

        public int GetScore() { return score; }

    }
}
