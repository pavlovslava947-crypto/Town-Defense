using System;
using TMPro;
using UnityEngine;

public class HungrySystemUI : MonoBehaviour
{
    [SerializeField] GameObject _hungryButton;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private HungrySystem _hungrySystem;
    [SerializeField] private TextMeshProUGUI _hungryText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameManager._wheatCount < _wallet._wellFadWarriorCost)
        {
            _hungryButton.SetActive(false);
        }
        else
        {
            Debug.Log("Ложно");
        }

        if(_gameManager._wheatCount >= _wallet._wellFadWarriorCost)
        {
            _hungryButton.SetActive(true);
        }
        else
        {
            Debug.Log("Ложно1");
        }

        if (_hungrySystem._calldown > 0)
        {
            UpdateUI();
        }

        else
        {
            _hungryText.text = " ";
        }
    }

    void UpdateUI()
    {
        _hungryText.text = "BEFORE WARRIOR HUNGRY: " + _hungrySystem._calldown.ToString("F1");
    }
}
