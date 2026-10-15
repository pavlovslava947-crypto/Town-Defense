using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private WarriorAttack _warrior;
    [SerializeField] WheatUI _wheatUI;
    [SerializeField] private float _damage = 2.5f;
    [SerializeField] private float _enemySpeed = 2.5f;
    public Animator _enemyAnim;
    public Vector2 _move;
    public float _enemyHealth = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemyAnim = GetComponent<Animator>();
        _move = Vector2.zero;
        _enemyAnim.SetBool("isWalk" , false);
    }

    // Update is called once per frame
    void Update()
    {
        _move.x = -1f;
        gameObject.transform.Translate(_move * Time.deltaTime * _enemySpeed);
    }

    public void EnemyAttack()
    {
        if (_warrior._timer <= 0)
        {
            _warrior._health -= _damage;

            _wheatUI.UpdateUI();
        }

        if(_warrior._health <= 0)
        {
           _warrior.Die();
        }
            
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    
}
