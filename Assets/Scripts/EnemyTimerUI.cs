using TMPro;
using UnityEngine;

public class EnemyTimerUI : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TextMeshProUGUI _enemySpawnText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        _enemySpawnText.text = _gameManager._enemyTimer._timer.ToString("F1");
    }
}
