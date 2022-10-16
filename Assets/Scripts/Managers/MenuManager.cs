using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
//using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    float timer = 3;

    List<GameObject> previousMenus = new List<GameObject>();

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject InstructionsMenu;
    [SerializeField] GameObject SettingsMenu;

    [SerializeField] GameObject ball;

    [SerializeField] GameObject FirstLevel;

    [SerializeField] TMP_Text timerText;

    private void Awake()
    {
        Time.timeScale = 0;
    }


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
        GameManager.instance.onMenu = false;
        MainMenu.SetActive(false);
        FirstLevel.SetActive(true);
        timerText.gameObject.SetActive(true);
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        Time.timeScale = 1;
        while(timer > 0)
        {
            timerText.text = timer.ToString();
            timer--;
            yield return new WaitForSeconds(1);
        }
        timerText.gameObject.SetActive(false);
        ThrowBall();
    }

    void ThrowBall()
    {
        int i = Random.Range(0, 2);

        Rigidbody ballRb = ball.GetComponent<Rigidbody>();

        if (i == 0)
        {
            ballRb.AddForce(transform.right * 10, ForceMode.Impulse);
            return;
        }
        ball.GetComponent<Rigidbody>().AddForce(-transform.right * 5, ForceMode.Impulse);
    }

    public void OnInstructionsButton()
    {
        LoadMenu(InstructionsMenu);
    }

    public void OnSettingsButton()
    {
        LoadMenu(SettingsMenu);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
