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
        //É}ÉEÉXí«è]
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // rb.MovePosition(mousePos);
        transform.position = mousePos;
    }
    //private void OnMouseDrag()
    //{
    //}
    private void OnMouseUp()
    {
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
