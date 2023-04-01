using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float gravity = -1;
    [SerializeField] private TextMeshProUGUI levelText;

    private void Awake()
    {
        Instance = this;
        Physics2D.gravity = new Vector2(0f, gravity);
        levelText.text = SceneManager.GetActiveScene().name;
    }

    public void LevelCompleted()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            // No more levels
            SceneManager.LoadScene("Menu");
        }
        else
        {
            // Load next level
            SceneManager.LoadScene(sceneIndex + 1);
        }
    }
    
}
