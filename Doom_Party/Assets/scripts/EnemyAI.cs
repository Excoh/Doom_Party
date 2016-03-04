using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public enum AIMode { ATTACK, IDLE }
	
	public static PlayerMovement[] s_Players = new PlayerMovement[4]; // Temporary solution until we figure out how players are represented.
	
	[SerializeField] private float m_Speed;
	[SerializeField] private float m_TurningRadius;
	[SerializeField] private int m_HP = 6; // Might want to move to a separate component?
	[SerializeField] private float m_Range;
	[SerializeField] private float m_CloseRange;
	[SerializeField] private float m_AimingLeewayRadians = 0.1f;
	[SerializeField] private float m_TargetReachingLeeway;
	[SerializeField] private float m_WanderRadius;
	[SerializeField] private Timer m_WanderTimer;
	
	private AIMode m_AIMode = AIMode.IDLE;
	
	public PlayerMovement[] players { get { return s_Players; } }
	private float[] m_ThreatValues = null;
	private bool[] m_IsInRange = null;
	private Vector2 m_CurrentTarget;
	private Vector2 m_StartingPosition;
	
	private float m_Direction; // Measured in radians.
	
	public Vector2 velocity { get { return new Vector2(m_Speed * Mathf.Cos(m_Direction), m_Speed * Mathf.Sin(m_Direction)); } }
	
	public void OnEnable()
	{
		m_StartingPosition = transform.position;
		m_ThreatValues = new float[players.Length];
		m_IsInRange = new bool[players.Length];
		m_WanderTimer.Reset();
		m_WanderTimer.End();
	}
	
	public void Update()
	{
		TrackThreats();
		HandleMovement();
	}
	
	private void TrackThreats()
	{
		// Increase or reset the threat values of individual players.
		for (int i = 0; i < players.Length; i++)
			if (players[i] != null)
			{
				float distanceToPlayer = Vector2.Distance(transform.position, players[i].transform.position);
				if (m_AIMode == AIMode.IDLE && distanceToPlayer <= m_Range)
					m_ThreatValues[i] += 10.0f;
				if (!m_IsInRange[i] && distanceToPlayer <= m_Range)
				{
					m_IsInRange[i] = true;
					m_ThreatValues[i] += 10.0f;
				}
				if (distanceToPlayer <= m_CloseRange)
					m_ThreatValues[i] += 10.0f * Time.deltaTime;
				if (m_IsInRange[i] && distanceToPlayer > m_Range)
				{
					m_IsInRange[i] = false;
					m_ThreatValues[i] = 0.0f;
				}
				// if players[i] is dead
				// m_ThreatValues[i] = 0;
			}
		
		// Determine if this enemy should be idle, and which player (if any) is its current target.
		float maxThreat = 0.0f;
		m_AIMode = AIMode.IDLE;
		for (int i = 0; i < players.Length; i++)
		{
			if (m_ThreatValues[i] > 0.0f)
				m_AIMode = AIMode.ATTACK;
			
			if (m_ThreatValues[i] > maxThreat)
			{
				m_CurrentTarget = players[i].transform.position;
				maxThreat = m_ThreatValues[i];
			}
		}
		if (m_AIMode == AIMode.IDLE)
			Wander();
	}
	
	private void HandleMovement()
	{
		// Turn towards the target.
		Vector2 vectorToTarget = m_CurrentTarget - (Vector2)transform.position;
		float angleToTarget = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x);
		float deltaAngleToTarget = angleToTarget - m_Direction;
		if (deltaAngleToTarget < 0.0f){ deltaAngleToTarget += 2.0f * Mathf.PI;}
		///
		// If delta < pi, turn clockwise. If delta > pi, turn counterclockwise.
		if (deltaAngleToTarget > m_AimingLeewayRadians && deltaAngleToTarget < Mathf.PI)
			m_Direction += m_Speed / m_TurningRadius * Time.deltaTime;
		else if (deltaAngleToTarget >= Mathf.PI && deltaAngleToTarget < (2.0f*Mathf.PI) - m_AimingLeewayRadians)
			m_Direction -= m_Speed / m_TurningRadius * Time.deltaTime;
		
		float distanceToTarget = Vector2.Distance(m_CurrentTarget, transform.position);
		if (distanceToTarget > m_TargetReachingLeeway)
		{
			transform.position = (Vector2)transform.position + velocity * Time.deltaTime;
		}
	}
	
	private void Wander()
	{
		if (m_WanderTimer.complete)
		{
			m_WanderTimer.Reset();
			m_CurrentTarget = m_StartingPosition + Random.insideUnitCircle * m_WanderRadius;
		}
	}
}