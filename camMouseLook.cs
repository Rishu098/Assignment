using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMouseLook : MonoBehaviour
{
   // Vector2 mouseLook;
    //Vector2 smoothV;
    //public float sensitivity = 5f;
    //public float smoothing = 2f;
   

    GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal")>0)
            transform.Rotate(0, 5, 0);
        if (Input.GetAxis("Horizontal") <0)
            transform.Rotate(0, -5, 0);


        //transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        // transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);
        // transform.localRotation = Quaternion.AngleAxis(10, Vector3.right);
        //character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
        // character.transform.Rotate(0, mouseLook.x, 0);
        //character.transform.localPosition = new Vector2(mouseLook.y, character.transform.up);
    }

   
}
