using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Contains scene switching functions
 */
public class menuButtonHandler : MonoBehaviour
{
    public void switchToMain()
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }

    public void switchToHelp()
    {
        SceneManager.LoadScene("help", LoadSceneMode.Single);
    }
}
