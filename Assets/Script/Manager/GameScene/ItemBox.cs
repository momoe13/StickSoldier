using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    
    [SerializeField] GameObject instantObj;//生成するオブジェクト
    [SerializeField] int[] MergeNumber;    //合成値
    [SerializeField] int BoxNumber;        //このボックスアイテムの値
    [SerializeField] AllyGenerater generate;//味方生成呼び出し用

    [SerializeField] int _count;    //アイテム残数
    [SerializeField] Text countText;//アイテム数表示用テキスト
    [SerializeField] float itemSpawnInterval;//アイテムが増える時間
    float itemSpawnTimer = 0f;//↑の残り時間
    [SerializeField]SpriteRenderer spriteRenderer;

    private void Start()
    {
        Count = _count;
    }
    private void Update()
    {
        itemSpawnTimer +=Time.deltaTime;
        if (itemSpawnTimer > itemSpawnInterval) {
            Count++;
            itemSpawnTimer = 0f;
        }
    }
    protected int Count
    {
        get => _count;
        set
        {
            _count = value;
            if (Count >0)
            { spriteRenderer.color = Color.white; }
            else { spriteRenderer.color = new Color32(176, 176, 176, 200); }
            countText.text = $"×{_count}";
        }
    }
    //アイテム生成
    private void OnMouseDown()
    {
        if (Count > 1)
        {
            //アイテムの数減らす
            //TODO:02:生成失敗した場合アイテムが帰ってこない
            Count--;
            Instantiate(instantObj, this.transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int getItemNum=0;//取得した値を保存するもの

        //生成アイテムだったら値を取得
        if (collision.gameObject.TryGetComponent<Mergeitem>(out var mergeitem))
        {
           getItemNum= mergeitem.GetNum();
        }

        ItemGenerater(getItemNum);
    }

    public void ItemGenerater(int getItemNum)
    {
        if (getItemNum == 0||Count<1) return;
        int BoxNum = BoxNumber;
        if (BoxNum > getItemNum) { (BoxNum, getItemNum) = (getItemNum, BoxNum); }

        //取得した値と合わせてキャラObjを生成できるか調べる
        int instantNum = BoxNum * 10 + getItemNum;
        for (int i = 0; i < MergeNumber.Length; i++)
        {
            if (MergeNumber[i] == instantNum)
            {
                generate.PLGeneration(instantNum);
                //アイテムの数減らす
                Count--;
                break;
            }
        }
    }

    public void StopBox()
    {
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;
    }
}
