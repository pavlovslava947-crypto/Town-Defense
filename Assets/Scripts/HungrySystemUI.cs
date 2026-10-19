
using TMPro;
using UnityEngine;

public class HungrySystemUI : MonoBehaviour
{
    [SerializeField] GameObject _hungryButton;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Wallet _wallet;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = Object.FindAnyObjectByType<GameManager>();
        _wallet = Object.FindAnyObjectByType<Wallet>();
      
    }

    // Update is called once per frame
    void Update()
    {


        if (_gameManager._wheatCount >= _wallet._wellFadWarriorCost)
        {
            
             _hungryButton.SetActive(true);
        }
        else
        {
            
             _hungryButton.SetActive(false);
        }

    }

    
}
