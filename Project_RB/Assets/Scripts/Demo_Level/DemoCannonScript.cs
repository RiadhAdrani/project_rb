using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCannonScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform bomb_pos;
    public float speed = 100f;
    public float firerate = 0.5f;
    public bool Firing = true;
    public float fireTime;
    // Start is called before the first frame update
    void Start()
    {
        Firing = true;
    }

    // Update is called once per frame
    void Update()
    {
        CanFire();
        Fire();
    }

    void Fire(){
        if (Firing){
            GameObject instBullet = Instantiate(bullet,bomb_pos.position,Quaternion.identity) as GameObject;
            instBullet.tag = "bullet";
            instBullet.transform.parent = gameObject.transform;
            Rigidbody instBulletRB = instBullet.GetComponent<Rigidbody>();
            instBulletRB.AddForce(bomb_pos.forward*speed);
            fireTime = Time.time;
            Firing = false;
        }  
    }

    void CanFire(){
        if (Time.time > fireTime+firerate){
            Firing = true;
        }

    }
}
