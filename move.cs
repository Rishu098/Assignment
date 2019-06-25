using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Quaternion playerRot;
    float rotSpeed = 5;
    bool moving = false;
    bool fix = false;
    public float speed = 10f;
    public Rigidbody bullet;
    public GameObject cursor;
    public LayerMask layer;
    private Camera cam;
    public Transform shootpoint;
    private float fireRate = 2f;
    private float nextFire = 0f;
    private float coolDown = 5f;
    private float nextFix = 0f;
    public calculate dam;
    public float hitt = 0;
    public float miss=0;
    // Animator anim;
   public animationn a;
     public AudioSource musicSource;
    public AudioClip musicClip;
    private int count = 0;
    public Text t;
    public Text hit1;
    //  public float count = 0;



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        // anim = GetComponent<Animator>();
        // audio =  GetComponent<AudioSource>();
        musicSource.clip = musicClip;
        t.text = "coins    " + count.ToString();
        hit1.text ="miss    " + count.ToString();



    }

    // Update is called once per frame
    void Update()
    {
       // a.unperform();
        //LaunchProjectile();


        if (Input.GetKeyDown(KeyCode.L) && Time.time > nextFix) { 

            nextFix = Time.time + nextFix;
            fix = !fix;
        }
            if (Input.GetMouseButton(0))
            {
                SetTargetPosition();
           }
        if (moving && !fix)
        {
            Move();
        }
        if (fix)
        {
            
            LaunchProjectile();
            //a.unperform();
        }

    }
    void SetTargetPosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            targetPosition = hit.point;
            lookAtTarget = new Vector3(targetPosition.x - transform.position.x,
                transform.position.y,
                targetPosition.z - transform.position.z);
            playerRot = Quaternion.LookRotation(lookAtTarget);
          //  transform.rotation = Quaternion.Slerp(transform.rotation,
           //playerRot, rotSpeed * Time.deltaTime);
          //transform.rotation = Quaternion.LookRotation(Vo);
        moving = true;
        }
    }

    void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
           playerRot, rotSpeed * Time.deltaTime);
       
         transform.position = Vector3.MoveTowards(transform.position,
           targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
        moving = false;
    }
    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;
        return result;


    }
    void LaunchProjectile()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(camRay, out hit, 800f, layer))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;

            Vector3 Vo = CalculateVelocity(hit.point, shootpoint.position, 1f);
            // transform.rotation = Quaternion.LookRotation(Vo);
            transform.rotation = Quaternion.Slerp(transform.rotation,
             playerRot, rotSpeed * Time.deltaTime);

            if (Input.GetMouseButtonDown(0) && Vector3.Distance(hit.point+Vector3.up*0.1f,transform.position)>100 && Time.time>nextFire)
                
            {

                a.perform();
                StartCoroutine("example");
                nextFire = Time.time + fireRate;
                Rigidbody obj = Instantiate(bullet, shootpoint.position, Quaternion.identity);
                obj.velocity = Vo;
                //  audio = GetComponent<AudioSource>();
                musicSource.Play();

                if (dam.damage)
                {
                 hitt = hitt + 1;
                 Debug.Log("hit"+hitt);
                }
               else if(!dam.damage){
                   miss = miss + 1;
                    hit1.text = "miss    " + count.ToString();
                    //Debug.Log("mis "+ miss);
                }


              
                
            }

            
            moving = false;
          

        }
        
        

    }
    IEnumerator example() {
        
        yield return new WaitForSeconds(1f);
        
        
       a.unperform();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "drop") {
            Destroy(collision.gameObject);
            count = count + 1;
            t.text = "count  " + count.ToString();
        }
    }


}
