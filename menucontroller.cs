using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menucontroller : MonoBehaviour {
	public static int k;
	public static int pikachu;
	public static int bulbasaur;
	public static int sceneL;
	public static int squirtle;
	public static  int charmender;
	public static  int eve;
	public static  int pipe;
	public static int tokkerpi;
	public static menucontroller control;
	public GameObject Aon;
	public GameObject Aoff;

	// Use this for initialization
	void Start () {
		k= PlayerPrefs.GetInt ("k");
		eve= PlayerPrefs.GetInt ("eve");
		sceneL= PlayerPrefs.GetInt ("sceneL");
		pikachu = PlayerPrefs.GetInt ("pikachu");
		bulbasaur = PlayerPrefs.GetInt ("bulbasaur");
		squirtle = PlayerPrefs.GetInt ("squirtle");
		charmender = PlayerPrefs.GetInt ("charmender");
		pipe = PlayerPrefs.GetInt ("pipe");	
		tokkerpi = PlayerPrefs.GetInt ("tokkerpi");

		setsound ();
	}
	
	// Update is called once per frame
	void Update () {
		k = characters.j;
		eve = characters.evee;
		bulbasaur = characters.bulba;
		sceneL = characters.scene;
		pikachu = characters.pika;
		squirtle = characters.squa;
		charmender = characters.charm;
		pipe = characters.pikoi;
		tokkerpi = characters.toki;
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}

	}
	public void StartGame()
	{
		PlayerPrefs.SetInt ("k",k);
		PlayerPrefs.SetInt ("sceneL",sceneL);
		if (k >= 1&&sceneL==1) {
			Application.LoadLevel ("pidgey");
			PlayerPrefs.Save ();
		}
		else if(k!=1 && pikachu!=1 && bulbasaur!=1&&squirtle!=1&&charmender!=1&&eve!=1&&pipe!=1&&tokkerpi!=1)
		{
			Application.LoadLevel("game");

		}
		PlayerPrefs.SetInt ("bulbasaur",bulbasaur);
		PlayerPrefs.SetInt ("sceneL",sceneL);
		if (bulbasaur >= 1&&sceneL==3) {
			Application.LoadLevel("bulbasaur");
			PlayerPrefs.Save ();

		}else if(k!=1 && pikachu!=1 && bulbasaur!=1&&squirtle!=1&&charmender!=1&&eve!=1&&pipe!=1&&tokkerpi!=1)
		{
			Application.LoadLevel("game");

		}
		PlayerPrefs.SetInt ("pikachu",pikachu);
		PlayerPrefs.SetInt ("sceneL",sceneL);
		if (pikachu >= 1&&sceneL==2) {
			Application.LoadLevel("game");
			PlayerPrefs.Save ();
		}else if(k!=1 && pikachu!=1 && bulbasaur!=1&&squirtle!=1&&charmender!=1&&eve!=1&&pipe!=1&&tokkerpi!=1)
		{
			Application.LoadLevel("game");

		}
		PlayerPrefs.SetInt ("squirtle",squirtle);
		PlayerPrefs.SetInt ("sceneL",sceneL);
		if (squirtle >= 1&&sceneL==4) {
			Application.LoadLevel("squirtle");
			PlayerPrefs.Save ();
		}else if(k!=1 && pikachu!=1 && bulbasaur!=1&&squirtle!=1&&charmender!=1&&eve!=1&&pipe!=1&&tokkerpi!=1)
		{
			Application.LoadLevel("game");

		}
		PlayerPrefs.SetInt ("charmender",charmender);
		PlayerPrefs.SetInt ("sceneL",sceneL);
		if (charmender>= 1&&sceneL==5) {
			Application.LoadLevel("charmender");
			PlayerPrefs.Save ();
		}else if(k!=1 && pikachu!=1 && bulbasaur!=1&&squirtle!=1&&charmender!=1&&eve!=1&&pipe!=1&&tokkerpi!=1)
		{
			Application.LoadLevel("game");

		}
		PlayerPrefs.SetInt ("eve",eve);
		PlayerPrefs.SetInt ("sceneL",sceneL);
		if (eve>= 1&&sceneL==6) {
			Application.LoadLevel("evee");
			PlayerPrefs.Save ();
		}else if(k!=1 && pikachu!=1 && bulbasaur!=1&&squirtle!=1&&charmender!=1&&eve!=1&&pipe!=1&&tokkerpi!=1)
		{
			Application.LoadLevel("game");

		}
		PlayerPrefs.SetInt ("piko",pipe);
		PlayerPrefs.SetInt ("sceneL",sceneL);
		if (pipe >= 1 && sceneL == 7) {
			Application.LoadLevel ("pikoi");
			PlayerPrefs.Save ();
		} else if (k != 1 && pikachu != 1 && bulbasaur != 1 && squirtle != 1 && charmender != 1 && eve != 1 && pipe != 1 && tokkerpi != 1) 
		{
			Application.LoadLevel ("game");
		}
		PlayerPrefs.SetInt ("tokkerpi",tokkerpi);
		PlayerPrefs.SetInt ("sceneL",sceneL);
		if (pipe>= 1&&sceneL==8) {
			Application.LoadLevel("tokkerpi");
			PlayerPrefs.Save ();
		}else if(k!=1 && pikachu!=1 && bulbasaur!=1&&squirtle!=1&&charmender!=1&&eve!=1&&pipe!=1&&tokkerpi!=1)
		{
			Application.LoadLevel("game");
		}


	}
	public void load()
	{
		Application.LoadLevel("charatecters");
	
	}
	public void Click()
	{
		Application.LoadLevel("title");
	}
	public void Click1()
	{
		Application.LoadLevel("settings");
	}
	public void setting()
	{
		Application.LoadLevel ("settings");
	}
	public void evee1()
	{
		Application.LoadLevel ("tokkerpi");
	}
	public void Multi()
	{
		Application.LoadLevel("multiplayer");
	}
	public void intruct()
	{
		Application.LoadLevel ("instructions");
	}
	public void ToggleSound()
	{
		if (PlayerPrefs.GetInt ("muted", 0) == 0) {
			PlayerPrefs.SetInt ("muted", 1);

		} else {
			PlayerPrefs.SetInt ("muted", 0);
		}

		setsound ();
	}
	public void setsound()
	{
		if (PlayerPrefs.GetInt ("muted", 0) == 0) {
			AudioListener.volume = 1;
			Aon.SetActive (true);
			Aoff.SetActive (false);
		} else
		{
			AudioListener.volume = 0;
			Aon.SetActive (false);
			Aoff.SetActive (true);
		}
	}
}

