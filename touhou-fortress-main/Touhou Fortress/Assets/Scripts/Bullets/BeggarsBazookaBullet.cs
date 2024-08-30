using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeggarsBazookaBullet : MonoBehaviour
{
    public float speed;
    public byte damageVal;
    protected System.Random rand = new System.Random();
    private int randomization;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        }
        randomization = rand.Next(-10, 10);
        transform.Rotate(Vector3.up * randomization);
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
