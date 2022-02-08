using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopKontrol : MonoBehaviour
{
    public GameObject finish;
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Text zaman, can, durum;
    private Rigidbody rg;
    public float Hýz = 2f;
    static float zamanSayaci = 60;
    static int canSayaci = 5;
    bool oyunDevam = true;
    bool oyunTamam = false;
    // Start is called before the first frame update
    void Start()
    {
        can.text = canSayaci + "";
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !oyunTamam)
        {
            zamanSayaci -= Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
        }
        else if (!oyunTamam)
        {
            durum.text = "Oyun Tamamlanamadý.";
            btn.gameObject.SetActive(true);
            canSayaci = 5;
            zamanSayaci = 60;
        }
        if(zamanSayaci<0)
            oyunDevam=false;
        if(Input.GetKey(KeyCode.Escape))
            Application.Quit();

    }
    private void FixedUpdate()
    {
        if (oyunDevam && !oyunTamam) { 
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        Vector3 kuvvet = new Vector3(dikey*3, 0, -yatay*3);
        rg.AddForce(kuvvet * Hýz);
    }
        else
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }

    }
    private void OnCollisionEnter(Collision cls)
    {
        string objIsmi = cls.gameObject.name;
        if (objIsmi.Equals("bitis"))
        {
            SceneManager.LoadScene(1);
            canSayaci += 1;
            zamanSayaci += 10;
        }
        else if (!objIsmi.Equals("Zemin") && !objIsmi.Equals("LabirentZemin") && !objIsmi.Equals("first"))
        {
            canSayaci -= 1;
            can.text = canSayaci + "";
            if (canSayaci == 0)
                oyunDevam = false;
        }
        if (objIsmi.Equals("first"))
        {
            finish.gameObject.SetActive(true);
            
        }
        if (objIsmi.Equals("finish") && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("bolum2"))
        {
            oyunTamam = true;
            canSayaci = 5;
            zamanSayaci = 60;
            SceneManager.LoadScene(2);
        }
    }
}
