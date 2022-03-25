using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce;
    public int PlayerSpeed;
    Rigidbody rb;
    int score;
   
    void Start()
    {
        rb=GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Physics.gravity*= -1;
        }
        // if(Input.GetKeyDown())
       score= Mathf.FloorToInt(transform.position.x);
        if(score >100)
        {
            PlayerSpeed = 2*PlayerSpeed;
        }
        
    }
    private void FixedUpdate()
    {
       
        rb.velocity=new Vector3(PlayerSpeed,rb.velocity.y,rb.velocity.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<ObstacleCollider>() != null)
        {
            Destroy(this.gameObject);
        }
    }
}
