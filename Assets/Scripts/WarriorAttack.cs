using UnityEngine;

public class WarriorAttack : MonoBehaviour
{
    private Animator _attack;
    public float _health = 100f;
    [SerializeField] private float _damage = 30f;
    [SerializeField] private float _seconds = 3f;

    public float _currentTime;
    public float _timer;

    private Enemy _currentTargetEnemy;

    void Start()
    {
        _currentTime = _seconds;
        _timer = 0f; // Воин готов к бою сразу
        _attack = GetComponent<Animator>();
    }

    void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }

        // Воин бьет врага независимо в Update
        if (_currentTargetEnemy != null && _timer <= 0)
        {
            Attack(_currentTargetEnemy);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy currentEnemy = other.GetComponent<Enemy>();
            if (currentEnemy != null && currentEnemy._enemyHealth > 0)
            {
                _currentTargetEnemy = currentEnemy;
                if (_attack != null) _attack.SetBool("isAttack", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _currentTargetEnemy = null;
            if (_attack != null) _attack.SetBool("isAttack", false);
        }
    }

    void Attack(Enemy currentEnemy)
    {
        if (currentEnemy._enemyHealth > 0)
        {
            currentEnemy._enemyHealth -= _damage;
            Debug.Log($"⚔️ Воин ударил! У врага осталось: {currentEnemy._enemyHealth}");

            _timer = _currentTime;

            if (currentEnemy._enemyHealth <= 0f)
            {
                Debug.Log("💀 Враг умер, удаляем со сцены.");
                currentEnemy.Die();
                _currentTargetEnemy = null;
                if (_attack != null) _attack.SetBool("isAttack", false);
            }
        }
        else
        {
            _currentTargetEnemy = null;
        }
    }

    public void Die()
    {
        Debug.Log("Воин умер.");

        GameManager gameManager = Object.FindFirstObjectByType<GameManager>();
        if (gameManager != null)
        {
            gameManager.RemoveWarriorFromList(this);
        }

        Destroy(gameObject, 0.5f);
    }
}
