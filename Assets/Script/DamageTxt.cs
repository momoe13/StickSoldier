using UnityEngine;
using UnityEngine.UI;

public class DamageTxt : MonoBehaviour
{
    [SerializeField]
    readonly float displayTime = 2.0f;
    float timer=0.0f ;
    Vector2 pos;
    private void Start()
    {
        pos = transform.position;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > displayTime)Destroy(gameObject);
        pos.y += 0.01f;
        transform.position = pos;
    }
}
