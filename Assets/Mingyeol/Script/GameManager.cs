using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    [SerializeField] private GameObject player;
    public GameObject Player => player;
    [SerializeField] private GameObject testPickUpitem;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(testPickUpitem, new Vector3(0,0,0), Quaternion.identity);
            testPickUpitem.GetComponent<PickUpItem>().ItemPickUp();
        }
    }
}
