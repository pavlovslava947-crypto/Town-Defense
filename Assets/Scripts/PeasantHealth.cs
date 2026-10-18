using UnityEngine;

public class PeasantHealth : MonoBehaviour
{
    public float _health = 30;
    
   
    void Update()
    {
        if( _health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
