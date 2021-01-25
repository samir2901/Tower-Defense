using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    
    [SerializeField] private Vector2 rangeTime;    
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameManager gameManager;
    [HideInInspector] public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(rangeTime.x,rangeTime.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            timerText.text = (Mathf.Round(timer)).ToString();
        }
        else
        {
            gameManager.gameWin();
        }
    }
}
