using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public static SceneTransitioner Instance { get; private set; }

    [SerializeField] private Animator animator;
    [SerializeField] private float fadeDuration;
    [SerializeField] private float loadSceneDelay;

    private void Awake()
    {
        Instance = this;
    }

    public void FadeToScene(string sceneName)
    {
        animator.SetTrigger("FadeToBlack");
        DelayedCall.Create(this, () => SceneManager.LoadScene(sceneName), fadeDuration + loadSceneDelay);
    }

    public void FadeToNextLevel()
    {
        animator.SetTrigger("FadeToBlack");
        DelayedCall.Create(this, NextLevel, fadeDuration + loadSceneDelay);
    }

    public void FadeToMenuScene()
    {
        animator.SetTrigger("FadeToBlack");
        DelayedCall.Create(this, LoadMenuScene, fadeDuration + loadSceneDelay);
    }

    public void FadeReloadActiveScene()
    {
        animator.SetTrigger("FadeToBlack");
        DelayedCall.Create(this, ReloadActiveScene, fadeDuration + loadSceneDelay);
    }

    public void FadeExitGame()
    {
        animator.SetTrigger("FadeToBlack");
        DelayedCall.Create(this, Exit.ExitApplication, fadeDuration + loadSceneDelay);
    }

    public void NextLevel()
    {
        int level = int.Parse(SceneManager.GetActiveScene().name.Replace("Level ", ""));

        if (level == LevelSelect.LevelCount)
        {
            SceneManager.LoadScene("End");
        }
        else
        {
            SceneManager.LoadScene("Level " + (level + 1).ToString());
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
