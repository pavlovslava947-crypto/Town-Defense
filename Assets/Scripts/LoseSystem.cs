using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseSystem : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private TextMeshProUGUI _loseText;
    private string _gamePlayScene = "SampleScene";
    private string _mainMenuScene = "MainMenu";
    private float _scoreTimer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   

    // Update is called once per frame
    void Update()
    {
        _scoreTimer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _losePanel.SetActive(true);
            Time.timeScale = 0f;
            _loseText.text = "the score for this game: " + _scoreTimer.ToString("F0");
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
}
