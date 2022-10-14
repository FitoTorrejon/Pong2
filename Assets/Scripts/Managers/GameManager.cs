using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    #region Variables

    List<GameObject> previousMenus;

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
    [SerializeField] GameObject MainMenu;

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
            if (!onMenu)
            {
                PauseUnpauseGame();
            }
            else if (InputManager.instance.changingAnyKey)
            {
                InputManager.instance.CancelChangeKey();
            }
            else
            {
                ReturnToPreviousMenu();
            }
        }
    }

    public void ReturnToPreviousMenu()
    {
        if (previousMenus.Count == 0)
        {
            return;
        }
        else
        {
            previousMenus.Last().SetActive(false);
            previousMenus.RemoveAt(previousMenus.Count - 1);
            if (previousMenus.Count != 0)
                LoadMenu(previousMenus.Last());
        }
    }

    public void PauseUnpauseGame()
    {
        GamePaused = !GamePaused;
        if (GamePaused == true)
        {
            //Time stop
            Time.timeScale = 0;

            previousMenus.Add(PauseMenu);
            LoadMenu(PauseMenu);

            return;
        }
        //else
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        previousMenus.Clear();
    }

    private void LoadMenu(GameObject menu)
    {
        previousMenus.Add(menu);
        menu.SetActive(true);
    }

    public void OnSettingsButton()
    {
        LoadMenu(SettingsMenu);
    }

    public void OnBackToMenu()
    {
        onMenu = true;
        LoadMenu(MainMenu);
    }


    #endregion
}
