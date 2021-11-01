using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlEnemigo : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.gameObject.name);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    if (collision.gameObject.name == "Player" || collision.gameObject.name == "Base")
        { 
            PlayerMove scriptVida = collision.gameObject.GetComponent<PlayerMove>();
            scriptVida.vida -= 1;
         
            Destroy(gameObject);
            if (scriptVida.vida <= 0) SceneManager.LoadScene("Final");
        }

    }
    void SceneFinal()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
