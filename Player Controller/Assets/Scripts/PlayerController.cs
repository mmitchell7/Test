using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpForce = 8.0f;
    public float gravity = 20.0f ;
    public float rotSpeed = 150.0f;

    public GameObject bullet;
    public Transform shootPos;
    public float fireRate = 1f;

    private bool canShoot = true;


    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private PlayerStats stats;
    



    // Start is called before the first frame update
    void Start()
    {
        //store our controller
      controller = GetComponent<CharacterController>();
        stats = GetComponent<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {
        speed = stats.speed;
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0,0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed; 

            if(Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce; 
            }
            
        }
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime, 0);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        if(moveDirection != Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward,new Vector3(moveDirection.x, 0, moveDirection.z).normalized,0.5f) ;
        }
        if (Input.GetMouseButton(0))
        {
            if(canShoot)
            {
                ShootRay();
                Debug.Log("PEW!");
                StartCoroutine(FireCoolDown());
            }
        }
    }

    public void ShootRay()
    {
        RaycastHit hit;
        if(Physics.Raycast(shootPos.position,shootPos.forward, out hit,100f))
        {
            Debug.DrawRay(shootPos.position, shootPos.forward * 100f, Color.cyan, 1f);
            if (hit.collider.gameObject.tag == "Player")
            {
                hit.collider.gameObject.GetComponent<PlayerStats>().increaseHealth(-5);
              
            }
        }
    }

    public void ShootBullet()
    {

    }

    IEnumerator FireCoolDown()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
        
    }

     
}
