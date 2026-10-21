using UnityEngine;

public class EnemyTimer : MonoBehaviour
{
    public float _seconds = 30f;
    [SerializeField] private GameManager _gameManager;
    private float _currentTime;
    public float _timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentTime = _seconds;
    }

    // Update is called once per frame
    void Update()
    {
        _timer = _seconds -= Time.deltaTime;

        if(_timer <= 0)
        {
            _seconds = _currentTime;
            _gameManager.SpawnEnemy();
        }

        

    }
}
