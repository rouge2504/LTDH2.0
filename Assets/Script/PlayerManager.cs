using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector] public AIDestinationSetter AI_DestinationSetter;
    [SerializeField] private GameObject pointer;
    // Start is called before the first frame update
    void Start()
    {
        AI_DestinationSetter = this.GetComponent<AIDestinationSetter>();
        AI_DestinationSetter.target = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            pointer.transform.position = worldPosition;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 200, LayerMask.GetMask(GameConstant.OBSTACLE));

            if (hit.collider != null)
            {
                AI_DestinationSetter.target = this.transform;
                return;
            }
            AI_DestinationSetter.target = pointer.transform;
        }

    }

}
