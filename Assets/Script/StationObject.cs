using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationObject : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    public delegate void DidFinishedAction();
    private void Update()
    {
        
    }
    virtual public Transform MoveToThisStation(Transform player, DidFinishedAction callback = null)
    {
        float distance = 0;
        float tempDistance = 100;
        int temp_it = 0;
        for(int i = 0; i < points.Length; i++)
        {
            if (!points[i].gameObject.activeSelf)
            {
                continue;
            }
            distance = Vector3.Distance(player.position, points[i].position);
            if (distance < tempDistance)
            {
                tempDistance = distance;
                temp_it = i;
            }
        }
        Debug.Log("Move To: " + points[temp_it].name);
        return points[temp_it];
    }
}
