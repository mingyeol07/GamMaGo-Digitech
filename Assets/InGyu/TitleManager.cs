using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public UnityEngine.UI.Button start;
    public UnityEngine.UI.Button QUit;

    private void Start()
    {
        start.onClick.AddListener(() => { SceneManager.LoadScene("InGame"); });
    }
}
