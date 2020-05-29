using UnityEngine;

public class Spellcaster : MonoBehaviour {
    [SerializeField] GameObject projectile, spellSpawnPoint;
    
    public void Cast() {
        Instantiate(projectile, spellSpawnPoint.transform.position, transform.rotation);
        return;
    }    
}
