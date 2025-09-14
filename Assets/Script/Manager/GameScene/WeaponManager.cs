
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    Character_Controller controller;
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField] int attackPower;

    void FixedUpdate()
    {
        Vector2 velocity = rb.linearVelocity;
        if (velocity.sqrMagnitude > 0.01f) // ほぼ静止してない時だけ回転
        {
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Z軸回転
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //替え
        if (collision.gameObject.TryGetComponent<Character_Controller>(out var controller))
        {
            controller.Damage(attackPower);
        }

        Destroy(this.gameObject);
    }
}
