using UnityEngine;

public class Mergeitem : MonoBehaviour
{
    Vector2 mousePos;
    private void Update()
    {   //É}ÉEÉXí«è]
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    private void OnMouseUp()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
