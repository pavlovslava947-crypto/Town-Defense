using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheatUI : MonoBehaviour
{


    [SerializeField] private GameManager gameManager;
    [SerializeField] private Image _wheatImage;
    [SerializeField] private TextMeshProUGUI _wheatText;
    [SerializeField] private Wallet _wallet;
    [SerializeField] GameObject _spawnPeasantButton;
    [SerializeField] private GameObject _spawnWarriorButton;
    [SerializeField] private TextMeshProUGUI _spawnPeasantCostText;
    [SerializeField] private TextMeshProUGUI _spawnWarriorCostText;
    [SerializeField] private WarriorAttack _warrior;
    
    

    public float maxSeconds = 15f;
    private float _currentTimer;




    void Start()
    {

        _currentTimer = maxSeconds;
        UpdateUI();
    }

    void Update()
    {
        _wheatImage.fillAmount = _currentTimer / maxSeconds;

        if (_currentTimer <= 0f)
        {
            _wheatImage.fillAmount = 1f;
            _currentTimer = maxSeconds;


        }

        if (gameManager._wheatCount >= _wallet._peasantSpawnCost && !_spawnPeasantButton.activeInHierarchy)
        {
            _spawnPeasantButton.SetActive(true);
        }

        if (gameManager._wheatCount < _wallet._peasantSpawnCost)
        {
            _spawnPeasantButton.SetActive(false);
        }

        if (gameManager._wheatCount >= _wallet._warriorSpawnCost && !_spawnWarriorButton.activeInHierarchy)
        {
            _spawnWarriorButton.SetActive(true);
        }

        if (gameManager._wheatCount < _wallet._warriorSpawnCost)
        {
            _spawnWarriorButton.SetActive(false);
        }
    }

    public void Init(float baseTime, float curTime)
    {
        _currentTimer = curTime;
        maxSeconds = baseTime;
    }

    public void UpdateCountWheat(int wheat)
    {
        _wheatText.text = wheat.ToString();
    }

    public void UpdateTimer(float time)
    {
        _currentTimer = time;
    }


    public void UpdateUI()
    {
       
        _wheatText.text = _wallet._calc.ToString();
        _spawnWarriorCostText.text = _wallet._warriorSpawnCost.ToString();
        _spawnPeasantCostText.text = _wallet._peasantSpawnCost.ToString();

    }
}
