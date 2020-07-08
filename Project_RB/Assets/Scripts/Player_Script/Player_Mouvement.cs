using UnityEngine;

public class Player_Mouvement : MonoBehaviour
{
    public Player Player;

    public bool Auto;
    public bool Is_Grounded;
    public bool Is_Grounded_Trigger;
    public bool Can_double_jump;
    public bool Has_Jumped;
    public bool Start_Timer = false;
    public bool Start_Timer_Jump;

    public int Jump_Count;
    public int Jump_Count_Max;

    public float Speed;
    public float Acceleration;
    public float Jump_Power_const = 300f;
    public float Jump_Power;
    public float Jump_Count_Delay;
    public float Jump_Count_Cooldown_Start_Time = 0f;
    public float Jump_Reset_Timer;
    public float Jump_Reset_Start_Time;
    public float Evade_Speed;

    public Vector3 Jump_Direcetion;
    public Vector3 Mouvement_Direction;    
    public Vector3 Evade_Right_Direcetion;
    public Vector3 Evade_Left_Direcetion;

    public Joystick joystick;

    void Start()
    {
        Player = GetComponent<Player>();
        Jump_Power = Jump_Power_const;
    }

    void FixedUpdate() {
        
       Advance(Speed,Auto,Is_Grounded,Player.Rigid_Body);
    }

    void Update()
    {
        Acceleration_Player();

        Evade_Left_Right(Evade_Speed,Player.Rigid_Body,Evade_Right_Direcetion,Evade_Left_Direcetion);
        Evade_Left_Right_Android(Evade_Speed,Player.Rigid_Body,Evade_Right_Direcetion,Evade_Left_Direcetion);
        
        // Player_Jump(Jump_Power,Player.Rigid_Body,Jump_Direcetion,Is_Grounded);
        // Player_Jump_V3(Jump_Power,Player.Rigid_Body,Jump_Direcetion,Jump_Count_Max);
        // Player_Jump_V4();

        Player_Jump_V5();
    }

    void Advance(float Speed,bool Auto,bool IsGrounded,Rigidbody RB){
        if (Auto) {
            if (IsGrounded) RB.AddForce(Mouvement_Direction*Speed*Time.deltaTime);
            else RB.AddForce(Mouvement_Direction*Speed/5*Time.deltaTime);
            }
        else if (Input.GetKeyDown(Player.Player_Key_Binding.Advance_Key)) {
            if (IsGrounded) RB.AddForce(Mouvement_Direction*Speed*Time.deltaTime);
            else RB.AddForce(Mouvement_Direction*Speed/5*Time.deltaTime);
            }
    }

    void Jump(Rigidbody RB,Vector3 Jump_Vector){
        RB.AddForce(Jump_Vector*Jump_Power); 
        Debugger("Jump_Power: "+Jump_Power);
        Jump_Power *= (2f/3f);
        Jump_Reset_Start_Time = Time.time;
        Has_Jumped = true;
    }

    void Evade_Left_Right(float Evade_Speed,Rigidbody RB,Vector3 Evade_Right_Direcetion,Vector3 Evade_Left_Direcetion){
        if (Input.GetKey(Player.Player_Key_Binding.Evade_Right_Key)) RB.AddForce(Evade_Right_Direcetion*Evade_Speed*Time.deltaTime);
        if (Input.GetKey(Player.Player_Key_Binding.Evade_Left_Key)) RB.AddForce(Evade_Left_Direcetion*Evade_Speed*Time.deltaTime);
    } 

    void Evade_Left_Right_Android(float Evade_Speed,Rigidbody RB,Vector3 Evade_Right_Direcetion,Vector3 Evade_Left_Direcetion){
            if (joystick.Horizontal > 0.65f) RB.AddForce(Evade_Right_Direcetion*Evade_Speed*Time.deltaTime);
            if (joystick.Horizontal < -0.65f) RB.AddForce(Evade_Left_Direcetion*Evade_Speed*Time.deltaTime);
        } 

    void Evade_Left_Right_Android_V2(float Evade_Speed,Rigidbody RB,Vector3 Evade_Right_Direcetion,Vector3 Evade_Left_Direcetion){
        Vector2 touch_position = Input.GetTouch(0).position;
        if (touch_position.x > Screen.width/2 && touch_position.y < Screen.height/3 && touch_position.y > -Screen.height/3){
            RB.AddForce(Evade_Right_Direcetion*Evade_Speed*Time.deltaTime);
        }
        if (touch_position.x < -Screen.width/2 && touch_position.y < Screen.height/3 && touch_position.y > -Screen.height/3){
            RB.AddForce(Evade_Left_Direcetion*Evade_Speed*Time.deltaTime);
        }
    }

