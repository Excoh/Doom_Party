using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public enum AIMode { ATTACK, IDLE }

	public EnemySpawner parentSpawner;

	public int startingHP = 6;
	private int currentHP;
	
    public AudioClip damageClip;
    Vector3 input_movement;
    Vector3 input_rotation;
    Vector3 target_direction;
    public float movement_speed = 0.75f;

	public int scoreToGive = 1;

	public Animator animationController;

	private void Start()
	{
		currentHP = startingHP;
    }

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
        target_direction = (target.transform.position - transform.position).normalized;
        //Inherited variable for firing direction, used for the projectile script
        input_rotation = target_direction;
        //Here I actually set the AI state, but this line below will move the object that this script is on towards the player
        transform.position += target_direction * movement_speed * Time.deltaTime;

		if (target_direction.y <= 0)
		{
			animationController.SetBool("FacingForwards", true);
		}
		else
		{
			animationController.SetBool("FacingForwards", false);
		}
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

    public void damage(int damage, int playerNum)
	{
		currentHP -= damage;
        GetComponent<AudioSource>().clip = damageClip;
        GetComponent<AudioSource>().Play();
		if (currentHP <= 0)
		{
			if (parentSpawner)
				parentSpawner.TakeDamage(1);

			string playerName = "Player" + playerNum;
			GameObject.Find(playerName).GetComponent<ScoreHandler>().AddScore(scoreToGive);

			Destroy(gameObject);
		}
    }
}