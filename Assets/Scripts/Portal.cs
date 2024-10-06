using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    Transform warpPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        float y = other.transform.position.y;
        other.transform.position = new Vector3(warpPoint.position.x, y, warpPoint.position.z);
    }
}
