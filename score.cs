using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour
{
    public float hit = 0;
    public float miss = 0;
    public Text hitText;
   public Text missText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ishit() {
        hit = hit + 1;
       // hitText.text = hit.ToString();
        Debug.Log("hit"+hit);

    }
    public void ismiss()
    {
        miss = miss + 1;
       // hitText.text = miss.ToString();
        Debug.Log("miss" + miss);

    }

}
