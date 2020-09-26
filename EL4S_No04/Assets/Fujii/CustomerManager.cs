using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerManager : MonoBehaviour
{
    //! スープ素材画像リスト
    [SerializeField] Sprite m_SoupImage;
    //! 麺素材リスト
    [SerializeField] Sprite m_NoodlesImage;
    //! 麺の色リスト
    [SerializeField] List<Color> m_NoodleColors;
    //! スープの色リスト
    [SerializeField] List<Color> m_SoupColors;
    //! トッピング素材リスト
    [SerializeField] List<Sprite> m_ToppingImageList;
    //! 客の画像リスト
    [SerializeField] List<Sprite> m_CustomerImageList;
    //! 現在の要求スープ画像
    [SerializeField] Image m_Soup;
    //! 現在の要求麺画像
    [SerializeField] Image m_Noodle;
    //! 現在の要求トッピング画像
    [SerializeField] Image m_Topping;
    //! 客の画像
    [SerializeField] Image m_Customer;
    //! 現在の要求スープ番号
    int m_SoupIndex = 0;
    //! 現在の要求麺番号
    int m_NoodlesIndex = 0;
    //! 現在の要求トッピング番号
    int m_ToppingIndex = 0;

    private void Start()
    {
        m_Soup.sprite = m_SoupImage;
        m_Noodle.sprite = m_NoodlesImage;
        LotteryCustomer();
    }

    /*
     * @fn Judgement
     * @param (soup)    提供するラーメンのスープ番号    (0:コーラ 1:煮干し 2:チョコ)
     * @param (noodle)  提供するラーメンの麺番号        (0:小麦 1:ブルーハワイ 2:イカ墨)
     * @param (topping) 提供するラーメンのトッピング番号(0:タピオカ 1:アボカド 2:イチゴ)
     * @return スコア(-30～30)
    */
    public int Judgement(int soup, int noodle, int topping)
    {
        int result = 0;
        if (m_SoupIndex != soup) result++;
        if (m_NoodlesIndex != noodle) result++;
        if (m_ToppingIndex != topping) result++;
        return 10 * (3 - result) + -10 * result;
    }

    /*
     * @fn LotteryCustomer
     * @brief 客の抽選
    */
    public void LotteryCustomer()
    {
        m_SoupIndex = (int)Random.Range(0, 2.999f);
        m_NoodlesIndex = (int)Random.Range(0, 2.999f);
        m_ToppingIndex = (int)Random.Range(0, 2.999f);

        m_Soup.color = m_SoupColors[m_SoupIndex];
        m_Noodle.color = m_NoodleColors[m_NoodlesIndex];
        m_Topping.sprite = m_ToppingImageList[m_ToppingIndex];

        int customer_index = (int)Random.Range(0, 2.999f);
        m_Customer.sprite = m_CustomerImageList[customer_index];
    }
}
