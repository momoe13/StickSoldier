using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character_Controller : MonoBehaviour
{
    [Header("プレイヤーキャラには✔入れる")]
    [SerializeField] bool ally;//味方
    protected int target_direction;      //進行方向

    [Header("パラメーター")]
    [SerializeField] protected float      speed;//速度
    [SerializeField] float          hp;

    [SerializeField] float coolTime;//クールタイム

    float                   attack_Time;//攻撃までのカウントダウン用タイム
    protected string            target;//攻撃するオブジェクト

    [SerializeField] int attackPower;//攻撃力

    [Header ("ダメージUI用Prefab")]
    [SerializeField] GameObject DamagePre;
    Canvas     DamageCanvas;

    [SerializeField]
    protected bool isStop = false;
    bool isCastel = false;

    public Character_Controller attackTarget;

    Vector2 pos, scale;//死亡モーション用。
    bool DieFlg = false;//死亡判定


    [Header("アニメーター")]
    [SerializeField] Animator anim;


    private void Awake()
    {
        //実機なら右に向かって動く
        if (ally) { target_direction = 1; }

        else { target_direction = -1; }

        scale= transform.localScale;
        DamageCanvas = GameObject.Find("DamageCanvas").GetComponent<Canvas>();
        anim.SetBool("AttackFlg", false);
    }

    private void Update()
    {
        if (DieFlg) { 
            Die();        }
        else
        {
            Move();
            attack_Time += Time.deltaTime;

        }
        if (Input.GetKeyDown(KeyCode.Escape)) { Damage(5); }
        }

    protected virtual void Move()
    {
        if (isStop)
        {
            Attack();
            return;
        }

        Vector2 pos = transform.position;
        Vector2 newPos = new Vector2(pos.x+(speed * target_direction*Time.deltaTime) , pos.y);
        transform.position = newPos;
    }

    protected virtual void Attack()
    {
        //Debug.Log(string.Format( "{0}/{1}", attack_Time,attack_Timing));
        if (attack_Time < coolTime){ return; }
        anim.SetBool("AttackFlg", true);
        attack_Time = 0.0f;
        if (isCastel) { return; }
        //Damege関数呼び出し
        attackTarget.Damage(attackPower);
    }

    public void Damage(int dm)
    {
        if (DieFlg) return ;
        hp -= dm;
        DamageTex(dm);
        if (hp <= 0) { DieFlg = true; }
        Debug.Log("ダメージ"+this.gameObject.name);
    }
    private void DamageTex(int dm)
    {
        Vector2 pos = new(Random.Range(transform.position.x - 1, transform.position.x + 1),
           Random.Range(transform.position.y - 1, transform.position.y + 1));

        //テキスト生成
        Text damageIns = Instantiate(DamagePre, pos, Quaternion.identity, DamageCanvas.transform).GetComponent<Text>();
        //テキストの表示をダメージにする
        damageIns.text = dm.ToString();
    }


    protected virtual void Die()
    {
        if (scale.y > 0)
        {
            pos = transform.position;
            pos.y -= Time.deltaTime;
            scale.y -= Time.deltaTime;
            transform.position = pos;
            transform.localScale = scale;

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        //if (Vector3.Distance(transform.position, collision.transform.position) <= boxCollider.size.x / 2.0f)
        //{
        if ( collision.gameObject.name == ("Castle"))
        {
            StartCoroutine("AttackWait");

            isCastel = true;
            collision.gameObject.GetComponent<CastleManager>().Damage();
        }
        else if (collision.gameObject.tag == ("Target"))
        {            //ターゲット名からターゲットとそのスクリプトを取得
            //attackTarget = GameObject.Find(collision.gameObject.name).GetComponent<Character_Controller>();
            attackTarget = collision.gameObject.GetComponentInParent<Character_Controller>();
            StartCoroutine("MovingCancel");
        }
        //}

    }

    IEnumerator MovingCancel()
    {
        yield return new WaitForSeconds(0.1f);
        isStop = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!gameObject.activeInHierarchy) return;
        //if (collision.CompareTag(this.tag)) { return; }
        StartCoroutine("MovingStart");
        //controller = null;
    }

    IEnumerator MovingStart()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("AttackFlg", false);
        isStop = false;

    }
    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(0.5f);
        isStop = true;
    }
}
