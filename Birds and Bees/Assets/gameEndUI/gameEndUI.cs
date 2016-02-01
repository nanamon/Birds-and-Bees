using UnityEngine;
using System.Collections;

public class gameEndUI : MonoBehaviour {
	private class Heart
	{
		public Vector2 pos;
		public Texture2D icon;
		public float mult;
		public Vector2 vel;
		public Vector2 accel;

		public void moveParticle()
		{
			Vector2 scale = new Vector2();
			scale.x = icon.width * mult;
			scale.y = icon.height * mult;
			if (this.pos.x > -scale.x && pos.x < Screen.width+scale.x && this.pos.y > -scale.y && pos.y < Screen.height+scale.y) {
				pos.x += vel.x*mult;
				pos.y += vel.y*mult;
				vel.x += accel.x*mult;
				vel.y += accel.y*mult;
			}
		}

		public void draw()
		{
			Vector2 scale = new Vector2();
			Vector2 posSub = new Vector2();
			scale.x = icon.width * mult *.5f;
			scale.y = icon.height * mult *.5f;
			posSub.x = pos.x - scale.x/2;
			posSub.y = pos.y - scale.y/2;

			GUI.DrawTexture (new Rect (posSub.x, posSub.y, scale.x, scale.y), icon);
		}
	}

	[SerializeField] public Texture2D[] animalSilhouetteIcons = new Texture2D[5];
	[SerializeField] public Texture2D[] animalIcons = new Texture2D[5];
	[SerializeField] public Texture2D[] animalBlendIcons = new Texture2D[10];
	[SerializeField] public Texture2D bg;
	[SerializeField] public Texture2D par_heart;
	[SerializeField] public GUISkin skin;

	private float mult;

	private int seducedIndex;
	private int winnerIndex;
	private float endScore;

	private bool flashIcon;

	private float flashTimer;
	private float flashDelay;
	private float flashDelayDefault;
	private float flashDelayIncrement;

	private float maxFlashes;
	private float flashCount;

	private bool flashing;

	private Heart[] hearts;
	private int heartCount;

	AudioPlayer audioPlayer;

	// Use this for initialization
	void Start () {
		audioPlayer = this.GetComponent<AudioPlayer>();

		seducedIndex = GameManager.seducedIndex - 1;
		winnerIndex = GameManager.winnerIndex;
		endScore = GameManager.score[GameManager.winnerIndex];

		flashIcon = true;

		flashTimer = 0;
		flashDelayDefault = 1f;
		flashDelay = flashDelayDefault;
		flashDelayIncrement = 0.1f;

		flashCount = 0;
		maxFlashes = 25;

		flashing = true;

		//particles
		heartCount = 10;
		hearts = new Heart[heartCount];
		for (int i = 0; i < heartCount; i++) {
			Heart tempHeart = new Heart();
			tempHeart.accel = new Vector2();
			tempHeart.accel.x = Random.Range(-3f,3f);
			tempHeart.accel.y = Random.Range(-3f,3f);
			tempHeart.vel = new Vector2();
			tempHeart.vel.x = Random.Range(-1f,1f);
			tempHeart.vel.y = Random.Range(-1f,1f);
			tempHeart.pos = new Vector2();
			tempHeart.pos.x = (float)Screen.width / 2;
			tempHeart.pos.y = (float)Screen.height / 2;
			tempHeart.icon = par_heart;

			hearts[i] = tempHeart;
		}
	}

