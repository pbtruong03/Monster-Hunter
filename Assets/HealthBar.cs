using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] Gradient healthGradient;
    [SerializeField] TextMeshProUGUI healthText;
    private float maxHealth;
    private float currentHealth;

    [SerializeField] private Image healthField;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = player.MaxHealth;
        currentHealth = player.getHealth();
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        float tmpHealth = player.getHealth();
        if(currentHealth != tmpHealth) {
            currentHealth = tmpHealth;
            UpdateHealthBar();
        }
    }
    // Update HealthBar UI status
    void UpdateHealthBar()
    {
        healthText.text = $"HP: {currentHealth}/{maxHealth}";
        float targetFill = currentHealth / maxHealth;
        healthField.fillAmount = targetFill;
        healthField.color = healthGradient.Evaluate(targetFill);
    }
}
