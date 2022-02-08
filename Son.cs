using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Son : MonoBehaviour
{
    public Text durumText;
    public GameObject btn;
    // Start is called before the first frame update
    void Start()
    {
            durumText.text = "Oyunu Tamamladýnýz.Tebrikler!";
            btn.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
