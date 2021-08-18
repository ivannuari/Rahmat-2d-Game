using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    Animator anim;
    public bool isDeadzone = false;
    public bool isFinish = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D cl)
    {
        if(cl.CompareTag("Player"))
        {
            if(isDeadzone)
            {
                LevelManager.LM.GameOver();
            }
            else if(isFinish)
            {
                LevelManager.LM.FinishLevel();
            }
            else
            {
                PickUp();
            } 
        }
    }

    void PickUp()
    {
        anim.SetBool("buka" , true);
    }

    void QuisBuka()
    {
        LevelManager.LM.MunculPertanyaan();
    }
}
