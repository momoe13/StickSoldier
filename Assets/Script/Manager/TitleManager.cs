using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    SceneChange SceneChange;

    //カメラ接近用
    Vector3 startPos,targetPos;
    float startSize,targetSize;

    //カメラ移動にかかる時間
    float duration = 1.5f;


    private void Start()
    {
        startPos = mainCamera.transform.position; 
        targetPos = new Vector3(startPos.x, -2.6f, startPos.z);
        startSize = mainCamera.orthographicSize;
        targetSize = startSize - 3.5f; // 任意でズーム量
    }

    public void GetButton()
    {
        //扉を開けるアニメーション
        anim.SetBool("Click", true);

        //カメラが扉に近づく
        StartCoroutine(CameraMove());
    }

    //コルーチン
    IEnumerator CameraMove()
    {
        float elapsed = 0f;
        while (elapsed < duration) {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            // スクリプト内のEaseInOutSine関数を使用
            float easedT = EaseInOutSine(t);

            mainCamera.transform.position = Vector3.Lerp(startPos, targetPos, easedT);
            mainCamera.orthographicSize = Mathf.Lerp(startSize, targetSize, easedT);

            yield return null;
        }

        // 最終位置を確実にセット
        mainCamera.transform.position = targetPos;
        mainCamera.orthographicSize = targetSize;

        // シーン遷移呼び出し
        SceneChange.MapLordScene(); 
    }

    // スクリプト内で完結するEaseInOutSine関数
    private float EaseInOutSine(float t)
    {
        return -(Mathf.Cos(Mathf.PI * t) - 1f) / 2f;
    }
}
    
 
