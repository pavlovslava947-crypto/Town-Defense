using UnityEngine;

public class WarriorAttack : MonoBehaviour
{
    [SerializeField] Animator _attack;
    public float _health = 100f;
    [SerializeField] private float _damage = 30f;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _seconds = 3f;
    private float _currentTime;
    public float _timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentTime = _seconds;
        _timer = _seconds;
        _attack = GetComponent<Animator>();
        _attack.SetBool("isAttack" , false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_timer  > 0)
        {
            _timer -= Time.deltaTime;
            
        }
       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            _attack.SetBool("isAttack" , true);

            _enemy._enemyAnim.SetBool("isWalk" , true);

            _enemy._move.x += 0f;

            _enemy.EnemyAttack();
            Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _attack.SetBool("isAttack", false);
    }

    void Attack()
    {
        

        if(_timer <= 0)
        {
            
            _enemy._enemyHealth -= _damage;
            _timer = _currentTime;
            Debug.Log(_enemy._enemyHealth);
        }

        if(_enemy._enemyHealth <= 0f)
        {
            Debug.Log("die");
            _enemy.Die();
        }
        
    }

    public void Die()
    {
        Destroy(gameObject, 0.5f);
    }
}
