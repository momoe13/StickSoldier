using System.Collections.Generic;
using UnityEngine;

public class GenerationManager : MonoBehaviour
{
    int Type;
    [SerializeField]//生成アイテム
    GameObject[] CreatePrefabs;

    int maxEne=3;
    float gameTime= 0;

    float BossTime = 10.0f;

    //敵キャラの生成数を保存する
    [SerializeField]
    List<GameObject> EnemyBox;
    int eneType = 0;

    //ボスを生成したか
    bool isBossGenerated = false;
    bool isBossDie = false;
    // TODO : ミサイルをとりあえず動かすための追加！！後で変えましょう
    public IReadOnlyList<GameObject> ActiveEnemyList => EnemyBox;
    

    private void Update()
    {
        if(isBossDie)
        {
            for (int i = 0; i < EnemyBox.Count; i++)
            {
                //敵全消し
                Destroy(EnemyBox[i]);   
            }
            return;
        }

        //ボスの生成
        if(!isBossGenerated)
        {
            gameTime += Time.deltaTime;
            if (BossTime < gameTime)
            {
                //ボス生成
                Instantiate(CreatePrefabs[3], GetEnemySpawnPos(), Quaternion.identity);
                isBossGenerated = true;
                return;
            }
        }

        //nullになっている場所を掃除
        for (int i = 0; i < EnemyBox.Count; i++)
        {
            if(EnemyBox[i] == null) EnemyBox.Remove(EnemyBox[i]);
        }

        //敵がｎ体以下なら生成
        if(EnemyBox.Count<maxEne)
        {
            EnemyGeneration();
        }
    }

    //敵生成
    private void EnemyGeneration()
    {
        GameObject ene= Instantiate(CreatePrefabs[eneType], GetEnemySpawnPos(), Quaternion.identity);
       
        EnemyBox.Add(ene);
        eneType++;
        if (eneType > 1) eneType = 0;
    }

    private Vector2 GetEnemySpawnPos()
    {
        return new Vector2(this.transform.position.x , this.transform.position.y);
    }

    public void BossDie()
    {
        isBossDie = true;
    }
}
