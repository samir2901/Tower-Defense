using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanelUI : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
