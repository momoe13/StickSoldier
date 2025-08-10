using UnityEngine;
using UnityEngine.InputSystem.XR;

public class ItemBox : MonoBehaviour
{
    //生成するオブジェクト
    [SerializeField] GameObject instantObj;

    [SerializeField] GameObject[] MergeNumber;
    [SerializeField] int BoxNumber;

    private void OnMouseDown()
    {
        Instantiate(instantObj, this.transform.position, Quaternion.identity);
    }

    //
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        int getItemNum=0;//取得した値を保存するもの

        //生成アイテムだったら値を取得
        if (collision.gameObject.TryGetComponent<Mergeitem>(out var mergeitem))
        {
           getItemNum= mergeitem.GetNum();
            Debug.Log(getItemNum);
        }

        if (getItemNum == 0) return;
        //取得した値と合わせてアイテムを生成できるか調べる
        for (int i = 0; i < MergeNumber.Length; i++)
        {

        }

    }
}
