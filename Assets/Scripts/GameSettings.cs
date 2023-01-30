using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu, QuizPanel;
    [SerializeField] PlayerController player;
    [SerializeField] Slider bgMusicSlider, fxMusicSlider;
    [SerializeField] AudioSource bgMusic, clickFx, correctfx, wrongfx, Victoryfx;
    [SerializeField] EnemyController[] enemies;
    [SerializeField] Button Quizbtn;
    [SerializeField] Image FilipinoBtnBg, EnglishBtnBg;
    public bool ChangeInLanguage = false;

    public void Start()
    {
        bgMusicSlider.value = player.bgMusicVolume;
        fxMusicSlider.value = player.fxMusicVolume;

        bgMusic.volume = player.bgMusicVolume;
        clickFx.volume = player.fxMusicVolume;
        if (!player.isOnBase)
        {
            player.AttackFx.volume = player.fxMusicVolume;
            correctfx.volume = player.fxMusicVolume;
            wrongfx.volume = player.fxMusicVolume;
            Victoryfx.volume = player.fxMusicVolume;
            for (var i = 0; i < enemies.Length; i++)
            {
                enemies[i].SlimeMovementFx.volume = player.fxMusicVolume;
                enemies[i].SlimeAttackFx.volume = player.fxMusicVolume;
            }
        }
        else
        {
            if (player.language == "english")
            {
                EnglishBtnBg.color = Color.gray;
                FilipinoBtnBg.color = Color.white;
            }
            else
            {
                EnglishBtnBg.color = Color.white;
                FilipinoBtnBg.color = Color.gray;
            }
        }
        player.MovementFx.volume = player.fxMusicVolume;
    }

    public void RetryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToTitleScreen()
    {
        player.SavePlayer();
        SceneManager.LoadScene("Start Menu");
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        player.SavePlayer();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Base");
    }

    public void BgMusicVolumeOnChange()
    {
        player.bgMusicVolume = bgMusicSlider.value;
        bgMusic.volume = player.bgMusicVolume;
    }

    public void FxVolumeOnChange()
    {
        player.fxMusicVolume = fxMusicSlider.value;
        clickFx.volume = player.fxMusicVolume;
        player.MovementFx.volume = player.fxMusicVolume;
        if (!player.isOnBase)
        {
            player.AttackFx.volume = player.fxMusicVolume;
            correctfx.volume = player.fxMusicVolume;
            wrongfx.volume = player.fxMusicVolume;
            Victoryfx.volume = player.fxMusicVolume;
            for (var i = 0; i  < enemies.Length; i++)
            {
                enemies[i].SlimeMovementFx.volume = player.fxMusicVolume;
                enemies[i].SlimeAttackFx.volume = player.fxMusicVolume;
            }
        }
    }

    public void clickSoundFx()
    {
        clickFx.Play();
    }

    private void Update()
    {
        if (player.StageFinished["House"] == true && player.StageFinished["Community"] == true && player.StageFinished["School"] == true && player.StageFinished["Park"] == true)
        {
            QuizPanel.SetActive(true);
            Application.runInBackground = true;
        }
    }

    public void EnglishButton()
    {
        player.language = "english";
        ChangeInLanguage = true;
        Debug.Log("Settings"+player.language);
        FilipinoBtnBg.color = Color.white;
        EnglishBtnBg.color = Color.gray;
    }

    public void FilipinoButton()
    {
        player.language = "filipino";
        ChangeInLanguage = true;
        EnglishBtnBg.color = Color.white;
        FilipinoBtnBg.color = Color.gray;
    }
}
