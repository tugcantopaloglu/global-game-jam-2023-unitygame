using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
