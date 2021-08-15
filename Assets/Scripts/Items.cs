using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D cl)
    {
        if(cl.CompareTag("Player"))
        {
            PickUp();
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
