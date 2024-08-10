using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text[] _scoreText;
    [SerializeField] TMP_Text _totalScoreText, _endTotalScore;
    [SerializeField] GameObject[] allGameObject;
    [SerializeField] GameObject _endCanvas;

    private int yourScore;
    public bool hasScore;
    public int _currentAttemptNo;

    // Start is called before the first frame update
    void Start()
    {
        hasScore = false;
        yourScore = 0;

        for (int i = 0;  i < _scoreText.Length; i++)
        { _scoreText[i].text = ""; }

        _currentAttemptNo = 0;
        _endCanvas.SetActive(false);
    }

    private void Update()
    {
        _totalScoreText.text = yourScore.ToString();
        _endTotalScore.text = yourScore.ToString();
    }

    public void ScoringSystem(string areaHit)
    {
        switch (areaHit) 
        {
            case "White":
                yourScore += 2;
                AddScoreText(2);
                break;

            case "Black":
                yourScore += 4;
                AddScoreText(4);
                break;

            case "Blue":
                yourScore += 6;
                AddScoreText(6);
                break;

            case "Red":
                yourScore += 8;
                AddScoreText(8);
                break;

            case "Yellow":
                yourScore += 10;
                AddScoreText(10);
                break;

            default:
                Debug.LogWarning("Wrong scoring are input");
                break;

        }
    }

    private void AddScoreText(int currentScore)
    {
        switch (_currentAttemptNo)
        {
            case 1:
                _scoreText[0].text = currentScore.ToString();
                break;

            case 2:
                _scoreText[1].text = currentScore.ToString();
                break;

            case 3:
                _scoreText[2].text = currentScore.ToString();
                break;

            case 4:
                _scoreText[3].text = currentScore.ToString();
                break;

            case 5:
                _scoreText[4].text = currentScore.ToString();
                break;

            default:
                Debug.LogWarning("Attempt Might be 0 or more than 6");
                break;
        }
    }

    private void EndGame()
    {
        if (_currentAttemptNo >= 6)
        {
            for (int i = 0; i < allGameObject.Length; i++)
            {
                allGameObject[i].gameObject.SetActive(false);   
            }
            _endCanvas.SetActive(true); 
        }
    }
}
