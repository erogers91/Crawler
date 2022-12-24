using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TMP_InputField _seedInput;

    public Generation generation;

    void Start()
    {
        _seedInput.text = PlayerPrefs.GetInt("Seed").ToString();
        generation = FindObjectOfType<Generation>();
    }

    public void OnUpdateSeed()
    {
        PlayerPrefs.SetInt("Seed", int.Parse(_seedInput.text));
    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");
    }
}
