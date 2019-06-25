using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickup : MonoBehaviour
{
    private GameObject go;
    private int count = 0;
    public Text t;
    // Start is called before the first frame update
    void Start()
    {
        t.text = "count" + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Destroy(this.gameObject);
        count = count + 1;
        t.text = "count" + count.ToString();

        //   Debug.Log(count);
    }
}
