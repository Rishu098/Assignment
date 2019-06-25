using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour

{
    public Transform player;
    public float playerDistance;
    public float rotationDamping;
     Animator anim;
    public float maxHealth = 100f;
    public float damage = 50f;
    private GameObject go;
    public GameObject drop;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
      //  anim.SetBool("onDestroy", false);

    }

    // Update is called once per frame
    void Update()
    {

        playerDistance = Vector3.Distance(player.position, transform.position);

        if (playerDistance < 100f)
        {

            lookAtPlayer();

        }
    }


    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }



    private void OnTriggerEnter(Collider other)
    {
        //score mark = other.gameObject.GetComponent<score>();
        if (other.tag == "bullet")
        {
            maxHealth = maxHealth - damage;
            if (maxHealth > 0)
            {
              anim.SetBool("onDestroy", true);
            }
            else if(maxHealth<=0){
                anim.SetBool("onDeath", true);
               Destroy(this.gameObject,1f);
                Instantiate(drop, transform.position, Quaternion.identity);
            }
        }
        
    }
}
