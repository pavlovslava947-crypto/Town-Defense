using UnityEngine;

public class HungrySystem : MonoBehaviour
{
    [SerializeField] private WarriorAttack _warriorHealth;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Wallet _wallet;
   
    public float _calldown = 35f;
    [SerializeField] private float _hungryDamage = 15f;
    [SerializeField] private float _timer = 3f;
    [SerializeField] private float _currentTimer;
    private float _currentTime;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentTime = _calldown;
        _currentTimer = _timer;
        WarriorAttack warrior = _warriorHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        _calldown -= Time.deltaTime;
        _timer -= Time.deltaTime;

        if(_warriorHealth._health <= 0)
        {
            _warriorHealth.Die();
        }

        if (_calldown <= 0)
        {


            HungryDamage();
            
            

        }
    }

    public void WellFedWarrior()
    {
        if (_gameManager._wheatCount >= _wallet._wellFadWarriorCost)
        {
            
            _gameManager._wheatCount -= _wallet._wellFadWarriorCost;
            _calldown = _currentTime;
            Debug.Log("Выполнено");
        }

       

    }

    void HungryDamage()
    {
        if(_timer <= 0)
        {
            _warriorHealth._health -= _hungryDamage;
            _timer = _currentTimer;
        }
       
    }
}
