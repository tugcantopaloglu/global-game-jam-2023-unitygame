using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTower : MonoBehaviour
{
    CountDownTimer timer = new CountDownTimer();
    [SerializeField] Sprite nightSprite;
    [SerializeField] Sprite daySprite;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (timer.GetCycle()== "day")
        {
            spriteRenderer.sprite = daySprite;
        }
        else if (timer.GetCycle() == "night")
        {
            spriteRenderer.sprite = nightSprite;
        }
    }
}
