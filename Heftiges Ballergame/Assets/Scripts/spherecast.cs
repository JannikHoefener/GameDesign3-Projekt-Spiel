using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spherecast : MonoBehaviour
{
    public GameObject current; 
    public float radius;
    public float maxDistance;
    public LayerMask layerMask;

    private Vector3 origin;
    private Vector3 direction;
    private float currentDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;
        if(Physics.SphereCast(origin, radius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            current = hit.transform.gameObject;
            currentDistance = hit.distance;
        }
        else
        {
            current = null;
        }
    }
}
