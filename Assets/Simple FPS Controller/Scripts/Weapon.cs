using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public SFPSC_GrapplingHook grapplingHook;
    [SerializeField]change_gun ChangeGun;
    [SerializeField] private float gunDamage;
    public int maxAmmo;
    public float shootsPerSecond;
    public int reloadSpeed;
    public Vector3 aimPosition;

    public float smooth;

    bool isReloading;
    bool isShooting;
    bool isAiming;
    public int ammo;


    public TMP_Text ammoText;

    [SerializeField] private Camera _camera;
    public float range;

    public GameObject bulletMark;

    
    private void Start() {
        ammo = maxAmmo;
        ammoText.text = ammo + "/" + maxAmmo;
    }

    private void Update() {
        Debug.Log(ammo);

        if (Input.GetButton("Fire1") && !isReloading && !isShooting && grapplingHook.isGrappling == false)
        {
            if (ammo <= 0) return;
            
            ammo--;
            ammoText.text = ammo + "/" + maxAmmo;
            
            
            Fire();
            StartCoroutine(Shooting());
            
        }    

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
        if(grapplingHook.isGrappling == false)
        {
            isAiming = Input.GetMouseButton(1) && !isReloading;
            transform.localPosition = Vector3.Lerp(transform.localPosition, 
                isAiming ? aimPosition : Vector3.zero, smooth * Time.deltaTime);
            
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, 
                isAiming ? 40 : 60, smooth * Time.deltaTime);
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

    private IEnumerator Reload()
    {

        isReloading = true;
        ammoText.text = "Reloading...";
        yield return new WaitForSeconds(3);
        ammo = maxAmmo;
        ammoText.text = ammo + "/" + maxAmmo;
        isReloading = false;
        
    }

    private IEnumerator Shooting()
    {
        isShooting = true;
        //Debug.Log(1 / shootsPerSecond);
        yield return new WaitForSeconds(1f / shootsPerSecond);
        isShooting = false;
    }
}
