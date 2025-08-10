using UnityEngine;

public class Charactor : MonoBehaviour
{
    float speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        transform.position = new Vector2(pos.x + (speed * 1 * Time.deltaTime), pos.y);

    }
}
