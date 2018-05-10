using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Writting : MonoBehaviour
{
    protected Animator leonAnimator;
    private LevelManager levelManager;
    protected Material firstMat, secondMat, thirdMat, fourthMat;
    private Text[] answerArray;

    public GameObject LevelM;
    public Transform correctPSSpawnPoint, correctSpawnPoint, wrongSpawnPoint;
    public GameObject leon, correctPS, correctPrefab, wrongPrefab;
    public GameObject firstCube, secondCube, thirdCube, fourthCube;
    public Text FirstAnswer, SecondAnswer, ThirdAnswer, FourthAnswer;
    public Color selectionColor, defaultColor, wrongColor, correctColor;
    public bool showAnswers = false;
    private bool paintCubes = false;
    private bool answer;

    public float letterPause = 0.2f;
    public AudioClip typeSound1;
    public AudioClip typeSound2;

    private int randomIndexQuestion;
    private int moneyPerAnswer;
    string[] message;
    Text textComp;

    // Use this for initialization
    void Start()
    {
        LevelM = GameObject.Find("LevelManager");
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        leonAnimator = leon.GetComponent<Animator>();
        firstMat =  firstCube.GetComponent<Renderer>().material;
        secondMat = secondCube.GetComponent<Renderer>().material;
        thirdMat = thirdCube.GetComponent<Renderer>().material;
        fourthMat = fourthCube.GetComponent<Renderer>().material;

        textComp = GetComponent<Text>();
        message = new string[5];

        message[0] = "¿Cuánto es 2 + 2?";
        message[1] = "¿Cuánto es 3 + 3?";
        message[2] = "¿?";
        message[3] = "¿Cuál es la mejor puntuación?";
        message[4] = "¿Para qué existimos?";

        textComp.text = "";
        StartCoroutine(TypeText());

        leonAnimator.SetBool("isWrong", false);

        moneyPerAnswer = 200;
    }


    IEnumerator TypeText()
    {
        AudioSource audio = GetComponent<AudioSource>();
        randomIndexQuestion = Random.Range(0, 4);
        Debug.Log(randomIndexQuestion);
        string question = message[randomIndexQuestion];
        yield return new WaitForSeconds(1.5f);
        foreach (char letter in question.ToCharArray())
        {
            audio.clip = typeSound1;
            audio.Play();
            textComp.text += letter;
            audio.clip = typeSound2;
            audio.Play();
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        CallingAnswers();
        firstMat.SetColor("_EmissionColor", selectionColor);
        showAnswers = true;
        paintCubes = true;
    }

    public void CallingAnswers()
    {
        switch (randomIndexQuestion)
        {
            case 0:
                FirstAnswer.text = "pez";
                SecondAnswer.text = "Gato";
                ThirdAnswer.text = "Hola1";
                FourthAnswer.text = "SOMEBODY";
                break;
            case 1:
                FirstAnswer.text = "8";
                SecondAnswer.text = ":v";
                ThirdAnswer.text = "Mi libro";
                FourthAnswer.text = "Salud";
                break;
            case 2:
                FirstAnswer.text = "Hola";
                SecondAnswer.text = "ehm, 3";
                ThirdAnswer.text = "HMMMMmmm";
                FourthAnswer.text = "$399.99";
                break;
            case 3:
                FirstAnswer.text = "5/7";
                SecondAnswer.text = "7/5";
                ThirdAnswer.text = "México";
                FourthAnswer.text = "Elotes";
                break;
            default:
                FirstAnswer.text = "baño?";
                SecondAnswer.text = "Para comer";
                ThirdAnswer.text = "3";
                FourthAnswer.text = "2?";
                break;
        }

        
    }

    private void Update()
    {
        if (showAnswers == true && paintCubes == true)
        {
            int option;
            if (firstMat.GetColor("_EmissionColor") == selectionColor)
            {

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    secondMat.SetColor("_EmissionColor", selectionColor);
                    firstMat.SetColor("_EmissionColor", defaultColor);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    thirdMat.SetColor("_EmissionColor", selectionColor);
                    firstMat.SetColor("_EmissionColor", defaultColor);
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    option = 1;
                    paintCubes = false;
                    CheckAnswer(option, firstMat);
                }
            }
            else if (secondMat.GetColor("_EmissionColor") == selectionColor)
            {

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    firstMat.SetColor("_EmissionColor", selectionColor);
                    secondMat.SetColor("_EmissionColor", defaultColor);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    fourthMat.SetColor("_EmissionColor", selectionColor);
                    secondMat.SetColor("_EmissionColor", defaultColor);
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    option = 2;
                    paintCubes = false;
                    CheckAnswer(option, secondMat);
                }
            }
            else if (thirdMat.GetColor("_EmissionColor") == selectionColor)
            {

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    firstMat.SetColor("_EmissionColor", selectionColor);
                    thirdMat.SetColor("_EmissionColor", defaultColor);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    fourthMat.SetColor("_EmissionColor", selectionColor);
                    thirdMat.SetColor("_EmissionColor", defaultColor);
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    option = 3;
                    paintCubes = false;
                    CheckAnswer(option, thirdMat);
                }
            }
            else if (fourthMat.GetColor("_EmissionColor") == selectionColor)
            {

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    secondMat.SetColor("_EmissionColor", selectionColor);
                    fourthMat.SetColor("_EmissionColor", defaultColor);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    thirdMat.SetColor("_EmissionColor", selectionColor);
                    fourthMat.SetColor("_EmissionColor", defaultColor);
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    option = 4;
                    paintCubes = false;
                    CheckAnswer(option, fourthMat);
                }

            }

        }
    }

    void CheckAnswer(int option, Material mat)
    {
        switch(randomIndexQuestion)
        {
            case 0:
                if (option == 1)
                {
                    mat.SetColor("_EmissionColor", correctColor);
                    CorrectAnswer();
                }
                else
                {
                    mat.SetColor("_EmissionColor", wrongColor);
                    IncorrectAnswer();
                }
                break;
            case 1:
                if (option == 1)
                {
                    mat.SetColor("_EmissionColor", correctColor);
                    CorrectAnswer();
                }
                else
                {
                    mat.SetColor("_EmissionColor", wrongColor);
                    IncorrectAnswer();
                }
                break;
            case 2:
                if (option == 1)
                {
                    mat.SetColor("_EmissionColor", correctColor);
                    CorrectAnswer();
                }
                else
                {
                    mat.SetColor("_EmissionColor", wrongColor);
                    IncorrectAnswer();
                }
                break;
            case 3:
                if (option == 1)
                {
                    mat.SetColor("_EmissionColor", correctColor);
                    CorrectAnswer();
                }
                else
                {
                    mat.SetColor("_EmissionColor", wrongColor);
                    IncorrectAnswer();
                }
                break;
            default:
                if (option == 1)
                {
                    mat.SetColor("_EmissionColor", correctColor);
                    CorrectAnswer();
                }
                else
                {
                    mat.SetColor("_EmissionColor", wrongColor);
                    IncorrectAnswer();
                }
                break;
        }
    }

    void CorrectAnswer()
    {
        Debug.Log("Correct!");
        
        GameObject effect = Instantiate(correctPS,correctPSSpawnPoint.position,Quaternion.identity) as GameObject;
        GameObject correct = Instantiate(correctPrefab, correctSpawnPoint.position, correctPrefab.transform.rotation) as GameObject;
        Destroy(effect, 3f);
        Destroy(correct, 3f);
        answer = correct;
        StartCoroutine(ChangeScene());
    }

    void IncorrectAnswer()
    {
        Debug.Log("Incorrect :(");
        leonAnimator.SetBool("isWrong", true);
        GameObject wrong = Instantiate(wrongPrefab, wrongSpawnPoint.position, wrongPrefab.transform.rotation) as GameObject;
        Destroy(wrong, 3f);
        answer = false;
        StartCoroutine(ChangeScene());
    }


    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        if (answer == true)
        {
            PlayerStats.money += moneyPerAnswer;
            moneyPerAnswer *= 2;
        }
        else
        {
            moneyPerAnswer *= 2;
        }
        Debug.Log("Cambiando de escena");
        GameObject.Find("UserData").GetComponent<PlayerStats>().waveIndex++;
        GameObject.Find("UserData").GetComponent<PlayerStats>().waveBlock++;
        GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("Game");
    }
}
