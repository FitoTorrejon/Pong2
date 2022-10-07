using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Variables

    private bool gamePaused;

    #endregion

    #region Constants

    #endregion

    #region Accesses

    [SerializeField] Scene UIScene;

    public UnityEvent OnPause = new UnityEvent();

    public bool GamePaused {
        get => gamePaused;
        set => gamePaused = value;
    }
    #endregion

    #region Methods

    private void Start()
    {
        OnPause.AddListener(PauseUnpauseGame);
    }

    public void PauseUnpauseGame()
    {
        GamePaused = !GamePaused;
        if (GamePaused == true)
        {
            //Time stop
            Time.timeScale = 0;
            if (UIScene != null)
            {
                SceneManager.LoadSceneAsync(UIScene.buildIndex, LoadSceneMode.Additive);
            }
            return;
        }
        //else
        Time.timeScale = 1;
        if (UIScene != null)
        {
            SceneManager.UnloadSceneAsync(UIScene.buildIndex);
        }
    }
    #endregion
}
