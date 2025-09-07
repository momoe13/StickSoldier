using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class Boss:Character_Controller
{
    GameObject ClearText;
    [SerializeField] GenerationManager generationManager;
    private void Awake()
    {
        ClearText = GameObject.Find("Clear");
    }
    protected override void Die()
    {
        base.Die();
        ClearText.GetComponent<Text>().color = new Color(0.2f, 0.2f, 0.2f, 1.0f);
        generationManager.BossDie();
        Destroy(this.gameObject);
    }
}
