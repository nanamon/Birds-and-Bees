using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player {

	public Texture2D selectorTexture;
	public Texture2D selectorTextureDisabled;
	public int animal;
	public bool hover;
	public bool buttonPressed;
	public bool lockChar;
	public float dirX;
	public int menuState;

}

public class MenuManager : MonoBehaviour {

	private bool start;
	bool buttonPressedMain;

	// 0 is NO player selected
	public static int[] players = new int[4];

	// the menu item selector (transparent)
	public Texture2D menuSelect; //delete
	public Texture2D charSelect; //delete

	public Texture2D[] menuItem_Start;
	public Texture2D[] menuItem_HowTo;
	public Texture2D[] menuItem_Credits;
	public Texture2D[] menuItem_Exit;

	public Texture2D[] charItem_Hippo;
	public Texture2D[] charItem_Giraffe;
	public Texture2D[] charItem_Sloth;
	public Texture2D[] charItem_Peacock;
	public Texture2D[] charItem_Ostrich;

	bool[] disabled = new bool[5];

	public Player[] player = new Player[4];
	AudioPlayer audioPlayer;

	/*public Texture2D selectorPlayer1;
	public Texture2D selectorPlayer2;
	public Texture2D selectorPlayer3;
	public Texture2D selectorPlayer4;*/

	public Texture2D howTo;
	public Texture2D credits;
	public Texture2D startScreenBG;
	public Texture2D charSelectBG;

	int menuState;
	int selectedMenu;
	float mult;

	float guiheight;
	float guiwidth;

	Vector2 scale;
	Vector2 pos;


	void Start () {

		audioPlayer = this.GetComponent<AudioPlayer>();

		selectedMenu = 0;

		for (int i = 0; i < 5; i++) {
			disabled [i] = false;
		}

		// scaler multiplier
		mult = (float) Screen.width / 1920.0f;

		scale = new Vector2(0, 0);
		pos = new Vector2(0, 0);

		guiheight = Screen.height;
		guiwidth = Screen.width;

		buttonPressedMain = false;
		menuState = 1;
		start = false;

		// set players to have no character selected
		/* animal index
		 * Giraffe: 1
		 * Peacock: 2
		 * Hippo: 3
		 * Sloth: 4
		 * Ostrich: 5 */

		for (int i = 0; i < 4; i++) {
			player [i].menuState = 1;
			player [i].animal = 0;
			player [i].lockChar = false;
		}

	}

	// Update is called once per frame
	void Update () {

		if (!start) {

			// nothing selected yet
			if (selectedMenu == 0) {

				// KEYBOARD SELECTION MAIN MENU (up-down, WASD)
				float dirY = Input.GetAxis ("DPad_YAxis_1");

				// if pressing down key (wasd)
				if (dirY > 0) {

					if (menuState < 4 && !buttonPressedMain) {
						menuState++;
						Debug.Log ("Menu state: " + menuState);
						buttonPressedMain = true;
						audioPlayer.PlaySwitchMenu ();
					}
				}

				// pressing up key (wasd)
				else if (dirY < 0) {
					if (menuState > 1 && !buttonPressedMain) {
						menuState--;
						Debug.Log ("Menu state: " + menuState);
						buttonPressedMain = true;
						audioPlayer.PlaySwitchMenu ();
					}
				} else {
					buttonPressedMain = false;
				}

				if (Input.GetButtonUp("Start_1")) {

					audioPlayer.PlaySelectMenu ();

					selectedMenu = menuState;
					buttonPressedMain = false;
				}
			}

			// 1. selected start game, go to keyboard controls for char selection
			else if (selectedMenu == 1) {
				
				// KEYBOARD CHARACTER SELECTION (left-right, WASD)
				for (int i = 0; i < 4; i++) {
					
					// if the player hasn't selected
					if (!player [i].lockChar) {

						player [i].dirX = Input.GetAxis ("DPad_XAxis_" + (i + 1));
						Debug.Log ("DPad_XAxis_" + (i + 1));

						// all players
						// if pressing right key (wasd)
						if (player [i].dirX > 0.01f) {
							if (!player [i].buttonPressed) {
								player [i].menuState++;
								player [i].buttonPressed = true;
								audioPlayer.PlaySwitchMenu ();
								if (player [i].menuState > 5)
									player [i].menuState = 1;
								while (disabled [player [i].menuState - 1]) {
									player [i].menuState++;
									if (player [i].menuState > 5)
										player [i].menuState = 1;
								}
							}
						}

						// pressing left key (wasd)
						else if (player [i].dirX < -0.01f) {
							if (!player [i].buttonPressed) {
								player [i].menuState--;
								player [i].buttonPressed = true;
								audioPlayer.PlaySwitchMenu ();
								if (player [i].menuState < 1)
									player [i].menuState = 5;
								while (disabled [player [i].menuState - 1]) {
									player [i].menuState--;
									if (player [i].menuState < 1)
										player [i].menuState = 5;
								}
							}
						} 

						else {
							player [i].buttonPressed = false;
						}

						// ON CHARACTER SELECT



						if (Input.GetButtonUp ("Start_" + (i + 1))) {


							//player [i].selectorTexture = player [i].selectorTextureDisabled;
							Debug.Log ("Player " + (i + 1) + " selected animal #" + player [i].menuState);
							player [i].lockChar = true;
							disabled[player [i].menuState-1] = true;
							GameManager.players [i] = player [i].menuState;
							bool allLocked = true;

							audioPlayer.PlaySelectMenu ();

							//kick out the other losers
							for (int j = 0; j < 4; j++) {
								if (j != i) {
									if (player [j].menuState == player [i].menuState) {
										if (player [j].menuState > 5)
											player [j].menuState = 1;
										while (disabled [player [j].menuState - 1]) {
											player [j].menuState++;
											if (player [j].menuState > 5)
												player [j].menuState = 1;
											
										}
									}
								}


								if(player[j].lockChar == false)
									allLocked = false;
							}

							if(allLocked)
							{
								//load level
								Application.LoadLevel("AnimationSetup");
							}
						}
					}

					// Disable texture
					if (player [i].lockChar) {
						player [i].selectorTexture = player [i].selectorTextureDisabled;
					}

				}

			}

			// 2. selected how to
			else if (selectedMenu == 2) {
				
				if (Input.GetButtonUp("Start_1")) {
					selectedMenu = 0;
				}

			}

			// 3. selected credits
			else if (selectedMenu == 3) {

				if (Input.GetButtonUp("Start_1")) {
					selectedMenu = 0;
				}

			}

			// 4. selected exit
			else if (selectedMenu == 4) {
				// TODO: Fix quit
				Application.Quit ();

			}
		}
	}

