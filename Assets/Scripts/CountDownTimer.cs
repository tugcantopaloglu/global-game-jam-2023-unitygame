using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] Text countDownText;
    private static float currentScore = 0f;
    [SerializeField] Image scoreImage;
    
    //Day night change
    [SerializeField] Sprite nightBackground;
    [SerializeField] Sprite dayBackground;
    [SerializeField] SpriteRenderer backgroundObject;

    [SerializeField] Sprite dayEnemy;
    [SerializeField] Sprite nightEnemy;
    [SerializeField] SpriteRenderer enemyObject;

    [SerializeField] Sprite dayPlayer;
    [SerializeField] Sprite nightPlayer;
    [SerializeField] SpriteRenderer playerObject;

    [SerializeField] Sprite dayTower;
    [SerializeField] Sprite nightTower;
    [SerializeField] SpriteRenderer towerObject;

    [SerializeField] AudioClip dayAudio;
    [SerializeField] AudioClip nightAudio;
    [SerializeField] AudioSource audioSource;
    bool isCycleRunning = false;
    string cycle = "day";


    private void Start()
    {
        StartCoroutine(AddScore());
    }

    private void Update()
    {
        countDownText.text = ("Score: " + currentScore.ToString());
        

        if(!isCycleRunning)
        {
            StartCoroutine(CountForChange());
        }

    }

    IEnumerator AddScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            currentScore += 10;
            scoreImage.color = new Color(255f, 255f - currentScore / 100, 255f - currentScore / 10);
        }
        
    }

    IEnumerator CountForChange()
    {
        isCycleRunning = true;
        yield return new WaitForSeconds(Random.Range(5f, 10f));
        if (cycle == "day")
        {
            backgroundObject.sprite = nightBackground;
            backgroundObject.sortingOrder = -1;
            enemyObject.sprite = nightEnemy;
            playerObject.sprite = nightPlayer;
            towerObject.sprite = nightTower;
            audioSource.clip = dayAudio;
            audioSource.volume = 0.6f;
            cycle = "night";
        }
        else if (cycle == "night")
        {
            backgroundObject.sprite = dayBackground;
            backgroundObject.sortingOrder = -1;
            enemyObject.sprite = dayEnemy;
            playerObject.sprite = dayPlayer;
            towerObject.sprite = dayTower;
            audioSource.clip = nightAudio;
            audioSource.volume = 1f;
            cycle = "day";
        }

        isCycleRunning = false;
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

