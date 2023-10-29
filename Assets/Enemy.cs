using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakenDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        AudioManager.instance.Play("Hurt");
        if (currentHealth < 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("EnemyDie");
        animator.SetBool("isDead", true);
        this.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject);
    }
}
