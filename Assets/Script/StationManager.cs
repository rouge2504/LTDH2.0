using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationManager : MonoBehaviour
{
    private GameObject player;
    private float distance;

    [SerializeField] private float timeToMakeFood = 5;
    [SerializeField] private float timingToMakeFood;
    private bool makingFood;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(GameConstant.PLAYER);
    }

    // Update is called once per frame
    void Update()
    {
        UseStation();
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        MakeFood();
    }

    private void MakeFood()
    {
        if (makingFood && distance < GameConstant.MAX_DISTANCE_OBSTACLE)
        {
            timingToMakeFood += Time.deltaTime;
            if (timingToMakeFood > timeToMakeFood)
            {
                makingFood = false;
                timingToMakeFood = 0;
            }
        }
    }

    private void UseStation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 200, LayerMask.GetMask(GameConstant.STATION));

            if (hit.collider != null)
            {
                if (distance < GameConstant.MAX_DISTANCE_OBSTACLE)
                {
                    player.GetComponent<AIPath>().canMove = false;
                    makingFood = true;
                    return;
                }
                PlayerManager.instance.AI_DestinationSetter.target = this.transform;
                Debug.Log(hit.collider.gameObject.name);
            }
        }
        
    }
}
