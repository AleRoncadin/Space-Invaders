using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Punti_Navi : MonoBehaviour
{
    public static int puntiNavi;
    // Start is called before the first frame update
    void Start()
    {
        puntiNavi = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = puntiNavi.ToString();
    }
}
