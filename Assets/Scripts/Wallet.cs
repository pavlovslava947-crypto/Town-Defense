
using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private WheatUI _wheatUI;
    
    public int _peasantSpawnCost = 0;
    public int _warriorSpawnCost = 0;
    public int _calc;
    public int _wellFadWarriorCost = 5;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSpawnPeasantButtonClick()
    {
        IsHasMoney();
    }

    public void OnSpawnWarriorButton()
    {
        IshasMoneyForWarrior();
    }

    public void IshasMoneyForWarrior()
    {


        if (gameManager._wheatCount >= _warriorSpawnCost)
        {
            _calc = gameManager._wheatCount -= _warriorSpawnCost;
            _warriorSpawnCost += 7;

            gameManager.SpawnWarrior();


            _wheatUI.UpdateUI();
        }

    }

    public void IsHasMoney()
    {




        if (gameManager._wheatCount >= _peasantSpawnCost)
        {
            _calc = gameManager._wheatCount -= _peasantSpawnCost;

            _peasantSpawnCost += 5;


            gameManager.SpawnWorker();


            _wheatUI.UpdateUI();
        }

    }
}