	void FixedUpdate(){
		//timer
		if (flashing) {
			if (flashTimer > flashDelay) {
				flashDelay -= flashDelayIncrement;
				if (flashDelay < .2f)
					flashDelay = .1f;
				flashTimer = 0;
				flashIcon = !flashIcon;

				if(flashIcon) audioPlayer.PlayUpBeat();
				else audioPlayer.PlayDownBeat();

				flashCount ++;
				if (flashCount > maxFlashes)
				{
					Debug.Log("test");
					audioPlayer.PlayFanfare();
					flashing = false;
				}
			} 
			else {
				flashTimer += Time.deltaTime;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		GUI.skin = skin;
		mult = (float) Screen.width/(float) bg.width;

		//bg
//		Debug.Log (mult);
		Vector2 scale = new Vector2();
		Vector2 pos = new Vector2();
		scale.x = Screen.width;
		scale.y = bg.height*mult;

		GUI.DrawTexture (new Rect (0, 0, scale.x, scale.y), bg);

		//center
		if (flashing) {
			scale.x = animalSilhouetteIcons [0].width * mult * .5f;
			scale.y = animalSilhouetteIcons [0].height * mult * .5f;
			pos.x = (float)Screen.width / 2 - scale.x / 2;
			pos.y = (float)Screen.height / 2 - scale.y / 2;

			if (flashIcon)
				GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), animalSilhouetteIcons [winnerIndex]);
			else
				GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), animalSilhouetteIcons [seducedIndex]);
		} 
		else {
			scale.x = animalBlendIcons [0].width * mult * .5f;
			scale.y = animalBlendIcons [0].height * mult * .5f;
			pos.x = (float)Screen.width / 2 - scale.x / 2;
			pos.y = (float)Screen.height / 2 - scale.y / 2;
			
			if (seducedIndex == 0 && winnerIndex == 1 || seducedIndex == 1 && winnerIndex == 0)
				GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), animalBlendIcons [0]);
			else if (seducedIndex == 0 && winnerIndex == 2 || seducedIndex == 2 && winnerIndex == 0)
				GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), animalBlendIcons [1]);
			else if (seducedIndex == 0 && winnerIndex == 3 || seducedIndex == 3 && winnerIndex == 0)
				GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), animalBlendIcons [2]);
			else if (seducedIndex == 0 && winnerIndex == 4 || seducedIndex == 4 && winnerIndex == 0)
				GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), animalBlendIcons [3]);
			else if (seducedIndex == 1 && winnerIndex == 2 || seducedIndex == 2 && winnerIndex == 1)
				GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), animalBlendIcons [4]);
			else if (seducedIndex == 1 && winnerIndex == 3 || seducedIndex == 3 && winnerIndex == 1)
				GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), animalBlendIcons [5]);
			else if (seducedIndex == 1 && winnerIndex == 4 || seducedIndex == 4 && winnerIndex == 1)
				GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), animalBlendIcons [6]);
			else if (seducedIndex == 2 && winnerIndex == 3 || seducedIndex == 3 && winnerIndex == 2)
				GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), animalBlendIcons [7]);
			else if (seducedIndex == 2 && winnerIndex == 4 || seducedIndex == 4 && winnerIndex == 2)
				GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), animalBlendIcons [8]);
			else if (seducedIndex == 3 && winnerIndex == 4 || seducedIndex == 4 && winnerIndex == 3)
				GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), animalBlendIcons [9]);
			
			//score
			GUI.skin.GetStyle ("score").fontSize = Mathf.RoundToInt(80 * mult);
			GUI.Box(new Rect(0,Screen.height*0.8f,Screen.width,Screen.height*0.3f),endScore.ToString(),GUI.skin.GetStyle("score"));

			//particles
			for (int i = 0; i < heartCount; i++) {
				hearts[i].mult = mult;
				hearts[i].moveParticle();
				hearts[i].draw();
			}
		}

		//border
		scale.x = animalIcons [0].width * mult *-1;
		scale.y = animalIcons [0].height * mult;
		pos.x = 0 - scale.x - (scale.x*-1) / 3;
		pos.y = (float)Screen.height / 2 - scale.y / 2;
		GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), animalIcons [winnerIndex]);
		
		scale.x = animalIcons [0].width * mult;
		scale.y = animalIcons [0].height * mult;
		pos.x = (float)Screen.width - (scale.x *2/ 3);
		pos.y = (float)Screen.height / 2 - scale.y / 2;
		GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), animalIcons [seducedIndex]);
	}
}
