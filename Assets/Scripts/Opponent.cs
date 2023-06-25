using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    public  NavMeshAgent OpponentAgent;
    public GameObject Target;
    Vector3 OpponentStartPos;
    public GameObject SpeedBosterIcon;

    void Start()
    {
        OpponentAgent = GetComponent<NavMeshAgent>();
        OpponentStartPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

    }


    void Update()
    {
        OpponentAgent.SetDestination(Target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = OpponentStartPos;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("speedboost"))
        {
            OpponentAgent.speed = OpponentAgent.speed + 3f;
            SpeedBosterIcon.SetActive(true);
            StartCoroutine(SlowAfterAWhileCoroutine());

        }
        
    }

    private IEnumerator SlowAfterAWhileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        OpponentAgent.speed = OpponentAgent.speed - 3f;
        SpeedBosterIcon.SetActive(false);


    }


}
