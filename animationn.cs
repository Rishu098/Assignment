using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationn : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void perform() {
        anim.SetBool("fdd", true);
    }
    public void unperform() {
        anim.SetBool("fdd", false);
    }
}
