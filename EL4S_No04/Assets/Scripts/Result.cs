using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        Reset();
        Invoke("OnAddScore", 1);

    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("top");
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void Reset()
    {
        scoreText.text = "スコア：0";
    }
    void OnAddScore()
    {
        //ここの第一引数にスコアを入れる
        StartCoroutine(ScoreAnimation(100, 3.0f));
    }



    /// <summary>
    /// スコアのアニメーション
    /// </summary>
    /// <param name="addScore">獲得したスコア</param>
    /// <param name="time">桁が進む速さ</param>
    /// <returns></returns>
    IEnumerator ScoreAnimation(float addScore,float time)
    {
        float before = 0;
        float after = addScore;
        float elapsedTime = 0.0f;

        while(elapsedTime < time)
        {
            float rate = elapsedTime / time;
            //テキストの更新
            scoreText.text = "スコア：" + (before + (after - before) * rate).ToString("f0");

            elapsedTime += Time.deltaTime;

            yield return new WaitForSeconds(0.01f);
        }
        scoreText.text = "スコア：" + after.ToString();
        
    }


}
