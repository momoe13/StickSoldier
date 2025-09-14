using System.Collections;
using UnityEngine;

public class Mergeitem : MonoBehaviour
{
    Vector2 mousePos; 
    Rigidbody2D rb;
    [SerializeField] int ItemNum;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //マウス追従
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePos;
    }

    private void OnMouseUp()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        StartCoroutine("Destroy");
    }

    //アイテムボックスに当たり判定する暇を与えてからオブジェクト削除する
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    public int GetNum()
    {
        return ItemNum;
    }
}
