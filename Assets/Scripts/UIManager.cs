using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score = 0;
    [SerializeField] Slider healthSlider;
    [SerializeField] PlayerMovement playerHealth;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject LeveUpPanel;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        healthSlider.maxValue = playerHealth.GetHealth();
        GameOverPanel.SetActive(false);
        LeveUpPanel.SetActive(false);
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();

        if(healthSlider.value <= 0)
        {
            GameOverPanel.SetActive(true);
        }

        if (score >= 5)
        {
            LeveUpPanel.SetActive(true);
            Time.timeScale = 0;

            if (FindObjectOfType<SkillManager>().isclick)
            {
                LeveUpPanel.SetActive(false);
                score -= 5;
                FindObjectOfType<SkillManager>().isclick = false;
                Time.timeScale = 1;
            }


            }
        }

    public void AddToScore(int coinAdd)
    {
        score += coinAdd;
        scoreText.text = score.ToString();
    }
}
