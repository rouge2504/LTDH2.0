using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private AIDestinationSetter AI_DestinationSetter;
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
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            pointer.transform.position = worldPosition;
            AI_DestinationSetter.target = pointer.transform;


            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
               
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }

    void OnMouseDown()
    {
        /*var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            AI_DestinationSetter.target = hit.collider.gameObject.transform;
            Debug.Log(hit.collider.gameObject.name);
        }*/

        Vector3 mousePos = Input.mousePosition;
        print("Apretando");
        pointer.transform.position = mousePos;
        AI_DestinationSetter.target = pointer.transform;
    }
    
}
