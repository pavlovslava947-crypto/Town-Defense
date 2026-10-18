using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image _hpLine;
    [SerializeField] private WarriorAttack _warriorHP;
    [SerializeField] private TextMeshProUGUI _uiHPtext;
    public float _maxHealth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        _maxHealth = _warriorHP._health;

    }

    // Update is called once per frame
    void Update()
    {
        _hpLine.fillAmount = _warriorHP._health / _maxHealth;

        UpdateUI();
    }

    

    public void UpdateUI()
    {
        _uiHPtext.text = _warriorHP._health.ToString("F1");
    }
}
