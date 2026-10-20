using TMPro;
using UnityEngine;

public class HungryScriptController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hungryText;
    [SerializeField] private HungrySystem _hungrySystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_hungrySystem._calldown > 0)
        {
            UpdateUI();
        }

        else
        {
            _hungryText.text = " ";
        }
    }

    public void UpdateUI()
    {
        _hungryText.text = "HUNGRY: " + _hungrySystem._calldown.ToString("F0");
    }
}
