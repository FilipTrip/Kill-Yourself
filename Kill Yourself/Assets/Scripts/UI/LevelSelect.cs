using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private Transform levelGrid;
    [SerializeField] private GameObject levelButtonPrefab;
    [SerializeField] private int nonLevelScenes = 1;

    private void Awake()
    {
        foreach (Transform child in levelGrid)
            Destroy(child.gameObject);

        int levels = SceneManager.sceneCountInBuildSettings - nonLevelScenes;

        for (int i = 0; i < levels; ++i)
        {
            Instantiate(levelButtonPrefab, levelGrid);
        }
    }

}
