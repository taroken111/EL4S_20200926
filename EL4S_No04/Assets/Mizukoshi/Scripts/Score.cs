using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mizukoshi
{
    public class Score : MonoBehaviour
    {

        private Text ScoreUI;

        private void Start()
        {
            ScoreUI = GetComponent<Text>();
            ScoreManager.Instance.ScoreReset();
        }

        public void AddScore(int value)
        {
            ScoreManager.Instance.AddScore(value);
            ScoreUI.text = "Score " + ScoreManager.Instance.GetScore().ToString();
        }

    }
}
