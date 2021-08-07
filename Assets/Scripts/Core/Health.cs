using UnityEngine;

public class Health : MonoBehaviour, ITakeDamage {

    [SerializeField] private float maxHealth = 50f;
    public float currentHealth; //for prototyping
    [SerializeField] private AudioClip audioClip = null;

    private bool isDead = false;
    private Animator animator;
    private AudioSource audioSource;
    private DisplayFloatingText displayFloatingText;
    private LootManager lootManager;
    private DisplayScore displayScore;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        displayFloatingText = GetComponent<DisplayFloatingText>();
        lootManager = GameObject.Find("LootManager").GetComponent<LootManager>();
        displayScore = GameObject.FindObjectOfType<DisplayScore>();
    }

    public void TakeDamage(float damage) {

        if(currentHealth >= 1 && !isDead) {
            //currentHealth -= damage;
            currentHealth = Mathf.Max(currentHealth - damage, 0);
            if(displayFloatingText != null) {
                displayFloatingText.FloatingText(currentHealth);
            }
        }

        if(currentHealth <= 0) {
            Die(); 
        }

    }

    private void Die() {
        if(isDead) { return; }
        isDead = true;

        if(animator != null) {
            animator.SetTrigger("isDead");
        }

        displayScore.DisplayKillScore();
        DeathSound();
        SpawnLoot();
    }

    private void DeathSound() {
        if(audioClip == null) { return; }
        if(audioSource == null) { return; }

        audioSource.clip = audioClip;
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.Play();
    }

    //only for testing
    private void SpawnLoot() {
        SpawnLoots spawnLoots = GetComponent<SpawnLoots>();

        if(lootManager != null) { 
            lootManager.SpawnLootPoint(transform.position);   //prototyping
        }

        if(spawnLoots != null) {
            StartCoroutine(GetComponent<SpawnLoots>().StartSpawn()); // testing
        }
    }

    public bool GetIsDead() {
        return isDead;
    }

    public float GetHealthPercentage() {
        return (currentHealth / maxHealth);
    }


}
