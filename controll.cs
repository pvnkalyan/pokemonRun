    using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controll : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    public float bunnyJumpForce = 500f;
    private float HurtTime = -1;
    private Collider2D myCollider;
    public Text Textscore;
    private float startTime;
    private int jumpsLeft = 2;
	private float highscore=0.0f;
	private float score;


    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();

        startTime = Time.time;
	highscore = PlayerPrefs.GetFloat("highscore");
    }

    // Update is called once per frame
    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("title");
		}


        if (HurtTime == -1)
        {
			if ((Input.GetButtonUp("Jump")|| Input.GetButtonUp("Fire1")) && jumpsLeft > 0)
            {
                if (myRigidBody.velocity.y < 0)
                {
                    myRigidBody.velocity = Vector2.zero;
                }


                if (jumpsLeft == 1)
                {
                    myRigidBody.AddForce(transform.up * bunnyJumpForce * 0.75f);
                }
                else
                {
                    myRigidBody.AddForce(transform.up * bunnyJumpForce);
                }
                jumpsLeft--;
            }
            myAnim.SetFloat("vVelocity", myRigidBody.velocity.y);
            Textscore.text = (Time.time - startTime).ToString("0.0");
		score = (Time.time - startTime);
						
        }
        else
        {
            if (Time.time > HurtTime + 2)
            {
                Application.LoadLevel("title");
				Start();

            }
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            foreach (prefabspawner spawner in FindObjectsOfType<prefabspawner>())

            {
                spawner.enabled = false;
            }



            foreach (moveleft moveLefter in FindObjectsOfType<moveleft>())
            {
                moveLefter.enabled = false;
            }
            //Application.LoadLevel(Application.loadedLevel);
            HurtTime = Time.time;
            myAnim.SetBool("hurt", true);
            myRigidBody.velocity = Vector2.zero;
            myRigidBody.AddForce(transform.up * bunnyJumpForce);
            myCollider.enabled = false;

        }
        else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("ground"))
        { jumpsLeft = 2; }
		if (score > startTime) {
			highscore = score;
			PlayerPrefs.SetFloat("highscore", highscore);
		}
    }
	void OnGUI()
	{
		highscore = PlayerPrefs.GetFloat("highscore");
		//GUI.Box(new Rect(10, 10, 150, 30), "highscore:" + score.ToString());
		GUI.Box(new Rect(20, 20, 150, 60), "highscore:" + highscore.ToString());
	}
}