	void OnGUI() {


		if (!start) {
			// 0: nothing is selected, draw the main menu

			if (selectedMenu == 0) {
				DrawMainMenu ();
			}

			else if (selectedMenu == 1) {
				DrawCharacterSelection ();
			}

			else if (selectedMenu == 2) {
				DrawHowtoScreen ();
			}

			else if (selectedMenu == 3) {
				DrawCreditsScreen ();
			}

			else if (selectedMenu == 4) {
				// Exit
			}

		}

		else if (start) {
			// Load level
			Debug.Log("Load level! Player 1 as animal #" + players[0]);
			// Application.LoadLevel ("Level");
		}


	}

	void DrawMainMenu() {

		// Start menu
		// Start game, start = true, change scene to Level
		float padding = guiheight / 100.0f;
		int[] selectState = new int[] {0, 0, 0, 0};

		// TODO: Draw a background: Main menu

		//////// BEGIN GUI MAIN MENU
		GUI.BeginGroup(new Rect(0, 0, guiwidth, guiheight));

		GUI.DrawTexture (new Rect(0, 0, guiwidth, guiheight), startScreenBG);

		// Draw start game button
		scale.x = menuItem_Start[0].width * mult;
		scale.y = menuItem_Start[0].height * mult;
		pos.x = (guiwidth/2) - (scale.x/2);
		pos.y = (guiheight/2) - (scale.y/2);

		if (menuState == 1)
			selectState [0] = 1;
		else
			selectState [0] = 0;


		if (menuState == 2)
			selectState [1] = 1;
		else
			selectState [1] = 0;


		if (menuState == 3)
			selectState [2] = 1;
		else
			selectState [2] = 0;


		if (menuState == 4)
			selectState [3] = 1;
		else
			selectState [3] = 0;


		GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), menuItem_Start[selectState[0]]);

		// Draw how to button
		scale.x = menuItem_HowTo [0].width * mult;
		scale.y = menuItem_HowTo [0].height * mult;
		pos.x = (guiwidth/2) - (scale.x/2);
		GUI.DrawTexture (new Rect (pos.x, pos.y + scale.y * 0.33f + padding * mult * 0.33f, scale.x, scale.y), menuItem_HowTo [selectState[1]]);

		// Draw credits button
		scale.x = menuItem_Credits [0].width * mult;
		scale.y = menuItem_Credits [0].height * mult;
		pos.x = (guiwidth/2) - (scale.x/2);
		GUI.DrawTexture (new Rect (pos.x, pos.y + scale.y * 0.66f + padding * mult * 0.66f, scale.x, scale.y), menuItem_Credits [selectState[2]]);

		// Draw exit button
		scale.x = menuItem_Exit [0].width * mult;
		scale.y = menuItem_Exit [0].height * mult;
		pos.x = (guiwidth/2) - (scale.x/2);
		GUI.DrawTexture (new Rect (pos.x, pos.y + scale.y * 0.99f + padding * mult * 0.99f, scale.x, scale.y), menuItem_Exit [selectState[3]]);

		GUI.EndGroup ();

	}

	void DrawCharacterSelection() {

		float padding = guiwidth / 100.0f;
		// int[] selectState = new int[] { 0, 0, 0, 0, 0 };

		//////// BEGIN GUI CHAR SELECTION
		GUI.BeginGroup(new Rect(0, 0, guiwidth, guiheight));

		GUI.DrawTexture (new Rect(0, 0, guiwidth, guiheight), charSelectBG);

		// TODO: Draw a background: Char selection

		scale.x = charItem_Giraffe [0].width * mult;
		scale.y = charItem_Giraffe [0].height * mult;
		pos.y = (guiheight / 2) - (scale.y / 2);
		pos.x = (guiwidth / 2) - (scale.x * 5 / 2);
		GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), charItem_Giraffe [0]);

		scale.x = charItem_Peacock [0].width * mult;
		scale.y = charItem_Peacock [0].height * mult;
		pos.y = (guiheight/2) - (scale.y/2);
		GUI.DrawTexture(new Rect(pos.x + scale.x + padding * mult, pos.y, scale.x, scale.y), charItem_Peacock[0]);

		scale.x = charItem_Hippo [0].width * mult;
		scale.y = charItem_Hippo [0].height * mult;
		pos.y = (guiheight/2) - (scale.y/2);
		GUI.DrawTexture(new Rect(pos.x + scale.x * 2 + padding * mult * 2, pos.y, scale.x, scale.y), charItem_Hippo[0]);

		scale.x = charItem_Sloth [0].width * mult;
		scale.y = charItem_Sloth [0].height * mult;
		pos.y = (guiheight/2) - (scale.y/2);
		GUI.DrawTexture(new Rect(pos.x + scale.x * 3 + padding * mult * 3, pos.y, scale.x, scale.y), charItem_Sloth[0]);

		scale.x = charItem_Ostrich [0].width * mult;
		scale.y = charItem_Ostrich [0].height * mult;
		pos.y = (guiheight/2) - (scale.y/2);
		GUI.DrawTexture(new Rect(pos.x + scale.x * 4 + padding * mult * 4, pos.y, scale.x, scale.y), charItem_Ostrich[0]);

		for (int i = 0; i < 4; i++) {

			if (player [i].menuState == 1) {
				GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), charItem_Giraffe [1]);
				GUI.DrawTexture (new Rect (pos.x, pos.y, scale.x, scale.y), player [i].selectorTexture);
			} 

			else if (player [i].menuState == 2) {
				GUI.DrawTexture(new Rect(pos.x + scale.x + padding * mult, pos.y, scale.x, scale.y), charItem_Peacock[1]);
				GUI.DrawTexture (new Rect (pos.x + scale.x + padding * mult, pos.y, scale.x, scale.y), player [i].selectorTexture);
			}

			else if (player [i].menuState == 3) {
				GUI.DrawTexture(new Rect(pos.x + scale.x * 2 + padding * mult * 2, pos.y, scale.x, scale.y), charItem_Hippo[1]);
				GUI.DrawTexture (new Rect (pos.x + scale.x * 2 + padding * mult * 2, pos.y, scale.x, scale.y), player [i].selectorTexture);
			}


			else if (player [i].menuState == 4) {
				GUI.DrawTexture(new Rect(pos.x + scale.x * 3 + padding * mult * 3, pos.y, scale.x, scale.y), charItem_Sloth[1]);
				GUI.DrawTexture (new Rect (pos.x + scale.x * 3 + padding * mult * 3, pos.y, scale.x, scale.y), player [i].selectorTexture);
			}


			else if (player [i].menuState == 5) {
				GUI.DrawTexture(new Rect(pos.x + scale.x * 4 + padding * mult * 4, pos.y, scale.x, scale.y), charItem_Ostrich[1]);
				GUI.DrawTexture (new Rect (pos.x + scale.x * 4 + padding * mult * 4, pos.y, scale.x, scale.y), player [i].selectorTexture);
			}

		}

		GUI.EndGroup ();

	}

	void DrawHowtoScreen() {
		//////// BEGIN HOW-TO SCREEN
		GUI.BeginGroup(new Rect(0, 0, guiwidth, guiheight));
		// Draw how to bg
		GUI.DrawTexture(new Rect(0, 0, guiwidth, guiheight), howTo);
		GUI.EndGroup ();
	}

	void DrawCreditsScreen() {
		//////// BEGIN CREDITS SCREEN
		GUI.BeginGroup(new Rect(0, 0, guiwidth, guiheight));
		// Draw credits bg
		GUI.DrawTexture(new Rect(0, 0, guiwidth, guiheight), credits);
		GUI.EndGroup ();
	}
}
