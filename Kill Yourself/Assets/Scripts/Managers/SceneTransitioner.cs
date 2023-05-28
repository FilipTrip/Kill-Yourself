using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public static SceneTransitioner Instance { get; private set; }

    [SerializeField] private Animator animator;
    [SerializeField] private float fadeDuration;

    private void Awake()
    {
        Instance = this;
    }

    public void FadeToScene(string sceneName)
    {
        animator.SetTrigger("FadeToBlack");
        DelayedCall.Create(this, () => SceneManager.LoadScene(sceneName), fadeDuration);
    }

    public void FadeToNextScene()
    {
        animator.SetTrigger("FadeToBlack");
        DelayedCall.Create(this, NextScene, fadeDuration);
    }

    public void FadeToMenuScene()
    {
        animator.SetTrigger("FadeToBlack");
        DelayedCall.Create(this, LoadMenuScene, fadeDuration);
    }

    public void FadeReloadActiveScene()
    {
        animator.SetTrigger("FadeToBlack");
        DelayedCall.Create(this, ReloadActiveScene, fadeDuration);
    }

    public void NextScene()
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

    public void ReloadActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
