using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramen : MonoBehaviour
{
    private GameObject mouse_;
    private GameObject soup_, noodle_, topping_;

    // Start is called before the first frame update
    void Start()
    {
        soup_ = noodle_ = topping_ = null;
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリック離したら
        if (Input.GetMouseButtonUp(0))
        {
            // マウスが重なってるか
            if(mouse_ != null)
            {
                // 持ってる材料をもらう
                GameObject Material = mouse_.GetComponent<Mouse>().GetHaveMaterial();
                if (Material != null)
                {
                    if (Material.tag == "Soup")
                    {
                        soup_ = Material;
                        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = soup_.GetComponent<SpriteRenderer>().color;
                    }
                    else if (Material.tag == "Noodle")
                    {
                        noodle_ = Material;
                        transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = noodle_.GetComponent<SpriteRenderer>().color;
                    }
                    else if (Material.tag == "Topping")
                    {
                        topping_ = Material;
                        transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = topping_.GetComponent<SpriteRenderer>().sprite;
                        transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = topping_.GetComponent<SpriteRenderer>().color;
                    }
                }

                // マウスが持ってる材料を消す
                mouse_.GetComponent<Mouse>().ReleaseHaveMaterial();
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        mouse_ = other.gameObject;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        mouse_ = other.gameObject;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        mouse_ = null;
    }

    /**
     * 以下、水越が記述
     */

    public GameObject GetSoup() { return soup_; }
    public GameObject GetNoodle() { return noodle_; }
    public GameObject GetTopping() { return topping_; }
}
