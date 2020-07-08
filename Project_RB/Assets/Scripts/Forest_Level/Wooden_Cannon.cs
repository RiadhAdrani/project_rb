using UnityEngine;

public class Wooden_Cannon : MonoBehaviour
{
    public GameObject bullet;
    public Transform bomb_pos;
    public float speed = 100f;
    public float firerate = 0.5f;
    public bool Firing = true;
    public float fireTime;
    
    void Start()
    {
        Firing = true;
    }

    
    void FixedUpdate()
    {
        CanFire();
        Fire();
    }

    void Fire(){
        if (Firing){
            GameObject instBullet = Instantiate(bullet,bomb_pos.position,Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
            instBullet.tag = "bullet";
            instBullet.transform.parent = gameObject.transform;
            Rigidbody instBulletRB = instBullet.GetComponent<Rigidbody>();
            instBulletRB.isKinematic = false;
            instBulletRB.AddForce(bomb_pos.forward *speed);
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
