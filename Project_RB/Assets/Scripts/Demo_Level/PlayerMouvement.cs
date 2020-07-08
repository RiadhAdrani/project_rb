using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public Transform player;
    public PlayerScore _playerScore;
    public LevelManager level;

    public Rigidbody rb;
    public float speed;
    public float speedfactor = 1.0001f;
    public float jumpSpeed;
    public float evadeSpeed;
    private bool isGrounded; 

    private bool isGrounded2;

    private bool easyJump = false;
    private float isGroundedTime;
    [SerializeField]private float isGroundedIntervall = 0.2f;

    public bool dead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _playerScore = GetComponent<PlayerScore>();
    }

    void FixedUpdate() {
        //Advance();
        AutoAdvance();
    }

    void Update()
    {
        Respawn();
        Evade();
        Jump();
        EasyJumps();
        IsGroundedReCheck();

    }

    void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Platform")){
            isGrounded = true;
            isGrounded2 = true;
        }
    }

    void OnCollisionExit(Collision other) {
        if (other.collider.CompareTag("Platform")){
            isGroundedTime = Time.time;
            easyJump = true;
            isGrounded = false;
            isGrounded2 = false;
        }

        if (other.collider.CompareTag("Platform") && !isGrounded){
            isGrounded = false; // TRUE
        }
    }

    void EasyJumps(){
        if (isGroundedTime + isGroundedIntervall < Time.time && easyJump) {
            isGrounded = false;
            easyJump = false;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("coin")){
            _playerScore.score ++;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("fall")){
            dead = true;
        }
    }

    void IsGroundedReCheck(){
        if (isGrounded2){
            isGrounded = true ;
        }
    }

    void Advance(){
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded){
            rb.AddForce(-speed*Time.deltaTime,0,0);
            AdvancePlus();
        }  
    }

    void AutoAdvance(){
        if (isGrounded){
            rb.AddForce(-speed*Time.deltaTime,0,0);
            AdvancePlus();
        }  
    }

    void AdvancePlus(){
        speed = speed * speedfactor;
    }

    void Evade(){
        if (Input.GetKey(KeyCode.RightArrow)){
            rb.AddForce(0,0,evadeSpeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            rb.AddForce(0,0,-evadeSpeed*Time.deltaTime);
        }
    }

    void Jump(){
        if (isGrounded){
            if (Input.GetKeyDown(KeyCode.Space)){
                rb.AddForce(0,jumpSpeed,0);
            }
        }
    }

    void Respawn(){
        if (dead){
        _playerScore.score -= level.deathPenalty;
        rb.velocity = new Vector3(0,0,0);
        isGrounded = false;
        player.transform.position = level.checkPoint.position;
        _playerScore.deathCounter ++;
        dead = false;
        }
       
    }

}
