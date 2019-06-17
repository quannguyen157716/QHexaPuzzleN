using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {
	int currentScore;
	public Text textScore;
	public  int point,single,doubleC,tripleC;
	
	void Update () {
		UpdateScore();
	}

	public void ScoreSingle()
	{
		currentScore+=single;
	}

	public void ScoreDouble()
	{
		currentScore+=doubleC;
	}

	public void ScoreTriple()
	{
		currentScore+=tripleC;
	}

	public void ScorePoint()
	{
		currentScore+=point;
	}
	void UpdateScore()
	{
		textScore.text=currentScore.ToString();
	}
}
