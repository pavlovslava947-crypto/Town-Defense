using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    private Vector2 _enemyPos = new Vector2(20.12f , -0.57f);
   
    public Enemy Spawn()
    {
        Enemy enemy = Instantiate(_enemy);
        enemy.transform.position = _enemyPos;
        return enemy;
    }
    
}
