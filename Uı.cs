using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Uı : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);

    }

    public void QuitScene()
    { 
    Application.Quit();
    
    }
}
