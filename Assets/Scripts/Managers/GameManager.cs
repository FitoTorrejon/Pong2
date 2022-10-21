using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    #region Variables

    [SerializeField] GameObject firstLevel;
    [SerializeField] GameObject secondLevel;

    private bool gamePaused;
    public bool onMenu = true;

    #endregion

    #region Constants

    #endregion

    #region Accesses

    public static GameManager instance;

    [SerializeField] Scene LoadingScreen;
    [SerializeField] GameObject SettingsMenu;
    [SerializeField] GameObject PauseMenu;

    public bool GamePaused {
        get => gamePaused;
        set => gamePaused = value;
    }
    #endregion

    #region Methods

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (onMenu)
            {
                return;
            }
            if (InputManager.instance.changingAnyKey)
            {
                InputManager.instance.CancelChangeKey();
                return;
            }
            PauseUnpauseGame();
        }
    }

    public void PauseUnpauseGame()
    {
        GamePaused = !GamePaused;
        if (GamePaused == true)
        {
            //Time stop
            Time.timeScale = 0;

            LoadMenu(PauseMenu);

            return;
        }
        //else
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }

    private void LoadMenu(GameObject menu)
    {
        menu.SetActive(true);
    }

    public void OnSettingsButton()
    {
        PauseMenu.SetActive(false);
        LoadMenu(SettingsMenu);
    }

    public void OnBackToMenu()
    {
        onMenu = true;
        PauseMenu.SetActive(false);
        firstLevel.SetActive(false);
        secondLevel.SetActive(false);
        MenuManager.instance.ReturnToMainMenu();
    }


    #endregion
}
