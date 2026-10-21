using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinSystem : MonoBehaviour
{
    [SerializeField] GameObject _winPanel;
    [SerializeField] private TextMeshProUGUI _winText;
    private string _gamePlayScene = "SampleScene";
    private string _mainMenuScene = "MainMenu";
    [SerializeField] private GameObject _firstStar;
    [SerializeField] private GameObject _secondStar;
    [SerializeField] private GameObject _thirdStar;

    private float _gameScoreTimer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   

    // Update is called once per frame
    void Update()
    {
        _gameScoreTimer += Time.deltaTime;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Warrior"))
        {
            _winPanel.SetActive(true);
            Time.timeScale = 0f;
            StarScoreCalculate();
            _winText.text = "the score for this game: " + _gameScoreTimer.ToString("F0");
        }
        
    }

    public void OnReapetButton()
    {
        SceneManager.LoadScene(_gamePlayScene);
        Time.timeScale = 1.0f;
    }

    public void OnHomeButton()
    {
        SceneManager.LoadScene(_mainMenuScene);
        Time.timeScale = 1.0f;
    }

    void StarScoreCalculate()
    {
        if(_gameScoreTimer <= 20f)
        {
            _firstStar.SetActive(true);
            _secondStar.SetActive(true);
            _thirdStar.SetActive(true);
        }

        if(_gameScoreTimer >= 100f)
        {
            _firstStar.SetActive(true);
            _secondStar.SetActive(true);
            _thirdStar.SetActive(false);
        }

        if(_gameScoreTimer >= 200f)
        {
            _firstStar.SetActive(true);
            _secondStar.SetActive(false);
            _thirdStar.SetActive(false);
        }

        else if( _gameScoreTimer > 1000f)
        {
            _firstStar.SetActive(false);
            _secondStar.SetActive(false);
            _thirdStar.SetActive(false);
        }
    }
    
}
