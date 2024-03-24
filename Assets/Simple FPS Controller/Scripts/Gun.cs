using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float gunDamage;
    public SFPSC_GrapplingHook sfpsc_GrapplingHook;
    public TrailRenderer trailRenderer;
    [SerializeField] private Camera _camera;
    public float range;

    public GameObject bulletMark;
    private void Update() {

            if (Input.GetButtonDown("Fire1") && sfpsc_GrapplingHook.isGrappling == false)
            {
                Fire();
            }    

    }

    void Fire()
        {
            
            RaycastHit hit;
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
            {
                GameObject hitObject =  hit.transform.gameObject;
                Target target = hitObject.GetComponent<Target>();         
                            
                if (target) 
                {
                    target.TakeDamage(gunDamage);
                }
                else 
                {
                    Instantiate(bulletMark, hit.point, Quaternion.LookRotation(hit.normal));
                    //CreateSphere(hit.point);
                }
            } 
        }
}
