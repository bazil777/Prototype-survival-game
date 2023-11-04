using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void onPlayButton(){
        SceneManager.LoadScene(1);

    }

    public void onQuitButton(){
        Application.Quit();
    }

}
