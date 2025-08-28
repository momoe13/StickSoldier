
using UnityEngine;

public class Charactor : MonoBehaviour
{
    Vector2 mousePos;
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

}
