using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Castel;
    [SerializeField] GameObject Boss;
    bool BossInstantFlg = false;

    [SerializeField] Text ClearText;

    [SerializeField] float BossInstantTime;

    [SerializeField]float instantTimer=0;

    private void Update()
    {
        if (!BossInstantFlg)
        {
            instantTimer = Time.time;
            if (instantTimer > BossInstantTime)
            {
                Debug.Log("生成");
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
        if (name == "castel")
        {
            //敗北処理
        }
        else if (name == "bigtree_0(Clone)")
        {
            Debug.Log("勝利");
            //勝利処理
            ClearText.GetComponent<Text>().color = new Color(0.2f, 0.2f, 0.2f, 1.0f);

        }
    }
}
