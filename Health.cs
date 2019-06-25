using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float damage = 50;
    public float maxHealth = 100;
    public GameObject fire;
    public Transform fpoint;
   public AudioSource musicSource;
    public AudioClip musicClip;

    private GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        // audioo =  GetComponent<AudioSource>();
        musicSource.clip = musicClip;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    
     {

        if (other.tag == "bullet") {
          maxHealth = maxHealth - damage;
            Debug.Log("max" + maxHealth);
           // GameObject fie = Instantiate(fire, fpoint.position, Quaternion.identity);
            // Instantiate(fire, fpoint.position, Quaternion.identity);



        }
        
     if (maxHealth <= 0) {
        Destroy(this.gameObject);
       GameObject fie   =  Instantiate(fire, fpoint.position, fpoint.rotation);
            // GetComponent<AudioSource>().Play();
            // audioo.Play();
            musicSource.Play();
            Destroy(fie.gameObject, 5);
           // Debug.Log("max" + maxHealth);

        }
     }

    /// / private void OnCollisionEnter(Collision collision)
    // {
    //   if (collision.gameObject.tag == "bullet")
    //  {

    //  if (other.tag == "bullet")

    //      maxHealth = maxHealth - damage;
    //  }
    //  if (maxHealth <= 0)
    //  {
    //      Destroy(gameObject);

    //  }
    //   }
}
