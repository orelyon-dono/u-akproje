using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject plane;
    public Text durum;
    public Button button;

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Finish")
        {
            durum.gameObject.SetActive(true);
            durum.text="AKINCININ ilk u�u� testi ba�ar�l� daha zorlu ko�ullarda test edilicek";
            button.gameObject.SetActive(true);
        }


    }

    public void TiklandigindaButton() 
    {
        SceneManager.LoadScene(2);
    
    }
}  
