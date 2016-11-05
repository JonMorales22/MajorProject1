using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoresScript2 : MonoBehaviour {

	const int LIMIT = 10;
	public GameObject gObj; //<--- Holds the EnterButton, which holds InputScript which is where we retrive the player's initials
	public GameObject textHolder; //<--- GameObject that holds the GUIText for displaying Names and Scores

	private string[] nameArray = new string[LIMIT];
	private int[] scoreArray = new int[LIMIT];
	private int score=0;
	private string initials = "";
	private int numOfPlayers = 0;

	/* We either get to this screen from the GameScreen or the WelcomScreen:
	 *	1.	If we came from GameScreen, that means we have a CurrentScore and
	 *		a.	Grab info from PlayerPrefs
	 *		b.	Check to see if CurrentScore makes the cut for high scores
	 *	2.	If we came form WelcomeScreen, then we just have to display the stuff in PlayPrefs */
	void Start () {
		if (PlayerPrefs.HasKey ("247127CurrentPlayerScore")) {
			Debug.Log("HasKey");
			score = PlayerPrefs.GetInt ("247127CurrentPlayerScore");
			getPlayerPrefs ();
			checkPlayerPrefs ();
		} 
		else
		{
			Debug.Log("DoesntHaveKey");
			gObj.GetComponent<InputScript> ().activeButtons ();
			getPlayerPrefs ();
			displayText ();
		}
	}
		
	// Retrieves the information from PlayerPrefs and stores it in nameArray and scoreArray.
	// We keep track of the number of Players+Scores in playerprefs to make things easier later on.
	void getPlayerPrefs()
	{
		for (int i = 0; i < LIMIT; i++) {
			if (PlayerPrefs.HasKey ("247127Player" + i)) {
				numOfPlayers++;
				nameArray [i] = PlayerPrefs.GetString (("247127Player" + i));
				scoreArray [i] = PlayerPrefs.GetInt (("247127Score" + i));
			}
		}
	}

	// Checks the info we got from PlayerPrefs, which is stored in nameArray and scoreArray
	void checkPlayerPrefs()
	{
		if (numOfPlayers < 10) {
			StartCoroutine("getUserInput",numOfPlayers);
			return;
		}
		for (int i = 0; i < LIMIT; i++) {
			if (score > scoreArray [i]) {
				StartCoroutine("getUserInput2",i);
				return;
			}
		}
		gObj.GetComponent<InputScript> ().activeButtons ();
		displayText ();
	}
	/// <summary>
	/// I have 2 separate coroutines for getting input, I wanted to find a better solution, but simplicity>elegance.
	/// In this coroutine, we wait for the user's input, and then we just add it into our array
	/// </summary>
	/// <param name="index">The place we want to add our playerName and playerScore in the array </param>
	IEnumerator getUserInput(int index)
	{
		var button = gObj.GetComponent<InputScript> ();
		yield return new WaitUntil(() => button.flag);
		initials = button.initials;
		nameArray [index] = initials;
		scoreArray [index] = score;
		sortArrays ();
	}

	//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	//**************** USED WHEN THERE ARE 10 SCORES IN PLAYER PREFS **********************//
	/// <summary>
	/// In this coroutine we wait until we get the user's input, and instead of randomly adding it to our array,
	/// we have to place it where it belongs and shift the rest of the stuff in the array down.
	/// </summary>
	IEnumerator getUserInput2(int index)
	{
		var button = gObj.GetComponent<InputScript> ();
		yield return new WaitUntil(() => button.flag);
		initials = button.initials;
		scoreArray = shiftScoreArray(index);
		nameArray = shiftNameArray(index);
		saveArray (numOfPlayers);
	}

	int [] shiftScoreArray(int index) {
		int[] newArray = new int[LIMIT];
		for (int i = 0; i < LIMIT; i++) {
			if (i < index) {
				newArray [i] = scoreArray [i];
			} else if (i == index) {
				newArray [i] = score;
			} else { //i>index
				newArray [i] = scoreArray [i-1];
			}
		}
		return newArray;
	}

	string[] shiftNameArray(int index){
		string[] newArrayS = new string[LIMIT];
		for (int i = 0; i < LIMIT; i++) {
			if (i < index) {
				newArrayS [i] = nameArray [i];
			} else if (i == index) {
				newArrayS [i] = initials;
			} else {
				newArrayS [i] = nameArray [i-1];
			}
		}
		return newArrayS;


	}

	void sortArrays()
	{
		for (int i = 0; i < LIMIT; i++) {
			for (int x = 0; x < LIMIT; x++) {
				if (scoreArray [x] < scoreArray [i]) {
					int temp = scoreArray [x];
					string tempS = nameArray [x];
					scoreArray [x] = scoreArray [i];
					nameArray [x] = nameArray [i];
					scoreArray[i] = temp;
					nameArray [i] = tempS;				
				}

			}
		}
		saveArray (numOfPlayers+1);

	}

	void saveArray(int index) {
		for (int i = 0; i < index; i++) {
			if (nameArray [i] != null) {
				PlayerPrefs.SetString ("247127Player" + i, nameArray [i]);
				PlayerPrefs.SetInt ("247127Score" + i, scoreArray [i]);
			}
		}
		printArray ();
		displayText ();
	}

	void displayText(){
		Text[] textArray = textHolder.GetComponentsInChildren<Text> ();
		for (int i = 0; i < LIMIT; i++) {
			if(PlayerPrefs.HasKey("247127Player" + i))
				textArray[i].text = (i+1) + ". Name: " +PlayerPrefs.GetString ("247127Player" + i) + " Score: " +PlayerPrefs.GetInt ("247127Score" + i).ToString();
		}
	}

	void printArray(){
		for (int i = 0; i < LIMIT; i++) {
			Debug.Log ("NameArray["+i+"] = " + nameArray [i] + "\nScoreArray[i] = " + scoreArray [i]);
		}
	}

}
