using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float distance;
    public int rank;
    public GameObject target;

    void Update()
    {
        CalculateDistance();
    }

    void CalculateDistance()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
    }
}
