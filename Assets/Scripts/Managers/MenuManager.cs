using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    List<GameObject> previousMenus;

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject InstructionsMenu;
    [SerializeField] GameObject AchievementsMenu;
    [SerializeField] GameObject SettingsMenu;

    [SerializeField] Scene LoadingScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (InputManager.instance.changingAnyKey)
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
            LoadMenu(MainMenu);
        }
        else
        {
            previousMenus.Last().SetActive(false);
            previousMenus.RemoveAt(previousMenus.Count - 1);
            LoadMenu(previousMenus.Last());
        }
    }

    private void LoadMenu(GameObject menu)
    {
        previousMenus.Add(menu);
        menu.SetActive(true);
    }

    public void OnNewGameButton()
    {
        SceneManager.LoadSceneAsync(LoadingScreen.buildIndex, LoadSceneMode.Additive);
        //mirar com fer servir el await per carregar la escena de la partida
        //SceneManager.UnloadSceneAsync(LoadingScreen.buildIndex);
    }

    public void OnInstructionsButton()
    {
        LoadMenu(InstructionsMenu);
    }

    public void OnSettingsButton()
    {
        LoadMenu(SettingsMenu);
    }

    public void OnAchievementsButton()
    {
        LoadMenu(AchievementsMenu);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
