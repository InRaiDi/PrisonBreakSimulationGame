using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;

	[HideInInspector]
	public float speed;

	public float startHealth = 100;
	public float health;

	public int worth = 50;

	public GameObject deathEffect;

	[Header("Unity Stuff")]
	public Image healthBar;
	public NavMeshAgent navMeshAgent;
	public bool isDead = false;

	void Start ()
	{
		navMeshAgent = this.GetComponent<NavMeshAgent>();
        switch (SceneManager.GetActiveScene().name)
        {
			case "Level01":
				startHealth = 100;
				navMeshAgent.speed = 1;
				break;
			case "Level02":
				startHealth = 150;
				navMeshAgent.speed = 1;
				break;
			case "Level03":
				startHealth = 200;
				navMeshAgent.speed = 1.5f;
				break;
		}
		speed = startSpeed;
		health = startHealth;
	}

	public void TakeDamage (float amount)
	{
		health -= amount;

		healthBar.fillAmount = health / startHealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	public void Slow (float pct)
	{
		speed = startSpeed * (1f - pct);
	}

	void Die ()
	{
		isDead = true;

		PlayerStats.Money += worth;

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

		WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}

	void EndPath()
	{
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
			case "END":
				EndPath();
				break;
        }
    }
}
