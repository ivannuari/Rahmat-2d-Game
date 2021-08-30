using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager LM;

    public List<Quis> soal = new List<Quis>();

    public GameObject panelQuis , panelResult , panelHp , panelGameOver , Joystick , panelVolume , panelconfirmation;

    //panel kuis
    public TMP_Text coinText , pertanyaan , opsiA , opsiB , opsiC , opsiD;
    int rand , currHp , bisaJawab = 0;
    bool isOpenVolume = false;

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
        Time.timeScale = 1f;

        panelQuis.SetActive(false);
        panelResult.SetActive(false);
        panelGameOver.SetActive(false);
        panelconfirmation.SetActive(false);
        Joystick.SetActive(true);
        panelVolume.SetActive(false);
        isOpenVolume = false;
        bisaJawab = 0;
        
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
        Joystick.SetActive(false);
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
            if(currHp < 1)
            {
                GameOver();
            }
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
            bisaJawab++;
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
        Joystick.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        panelGameOver.SetActive(true);
        Joystick.SetActive(false);
    }

    public void FinishLevel()
    {
        SceneManager.LoadScene(1);
        if(bisaJawab == 5)
        {
            GameManager.GM.data.levelUnlocked++;
        }
    }

    public void MenuButton(string n)
    {
        if(n == "replay")
        {
            Scene s = SceneManager.GetActiveScene();
            SceneManager.LoadScene(s.name);
        }
        else if(n == "home")
        {
            panelconfirmation.SetActive(true);
        }
        else if(n == "lobby")
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu lobby");
        }
        else if(n == "back")
        {
            panelconfirmation.SetActive(false);
            Time.timeScale = 1f;
        }

        else if(n == "volume")
        {
            if(isOpenVolume)
            {
                panelVolume.SetActive(false);
                isOpenVolume = false;
            }
            else
            {
                panelVolume.SetActive(true);
                isOpenVolume = true;
            }
        }
    }
}