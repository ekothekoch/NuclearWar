using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum GamePhases{Player1,Player2,Player3,Player4}
public  class GameManager : MonoBehaviour
{
    public GamePhases gamePhase;
    public  Player[] players;
    // Start is called before the first frame update
    void Start()
    {
        gamePhase = GamePhases.Player1;
    }

    // Update is called once per frame
    void Update()
    {
        DisableOthers();
        //FindPhase();
      
    }
    void DisableOthers()
    {
        if (gamePhase == GamePhases.Player1)
        {
            
            for(int x=0; x<players.Length;x++)
            {
                if (players[x].isim == "1")
                {
                    players[x].gameObject.GetComponentInChildren<CanvasGroup>().alpha = 1;
                    continue;
                }
                
                    players[x].gameObject.GetComponentInChildren<CanvasGroup>().alpha = 0;
                 
                
                for (int y=0; y<players[x].buttons.Length;y++)
                {

                    players[x].buttons[y].interactable = false;
                }
            }

        players[3].played = false;

        FindPhase();
        //Debug.Log(gamePhase);
    }
        if (gamePhase == GamePhases.Player2)
        {
            
            for (int x = 0; x < players.Length; x++)
            {
                if (players[x].isim == "2")
                {
                    players[x].gameObject.GetComponentInChildren<CanvasGroup>().alpha = 1;
                    continue;
                }
                   
                players[x].gameObject.GetComponentInChildren<CanvasGroup>().alpha = 0;

                for (int y = 0; y < players[x].buttons.Length; y++)
                    {
                        players[x].buttons[y].interactable = false;
                    }
                
            }
            players[0].played = false;

            FindPhase();
           // Debug.Log(gamePhase);


        }
         if (gamePhase == GamePhases.Player3)
        {
            for (int x = 0; x < players.Length; x++)
            {
                if (players[x].isim == "3")
                {
                    players[x].gameObject.GetComponentInChildren<CanvasGroup>().alpha = 1;
                    continue;
                   
                }
                players[x].gameObject.GetComponentInChildren<CanvasGroup>().alpha = 0;
                for (int y = 0; y < players[x].buttons.Length; y++)
                {
                    players[x].buttons[y].interactable = false;
                }

            }
            players[1].played = false;
            FindPhase();
           // Debug.Log(gamePhase);
        }
        if (gamePhase == GamePhases.Player4)
        {
            for (int x = 0; x < players.Length; x++)
            {
                if (players[x].isim == "4")
                {
                    players[x].gameObject.GetComponentInChildren<CanvasGroup>().alpha = 1;
                    continue;
                }
                players[x].gameObject.GetComponentInChildren<CanvasGroup>().alpha = 0;
                for (int y = 0; y < players[x].buttons.Length; y++)
                {
                    players[x].buttons[y].interactable = false;
                }

            }

            players[2].played = false;
            FindPhase();
            //Debug.Log(gamePhase);
        }
    }
    void FindPhase()
    {
        if (gamePhase == GamePhases.Player1)
        {
            if (players[0].played)
            {
                for (int y = 0; y < players[1].buttons.Length; y++)
                    players[1].buttons[y].interactable = true;

                gamePhase = GamePhases.Player2;
            }
        }

        if (gamePhase == GamePhases.Player2)
        { if(players[1].played)
                {
                for (int y = 0; y < players[2].buttons.Length; y++)
                    players[2].buttons[y].interactable = true;

                gamePhase = GamePhases.Player3;
            }
        }
        if (gamePhase == GamePhases.Player3)
        {
            if (players[2].played)
            {
                for (int y = 0; y < players[3].buttons.Length; y++)
                    players[3].buttons[y].interactable = true;
                gamePhase = GamePhases.Player4;
            }
        }
        if (gamePhase == GamePhases.Player4)
        {
            if (players[3].played)
            {
                for (int y = 0; y < players[0].buttons.Length; y++)
                    players[0].buttons[y].interactable = true;

                gamePhase = GamePhases.Player1;
               
            }
        }
    }
    }

