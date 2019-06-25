using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    public Vector3 destination;

    private Vector3 clickPos;

    private NavMeshAgent agent;
    
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButton(0))
        {
            //fire a ray
            RaycastHit hit;
            //see if it hit anything
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                clickPos = hit.point;
                //try to move to that position
                agent.destination = clickPos;
            }
           
        }
    }
}
