using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _timeForRecources = 5f;
    [SerializeField] private float _timer = 5f;

    [SerializeField] private WheatUI _wheatUI;
    [SerializeField] private PeasantSpawner _spawner;
    [SerializeField] private WarriorSpawner _warSpawenr;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private HealthUI _healthUI;
    [SerializeField] private EnemyTimerUI _enemyTimerUI;
    public TextMeshProUGUI _enemyTimerText;
    public EnemyTimer _enemyTimer;


    public int _wheatCount = 0;
    private List<WheatCollect> _workers = new();
    private List<WarriorAttack> _warriors = new();
    private List<Enemy> _enemys = new();

    private void Start()
    {
        _timer = _timeForRecources;
        _wheatUI.Init(_timeForRecources, _timer);

        for (int i = 0; i < 1; i++)
        {
            SpawnWorker();
            SpawnEnemy();
            SpawnWarrior();
        }
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        _wheatUI.UpdateCountWheat(_wheatCount);
        _wheatUI.UpdateTimer(_timer);

        // Безопасное обновление UI здоровья
        if (_warriors != null && _warriors.Count > 0)
        {
            int lastIndex = _warriors.Count - 1;

            // Дополнительная проверка: индекс должен быть строго больше или равен 0
            if (lastIndex >= 0 && lastIndex < _warriors.Count)
            {
                WarriorAttack activeWarrior = _warriors[lastIndex];



                if (activeWarrior = null)
                {
                    _warriors.RemoveAt(lastIndex);
                }
               

            }
        }
       

        // Сбор ресурсов рабочими
        if (_timer <= 0)
        {
            int amount = 0;
            foreach (var worker in _workers)
            {
                if (worker != null)
                {
                    amount += worker.WheatProduction;
                }
            }

            _wheatCount += amount;
            _timer = _timeForRecources;
        }

        _enemyTimerUI.UpdateUI(_enemyTimerText);
    }


    public void SpawnWorker()
    {
        WheatCollect worker = _spawner.Spawn();
        _workers.Add(worker);
    }

    public void SpawnWarrior()
    {
        WarriorAttack warrior = _warSpawenr.Spawn();
        _warriors.Add(warrior);
    }

    public void SpawnEnemy()
    {
        if (_enemyTimer._timer <= 0)
        {
            Enemy enemy = _enemySpawner.Spawn();
            _enemys.Add(enemy);
        }
    }

    public void RemoveWarriorFromList(WarriorAttack warrior)
    {
        if (_warriors.Contains(warrior))
        {
            _warriors.Remove(warrior);
        }
    }



}
