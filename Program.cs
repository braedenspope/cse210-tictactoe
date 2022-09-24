﻿/*
Assignment: Tic Tac Toe Program
Name: Braeden Pope
Class: Programming with Classes
*/

using System;
using System.Collections.Generic;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            startGame();
        }
        static void startGame() {
            List<string> board = new List<string> {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
            while (!gameDone(board)) {
                displayBoard(board);
                playGame(board);
            }
        }

        static void displayBoard(List<string> board) {
            for (int i = 0; i < 9; i++) {
                Console.Write(board[i]);
                if ((i + 1) % 3 != 0) {
                    Console.Write(" | ");
                }
                else {
                    Console.Write("\n");
                    Console.WriteLine("- + - + - ");
                }
            }
        }


        static bool is_x_turn(List<string> board) {
            int xSpaces = 0;
            int oSpaces = 0;
            foreach (string space in board) {
                if (space == "X") {
                    xSpaces++;
                }
                else if (space == "O") {
                    oSpaces++;
                }
            }
            if (xSpaces <= oSpaces) {
                return true;
            }
            else {
                return false;
            }
        }

        static void playGame(List<string> board) {
            if (is_x_turn(board)) {
                Console.Write("X's turn to choose a square (1-9): ");
            }
            else {

                Console.Write("O's turn to choose a square (1-9): ");
            }
            string space = Console.ReadLine();
            int spot = int.Parse(space)-1;
            if (board[spot] == "X" || board[spot] == "O") {
                Console.WriteLine("That spot is already filled.");
            }
            else {
                if (is_x_turn(board)) {
                    board[spot] = "X";
                }
                else {
                    board[spot] = "O";
                }
            }
        }

        static bool gameDone(List<string> board) {
            for (int row = 0; row < 3; row++) {
                if (board[row * 3] == (board[row* 3 + 1]) && (board[row * 3] == board[row * 3 + 2])) {
                    Console.Write($"The game was won by {board[row * 3]}");
                    return true;
                }
            }

            for (int col = 0; col < 3; col++) {
                if (board[col] == (board[col + 3]) && (board[col] == board[col + 6])) {
                    Console.Write($"The game was won by {board[col * 3]}");
                    return true;
                }
            }
            
            if (board[4] != " " && (board[0] == board[4] && board[0] == board[8]) || (board[2] == board[4] && board[2] == board[6])) {
                Console.Write($"The game was won by {board[4]}!");
                return true;
            }

            bool tie = true;
            foreach (string space in board) {
                if (space != "X" && space != "O") {
                    tie = false;
                }
            }
            if (tie) {
                Console.Write("The game is a tie!");
                return true;
            }
            return false;
        }
    }
}