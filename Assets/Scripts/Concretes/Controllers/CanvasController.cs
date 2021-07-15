using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    SceneType sceneType;
    [SerializeField]
    GameObject CanvasObject;

    private void Start()
    {
        GameManager.Instance.OnSceneChanged += HandleSceneChanged;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnSceneChanged -= HandleSceneChanged;
    }

    private void HandleSceneChanged(SceneType sceneType)
    {
        if (sceneType.Equals(this.sceneType))
        {
            CanvasObject.SetActive(true);
        }
        else
        {
            CanvasObject.SetActive(false);
        }
    }

}
