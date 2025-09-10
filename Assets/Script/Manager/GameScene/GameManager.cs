using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   // [SerializeField] GameObject Castel;
    [SerializeField] GameObject Boss;
    bool BossInstantFlg = false;

    [SerializeField] GameObject ClearText;
    [SerializeField] GameObject ClearObj;

    [SerializeField] GameObject FailText;
    [SerializeField] GameObject FailObj;

    [SerializeField] GameObject MapReload;

    [SerializeField] float BossInstantTime;
    [SerializeField] float instantTimer=0;

    private void Update()
    {
        if (!BossInstantFlg)
        {
            instantTimer = Time.time;
            if (instantTimer > BossInstantTime)
            {
                //ボス生成
                BossGenerat();
            }
        }
    }
     private void BossGenerat()
    {
        BossInstantFlg = true;
        var parent = this.transform;
        Instantiate(Boss, this.transform.position, Quaternion.identity, parent);
        //BGMをボス戦用に変更
    }

    public void Die(string name)
    {
        if (name == "Castle")
        {
            //敗北処理
            FailText.SetActive(true);
        }
        else if (name == "bigtree_0(Clone)")
        {
            Debug.Log("勝利");
            //勝利処理
            ClearText.SetActive(true);
            ClearObj.SetActive(true);
        }
        //マップに戻るを表示
        MapReload.SetActive(true);
    }
}
