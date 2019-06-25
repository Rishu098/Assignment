using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calculate : MonoBehaviour
{
    private GameObject go;
   // private float hit=0;
   // private float miss=0;
   // private bool ishit = false;
    //public Text hitText;
   //public Text missText;
  // public score mark;
    public bool damage = false;

    //public score mark;

    // Start is called before the first frame update
    void Start()
    {
        //score mark = gameObject.GetComponent<score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnCollisionEnter(Collision other)
    {
       //score mark = other.gameObject.GetComponent<score>();
        if (other.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
      //      mark.ishit();

            //score mark = other.gameObject.GetComponent<score>();


             damage = true;

        }
        else if (other.gameObject.tag == "ground")
        {
            
            Destroy(this.gameObject);
        //    mark.ismiss();


            //Debug.Log("hit" + hit);
             damage = false;
        }

        
        //ishit = false;

     }
}
