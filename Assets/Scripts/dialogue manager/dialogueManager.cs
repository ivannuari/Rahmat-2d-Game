using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogueManager : MonoBehaviour
{
    public GameObject[] paneldialog;
    public TMP_Text[] textdialog;

    public dialogue[] dialog;

    public Button tombolLanjut;

    int n = 0 , p = 0;

    public void Lanjut()
    {
        if(n < dialog.Length)
        {
            StartCoroutine(MunculkanDialog());
        }
        else
        {
            MateriMenu.MM.menuButton(2);
        }
    }

    IEnumerator MunculkanDialog()
    {
        tombolLanjut.interactable = false;

        foreach (GameObject g in paneldialog)
        {
            g.SetActive(false);
        }

        if(p > 1)
        {
            p = 0;
        }

        paneldialog[p].SetActive(true);
        textdialog[p].text = dialog[n].kata;

        yield return new WaitForSeconds(dialog[n].waktu);
        tombolLanjut.interactable = true;
        p++;
        n++;
    }
}
