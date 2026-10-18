using UnityEngine;
using UnityEngine.UI;

public class WarriorSpawner : MonoBehaviour
{
    [SerializeField] private WarriorAttack _warrior;

    private Vector2 _wVector = new Vector2(0f , -0.3f);
    public WarriorAttack Spawn()
    {

        _wVector.x += 4f;
        _wVector.y = -0.3f;
        WarriorAttack warrior = Instantiate(_warrior);
        warrior.transform.position = _wVector;
        warrior._health = 100f;
        warrior._timer = 0f;
        return warrior;
    }
}
