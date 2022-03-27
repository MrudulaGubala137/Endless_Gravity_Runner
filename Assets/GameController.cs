using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update    
    public Camera cam;
    public GameObject player;
    public GameObject[] blockPrefab;
    public float spawnPoint;
    public float spawnMargin;
    public GameObject gameOverPanel;
   // public Text scoreText;
    PlayerMovement playerMove;
    public Button playAgain;
    void Start()
    {
        gameOverPanel.SetActive(false);
        playAgain.onClick.AddListener(PlayAgain);
    }

    // Update is called once per frame
    void Update()
    {
        int k=Random.Range(0, blockPrefab.Length);
        if(spawnPoint<5)
        {
            k = 0;
        }
        while(player!=null && spawnPoint< player.transform.position.x + spawnMargin)
        {
            GameObject temp = Instantiate(blockPrefab[k]);
            PlatformController platform = temp.GetComponent<PlatformController>();
            temp.transform.position = new Vector3(spawnPoint + platform.platformSize / 2, 0, 0);
            spawnPoint = spawnPoint + platform.platformSize;
        }
        //Camera follows player 
        if (player != null)
        {
            cam.transform.position = new Vector3(player.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        }
        else if(player==null)
        {
            gameOverPanel.SetActive(true);
            
        }
        
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
}
