using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject bar;
    private float damageScale = 0.2f;

    private void Update()
    {
        Debug.Log(bar);
    }
    public void setSize()
    {
        if(bar!=null)
        { 
        Vector3 currentScale = bar.transform.localScale;
        currentScale.x -= damageScale;
        bar.transform.localScale = currentScale;
        }
    }
}
