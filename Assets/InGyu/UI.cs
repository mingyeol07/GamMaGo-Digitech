using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider hpbar;
    float imsi;

    private float MaxHp = 100;
    private float CurHp = 100;  

    
    void Start()
    {
     
    }

    
    void Update() {

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            if(CurHp > 0)
            {
                CurHp -= 10;
            }
            else
            {
                CurHp = 0;
            }
        }*/

        HandleHp();
    }

    private void HandleHp()
    {
        hpbar.value = Mathf.Lerp(hpbar.value, (float)CurHp / (float)MaxHp, Time.deltaTime * 10);
    }
}
