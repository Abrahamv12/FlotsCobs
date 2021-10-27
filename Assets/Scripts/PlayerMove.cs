using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject Enemigo;

    public float TiempoEnemigo;
    private float NuevoEnemigo;

    public GameObject Cartucho;
    public GameObject BalaPrefabs;
    public float VelBala;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(NuevoEnemigo <= 0) {
          NuevoEnemigo = TiempoEnemigo;
            int EnemigoPost = Random.Range(-2, 3);
          GameObject EnemigoTemp= Instantiate(Enemigo,new Vector3(EnemigoPost,6,0),Quaternion.identity);
            Destroy(EnemigoTemp, 5);
        }

        NuevoEnemigo -= Time.deltaTime;

        if(Input.GetKey("d"))
        {
            rb.velocity = transform.right * 5;
        }

        if (Input.GetKey("a"))
        {
            rb.velocity = -transform.right * 5;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            GameObject TempBala = Instantiate(BalaPrefabs, Cartucho.transform.position, Cartucho.transform.rotation);

            Rigidbody TempoRb = TempBala.GetComponent<Rigidbody>();

            TempoRb.AddForce(transform.up * VelBala);

            Destroy(TempBala, 5.0f);
        }
    }
}
