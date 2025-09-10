using UnityEngine;

public class CastleManager : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
    int CastelHP;//複数回ダメージを受け付ける時用
    public void Damage()
    {
        Debug.Log("呼び出されたよ～");
        gameManager.Die(this.name);
    }
}
