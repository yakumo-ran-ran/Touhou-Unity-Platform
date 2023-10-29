using UnityEngine;

public class Attack : MonoBehaviour
{
    AnimatorController ac;
    public Transform attackPoint;
    public float attackRange=0.5f;
    public LayerMask enemyLayers;
    public int attackDamage=40;
    [SerializeField]float attackCooldown = 1f;
    float attackTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        ac=GetComponent<AnimatorController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer-=Time.deltaTime;
        }
        if(Input.GetMouseButton(0)&&attackTimer<=0)
        {
            Atk();
            attackTimer=attackCooldown;
        }
    }
    void Atk()
    {
        ac.animator.SetTrigger("Attack");
        Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(attackPoint.position, attackRange,enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakenDamage(attackDamage);
        }
        AudioManager.instance.Play("Attack");
        
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
