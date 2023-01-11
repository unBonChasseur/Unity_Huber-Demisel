using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Slider score;

    //We store the score of any delivery
    [SerializeField]
    private List<float> scores = new List<float>(); 

    void Start()
    {
        //Init slider
        score.maxValue = 5.0f; 
        score.value = 5.0f;

        //Init scores's list
        scores.Add(score.value);
    }
    
    public void addScore(float p_score)
    {
        //We add the score to all scores
        scores.Add(p_score);
        updateScore();
    }

    public void updateScore()
    {
        //Calculation of the mean score value
        float current_score = 0;
        foreach (float score in scores)
        {
            current_score += score;
        }
        current_score = current_score / scores.Count;
        score.value = current_score;
    }
}
