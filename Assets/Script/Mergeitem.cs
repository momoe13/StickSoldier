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
    {   //マウス追従
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       // rb.MovePosition(mousePos);
       transform.position = mousePos;  
    }

    private void OnMouseUp()
    {
        //当たり判定On

        //Collider2D[] hits = Physics2D.OverlapPointAll(transform.position);
        //foreach (var hit in hits)
        //{
        //    if (hit.CompareTag("ItemBox"))
        //    {
        //        Debug.Log("合成成功！");
        //    }
        //}
        rb.bodyType = RigidbodyType2D.Kinematic;
        StartCoroutine("Destroy");
    }
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