    void Player_Jump(float Jump_Power,Rigidbody RB,Vector3 Jump_Vector,bool Is_Grounded){
        if (Is_Grounded){
            if (Input.GetKeyDown(Player.Player_Key_Binding.Jump_Key)) { 
                Jump(RB,Jump_Vector); 
                }
        }
    }

    public void Jump_Android(){
        if (Is_Grounded) {
            Player.Rigid_Body.AddForce(Jump_Direcetion*Jump_Power);
            }
    }

    void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Platform")){
            Is_Grounded = true;
            Player.Player_Audio_Source.clip = Player.Player_Audio.AudioGroupPicker("player_collide_ground",Player.Player_Audio.SFX_Audio_Groups).AudioPicker(true,0);
            Player.Player_Audio_Source.Play();
        }
    }

    void OnCollisionExit(Collision other) {
        if (other.collider.CompareTag("Platform")){
            Is_Grounded = false;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Platform")){
            Is_Grounded_Trigger = true;
            Can_double_jump = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Platform")){
            Is_Grounded_Trigger = false;
        }
    }

    void Acceleration_Player(){
        if (Is_Grounded && Time.timeScale == 1)
            Speed = Speed * Acceleration;
    }

    void Timer(bool condition, bool timer_finished, float countdown_time){
        float starting_time = 0f;
        bool activate_timer = false;
        timer_finished = false;

        if (condition){
            starting_time = Time.time;
            activate_timer = true;
            condition = false;
        }

        if (Time.time > starting_time + countdown_time && activate_timer){
            timer_finished = true;
            activate_timer = false;
        }
    }

    void Dash(Vector3 dash_distance,float dash_speed,GameObject gameObject){
        gameObject.transform.position = Vector3.Slerp(gameObject.transform.position,gameObject.transform.position+dash_distance,dash_speed);
    }

    void Player_Jump_V5(){
        Jump_Power_Reset();
        Player_Jump_V4();
        Double_Jump();
    }
    
    void Player_Jump_V4(){
        if (Is_Grounded_Trigger){
            if (Input.GetKeyDown(Player.Player_Key_Binding.Jump_Key)){
                Jump(Player.Rigid_Body,Jump_Direcetion);
                Can_double_jump = true;
            }
        }
    }

    void Player_Jump_V3(float Jump_Power,Rigidbody RB,Vector3 Jump_Vector,int Jump_Count_Max){
        
        if (Jump_Count > 0 && Input.GetKeyDown(Player.Player_Key_Binding.Jump_Key) ) { 
                Jump(RB,Jump_Vector);
                if (Jump_Count > 0) {
                    Jump_Count --;
                    if (Jump_Count == 0) {
                        Start_Timer = true;
                        Jump_Count_Cooldown_Start_Time = Time.time;
                    }
                }
        }

        if (Start_Timer && Time.time > (Jump_Count_Cooldown_Start_Time + Jump_Count_Delay)){
            Start_Timer = false;
            Jump_Count = Jump_Count_Max;
            // Debugger("Jump_Count: "+Jump_Count + " Start_Time: "+Start_Timer+" Time: "+start_time);
        }
    }
 
    void Player_Jump_V2(float Jump_Power,Rigidbody RB,Vector3 Jump_Vector,int Jump_Count){
        if (Jump_Count > 0){
            if (Input.GetKeyDown(Player.Player_Key_Binding.Jump_Key)) { 
                Jump(RB,Jump_Vector);
                if (Jump_Count > 0) Jump_Count --; 
                }
        }
    }

    void Jump_Counter(bool Is_Grounded,int Jump_Count,int Jump_Count_Max,float Jump_Count_Delay){
            bool timer_finished = false;
            bool started_ticking = false;
            float start_time = 0f;
            
            if (Is_Grounded && Jump_Count < Jump_Count_Max && !started_ticking){
                start_time = Time.time;
                started_ticking = true;
            }

            if (started_ticking && Time.time > start_time + Jump_Count_Delay){
                timer_finished = true;
                started_ticking = false;
            }

            if (timer_finished && Jump_Count < Jump_Count_Max){
                Jump_Count ++;
                timer_finished = false;
            }

    }

    void Double_Jump(){
        if (Can_double_jump && !Is_Grounded_Trigger && Input.GetKeyDown(Player.Player_Key_Binding.Jump_Key)){
            Jump(Player.Rigid_Body,Jump_Direcetion);
            Can_double_jump = false;
        }
    }

    void Jump_Power_Reset(){
        if (Has_Jumped && Time.time > Jump_Reset_Start_Time + Jump_Reset_Timer){
            Jump_Power = Jump_Power_const;
            Has_Jumped = false;
        }
    }
    void Debugger(string text){
        Debug.Log(text);
    }

}