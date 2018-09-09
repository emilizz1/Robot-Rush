using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    
	void Start ()
    {
        StartCoroutine(FollowPath());
	}
	
	void Update ()
    {
		
	}

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
