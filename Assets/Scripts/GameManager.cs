using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _timeForRecources = 5f;
    [SerializeField] private float _timer = 5f;

    [SerializeField] private WheatUI _wheatUI;
    [SerializeField] private PeasantSpawner _spawner;


    public int _wheatCount = 0;
    private List<WheatCollect> _workers = new();

    private void Start()
    {
        _timer = _timeForRecources;
        _wheatUI.Init(_timeForRecources, _timer);

        for(int i = 0; i < 1;  i++)
        {
            SpawnWorker();
        }
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        _wheatUI.UpdateCountWheat(_wheatCount);
        _wheatUI.UpdateTimer(_timer);

        if (_timer <= 0)
        {
            int amount = 0;
            foreach (var worker in _workers)
            {
                amount += worker.WheatProduction;
            }

            _wheatCount += amount;
            _timer = _timeForRecources;
        }
    }

    public void SpawnWorker()
    {
        WheatCollect worker = _spawner.Spawn();
        _workers.Add(worker);
    }

}
