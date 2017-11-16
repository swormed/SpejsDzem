using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class game_manager : MonoBehaviour {

	public int enemyPoints = 1;
	int destroyedEnemies = 0;
	int score = 0;
	public Text textScore;


	public int zycia = 5;
	int actualShips;
	public Text lifes;

	void Start()
	{
        //actualShips = zycia;
        lifes.text = zycia.ToString();
	}

	public void AddScore() 
	{
		//score += destroyedEnemies*10;
		destroyedEnemies++;
		score += destroyedEnemies*enemyPoints;
		textScore.text = score.ToString ();

	}

	public void Lifes()
	{
		zycia--;
		lifes.text = zycia.ToString ();
		//actualShips--;
		if (actualShips == 0) 
		{
		//koniec gry
		}
		//lifes.text = actualShips.ToString ();
	}
    public void PlusPlus()
    {
        zycia++;
        lifes.text = zycia.ToString ();
        //actualShips--;
        
        //lifes.text = actualShips.ToString();
    }


}
