﻿using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _scoreCounter.OnChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.OnChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = "Score: " + score.ToString();
    }
}