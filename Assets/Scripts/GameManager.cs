using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWinPanel;
    [SerializeField] private WaveSpawner waveSpawner;
    [SerializeField] private Timer timer;
    void Update()
    {
        if (PlayerStats.health<=0)
        {
            gameOver();
        }
    }

    void gameOver()
    {
        timer.enabled = false;
        waveSpawner.enabled = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        gameOverPanel.SetActive(true);        
    }

    public void gameWin()
    {
        timer.enabled = false;
        waveSpawner.enabled = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        gameWinPanel.SetActive(true);
    }
}
