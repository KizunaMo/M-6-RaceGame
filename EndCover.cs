using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
    
public class EndCover : MonoBehaviour
{

    [SerializeField] private string endCover = "End";
    [SerializeField] private SceneFader sceneFader;


    /// <summary>
    /// 進結尾
    /// </summary>
    void ENdCover()
    {
        sceneFader.FadeTo(endCover);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ENdCover();
        }
    }

}
