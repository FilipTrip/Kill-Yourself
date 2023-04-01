using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private int number;

    private void Start()
    {
        number = transform.GetSiblingIndex() + 1;
        text.text = number.ToString();
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Level " + number);
    }

}
