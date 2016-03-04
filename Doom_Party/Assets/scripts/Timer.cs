using UnityEngine;
using System;

// Special thanks to Chris Cameron, who made a more complicated version of this for another project, albeit with some help from yours truly.
// - Alex

[Serializable]
public class Timer
{
	[SerializeField] private float m_MaxTime;
	private float m_StartTime;
	
	public float maxTime { get { return m_MaxTime; } set { m_MaxTime = value; } }
	public float elapsed { get { return Time.time - m_StartTime; } }
	public float elapsedAsPercentage { get { return elapsed / m_MaxTime; } }
	public float remaining { get { return m_MaxTime - elapsed; } }
	public float overtime { get { return elapsed - m_MaxTime; } }
	
	public bool complete { get { return elapsed >= m_MaxTime; } }
	
	public void Reset()
	{
		m_StartTime = Time.time;
	}
	
	public void AddSeconds(float seconds)
	{
		m_StartTime += seconds;
	}
	
	public void End()
	{
		if (!complete)
			m_StartTime = Time.time - m_MaxTime;
	}
}
