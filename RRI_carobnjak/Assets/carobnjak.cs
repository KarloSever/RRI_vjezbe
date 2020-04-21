using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class carobnjak : MonoBehaviour {

    int min;
    int max;
    int pokusaj;
    int maxBrojPoksuaja = 10;

    public Text text;
    public Text textP;
    

    void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        max = 1001;
        min = 1;
        NextPokusaj();
    }
    public void PokusajLower()
    {
        max = pokusaj;
        NextPokusaj();
    }
    public void pokusajHigher()
    {
        min = pokusaj;
        NextPokusaj();
    }
    void NextPokusaj()
    {
        maxBrojPoksuaja = maxBrojPoksuaja - 1;
        if(maxBrojPoksuaja<=0)
        {
            //Application.LoadLevel("Win");
            SceneManager.LoadScene(2);
        }
        else
        {
        pokusaj = Random.Range(min, max + 1);
        text.text = pokusaj.ToString();
        textP.text = maxBrojPoksuaja.ToString();
        }
    }

}
