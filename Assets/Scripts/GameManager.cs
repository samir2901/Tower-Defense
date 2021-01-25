using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private WaveSpawner waveSpawner;
    void Update()
    {
        if (PlayerStats.health<=0)
        {
            gameOver();
        }
    }

    void gameOver()
    {
        gameOverPanel.SetActive(true);
        waveSpawner.enabled = false;
    }
}
