using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager DM;

    public DataToko[] data;

    public Image tokoPict;      //assign image untuk gamabr toko kesini

    public Text tokoName , tokoAdress , jamBukaToko;      ////assign text nama toko , alamt ,dan jam buka toko kesini

    public float latitude , longitude; //kosongkan aja sementara

    public int NomorToko = 0;

    void Awake()
    {
        if(DM ==null)
        {
            DM = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        tokoPict.sprite = data[NomorToko].gambarToko;
        tokoName.text = data[NomorToko].namaToko;
        tokoAdress.text = data[NomorToko].alamatToko;
        latitude = data[NomorToko].koordinatLatitude;
        longitude = data[NomorToko].koordinatLongitude;
    }
}
