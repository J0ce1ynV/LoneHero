using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.CheckSaveFile();
        levelCurrent = GameManager.Instance.levelCurrent;
        AddChangeSceneListeners();
        DisableLockedLevel();
        //CheckStartPanelExp();
    }

    #region Level Interface Management
    [Header("Level Selection Buttons")]
    public int levelCurrent;
    public Button[] levelButtons;

    public int sceneIndex = 0;
    private void AddChangeSceneListeners()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int sceneIndex = i + 1;
            levelButtons[i].onClick.AddListener(() => GameManager.Instance.ChangeScene(sceneIndex));
        }
    }
    private void DisableLockedLevel()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > levelCurrent)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    #endregion
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private int levelCurrent;
    public Button[] levelButton;

    void Start()
    {
        GameManager.Instance.CheckSaveFile();
        levelCurrent = GameManager.Instance.levelCurrent;
        AddChangeSceneListerners();
        DisableLockedLevel();
    }
    
    public void AddChangeSceneListerners()
    {
        for(int i = 0; i < levelButton.Length; i++)
        {
            int sceneIndex = i + 1;
            levelButton[i].onClick.AddListener(() => GameManager.Instance.ChangeScene(sceneIndex));
        }
    }

    public void DisableLockedLevel()
    {
        for (int i = 0;i < levelButton.Length; i++)
        {
            if(i > levelCurrent)
            {
                levelButton[i].interactable = false; 
            }
        }
    }
}
*/