using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(5, 20)]
    public float speedBullet = 20;
    public int damage; 

    Rigidbody rb;
    [HideInInspector]
    public Vector3 direction;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 3.0f);
        Invoke("RecoveryGravity", 0.7f);
        rb.AddRelativeForce(direction * speedBullet, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Destroy();
            col.GetComponent<Enemy>().SubtractLife(damage);
        }   
    }
    void RecoveryGravity() 
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}
