using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QUIZMANAGER : MonoBehaviour
{
    public List<QUESTIONS> Data;

    [Header ("Quiz References")]
    [SerializeField] private TextMeshProUGUI questionsText;
    [SerializeField] private TextMeshProUGUI answer1;
    [SerializeField] private TextMeshProUGUI answer2;
    [SerializeField] private TextMeshProUGUI answer3;
    [SerializeField] private TextMeshProUGUI answer4;
    [SerializeField] private TextMeshProUGUI ScoreText  ;

    int randomQuestion;
    int currentScore;


  
    
    private void Start()
    {
        RandomQuestion();
        currentScore = 0;
        ScoreText.text = "Score: " + currentScore;
    }

    public void RandomQuestion()
    {
        randomQuestion = Random.Range(0, Data.Count);

        questionsText.text = Data[randomQuestion].question;
        answer1.text = Data[randomQuestion].Answer[0];
        answer2.text = Data[randomQuestion].Answer[1];
        answer3.text = Data[randomQuestion].Answer[2];
        answer4.text = Data[randomQuestion].Answer[3];
    }
    public void CheckAnswers(GameObject PushButton)
    {
        if(PushButton.name == Data[randomQuestion].Rightanswer.ToString())
        {
            Debug.Log("correct Answer");
            CorrectAnswer();
        }
        else
        {
            Debug.Log("wrong Answer");
            WrongAnswer();
        }
    }
    public void CorrectAnswer()
    {
        if (Data.Count > 1)
        {
            currentScore += 100;
            ScoreText.text = "Score: " + currentScore;
            Data.RemoveAt(randomQuestion);
            RandomQuestion();

       
        }
        else
        {
            currentScore += 100;
            ScoreText.text = "Score: " + currentScore;
            // vaya a tu escena final y mostrar score
           LoadScene();
           SaveScore();

        }
        
    }

    void Star()
    {

    }
  
    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score: ", currentScore);
    }

    public void LoadScore()
    {
        currentScore = PlayerPrefs.GetInt("Score:");
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("FinalScore"); // escena final cargada
    }

    public void WrongAnswer()
    {
        if(Data.Count > 1)
        {
            Data.RemoveAt(randomQuestion);
            RandomQuestion();
        }
        else
        {
            LoadScene();   // cambio de escena la final para mostrar score
            SaveScore();
        }

    }

  

}
