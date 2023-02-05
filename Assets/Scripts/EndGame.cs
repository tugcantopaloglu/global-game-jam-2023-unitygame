using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Canvas canvas;

    public void EndScene()
    {
        Time.timeScale = 0;
        canvas.gameObject.SetActive(true);
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            canvas.gameObject.SetActive(false);
            RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
