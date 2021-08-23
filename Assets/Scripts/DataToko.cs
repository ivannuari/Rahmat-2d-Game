using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DataToko
{
    public Sprite gambarToko;
    public string namaToko;

    [TextArea(3 , 5)]
    public string alamatToko;

    public float koordinatLatitude , koordinatLongitude;

    public string JamBuka;
}
