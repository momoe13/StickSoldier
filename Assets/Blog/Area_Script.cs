using UnityEngine;

public class Area_Script : MonoBehaviour
{
    [SerializeField] string[] unsupportedObj;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < unsupportedObj.Length; i++)
        {
            if(collision.gameObject.name == unsupportedObj[i]+ "(Clone)")
            {
                Debug.Log("’u‚¯‚È‚¢‚æ");
                break;
            }
        }
    }
}
