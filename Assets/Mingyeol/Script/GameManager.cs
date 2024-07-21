using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject pnl_gameOver;
    [SerializeField] private GameObject pnl_clear;

    [SerializeField] private GameObject player;
    public GameObject Player => player;

    [SerializeField] private Transform itemParent;
    public Transform ItemParent => itemParent;

    [SerializeField] private GameObject testPickUpitem;

    public Animator playerAnim;

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
      pnl_gameOver.SetActive(true);
    }

    void Update()
    {

    }
}
