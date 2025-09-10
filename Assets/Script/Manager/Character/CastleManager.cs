using UnityEngine;

public class CastleManager : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
    int CastelHP;//複数回ダメージを受け付ける時用
    public void Damage()
    {
        gameManager.Die(this.name);
    }
}
