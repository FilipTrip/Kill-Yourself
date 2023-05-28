using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private void Start()
    {
        if (GameManager.Speedrun)
        {
            GameManager.StopSpeedrun();
            timerText.gameObject.SetActive(true);
            timerText.text = GameManager.GetSpeedrunTimerString();
        }
        else
        {
            timerText.gameObject.SetActive(false);
        }
    }

}
