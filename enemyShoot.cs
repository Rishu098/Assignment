using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    public Transform player;
    public float playerDistance;
    public float rotationDamping;
    public Rigidbody sphere;
    public Transform point;
    private float speed = 1f;
    public float fireRate = 3f;
    public float nextFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(player.position, transform.position);

       if (playerDistance < 100f  && Time.time>nextFire){

            nextFire = Time.time + fireRate;
            lookAtPlayer();
            attack();
            
        }

       // if (playerDistance < 20f)
             //   attack();
        


    }

    void lookAtPlayer() {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation,Time.deltaTime*rotationDamping);

    }

    void attack() {
        Rigidbody rb = Instantiate(sphere, point.position, Quaternion.identity);
        rb.velocity = new Vector3(0,0,50f);
       // rb.(0, 0, speed);
    }

    IEnumerator Destruction() {
        yield return new WaitForSeconds(5f);
    }
}
