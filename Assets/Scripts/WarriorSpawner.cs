using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class WarriorSpawner : MonoBehaviour
{
    [SerializeField] private WarriorAttack _warrior;
    [SerializeField] private HungrySystem _hungrySystem;
    [SerializeField] private Button _feedButton;
    public int _warriorCount = 0;

    private Vector2 _wVector = new Vector2(-13.17f, -0.3f);

   
    public WarriorAttack Spawn()
    {
      
        if(_warriorCount < 4)
        {
            _wVector.x += 5f;
            _wVector.y = -0.3f;
            _warriorCount++;
            WarriorAttack warrior = Instantiate(_warrior);
            warrior.transform.position = _wVector;
            warrior._health = 100f;
            warrior._timer = 0f;

            _feedButton.onClick.RemoveAllListeners();

            _feedButton.onClick.AddListener(warrior.GetComponent<HungrySystem>().WellFedWarrior);
            return warrior;
        }

  

        return _warrior;
        
    }
}
