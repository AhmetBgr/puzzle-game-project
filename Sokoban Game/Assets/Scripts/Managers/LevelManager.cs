using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class LevelManager : MonoBehaviour
{
    public SceneLoader SceneLoader;
    public LevelData[] levels;

    public LevelData curLevel;

    public static LevelManager instance = null;

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
    }

    private void OnEnable()
    {
        if (GameManager.instance)
        {
            GameManager.instance.OnLevelComplete += SetCurLevelComplete;
            GameManager.instance.OnLevelComplete += LoadOverWorld;
        }


        LevelSelectionBox.OnLevelSelect += SetCurLevel;
    }

    private void OnDisable()
    {
        if (GameManager.instance)
        {
            GameManager.instance.OnLevelComplete -= SetCurLevelComplete;
            GameManager.instance.OnLevelComplete -= LoadOverWorld;
        }


        LevelSelectionBox.OnLevelSelect -= SetCurLevel;
    }

    void Start()
    {
        
    }


    public void SetCurLevelComplete()
    {
        if (curLevel == null) return;

        curLevel.SetComplete();
    }

    

    private void SetCurLevel(LevelData level)
    {
        Debug.LogWarning("Level selected: " + level.name);
        curLevel = level;
    }

    public void LoadOverWorld()
    {
        SceneLoader.LoadSceneWithName("OverWorld");
    }
}
