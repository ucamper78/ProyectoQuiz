using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;


public class GameOverScore : MonoBehaviour
{
    [SerializeField] PlayerPrefs playerPrefs;
    [SerializeField] TextMeshProUGUI TotalScore;


    void Start()
    {
         PlayerPrefs.GetInt("Score: ");
        TotalScore.text = PlayerPrefs.GetInt("Score: ").ToString();
        

    }


    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }


}
