using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class addBadWords : MonoBehaviour {


    public Text goodWordsTxt;
    public Text badWordsTxt;


	// Use this for initialization
	void Start () {

        string formattedGood = "";
        foreach ( string word in SharedObject.goodWords)
        {
            formattedGood += word + "\n";

        }
        goodWordsTxt.text = formattedGood;

        string formattedBad = "";
        foreach (string word in SharedObject.badWords)
        {
            formattedBad += word + "\n";

        }
        badWordsTxt.text = formattedBad;

        

    }
	
}
