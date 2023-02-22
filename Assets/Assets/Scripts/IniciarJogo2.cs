using UnityEngine;
using System.Collections;

public class IniciarJogo2 : MonoBehaviour {

	static public int difficultyLevel;

	public void LoadByIndex2 (int sceneIndex)
	{	
		gameMenu.difficultyLevel = 2;
		Application.LoadLevel (sceneIndex);
	}
}
