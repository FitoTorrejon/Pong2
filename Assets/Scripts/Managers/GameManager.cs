using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Variables

    [SerializeField] GameObject firstLevel;
    [SerializeField] GameObject secondLevel;

    [SerializeField] GameObject victoryPanel;

    private bool GamePaused = false;
    public bool onMenu = true;

    public int pointsToWin = 10;

    #endregion

    #region Constants

    #endregion

    #region Accesses

    public static GameManager instance;

    [SerializeField] Scene LoadingScreen;
    [SerializeField] GameObject SettingsMenu;
    [SerializeField] GameObject PauseMenu;

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

    public void GameOver(string winner)
    {
        GamePaused = true;
        Time.timeScale = 0;
        victoryPanel.SetActive(true);
        victoryPanel.GetComponentInChildren<TMP_Text>().text = winner + " WINS!!";
        StartCoroutine(OnGameOver(winner));
    }

    IEnumerator OnGameOver(string winner)
    {
        yield return new WaitForSeconds(3);
        victoryPanel.SetActive(false);
        OnBackToMenu();
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
        GamePaused = false;
        onMenu = true;
        PauseMenu.SetActive(false);
        firstLevel.SetActive(false);
        secondLevel.SetActive(false);
        MenuManager.instance.ReturnToMainMenu();
    }


    #endregion
}
