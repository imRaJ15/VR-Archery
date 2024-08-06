using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int yourScore;
    public bool hasScore;

    // Start is called before the first frame update
    void Start()
    {
        hasScore = false;
        yourScore = 0;
    }

    public void ScoringSystem(string areaHit)
    {
        switch (areaHit) 
        {
            case "White":
                yourScore += 2;
                break;

            case "Black":
                yourScore += 4;
                break;

            case "Blue":
                yourScore += 6;
                break;

            case "Red":
                yourScore += 8;
                break;

            case "Yellow":
                yourScore += 10;
                break;

            default:
                Debug.LogWarning("Wrong scoring are input");
                break;

        }
    }
}
