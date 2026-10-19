using UnityEngine;

public class HungrySystem : MonoBehaviour
{
    private WarriorAttack _warriorHealth;
    private GameManager _gameManager;
    private Wallet _wallet;
    private HungryScriptController _hungrySystemUI;

    public float _calldown;
    [SerializeField] private float _hungryDamage = 15f;
    [SerializeField] private float _timer;
    [SerializeField] private float _currentTimer = 3f;
    [SerializeField] private float _currentTime = 35f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _warriorHealth = GetComponent<WarriorAttack>();


        _gameManager = Object.FindAnyObjectByType<GameManager>();



        _wallet = Object.FindAnyObjectByType<Wallet>();

        _hungrySystemUI = Object.FindAnyObjectByType<HungryScriptController>();

        _calldown = _currentTime;
        _timer = _currentTimer;
        WarriorAttack warrior = _warriorHealth;
      


    }

    // Update is called once per frame
    void Update()
    {
        if(_calldown > 0)
        {
            _calldown -= Time.deltaTime;
        }

        else
        {


            HungryDamage();



        }

       

        if (_warriorHealth._health <= 0)
        {
            _warriorHealth.Die();
        }
        


    }

    public void WellFedWarrior()
    {
        _gameManager = Object.FindAnyObjectByType<GameManager>();
        _wallet = Object.FindAnyObjectByType<Wallet>();
        _warriorHealth = GetComponent<WarriorAttack>();
        _hungrySystemUI = Object.FindAnyObjectByType<HungryScriptController>();


        _gameManager._wheatCount -= _wallet._wellFadWarriorCost;

        _timer = _currentTimer;
        _calldown = _currentTime;
        
        _hungrySystemUI.UpdateUI();
        Debug.Log("Выполнено");
       




    }

    void HungryDamage()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _warriorHealth._health -= _hungryDamage;
            _timer = _currentTimer;
        }

        

    }
}
