using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private GameObject haveMaterial_;
    private GameObject stayMaterial_;
    public Sprite defaultSprite_;

    // Start is called before the first frame update
    void Start()
    {
        haveMaterial_ = stayMaterial_ = null;
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリック押したら
        if (Input.GetMouseButtonDown(0))
        {
            if (stayMaterial_ != null)
            {
                haveMaterial_ = stayMaterial_;
                gameObject.GetComponent<SpriteRenderer>().sprite = haveMaterial_.GetComponent<SpriteRenderer>().sprite;
                gameObject.GetComponent<SpriteRenderer>().color = haveMaterial_.GetComponent<SpriteRenderer>().color;
            }
        }

        // 左クリック離したら
        if (Input.GetMouseButtonUp(0))
        {
            ReleaseHaveMaterial();
        }

        // マウス座標更新
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0.0f;
        gameObject.transform.position = position;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        stayMaterial_ = other.gameObject;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        stayMaterial_ = other.gameObject;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        stayMaterial_ = null;
    }

    // 持ってる材料取得
    public GameObject GetHaveMaterial()
    {
        return haveMaterial_;
    }

    // 材料を消す
    public void ReleaseHaveMaterial()
    {
        haveMaterial_ = null;
        gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite_;
    }
}
