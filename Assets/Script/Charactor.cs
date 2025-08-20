using UnityEngine;

public class Charactor : MonoBehaviour
{
    float speed = 1f;
    bool isSet = false;

    Vector2 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSet)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
        Vector2 pos = transform.position;
        transform.position = new Vector2(pos.x + (speed * 1 * Time.deltaTime), pos.y);

    }


    private void OnMouseUp()
    {
        isSet = true;
    }
}
