using UnityEngine;

public class ItemBoxManager : MonoBehaviour
{
    //全アイテムボックスを無効にする
    public void StopItemBox()
    {
        Transform children = this.GetComponentInChildren<Transform>();
        foreach (Transform ob in children)
        {
            ItemBox itemBox = ob.GetComponent<ItemBox>();
            itemBox.StopBox();
        }
    }
}
