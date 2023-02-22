using UnityEngine;
using System.Collections;

public class IniciarJogo3 : MonoBehaviour {

	static public int difficultyLevel;
	public void LoadByIndex3 (int sceneIndex)
	{	
		gameMenu.difficultyLevel = 3;
		Application.LoadLevel (sceneIndex);
	}
}
