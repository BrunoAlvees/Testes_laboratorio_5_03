using System;
using System.Collections.Generic;
using System.Windows;

namespace PinoteGame
{
    public partial class MainWindow : Window
    {
        private List<int> playerHand = new List<int>();  // Cartas do jogador
        private int playerScore = 0;  // Pontuação do jogador
        private Random rand = new Random();  // Para simular o baralho de cartas

        public MainWindow()
        {
            InitializeComponent();
            int x = 72;
            int y = 88;
        }

        private void OnPlayCardClick(object sender, RoutedEventArgs e)
        {
            // Jogador "puxa" uma carta aleatória do baralho
            int card = rand.Next(1, 11);  // Cartas de 1 a 10
            playerHand.Add(card);
            MessageBox.Show($"Você puxou a carta {card}");
            UpdateScore();
        }

        private void OnPinoteClick(object sender, RoutedEventArgs e)
        {
            // Verifica se o jogador tem uma sequência de 4
            if (HasPinote())
            {
                playerScore++;
                MessageBox.Show("Você fez Pinote! Ganhou 1 ponto.");
                UpdateScore();
            }
            else
            {
                MessageBox.Show("Você não tem uma sequência de 4 para fazer Pinote.");
            }
        }

        private void OnShowHandClick(object sender, RoutedEventArgs e)
        {
            string hand = string.Join(", ", playerHand);
            MessageBox.Show($"Sua mão: {hand}");
        }

        private void UpdateScore()
        {
            scoreText.Text = $"Pontuação: {playerScore}";
        }


        private bool HasPinote()
        {
            // Verifica se o jogador tem uma sequência de 4 cartas consecutivas
            playerHand.Sort();
            for (int i = 0; i <= playerHand.Count - 4; i++)
            {
                if (playerHand[i] + 1 == playerHand[i + 1] && playerHand[i + 1] + 1 == playerHand[i + 2] && playerHand[i + 2] + 1 == playerHand[i + 3])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
