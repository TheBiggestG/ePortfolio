using UnityEngine;

public class ScoutChase : MonoBehaviour
{
    [SerializeField]
    private Behaviour scriptShootRef;
    [SerializeField]
    private ScoutBehavior scriptBehaviorRef;
    [SerializeField]
    private Behaviour scriptPlayerMovementRef;
    //Update is called once per frame
    private void Start()
    {
        enabled = false;
    }
    void Update()
    {
        Vector3 direction = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;

        transform.position += direction.normalized * 10 * Time.deltaTime;

    }
}
