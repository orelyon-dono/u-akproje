using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController2 : MonoBehaviour
{
    public GameObject plane;
    public Text durum;
    public Text EndText;
    public int puan;
    private bool hasCollided;

    private void Start()
    {
        puan = 0;
        hasCollided = false;
    }

    private void FixedUpdate()
    {
        durum.text = "Puan: " + puan.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        hasCollided = false; // Her çarpýþma anýnda hasCollided'i sýfýrla

        if (collision.gameObject.tag == "circle" && !hasCollided)
        {
            puan += 5;
            hasCollided = true;

            if (puan >= 350)
            {
                EndText.gameObject.SetActive(true);
                EndText.text = "Oyun Bitti";
            }
        }
    }
}
