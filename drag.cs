using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    private float speed = 3;
    private GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed);
    }

    private void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.tag == "player")
        {
            Destroy(this.gameObject);
           
            

            

        }
        else if (other.gameObject.tag == "ground")
        {

            Destroy(this.gameObject);
            


            
        }

        

    }

}
