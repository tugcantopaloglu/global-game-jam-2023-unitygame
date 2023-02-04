using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] Text countDownText;
    private static float currentScore = 0f;
    

    private void Start()
    {
        
        StartCoroutine(AddScore());
    }

    private void Update()
    {
        countDownText.text = ("Score: " + currentScore.ToString());
    }

    IEnumerator AddScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            currentScore += 10;
        }
        
    }
    public float GetScore()
    {
        return currentScore;
    }

    public void AddPointToScore(float score)
    {
        currentScore += score;
    }

    public void DeletePointFromScore(float score)
    {
        currentScore -= score;
    }
}

