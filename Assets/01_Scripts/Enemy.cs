using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private int targetIndex = 1;
    public float moveSpeed = 2;
    public int LifeInitial = 0;
    public int LifeActual = 0;

    // Start is called before the first frame update
    void Start()
    {
        LifeActual= LifeInitial;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        LookAt();
    }
    void Movement() 
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetIndex].position, moveSpeed * Time.deltaTime);
        var distance = Vector3.Distance(transform.position, waypoints[targetIndex].position);
        if (distance < 0.1f)
        {
            if (targetIndex >= waypoints.Count-1)
            {
                return;
            }
            targetIndex++;
        }
    }
    private void LookAt()
    {
        transform.LookAt(waypoints[targetIndex]);
    }

    public void SubtractLife(int damage)
    {
        LifeActual = LifeActual - damage;
        if (LifeActual <= 0)
        {
            Destroy();
        }
    }

    void Destroy() 
    {
        Destroy(gameObject);
    }
}
