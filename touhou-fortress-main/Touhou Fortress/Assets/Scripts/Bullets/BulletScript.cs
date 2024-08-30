using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public byte damageVal;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "BoundaryBox")
        {
            Destroy(this.gameObject);
        }
    }
}
