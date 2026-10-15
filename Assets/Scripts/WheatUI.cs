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
    [SerializeField] private int _costAdd;
    private int _calc;
    private int _warriorCalc;

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

    public void IsHasMoney()
    {
        while (_spawnPeasantButton.activeInHierarchy)
        {


            if (gameManager._wheatCount >= _wallet._peasantSpawnCost)
            {
                _calc = gameManager._wheatCount -= _wallet._peasantSpawnCost;

                _wallet._peasantSpawnCost += _costAdd;


                gameManager.SpawnWorker();


                break;
            }
        }

        



    }

    public void IshasMoneyForWarrior()
    {
        while (_spawnWarriorButton.activeInHierarchy)
        {
            if (gameManager._wheatCount >= _wallet._warriorSpawnCost)
            {
                _warriorCalc = gameManager._wheatCount -= _wallet._warriorSpawnCost;

                gameManager.SpawnWarrior();
            }
        }
    }


    private void UpdateUI()
    {



        _wheatText.text = _calc.ToString();








    }
}
