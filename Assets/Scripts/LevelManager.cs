using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager LM;

    public List<Quis> soal = new List<Quis>();

    public GameObject panelQuis , panelResult , panelHp;

    //panel kuis
    public TMP_Text coinText , pertanyaan , opsiA , opsiB , opsiC , opsiD;
    int rand , currHp;

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
        panelResult.SetActive(false);
        
        currHp = GameManager.GM.data.maxHp;
        UpdateHp();
    }

    void UpdateHp()
    {
        foreach (Transform t in panelHp.transform)
        {
            t.gameObject.SetActive(false);
        }
        for (int i = 0; i < currHp; i++)
        {
            panelHp.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    void Update()
    {
        coinText.text = GameManager.GM.data.coin.ToString();
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
            GameManager.GM.data.coin += 20;
        }
        else
        {
            JawabanBenar(false);
            currHp -= 1;
            UpdateHp();
        }

        soal.Remove(soal[rand]);
    }

    void JawabanBenar(bool ya)
    {
        panelResult.SetActive(true);
        TMP_Text res = panelResult.GetComponentInChildren<TMP_Text>();
        if(ya)
        {
            res.text = "BENAR";
        }
        else
        {
            res.text = "SALAH";
        }
        StartCoroutine(SelesaiPertanyaan());
    }

    IEnumerator SelesaiPertanyaan()
    {
        yield return new WaitForSeconds(1.5f);
        panelQuis.SetActive(false);
        panelResult.SetActive(false);
    }
}
