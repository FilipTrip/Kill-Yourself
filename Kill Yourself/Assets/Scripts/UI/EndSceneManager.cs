using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Keyboard keyboard;
    [SerializeField] private Scoreboard scoreboard;
    

    private void Start()
    {
        keyboard.gameObject.SetActive(false);
        mainMenuButton.Select();

        scoreboard.LoadHighscores();
        scoreboard.EnsureNoNames();

        if (GameManager.Speedrun)
        {
            GameManager.StopSpeedrun();
            timerText.gameObject.SetActive(true);
            timerText.text = GameManager.GetSpeedrunTimerString();

            if (scoreboard.IsTop(GameManager.GetSpeedrunTime()))
            {
                Debug.Log("New highscore!");
                scoreboard.AddHighscore(GameManager.GetSpeedrunTime());
                keyboard.gameObject.SetActive(true);
                keyboard.GetComponentInChildren<Button>().Select();
                mainMenuButton.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("No new highscore.");
            }
        }
        else
        {
            timerText.gameObject.SetActive(false);
        }

        scoreboard.ReloadScoreboard();
    }

}
