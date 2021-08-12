using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    [SerializeField]private Image image;
    [SerializeField]private AnimationCurve animationCurve;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
        
    }

    //用協程的概念做一次性動作
    IEnumerator FadeIn()
    {
        //做一個開關,決定什麼時候開始執行方法
        float t = 1f;
        while (t >0f)//進場應該是馬上進，然後持續到每個時間後停止
        {
            //設定t每秒-1
            t -= Time.deltaTime;
            //一開始t就大於0就會執行方法，當t-1=0f，就會停止
            //設定一個數值a,用來做動畫轉換計算用Evaluate
            float a = animationCurve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, a);


            yield return 0;
        }


    }
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;
        while (t < 1f) //等待到一個時間點時停止
        {
            t += Time.deltaTime;//到一秒之後停止
            float a = animationCurve.Evaluate(t);
            image.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        //轉換場景
        SceneManager.LoadScene(scene);
        //確認是否有執行
        Debug.Log("Active?" + gameObject.activeInHierarchy);

    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
        Debug.Log("Active?" + gameObject.activeInHierarchy);

    }



}
