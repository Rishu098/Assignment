using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Rigidbody bullet;
    public GameObject cursor;
    public LayerMask layer;
    private Camera cam;
    public Transform shootpoint;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        LaunchProjectile();
    }
    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time) {
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

    void LaunchProjectile() {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(camRay, out hit, 1000f, layer)) {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;

            Vector3 Vo = CalculateVelocity(hit.point, shootpoint.position, 1f);

                if (Input.GetMouseButtonDown(0))
            {
                Rigidbody obj = Instantiate(bullet, shootpoint.position, Quaternion.identity);
                obj.velocity = Vo;
            }

            
        }
    }
}
