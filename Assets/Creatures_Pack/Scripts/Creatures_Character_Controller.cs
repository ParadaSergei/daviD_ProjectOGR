using UnityEngine;
//Creatures controller, walk, attack, shield mode, jump and dying with "k"
public class Creatures_Character_Controller : MonoBehaviour
{

    //--Animators
    Animator anim;
    //--Renderers
    private SpriteRenderer rend;
    //--aux
    private bool faceright;
    public float maxspeed;
    private bool shield_mode = false;
    private bool twinkled = false;
    private int layers_ = 5;//Number of additional layers (bodies) (5 + layer 0 = 6 layers)


    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    void Start()
    {
        maxspeed = 3f;//Set walk speed
        faceright = true;
        anim = this.gameObject.GetComponent<Animator>();
        rend = this.gameObject.GetComponent<SpriteRenderer>();
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        anim.SetBool("attack", false);
        anim.SetBool("shield_mode", false);
        anim.SetBool("dead", false);
        rb = GetComponent<Rigidbody2D>();
        //anim.SetLayerWeight (1, 1f);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        anim.SetBool("jump", false);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        if (Input.GetKey("k"))
        {//###########Change the dead event, for example: life bar=0
            anim.SetBool("dead", true);
            Invoke("On_Destroy", 2f);
        }
        if (anim.GetBool("dead") == false)
        {
            //--Layer selection
            if (Input.GetKey("0")) { set_Layers(0); }
            if (Input.GetKey("1")) { set_Layers(1); }
            if (Input.GetKey("2")) { set_Layers(2); }
            if (Input.GetKey("3")) { set_Layers(3); }
            if (Input.GetKey("4")) { set_Layers(4); }
            if (Input.GetKey("5")) { set_Layers(5); }
            //--
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) { anim.SetBool("jump", false); }
            anim.SetBool("attack", false);
            if (Input.GetMouseButtonDown(0)) { PlayAttack(); }
            if (Input.GetMouseButtonDown(1)) { PlayShieldMode(true); }
            if (Input.GetMouseButtonUp(1)) { PlayShieldMode(false); }
            if (shield_mode == false)
            {
                if (Input.GetButtonDown("Jump")) { PlayJump(); }
                PlayMove();
            }
        }
        else
        {
            if (twinkled == false)
            {
                twinkled = true;
                Invoke("Twinkle_", 0.1f);
            }
        }
    }

    void set_Layers(int value)
    {//for...
        anim.SetLayerWeight(value, 1f);
        for (int i = layers_; i > value; i--)
        {
            anim.SetLayerWeight(i, 0f);
        }
    }

    void PlayShieldMode(bool aux_)
    {
        shield_mode = aux_;
        anim.SetBool("shield_mode", aux_);
        anim.SetBool("walk", false);
    }

    void PlayAttack() { anim.SetBool("attack", true); }

    void PlayJump()
    {
        if (anim.GetBool("jump") == false)
        {//only once time each jump
            {

                if (isGrounded && Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }

                //GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,200));
                anim.SetBool("jump", true);
            }
        }
    }

    void PlayMove()
    {
        float move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxspeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0)
        {//Go right
            anim.SetBool("walk", true);
            if (faceright == false) { Flip(); }
        }
        if (move == 0) { anim.SetBool("walk", false); }//Stop
        if ((move < 0))
        {//Go left
            anim.SetBool("walk", true);
            if (faceright == true) { Flip(); }
        }
    }

    void Flip()
    {
        faceright = !faceright;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Twinkle_()
    {
        rend.enabled = !rend.enabled;
        twinkled = false;
    }

    void On_Destroy()
    {
        Destroy(this.gameObject);
    }
}
