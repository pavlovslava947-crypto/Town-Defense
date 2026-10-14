using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private WarriorAttack _warrior;
    [SerializeField] private float _damamge = 2.5f;
    [SerializeField] private Animator _enemyAnim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
