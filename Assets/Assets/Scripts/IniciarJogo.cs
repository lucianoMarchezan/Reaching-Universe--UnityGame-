using UnityEngine;
using System.Collections;

public class IniciarJogo : MonoBehaviour
{
	static public int difficultyLevel;
	public void LoadByIndex (int sceneIndex)
	{	
		gameMenu.difficultyLevel = 1;
		Application.LoadLevel (sceneIndex);
	}
}
