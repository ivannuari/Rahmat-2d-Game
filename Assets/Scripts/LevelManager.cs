using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager LM;

    public List<Quis> soal = new List<Quis>();

    public GameObject panelQuis;

    //panel kuis
    public TMP_Text pertanyaan , opsiA , opsiB , opsiC , opsiD;
    int rand;

    void Awake()
    {
        if(LM == null)
        {
            LM = this;
        }
        else
        {
            return;
        }
    }

    void Start()
    {
        panelQuis.SetActive(false);
    }

    public void MunculPertanyaan()
    {
        panelQuis.SetActive(true);
        //Time.timeScale = 0;

        rand = Random.Range(0 , soal.Count);
        pertanyaan.text = soal[rand].pertanyaan;
        opsiA.text = soal[rand].opsiA;
        opsiB.text = soal[rand].opsiB;
        opsiC.text = soal[rand].opsiC;
        opsiD.text = soal[rand].opsiD;
    }

    public void PilihanJawaban(int i)
    {
        if(i == soal[rand].jawaban)
        {
            JawabanBenar(true);
        }
        else
        {
            JawabanBenar(false);
        }

        soal.Remove(soal[rand]);
    }

    void JawabanBenar(bool ya)
    {
        panelQuis.SetActive(false);
        Time.timeScale = 1f;
    }
}
