using UnityEngine;

public class TreasureHealth : MonoBehaviour {
    [SerializeField] 
    int health = 2;
    
    [Tooltip("Min health in position 0, max health in max position.")]
    [SerializeField] 
    Sprite[] healthSprites;

    void Start() {
        UpdateHeartSprite();
    }

    public void Hurt() {
        health -= 1;
        if (health < 0) {
            FindObjectOfType<LevelController>().GameOver();
        }
        UpdateHeartSprite();
    }

    void UpdateHeartSprite() {
        if (health < healthSprites.Length && health >= 0) GetComponent<SpriteRenderer>().sprite = healthSprites[health];
    }

}
