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
    
    public int TimeRemaining {get; set; }
    public int Score {get; set; }
    public int Pakete {get; set; } // how much pakete secured
    public int inHand {get; set; } // how much pakete in hand
    public int EndReason {get; set; } // why the game ended
}
