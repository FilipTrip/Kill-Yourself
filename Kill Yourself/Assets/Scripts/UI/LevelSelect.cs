using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private Transform levelGrid;
    [SerializeField] private GameObject levelButtonPrefab;
    [SerializeField] private int nonLevelScenes;

    private void Start()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings - nonLevelScenes;

        for (int i = 0; i < sceneCount; ++i)
        {
            Instantiate(levelButtonPrefab, levelGrid);
        }
    }

}
