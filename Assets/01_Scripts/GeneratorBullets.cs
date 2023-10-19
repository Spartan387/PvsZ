using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBullets : MonoBehaviour
{
    public float frequencyTrigger;
    public GameObject bulletPrefab;
    GameObject fatherBullets;
    bool ObjectiveDistance = true;
    

    // Start is called before the first frame update
    void Start()
    {
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Awake()
    {
        fatherBullets = GameObject.Find("Bullets");
    }
    void Shoot() 
    { 
        if (ObjectiveDistance) 
        {
            GameObject bulletTemp = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletTemp.transform.parent = fatherBullets.transform;
            bulletTemp.GetComponent<Bullet>().direction = transform.forward;
        }
        Invoke("Shoot", frequencyTrigger);
    }
}
