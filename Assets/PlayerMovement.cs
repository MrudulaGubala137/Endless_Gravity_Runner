using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce;
    public float PlayerSpeed;
    Rigidbody rb;
    int score;
    int maxDistance;
    public Text scoreText;
    
   
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        PlayerPrefs.SetString("Name","Mrudula");
        Debug.Log(PlayerPrefs.GetString("Name"));
        PlayerPrefs.SetFloat("float",0.5f);
        Debug.Log(PlayerPrefs.GetFloat("float"));
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
        Debug.Log(PlayerPrefs.GetInt("Score"));
       
        PlayerPrefs.SetInt("Score", score);
        scoreText.text = "score: " + score;
        if(score >maxDistance)
        {
            PlayerSpeed = PlayerSpeed+0.2f;
            maxDistance = maxDistance + 100;
        }
        
    }
    private void FixedUpdate()
    {
       
        rb.velocity=new Vector3(PlayerSpeed,rb.velocity.y,rb.velocity.z);
        if (Input.GetKeyDown(KeyCode.K))
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<ObstacleCollider>() != null)
        {
            Destroy(this.gameObject);
        }
    }
}
