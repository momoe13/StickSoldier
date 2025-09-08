using UnityEngine;
public class Boss:Character_Controller
{
    [SerializeField]
    GameManager gameManager;

    private void Start()
    {
      gameManager = GetComponentInParent<GameManager>();
    }
    
    protected override void Die()
    {
        Debug.Log("éÄÇÒÇæÅIÅIÅI");
        base.Die();
        gameManager.Die(this.name);

        Destroy(this.gameObject);
    }

}
