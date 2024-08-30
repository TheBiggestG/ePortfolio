using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectHitBazooka : MonoBehaviour
{
    public float speed;
    public byte damageVal;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        }
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
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
