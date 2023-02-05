using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Canvas canvas;
    [SerializeField] Text countDownText;
    private static float currentScore = 0f;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            countDownText.text = ("Score: " + currentScore.ToString());
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
