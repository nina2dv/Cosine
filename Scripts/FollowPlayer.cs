using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject PlayerObj;
    float smoothTime = 0.3f;
    Vector3 velocity = Vector3.zero;
    public int yOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayerObj();
    }
    
    void FollowPlayerObj()
    {
        Vector3 targetPosition = PlayerObj.transform.TransformPoint(new Vector3(3, yOffset, -10));
        targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
