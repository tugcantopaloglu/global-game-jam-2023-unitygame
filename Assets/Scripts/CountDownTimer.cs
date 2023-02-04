using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] Text countDownText;
    private float currentScore = 0f;
    

    private void Start()
    {
        
        StartCoroutine(AddScore());
    }

    private void Update()
    {
        
   }

    IEnumerator AddScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            currentScore += 10;
            countDownText.text = ("Score: " + currentScore.ToString());
        }
        
    }
}

