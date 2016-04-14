using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public enum AIMode { ATTACK, IDLE }

	public EnemySpawner parentSpawner;
	
	[SerializeField] private int m_HP = 6; // Might want to move to a separate component?
	
    public AudioClip damageClip;
    Vector3 input_movement;
    Vector3 input_rotation;
    Vector3 target_direction;
    float movement_speed = 0.5f;

    void Update()
    {
        //Code to run on update
        GameObject target = Get_Closest_Player(transform.position);
        float target_distance;
        if (target == null)
        {
            input_movement = Vector3.zero;
            input_rotation = transform.forward * -1;
            return;
        }
        //Targets distance allows me to do some different movement based on how close the enemy is to the player
        //such as move away if they get too close
        target_distance = Vector3.Distance(transform.position, target.transform.position);
        //Find the direction to the target based on the targets position to mine
        target_direction = target.transform.position - transform.position;
        //Inherited variable for firing direction, used for the projectile script
        input_rotation = target_direction;
        //Here I actually set the AI state, but this line below will move the object that this script is on towards the player
        transform.position += target_direction * movement_speed * Time.deltaTime;
    }

    private GameObject Get_Closest_Player(Vector3 enemy_location)
    {
        GameObject closest_player = null;
        float closest_player_distance = Mathf.Infinity;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            float temp_distance = Vector3.Distance(enemy_location, player.transform.position);
            if (temp_distance < closest_player_distance)
            {
                closest_player = player;
                closest_player_distance = temp_distance;
            }
        }
        return closest_player;
    }

    public void damage(int damage)
	{
		m_HP -= damage;
        GetComponent<AudioSource>().clip = damageClip;
        GetComponent<AudioSource>().Play();
		if (m_HP <= 0)
		{
			if (parentSpawner)
				parentSpawner.TakeDamage(1);
			Destroy(gameObject);
		}
    }
}