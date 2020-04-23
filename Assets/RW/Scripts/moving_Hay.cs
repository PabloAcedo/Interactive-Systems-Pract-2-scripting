using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_Hay : MonoBehaviour
{

    public GameObject hayBalePrefab;
    public Transform haySpawnpoint;
    public float shootInterval; 
    private float shootTimer; 
    public float limit_Hay_movement = 21;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        float horizontalInput = Input.GetAxisRaw("Horizontal"); 

        if (horizontalInput < 0 && transform.position.x > -limit_Hay_movement) {
            transform.Translate(transform.right * -20 * Time.deltaTime);
        } else if (horizontalInput > 0 && transform.position.x < limit_Hay_movement) {
            transform.Translate(transform.right * 20 * Time.deltaTime);
        }
        
        UpdateShooting();
    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime; 

        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)) {   
            shootTimer = shootInterval; 
            ShootHay(); 
        }
    }
    private void ShootHay(){
        SoundManager.Instance.PlayShootClip();
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
    }
}
