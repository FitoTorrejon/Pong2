using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
//using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    int timer = 3;

    List<GameObject> previousMenus = new List<GameObject>();

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject InstructionsMenu;
    [SerializeField] GameObject SettingsMenu;
    [SerializeField] GameObject LevelsMenu;
    [SerializeField] GameObject candyBackground;
    [SerializeField] GameObject spaceBackground;

    [SerializeField] GameObject FirstLevel;
    [SerializeField] GameObject SecondLevel;

    [SerializeField] TMP_Text timerText;
    [SerializeField] GameObject pointCounter1;
    [SerializeField] GameObject pointCounter2;

    [SerializeField] GameObject randomBall;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 0;
        randomBall.SetActive(true);
        LoadMenu(MainMenu);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameManager.instance.onMenu)
            {
                return;
            }
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
        if (previousMenus.Count == 1)
        {
            return;
        }
        if (previousMenus.Count > 1)
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

    public void ReturnToMainMenu()
    {
        candyBackground.SetActive(false);
        spaceBackground.SetActive(false);
        previousMenus.Add(MainMenu);
        MainMenu.SetActive(true);
        pointCounter1.SetActive(false);
        pointCounter2.SetActive(false);
        timerText.gameObject.SetActive(false);
        MusicManager.instance.source.clip = MusicManager.instance.clips[0];
        MusicManager.instance.source.Play();
        StopCoroutine(StartCountdown());
        timer = 3;
    }

    public void OnNewGameButton()
    {
        LoadMenu(LevelsMenu);
        MainMenu.SetActive(false);
    }

    public void OnLevel1Button()
    {
        GameManager.instance.onMenu = false;
        MainMenu.SetActive(false);
        LevelsMenu.SetActive(false);
        FirstLevel.SetActive(true);
        timerText.gameObject.SetActive(true);
        candyBackground.SetActive(true);
        pointCounter1.SetActive(true);
        pointCounter2.SetActive(true);
        MusicManager.instance.source.clip = MusicManager.instance.clips[1];
        MusicManager.instance.source.Play();
        StartCoroutine(StartCountdown());
    }

    public void OnLevel2Button()
    {
        GameManager.instance.onMenu = false;
        MainMenu.SetActive(false);
        LevelsMenu.SetActive(false);
        SecondLevel.SetActive(true);
        timerText.gameObject.SetActive(true);
        spaceBackground.SetActive(true);
        pointCounter1.SetActive(true);
        pointCounter2.SetActive(true);
        MusicManager.instance.source.clip = MusicManager.instance.clips[2];
        MusicManager.instance.source.Play();
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        Time.timeScale = 1;
        while (timer > 0)
        {
            timerText.text = timer.ToString();
            timer--;
            yield return new WaitForSeconds(1);
        }
        timerText.gameObject.SetActive(false);
        timer = 3;
    }

    public void OnInstructionsButton()
    {
        LoadMenu(InstructionsMenu);
        MainMenu.SetActive(false);
    }

    public void OnSettingsButton()
    {
        LoadMenu(SettingsMenu);
        MainMenu.SetActive(false);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
