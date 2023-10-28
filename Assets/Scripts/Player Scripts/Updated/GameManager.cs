using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Non-Combat Related Stats")]
    public float collectRange = 1f;

    // Player status variables //
    [Header("Player Upgradable Stats")]
    public float maxHealth = 100f;
    public float currentHealth;
    public float healthRegen = 0f;
    public float dmg = 10f;
    public float dmgDealt = 0f;
    public float armour = 1f;
    public float critChance = 0f;
    public float critDmg = 1.5f;
    public int lvl = 1;
    public float currentExp = 0f;
    public float expNeeded = 1000f;
    public float shootCoolDown = 0f;
    public float startShootCoolDown = 1f;
    public float shootRate = 0f; // The amount subtracted to startShootCoolDown per level (for now)
    public float shootRateLimit = 0.05f;
    public int projectileCount = 1;
    public int projectileSpreadAngle = 20;
    public bool canPierce = false;
    public int numOfPierce = 0;

    // World Time
    [Header("World Time")]
    public float elapsedTime = 0f;
    public int minutes = 0;
    public int seconds = 0;

    // Track num of enemies in scene
    [Header("Spawner")]
    public int numOfEnemies = 0;
    public int initialMaxNumOfEnemies = 15;
    public int currentMaxNumOfEnemies = 0;

    // Store current state of the game
    [Header("Game States")]
    public GameState currentState;
    public GameState previousState;
    public GameObject pauseScreen;
    public GameObject levelUpScreen;
    public GameObject statusScreen;

    [Header("Upgrades")]
    public RandomizeUpgrade randomizeUpgrade;
    public float swordDmg = 1000f;
    public bool hasTakenSword = false;
    public int numOfSwords = 0;
    public float swordDamageRadius = 5.0f;
    public float orbitSpeed = 50f;
    public Elements currentElementType;
    public float explosionRadius = 2f;
    public float explosionDmgMultiplier = 0.5f;
    

    // Different states of the game
    public enum GameState
    {
        Gameplay,
        Paused,
        GameOver,
        LevelUp,
        Status,
        Inventory
    }

    public enum Elements
    {
        None,       // No effect           
        Fire,       // Explodes on hit
        Water,      // Splashes on hit slowing enemies and dealing dmg over time
        Earth,      // Chance to stun 
        Lightning,  // Ricochet or split projectiles on hit
        Wind,       // Adds 'x' number of pierce on projectiles and add a trail of damaging wind behind them
        Ice         // Chance to freeze
    }

    private void Awake()
    {
        // Ensure there's only one instance of GameManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DisableScreens();
    }

    private void Update()
    {
        // Ensure shoot rate never becomes faster than the limit
        // Rounds up/down startShootCoolDown to shootRateLimit
        if (startShootCoolDown <= shootRateLimit)
        {
            startShootCoolDown = shootRateLimit;
        }

        switch (currentState)
        {
            case GameState.Gameplay:
                CheckForPauseAndResume();
                CheckForStatsWindow();
                break;

            case GameState.Paused:
                CheckForPauseAndResume();
                break;

            case GameState.GameOver:
                break;

            case GameState.LevelUp:
                CheckForLevelup();
                break;

            case GameState.Status:
                CheckForStatsWindow();
                break;

            case GameState.Inventory:
                break;

            default:
                Debug.LogWarning("Current State Does Not Exist!");
                break;
        }
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }

    public void PauseGame()
    {
        if(currentState != GameState.Paused)
        {
            previousState = currentState;
            ChangeState(GameState.Paused);
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        if(currentState == GameState.Paused)
        {
            ChangeState(previousState);
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void CheckForPauseAndResume()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentState == GameState.Gameplay)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void CheckForLevelup()
    {
        Time.timeScale = 0f;
        levelUpScreen.SetActive(true);
        
    }

    // Call this once per level-up on PlaterStats script
    public void Shuffle()
    {
        randomizeUpgrade.ShuffleUpgrades();
    }

    private void DisableScreens()
    {
        pauseScreen.SetActive(false);
        levelUpScreen.SetActive(false);
        statusScreen.SetActive(false);
    }

    public void CheckForStatsWindow()
    {
        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentState == GameState.Gameplay)
            {
                OpenStatsWindow();
            }
            else
            {
                CloseStatsWindow();
            }
        }
    }

    private void OpenStatsWindow()
    {
        if(currentState != GameState.Status)
        {
            previousState = currentState;
            ChangeState(GameState.Status);
            statusScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void CloseStatsWindow()
    {
        if (currentState == GameState.Status)
        {
            ChangeState(previousState);
            statusScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
