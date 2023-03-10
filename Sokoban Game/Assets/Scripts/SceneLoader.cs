using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*public enum Scene {
    MainMenu
}*/

public class SceneLoader : MonoBehaviour
{
    /**public static SceneLoader  instance = null;

    public void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }*/

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex +1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadSceneWithIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public static void LoadSceneWithName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
