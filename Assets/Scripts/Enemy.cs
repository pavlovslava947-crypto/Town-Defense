using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] WheatUI _wheatUI;
    [SerializeField] GameManager _gameManager;
    [SerializeField] private float _damage = 2.5f;
    [SerializeField] private float _enemySpeed = 2.5f;
    [SerializeField] private float _timer = 3f;

    private float _currentTime;
    private WarriorAttack _targetWarrior; // Храним ссылку на воина, которого бьем

    public Animator _enemyAnim;
    public Vector2 _move;
    public float _enemyHealth = 100f;

    void Start()
    {
        _currentTime = _timer;
        _timer = 0f; // Начинаем с 0, чтобы враг мог ударить сразу при встрече
        _enemyAnim = GetComponent<Animator>();
        _move = Vector2.zero;
        _enemyAnim.SetBool("isWalk", false);
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        // 1. Таймер перезарядки тикает всегда
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }

        // 2. Логика движения и атаки
        if (_targetWarrior != null)
        {
            // Если перед нами живой воин — останавливаемся и бьем его
            _move.x = 0f;

            if (_timer <= 0)
            {
                PerformAttack();
            }
        }
        else
        {
            // Если воина перед нами нет — продолжаем идти влево
            _move.x = -1f;
            _enemyAnim.SetBool("isWalk", false); // Включаем анимацию ходьбы
            gameObject.transform.Translate(_move * Time.deltaTime * _enemySpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Этот лог сработает ОДИН РАЗ, когда кто-то прикоснется к врагу
        Debug.LogWarning($"[ФИЗИКА ВРАГА]: В меня врезался объект: {other.gameObject.name} с тегом: {other.tag}");
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        // Враг определяет воина по тегу (убедитесь, что у Воина стоит тег "Player")
        if (other.CompareTag("Warrior"))
        {
            WarriorAttack warrior = other.GetComponentInParent<WarriorAttack>();
            _enemyAnim.SetBool("isWalk", true); // Включаем анимацию ходьбы
            if (warrior != null && warrior._health > 0)
            {
                _targetWarrior = warrior;
            }
            else
            {
                Debug.LogError($"[ОШИБКА]: На объекте {other.gameObject.name} не найден скрипт WarriorAttack!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Warrior"))
        {
            _targetWarrior = null;
        }
    }

    void PerformAttack()
    {
        if (_targetWarrior != null && _targetWarrior._health > 0)
        {
            if (_enemyAnim != null) _enemyAnim.SetBool("isWalk", false); // Например, выключаем ходьбу/включаем атаку

            _targetWarrior._health -= _damage;
            Debug.Log($"💥 Враг нанес урона объекту: {_targetWarrior.gameObject.name}. Осталось HP: {_targetWarrior._health}");

            _timer = _currentTime; // Сброс таймера перезарядки

            if (_targetWarrior._health <= 0)
            {
                _targetWarrior.Die();
                _targetWarrior = null;
            }
        }
        else
        {
            _targetWarrior = null;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
