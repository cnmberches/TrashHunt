using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleMenuController : MonoBehaviour
{
    [SerializeField] AudioSource bgMusic, clickFx;
    [SerializeField] Slider bgMusicSlider, fxMusicSlider;
    [SerializeField] TMP_Text Continue;
    [SerializeField] GameObject OnStartLanguagePanel;
    [SerializeField] Image FilipinoBtnBg, EnglishBtnBg;

    private SaveData data;
    private float bgMusicVolume, fxMusicVolume = 1;
    private bool isTutorialFinished = false;

    private void Awake()
    {
        data = SaveSystem.LoadPlayer();

        if (data == null)
        {
            //Create a save data if save data does not exist
            SaveSystem.OnStart();
            data = SaveSystem.LoadPlayer();
        }
        else
        {
            //load the volume of background music and sound effects 
            bgMusicVolume = data.bgMusicVolume;
            fxMusicVolume = data.fxMusicVolume;
            isTutorialFinished = data.isTutorialFinished;

            if(isTutorialFinished)
            {
                Continue.text = "Continue";
            }
        }
    }

    private void Start()
    {
        if(data.language == null)
        {
            OnStartLanguagePanel.SetActive(true);
        }
        else if(data.language.Equals("filipino"))
        {
            FilipinoBtnBg.color = Color.black;
        }
        else if(data.language.Equals("english"))
        {
            EnglishBtnBg.color = Color.black;
        }

        //set the values for slider and volumes
        bgMusicVolume = data.bgMusicVolume;
        fxMusicVolume = data.fxMusicVolume;
        bgMusicSlider.value = bgMusicVolume;
        fxMusicSlider.value = fxMusicVolume;
        bgMusic.volume = bgMusicVolume;
        clickFx.volume = fxMusicVolume;
    }

    public void QuitButton()
    {
        //quit the game
        SaveSystem.SaveFromTitleScreen(data, bgMusicVolume, fxMusicVolume);
        Application.Quit();
    }

    public void StartGame()
    {
        SaveSystem.SaveFromTitleScreen(data, bgMusicVolume, fxMusicVolume);

        if (!isTutorialFinished)
        {
            SceneManager.LoadScene("Introduction");
        }
        else
        {
            SceneManager.LoadScene("Base");
        }
    }

    public void clickSoundFx()
    {
        clickFx.Play();
    }
    public void BgMusicVolumeOnChange()
    {
        bgMusicVolume = bgMusicSlider.value;
        bgMusic.volume = bgMusicVolume;
    }
    public void FxVolumeOnChange()
    {
        fxMusicVolume = fxMusicSlider.value;
        clickFx.volume= fxMusicVolume;
    }

    private void OnDestroy()
    {
        SaveSystem.SaveFromTitleScreen(data, bgMusicVolume, fxMusicVolume);
    }

    public void EnglishButton()
    {
        data.language = "english";
        if(OnStartLanguagePanel.activeSelf)
        {
            OnStartLanguagePanel.SetActive(false);
        }
        FilipinoBtnBg.color = Color.white;
        EnglishBtnBg.color = Color.gray;
    }

    public void FilipinoButton()
    {
        data.language = "filipino";
        if (OnStartLanguagePanel.activeSelf)
        {
            OnStartLanguagePanel.SetActive(false);
        }
        EnglishBtnBg.color = Color.white;
        FilipinoBtnBg.color = Color.gray;
    }
}
