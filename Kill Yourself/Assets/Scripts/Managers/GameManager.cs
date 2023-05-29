using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Diagnostics;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float gravity = -1;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI timerText;

    private static bool speedrun;
    private static Stopwatch stopwatch;

    public static bool Speedrun => speedrun;

    public static string GetSpeedrunTimerString()
    {
        return stopwatch.Elapsed.ToString("mm\\:ss\\.FFF");
    }

    public static TimeSpan GetSpeedrunTime()
    {
        return stopwatch.Elapsed;
    }

    public static void StartSpeedrun()
    {
        speedrun = true;
        stopwatch = Stopwatch.StartNew();
    }

    public static void StopSpeedrun()
    {
        speedrun = false;
        stopwatch.Stop();
    }

    private void Awake()
    {
        Instance = this;
        Physics2D.gravity = new Vector2(0f, gravity);
        levelText.text = SceneManager.GetActiveScene().name;

        if (speedrun)
            timerText.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (speedrun)
        {
            timerText.text = GetSpeedrunTimerString();
        }

        if (Input.GetKeyDown(KeyCode.G))
            RestartLevel();

        else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (speedrun)
                StopSpeedrun();

            SceneTransitioner.Instance.FadeToMenuScene();
        }
    }

    public void RestartLevel()
    {
        SceneTransitioner.Instance.FadeReloadActiveScene();
        SoundManager.Instance.Play("Error");
    }

}
