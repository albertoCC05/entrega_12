using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables 

    private Rigidbody playerRigidboddy;
    [SerializeField] private float playerSpeed;
    private float forwardInput;
    [SerializeField] private GameObject focalPoint;
    [SerializeField] public bool hasPowerUp = false;
    [SerializeField] float PowerUpForce = 10f;
    [SerializeField] private GameObject[] powerupIndicators;
    private int lives = 3;
    private float lowerlimit = -3f;
    public bool isGameOver = false;
    private Vector3 initialPosition = Vector3.zero;

    public int points = 0;

    private UiGameScene uiGameScript;


    // funciones

    private IEnumerator PowerupCountdown()
    {
        //espera 6 segundos



        for (int i = 0; i < powerupIndicators.Length; i++)
        {
            powerupIndicators[i].SetActive(true);
            yield return new WaitForSeconds(2);
            powerupIndicators[i].SetActive(false);
        }

        hasPowerUp = false;
    }

    private void HideAllPowerupIndicators()
    {
        foreach (GameObject indicator in powerupIndicators)
        {
            indicator.SetActive(false);
        }
    }

    private void Movment()
    {
        forwardInput = Input.GetAxis("Vertical");
        playerRigidboddy.AddForce(focalPoint.transform.forward * playerSpeed * forwardInput);
    }

  


    //-----------------------------------------------
    private void Start()
    {
        uiGameScript = FindObjectOfType<UiGameScene>();
        HideAllPowerupIndicators();
        points = 0; 
    }

    private void Awake()
    {
        playerRigidboddy = GetComponent<Rigidbody>();
        isGameOver = false;
    }

    

    private void Update()
    {
        //movment

        if (isGameOver == true)
        {
            return;
        }
       
       
       
        if (transform.position.y < lowerlimit)
        {
            lives--;
            if (lives < 0)
            {
                isGameOver = true;
                uiGameScript.ShowGameOverPanel();

            }
            else
            {
                transform.position = initialPosition;
                playerRigidboddy.velocity = Vector3.zero;
            }
            
        }
        
       

        
        



       
    }
    private void FixedUpdate()
    {
        Movment();
    }

    //power up

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("powerUp"))
        {
            hasPowerUp = true;
            StartCoroutine(PowerupCountdown());
            Debug.Log(hasPowerUp);
            Destroy(other.gameObject);
           
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("enemy") && hasPowerUp == true)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 direction = other.transform.position - transform.position;
            other.rigidbody.AddForce(direction * PowerUpForce, ForceMode.Impulse);
        }
    }

    public void WinPoint()
    {
        points++;
    }
    


}
