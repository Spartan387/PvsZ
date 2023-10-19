using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCanyon : MonoBehaviour
{
    public Transform Enemy;

    private void Awake()
    {
        Enemy = GameObject.Find("Enemy").transform;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Enemy);
    }
}
