using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class GameController : MonoBehaviour {
	
	public GameObject bossHazard;

	//hazard for Kamikazeship
	public float waveWaitPong;
	public float spawnWaitPong;
	public float startWaitPong;
	public GameObject hazardPong;
	public	int countPongWave; 
	public int maxPongWave;

	//hazard for Kamikazeship
	public float waveWaitKamikaze;
	public float spawnWaitKamikaze;
	public float startWaitKamikaze;
	public GameObject hazardKamikaze;
	public	int countKamikazeWave; 
	public int maxKamikazeWave;

	//hazard for Orangeship
	public float waveWaitOrange;
	public float spawnWaitOrange;
	public float startWaitOrange;
	public GameObject hazardOrange;
	public	int countOrangeWave; 
	public int maxOrangeWave;

	//hazard for Greenship
	public float waveWaitGreen;
	public float spawnWaitGreen;
	public float startWaitGreen;
	public GameObject hazardGreen;
	public	int countGreenWave; 
	public int maxGreenWave;

	//hazard for blueship
	public float waveWaitBlue;
	public float spawnWaitBlue;
	public float startWaitBlue;
	public GameObject hazardBlue;
	public	int countBlueWave; 
	public int maxBlueWave;

	//hazard for aerolito
	public float startWait;
	public float waveWait;
	public float spawnWait;
	public GameObject hazard;
	public int hazardCount ;
	public Vector3 spawnValues;


	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText ultraText;
	
	private bool gameOver;
	private bool restart;
	private int score;
	private int scoreUltra;

	private IEnumerator coWaves;
	private IEnumerator coWavesBlue;
	private IEnumerator coWavesGreen;
	private IEnumerator coWavesOrange;
	private IEnumerator coWavesKamikaze;
	private IEnumerator coWavesPong;

	private int scoreMax;
	private int difficultyLevel;

	public AudioSource mainAudioClip;
	public AudioSource bossAudioClip;

	bool boss;
	void Start ()
	{
		boss = false;
		mainAudioClip.Play();
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		ultraText.text = "";
		score = 0;
		UpdateScore ();
		coWaves = SpawnWaves ();
		coWavesBlue = SpawnWavesBlueShip ();
		coWavesGreen = SpawnWavesGreenShip ();
		coWavesOrange = SpawnWavesOrangeShip ();
		coWavesKamikaze = SpawnWavesKamikazeShip ();
		coWavesPong = SpawnPong ();
		scoreUltra = 2000;

		int diff = 0;

		if (gameMenu.difficultyLevel == 1) {
			scoreMax = 4000;
			diff = 4;
			//hazard for Kamikazeship

			
			//hazard for aerolito
			spawnWait = 2;
		}
		if (gameMenu.difficultyLevel == 2) {
			scoreMax = 5500;
			
			diff = 2;
			//hazard for aerolito
			spawnWait = 3;
		}
		if (gameMenu.difficultyLevel == 3) {
			scoreMax = 7000;
			
			diff = 1;
		}
		waveWaitKamikaze += diff;
		spawnWaitKamikaze += diff;
		startWaitKamikaze += diff;
		
		
		//hazard for Orangeship
		waveWaitOrange += diff;
		spawnWaitOrange += diff;
		startWaitOrange += diff;
		
		//hazard for Greenship
		waveWaitGreen += diff;
		spawnWaitGreen += diff;
		startWaitGreen += diff;
		
		//hazard for blueship
		waveWaitBlue += diff;
		spawnWaitBlue += diff;
		startWaitBlue += diff;

		startGame ();
	}


	void Update ()
	{
		if(!MovePlayer.ultra)
			ultraText.text = "";

		if (restart)
		{
			if (Input.GetButton ("Fire3"))
			{
				Application.LoadLevel (Application.loadedLevel);
			}

		}

		if (gameOver)
		{
			stopRotines();
			restartText.text = "Pressione 'L' para reiniciar ou 'ESC' para sair!";
			restart = true;

			if (Input.GetButton ("Cancel"))
			{
				Back();
			}
		}

		if (score >= scoreMax && !boss) {
			boss = true;			
			bossAudioClip.Play ();
			stopRotines();
		}

		if (score >= scoreUltra) {
			MovePlayer.ultra = true;
			scoreUltra += 3000;
			ultraText.text = "ULTRA CARREGADO!";

		} 

	}

	void startGame(){

		StartCoroutine (coWaves);
		StartCoroutine (coWavesBlue);
		StartCoroutine (coWavesGreen);
		StartCoroutine (coWavesOrange);
		StartCoroutine (coWavesKamikaze);
	}
	 
	public void Back()
	{
		
		Application.LoadLevel (0);
	}

	void stopRotines(){
		StopCoroutine(coWaves);
		StopCoroutine(coWavesBlue);
		StopCoroutine(coWavesGreen);
		StopCoroutine(coWavesOrange);
		StopCoroutine(coWavesKamikaze);
		mainAudioClip.Stop ();
		if(!gameOver)
		spawnBoss ();
	}


	void spawnBoss(){
		bossAudioClip.Play() ;
		Vector3 spawnPosition = new Vector3 (0, spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (bossHazard, spawnPosition, spawnRotation);
		StartCoroutine (coWavesPong);

	}

	IEnumerator SpawnPong ()
	{
		yield return new WaitForSeconds (startWaitPong);
		while (true)
		{
			
			for (int i = 0; i < countPongWave; i++)
			{
				Vector3 spawnPosition = new Vector3 (bossHazard.transform.position.x , bossHazard.transform.position.y-9, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazardPong, spawnPosition,spawnRotation);
				yield return new WaitForSeconds (spawnWaitPong);
				
			}
			yield return new WaitForSeconds (waveWaitPong);	
			
			
		}
		
		
	}
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{


				for(int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);	
			
		}
	}

	IEnumerator SpawnWavesBlueShip ()
	{
		yield return new WaitForSeconds (startWaitBlue);
		while (true)
		{

			for (int i = 0; i < countBlueWave; i++)
				{
					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (hazardBlue, spawnPosition,spawnRotation);
					yield return new WaitForSeconds (spawnWaitBlue);

				}
				yield return new WaitForSeconds (waveWaitBlue);	
					
					
			}
			

	}

	IEnumerator SpawnWavesGreenShip ()
	{
		yield return new WaitForSeconds (startWaitGreen);
		while (true)
		{
			
			for (int i = 0; i < countGreenWave; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazardGreen, spawnPosition,spawnRotation);
				yield return new WaitForSeconds (spawnWaitGreen);
				
			}
			yield return new WaitForSeconds (waveWaitGreen);	
			
			
		}
		
		
	}
	IEnumerator SpawnWavesOrangeShip ()
	{
		yield return new WaitForSeconds (startWaitOrange);
		while (true)
		{
			
			for (int i = 0; i < countOrangeWave; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y-10, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazardOrange, spawnPosition,spawnRotation);
				yield return new WaitForSeconds (spawnWaitOrange);
				
			}
			yield return new WaitForSeconds (waveWaitOrange);	
			
			
		}
		
		
	}

	IEnumerator SpawnWavesKamikazeShip ()
	{
		yield return new WaitForSeconds (startWaitKamikaze);
		while (true)
		{
			
			for (int i = 0; i < countKamikazeWave; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y-10, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazardKamikaze, spawnPosition,spawnRotation);
				yield return new WaitForSeconds (spawnWaitKamikaze);
				
			}
			yield return new WaitForSeconds (waveWaitKamikaze);	
			
			
		}
		
		
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Pontos: " + score;
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
