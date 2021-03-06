using System.Collections;
using System.Collections.Generic;

public class GameStatistics
{
    private static GameStatistics _instance;
    public static GameStatistics Instance {
        get{
            if ( _instance == null ) {
                _instance = new GameStatistics();
            }
            return _instance;
        }
    }
    
    public string GameVersion {get; set; } // which version is this game
    public float TimeRemaining {get; set; }
    public int Score {get; set; }
    public int Pakete {get; set; } // how much pakete secured
    public int Goal {get; set; } // how much pakete available
    public bool inHand {get; set; } // how much pakete in hand
    public int EndReason {get; set; } // why the game ended
}
