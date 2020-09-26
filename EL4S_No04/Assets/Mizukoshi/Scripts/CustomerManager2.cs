using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * @brief   客クラス(ラーメン提供時に材料が一致しているか比較)
 */
namespace Mizukoshi
{
    public class CustomerManager2 : SingletonMonoBehaviour<CustomerManager>
    {

        [SerializeField] CustomerManager customerManager;
        // 汚いけど許して・・・

        [SerializeField]
        Ramen ramen;

        [System.Serializable]
        public class ItemTable
        {
            public List<SpriteRenderer> items = new List<SpriteRenderer>();
        }
        [SerializeField] List<ItemTable> itemSpritePrefabList;

        [SerializeField] Score score;

        [SerializeField] SpriteRenderer maruSpritePrefab;
        [SerializeField] SpriteRenderer batsuSpritePrefab;
        [SerializeField] SpriteRenderer sankakuSpritePrefab;

        /**
         * 恐らくPrefabかenumかなんかでSpriteを指定する形・・・?
         */


        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Decision();
            }


            //if (Input.GetKeyDown(KeyCode.W))
            //{
            //    CorrectAnswer();
            //}
            //if (Input.GetKeyDown(KeyCode.S))
            //{
            //    IncorrectAnswer();
            //}
            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    Instantiate(sankakuSpritePrefab, Vector3.zero, Quaternion.identity);
            //}

        }

        public void Decision()
        {

            int soup = 0;
            int noodle = 0;
            int topping = 0;
            int value = 0;
            for (int i = 0; i < 3; i++)
            {
                var _soup = ramen.GetSoup();
                var _noodle = ramen.GetNoodle();
                var _topping = ramen.GetTopping();
                if (itemSpritePrefabList[0].items[i].GetType() == _soup.GetType())
                {
                    soup = i;
                }
                if (itemSpritePrefabList[1].items[i].GetType() == _noodle.GetType())
                {
                    noodle = i;
                }
                if (itemSpritePrefabList[2].items[i].GetType() == _topping.GetType())
                {
                    topping = i;
                }
            }

            value = customerManager.Judgement(soup, noodle, topping);
            score.AddScore(value);

            if (value == 30){
                Instantiate(maruSpritePrefab, Vector3.zero, Quaternion.identity);
            }
            else if (value == -30)
            {
                Instantiate(batsuSpritePrefab, Vector3.zero, Quaternion.identity);
            }
            else
            {
                Instantiate(sankakuSpritePrefab, Vector3.zero, Quaternion.identity);
            }

        }


        /// <summary>
        /// 注文が一致している場合の処理
        /// </summary>
        void CorrectAnswer()
        {
            score.AddScore(30);
            Instantiate(maruSpritePrefab, Vector3.zero, Quaternion.identity);
        }

        /// <summary>
        /// 注文が一致していない場合の処理
        /// </summary>
        void IncorrectAnswer()
        {
            score.AddScore(-30);
            Instantiate(batsuSpritePrefab, Vector3.zero, Quaternion.identity);
        }

    }
}
