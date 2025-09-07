using UnityEngine;

public class AllyGenerater : MonoBehaviour
{
    [SerializeField]
    bool GeneratFlg = false;
    [SerializeField]
    int[] MargeNum;
    [SerializeField]//生成アイテム
    GameObject[] CreateObj;
    [SerializeField]//エリアタイプ
    int[] supportAreaNum;
    [SerializeField]//生成キャラ
    GameObject[] CreateWeapon;

    //生成オブジェクトの配列番号
    int objNum;

    [SerializeField] GameObject[] Area; //エリア

    GameObject Chil;
    SpriteRenderer Sprite;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (!GeneratFlg) return;
            Instantiate(CreateWeapon[objNum], this.transform.position, Quaternion.identity);
            Destroy(transform.GetChild(0).gameObject);
            GeneratFlg = false;
        }

    }
    public void PLGeneration(int num)
    {
        //自分を親オブジェクトとする
        var parent = this.transform;

        for (int i = 0; i < MargeNum.Length; i++)
        {
            if (MargeNum[i] == num) { objNum = i; break; }
        }
        //オブジェクト生成
        Chil = Instantiate(CreateObj[objNum], this.transform.position, Quaternion.identity, parent);
        Sprite = Chil.GetComponent<SpriteRenderer>();
    }

    //objとエリアの当たり判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Area[0].name)
        { //生成できるエリアなのか判定
            if (supportAreaNum[objNum] % 2 != 0)
            {
                GeneratFlg = true;
                Sprite.color = Color.white;
            }
            else
            {
                GeneratFlg = false;
            }
        }
        else if (collision.name == Area[1].name)
        {
            if (supportAreaNum[objNum] % 2 != 0)
            {
                GeneratFlg = false;
                Debug.Log("生成不可！！");
                Sprite.color = Color.red;

            }
            else { GeneratFlg = true; }
        }
    }

}
