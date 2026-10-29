using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Caro[] caros;
    public Transform caroContainer;
    public GameObject endPopup;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        caros = caroContainer.GetComponentsInChildren<Caro>();
        ResetBoard();
    }

    public void ResetBoard()
    {
        for (int i = 0; i < caros.Length; i++)
        {
            caros[i].Fill(0);
        }
    }    

    public void HandleBoard(int player)
    {
        int[,] board = GetCurrentBoard();
        int winner = CheckWinner(board);

        switch(winner)
        {
            case -1:
                Debug.Log("Hòa");
                break;
            case 0:
                if(player == 1) OpponentPlayRandom();
                break;
            case 1:
                Debug.Log("X thắng");
                break;
            case 2:
                Debug.Log("O thắng");
                break;
        };    

        if(winner != 0)
        {
            endPopup.SetActive(true);
        }    
    }    

    public void OpponentPlayRandom()
    {
        List<int> empty = new List<int>();
        for (int i = 0; i < caros.Length; i++)
        {
            if(caros[i].currentValue == 0)
            {
                empty.Add(i);
            }
        }
        //
        int rand = Random.Range(0, empty.Count);
        caros[empty[rand]].Fill(2);
        HandleBoard(2);
    }    

    public int[,] GetCurrentBoard()
    {
        int[,] board = new int[3, 3];

        for(int i = 0; i < caros.Length; i++)
        {
            int x = i % 3;
            int y = i / 3;
            board[x, y] = caros[i].currentValue;
        }    

        return board;
    }    

    public int CheckWinner(int[,] board)
    {
        // Kiểm tra hàng ngang và hàng dọc
        for (int i = 0; i < 3; i++)
        {
            // Hàng ngang
            if (board[i, 0] != 0 &&
                board[i, 0] == board[i, 1] &&
                board[i, 1] == board[i, 2])
                return board[i, 0];

            // Hàng dọc
            if (board[0, i] != 0 &&
                board[0, i] == board[1, i] &&
                board[1, i] == board[2, i])
                return board[0, i];
        }

        // Đường chéo chính
        if (board[0, 0] != 0 &&
            board[0, 0] == board[1, 1] &&
            board[1, 1] == board[2, 2])
            return board[0, 0];

        // Đường chéo phụ
        if (board[0, 2] != 0 &&
            board[0, 2] == board[1, 1] &&
            board[1, 1] == board[2, 0])
            return board[0, 2];

        // Kiểm tra còn ô trống không
        foreach (int cell in board)
        {
            if (cell == 0)
                return 0;
        }

        return -1; // Hòa
    }
}
