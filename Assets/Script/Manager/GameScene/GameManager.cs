using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   // [SerializeField] GameObject Castel;
    [SerializeField] GameObject Boss;
    bool BossInstantFlg = false;
    [SerializeField] float BossInstantTime;//ボスを生成する時間
     float instantTimer;                   //生成までのカウンター

    [SerializeField] GameObject ClearText;//防衛成功テキスト
    [SerializeField] GameObject ClearObj;//シーン遷移用ボタン

    [SerializeField] GameObject FailText;//防衛失敗テキスト
    [SerializeField] GameObject FailObj;//シーン再ロードボタン

    [SerializeField] GameObject MapReload;//マップに戻るボタン

    [SerializeField] GenerationManager GenerationManager;
    [SerializeField] ItemBoxManager ItemBoxManager;

    private void Start()
    {
        instantTimer = 0f;
    }
    private void Update()
    {
        if (!BossInstantFlg)
        {
            instantTimer += Time.deltaTime;
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
        //TODO:BGMをボス戦用に変更
    }

    //死んだオブジェクトの名前で勝利/敗北判定
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
        Time.timeScale = 0;
        //マップに戻るを表示
        MapReload.SetActive(true);

        ItemBoxManager.StopItemBox();
    }
}
