using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey =
        "30330525ff54db60f157034580929ee1daec01d3cb5aa9e1ba7cc3c3d8a57ce6";

    //Update leaderboard when starting the game
    private void Start()
    {
        GetLeaderboard();
        
    }
    //Connection to the service
    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; ++i)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));

        //Multiple entries possible, entries are only being overridden after a the 8 entry treshhold has been reached
        LeaderboardCreator.ResetPlayer();
    }
    //Push the values on the leaderboard
    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score,((msg) =>
            {
                GetLeaderboard();
            }));
    }
}
