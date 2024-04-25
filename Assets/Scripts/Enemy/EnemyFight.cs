using UnityEngine;

public class EnemyFight : MonoBehaviour
{
    Animator anim;
    public int damage = 5;
    public Transform player;
    public Transform pointAttack;

    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public float attackRate = 2f;   

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pointAttack = transform.GetChild(0);
    }
    private void Update()
    {
        Collider2D hitEnemies = Physics2D.OverlapCircle(pointAttack.position, attackRange, enemyLayer);
        if (hitEnemies != null)
        {
            anim.SetBool("attack", true);
            hitEnemies.GetComponent<PlayerHealth>().TakeDamade(damage * Time.deltaTime);
        }
        else 
        {
            anim.SetBool("attack", false);
        }
    }
}
