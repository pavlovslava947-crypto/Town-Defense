using UnityEngine;

public class WarriorAttack : MonoBehaviour
{
    [SerializeField] Animator _attack;
    [SerializeField] private float _health = 100f;
    [SerializeField] private float _damage = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _attack = GetComponent<Animator>();
        _attack.SetBool("isAttack" , false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            _attack.SetBool("isAttack" , true);


            Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _attack.SetBool("isAttack", false);
    }

    void Attack()
    {

    }
}
