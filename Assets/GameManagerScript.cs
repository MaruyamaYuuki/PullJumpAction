using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public string nextSceneName;
    public string titleScene;
    public string nextStage;
    public GameObject ClearText;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ClearText.activeInHierarchy)
            {
                SceneManager.LoadScene(nextStage);
            }
            else
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(titleScene);
        }
       /* if (ClearText.activeInHierarchy)
        {
            Debug.Log("Active");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(nextStage);
            }
        }*/

    }
}
