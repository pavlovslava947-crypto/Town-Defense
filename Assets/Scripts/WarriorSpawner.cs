using UnityEngine;
using UnityEngine.UI;

public class WarriorSpawner : MonoBehaviour
{
    [SerializeField] private WarriorAttack _warrior;
    [SerializeField] private HealthUI _maxHP;
    [SerializeField] private WheatUI _wheatUI;
    [SerializeField] private Image _HPbar;
    private Vector2 _wVector = new Vector2(2.65f , -0.3f);
    public WarriorAttack Spawn()
    {
        _wheatUI._uiHPtext.text = _maxHP._maxHealth.ToString("F1");
        _HPbar.fillAmount = 1f;

        _wVector.x += 4f;
        _wVector.y = -0.3f;
        WarriorAttack warrior = Instantiate(_warrior);
        warrior.transform.position = _wVector;
        return warrior;
    }
}
