using UnityEngine;

public class ItemBox : MonoBehaviour
{
    //生成するオブジェクト
    [SerializeField] GameObject instantObj;

    private void OnMouseDown()
    {
        Instantiate(instantObj,this.transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
