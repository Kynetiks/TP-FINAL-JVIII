using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Instance pour y accéder globalement
    public TextMeshProUGUI scoreText;    // Référence au texte UI
    private int score = 0;               // Variable pour stocker le score

    void Start()
    {
        UpdateScoreText();
    }

    // Méthode pour ajouter des points au score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Mettre à jour le texte UI avec le score actuel
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
