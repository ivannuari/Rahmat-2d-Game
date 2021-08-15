using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "soal")]
public class Quis : ScriptableObject
{
    [TextArea(5 , 10)]
    public string pertanyaan , opsiA , opsiB , opsiC , opsiD;

    public int jawaban;
}
