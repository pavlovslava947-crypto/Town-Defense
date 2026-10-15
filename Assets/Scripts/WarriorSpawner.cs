using UnityEngine;

public class WarriorSpawner : MonoBehaviour
{
    [SerializeField] private WarriorAttack _warrior;
    private Vector2 _wVector = new Vector2(2.65f , -0.3f);
    public WarriorAttack Spawn()
    {
        _wVector.x += 1f;
        _wVector.y = -0.3f;
        WarriorAttack warrior = Instantiate(_warrior);
        warrior.transform.position = _wVector;
        return warrior;
    }
}
