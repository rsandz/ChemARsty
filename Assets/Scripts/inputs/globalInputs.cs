using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class globalInputs : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "main":
                case "help":
                    SceneManager.LoadScene("menu", LoadSceneMode.Single);
                    break;
                default:
                    break;
            }
        }
    }
}
