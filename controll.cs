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
	public int highscore=0;
	private float score;
	public int count;
	public int score1 = 0;
	public Text scoretext;
	public Text coinstext;
	public Text highscoretext;
	public Text TCoins;
	public int TotCoins;
	public int t;




    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();

        startTime = Time.time;
		highscore = PlayerPrefs.GetInt("highscore");
		TotCoins = PlayerPrefs.GetInt ("TotCoins");
		SetCount ();
		count = 0;
		coinstext.text = "COINS:" + count.ToString ();
		highscoretext.text = "HIGHSCORE:" + highscore.ToString ();
		TCoins.text = "TOTALCOINS:" + TotCoins.ToString ();


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
           // Textscore.text = (Time.time - startTime).ToString("0.0");
		//score = (Time.time - startTime);
						
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
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("enemy")) {
			foreach (prefabspawner spawner in FindObjectsOfType<prefabspawner>()) {
				spawner.enabled = false;
			}



			foreach (moveleft moveLefter in FindObjectsOfType<moveleft>()) {
				moveLefter.enabled = false;
			}
			//Application.LoadLevel(Application.loadedLevel);
			HurtTime = Time.time;
			myAnim.SetBool ("hurt", true);
			myRigidBody.velocity = Vector2.zero;
			myRigidBody.AddForce (transform.up * bunnyJumpForce);
			myCollider.enabled = false;

		} else if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("ground")) {
			jumpsLeft = 2;
		}
		if (score1 > highscore)
		{
			highscore = score1;
			PlayerPrefs.SetInt ("highscore", highscore);
		}
		highscore = PlayerPrefs.GetInt("highscore");
		PlayerPrefs.Save();
		highscoretext.text = "HIGHSCORE:" + highscore.ToString ();
	   
			TotCoins +=count;
			PlayerPrefs.SetInt ("TotCoins", TotCoins);
		count=0

		PlayerPrefs.Save ();
		TCoins.text = "TOTALCOINS:" + TotCoins.ToString ();


	}
		
    void OnGUI()
	{
		//highscore = PlayerPrefs.GetInt("highscore");
		//PlayerPrefs.Save();
		//GUI.Box(new Rect(10, 10, 150, 30), "highscore:" + score.ToString());
		//GUI.Box (new Rect (20, 20, 150, 60), "HIGHSCORE:" + highscore.ToString ());
		//GUI.Box (new Rect (60, 100, 150, 60), "CARDS:" + count.ToString ());
		//GUI.Box (new Rect (60, 40, 150, 60), "score1" + score1.ToString ());
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "cardsspawn") 
		{
			Destroy (other.gameObject);
			count++;
			coinstext.text = "COINS:" + count.ToString ();
			}

		if (other.tag == "hurdles") 
		{
			score1++;  
			SetCount ();
		}
	}
	void SetCount()
	{
		scoretext.text = "SCORE:" + score1.ToString ();
		}


}
