using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public string namaPemain;
    public int coin;
    public int maxHp = 3;

    public int levelUnlocked = 1;

    public void InputNama(string n)
    {
        namaPemain = n;
    }
}
