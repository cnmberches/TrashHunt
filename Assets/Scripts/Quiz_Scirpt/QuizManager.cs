using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    private static List<Question> unAnsweredQuestion;
    private static List<Question> TagalogunAnsweredQuestion;

    public Question[] questions;
    public Question[] Tagalogquestions;
    public AudioSource CorrectFX, WrongFX;
    public TMP_Text txt, QuestionNum,FinalScoretxt;
    public GameObject CheckPanel, WrongPanel, FinalScore, CongratsPanel, FailedPanel;
    public PlayerController player;
    public Button btnTrue, btnFalse;

    [SerializeField] TMP_Text FailedPaneltxt;
    [SerializeField] AudioSource EnglsihAudio;
    [SerializeField] AudioSource TagalogAudio;

    private SaveData data;

    private int randomQuestionIndex;
    private int questionNum = 1;
    private int score = 0;
    public Question currentQuestion;
    public Question TagalogcurrentQuestion;
    public bool isQuizIsPassed;
    public bool isTagalog = false;

    string English_dialogs =  "You still lack knowledge, grandson. You need to learn more about waste segregation. You can go back to your missions or check the almanac to pass this quiz. Come back to me and retake the quiz if you are ready.";

    string Filipino_dialogues =  "Kulang ka pa sa kaalaman apo. Kailangan mong matuto nang higit pa tungkol sa paghihiwalay ng basura. Maaari kang bumalik sa iyong mga misyon o tingnan ang almanac para makapasa sa pagsusulit na ito. Bumalik ka sa akin at sagutan muli ang quiz kung handa ka na." ;
    private void Awake()
    {
        data = SaveSystem.LoadPlayer();
    }
    void Start()
    {
        CorrectFX.volume = data.fxMusicVolume;
        WrongFX.volume = data.fxMusicVolume;
        ChangeLanguage(data.language);
        if (data.language == "english")
        {
            if (unAnsweredQuestion == null || unAnsweredQuestion.Count == 0)
            {
                unAnsweredQuestion = questions.ToList<Question>();
            }
            SetCurrentQuestion();
        }
        else
        {
            if (TagalogunAnsweredQuestion == null || TagalogunAnsweredQuestion.Count == 0)
            {
                TagalogunAnsweredQuestion = Tagalogquestions.ToList<Question>();
            }
            SetCurrentQuestion();
        }
    }

    void SetCurrentQuestion()
    {
        if (data.language == "english")
        {
            randomQuestionIndex = Random.Range(0, unAnsweredQuestion.Count);

            QuestionNum.text = "Question " + questionNum.ToString() + "/20";

            if (unAnsweredQuestion.Count == 0)
            {
                FinalScoretxt.text = score.ToString();
                FinalScore.SetActive(true);

            }
            else
            {
                currentQuestion = unAnsweredQuestion[randomQuestionIndex];
                txt.text = currentQuestion.Fact;
            }
        }
        else
        {
            randomQuestionIndex = Random.Range(0, TagalogunAnsweredQuestion.Count);

            QuestionNum.text = "Question " + questionNum.ToString() + "/20";

            if (TagalogunAnsweredQuestion.Count == 0)
            {
                FinalScoretxt.text = score.ToString();
                FinalScore.SetActive(true);
            }
            else
            {
                TagalogcurrentQuestion = TagalogunAnsweredQuestion[randomQuestionIndex];
                txt.text = TagalogcurrentQuestion.Fact;
            }
        }
    }

    public void FinalScoreFunction()
    {
        if (score >= 18)
        {
            data.QuizTracker["isQuizIsPassed"] = true;
            SceneManager.LoadScene("FinishCutscene");

        }
        else if (score <= 17)
        {
            data.QuizTracker["isQuizIsFailed"] = true;
            FailedPanel.SetActive(true);
        }
    }
    public void ContinuebtnFinal()
    {
        if(CongratsPanel.activeSelf)
        {
            SceneManager.LoadScene("Cutscene_Last");
        }
        else if (FailedPanel.activeSelf)
        {
            player.transform.position = Vector3.zero;
            SceneManager.LoadScene("Base");
        }
    }

    public void UserSeclectTrue()
    {
       if(data.language == "english")
        {
            if (currentQuestion.isTrue)
            {
                StartCoroutine(Check());
            }
            else
            {
                StartCoroutine(Wrong());
            }
            StartCoroutine(TransitioToNextQuestions());
        }
        else
        {
            if (TagalogcurrentQuestion.isTrue)
            {
                StartCoroutine(Check());
            }
            else
            {
                StartCoroutine(Wrong());
            }
            StartCoroutine(TransitioToNextQuestions());
        }
      
    }

    public void UserSelectFalse()
    {
       if(data.language == "english")
        {
            if (!currentQuestion.isTrue)
            {
                StartCoroutine(Check());
            }
            else
            {
                StartCoroutine(Wrong());
            }
            StartCoroutine(TransitioToNextQuestions());
        }
        else
        {
            if (!TagalogcurrentQuestion.isTrue)
            {
                StartCoroutine(Check());
            }
            else
            {
                StartCoroutine(Wrong());
            }
            StartCoroutine(TransitioToNextQuestions());
        }
    }

    IEnumerator TransitioToNextQuestions()
    {

        if (data.language == "english")
        {
            unAnsweredQuestion.RemoveAt(randomQuestionIndex);
            yield return new WaitForSeconds(1);
            questionNum++;
            SetCurrentQuestion();
        }
        else
        {
            TagalogunAnsweredQuestion.RemoveAt(randomQuestionIndex);
            yield return new WaitForSeconds(1);
            questionNum++;
            SetCurrentQuestion();
        }
    }
    IEnumerator Check()
    {
        score++;
        CorrectFX.Play();
        CheckPanel.SetActive(true);
        yield return new WaitForSeconds(1);
        CheckPanel.SetActive(false);
    }
    IEnumerator Wrong()
    {
        WrongFX.Play();
        WrongPanel.SetActive(true);
        yield return new WaitForSeconds(1);
        WrongPanel.SetActive(false);
    }
    private void Update()
    {
        CorrectFX.volume = player.fxMusicVolume;
        WrongFX.volume = player.fxMusicVolume;
    }
    void ChangeLanguage(string language)
    {
        if (language == "filipino")
        {
            FailedPaneltxt.text = Filipino_dialogues;
            EnglsihAudio.mute = true;
        }
        else
        {
            FailedPaneltxt.text = English_dialogs;
            TagalogAudio.mute= true;
        }
    }
}
