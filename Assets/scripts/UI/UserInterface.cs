using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UserInterface : MonoBehaviour {

    public Button menuButton;
    public GameObject HUD;
    public GameObject gameOver;
    public GameObject menu;

    private bool paused = false;
    private bool menuButtonPressed = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || menuButtonPressed)
        {
            if (!paused)
            {
                Time.timeScale = 0;
                ShowMenu();

                menuButton.GetComponentInChildren<Text>().text = "Back";

            }
            else
            {
                Time.timeScale = 1;
                HideMenu();
                menuButton.GetComponentInChildren<Text>().text = "Menu";
            }

            paused = !paused;
        }
        menuButtonPressed = false;
    }
    public void OnMenuButton()
    {

        menuButtonPressed = true;

    }

    public void OnMainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("main menu");

    }
    public void OnRetryButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("scene1");

    }

    public void GameOver() {
        HUD.SetActive(false);
        gameOver.SetActive(true);
        string score = HUD.transform.Find("ScoreText").GetComponent<Text>().text;
        gameOver.transform.Find("gameOverScore").GetComponent<Text>().text=score;
        ShowMenu();


    }
    public void ShowMenu()
    {

        menu.SetActive(true);

    }
    public void HideMenu()
    {

        menu.SetActive(false);

    }


}
