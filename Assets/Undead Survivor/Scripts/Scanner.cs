using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange = 8.0f;

    private RaycastHit2D[] targets;

    public Transform nearestTransform;

    public LayerMask targetLayer;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero,0,targetLayer);
        nearestTransform = GetNearest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Transform GetNearest()
    {
        float minDistance = 100f;
        Transform result = new RectTransform();
        foreach (RaycastHit2D t in targets)
        {
            Vector3 myPosition = transform.position;
            Vector3 targetPosition = t.transform.position;
            float distance = Vector3.Distance(myPosition, targetPosition);
            if (distance < minDistance)
            {
                minDistance = distance;
                result = t.transform;
            }
        }

        return result;
    }
}