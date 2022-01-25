using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAiActon {
    bool Act(MonoBehaviour monoBehaviour);
}

public class RotateAction : IAiActon {
    private float _targetposition;
    private float _rotationSpeed;
    public RotateAction(float targetposition, float rotationSpeed){
        _targetposition = targetposition;
        _rotationSpeed = rotationSpeed;
    }
    public bool Act(MonoBehaviour monoBehaviour){

        float oneRotat =_rotationSpeed * Time.fixedDeltaTime;
        float difference = _targetposition  - (monoBehaviour.transform.eulerAngles.y );

        if(difference  <= oneRotat &&  difference >= -1* oneRotat){
            return true;
        }

        if(difference <= 0){
            monoBehaviour.transform.Rotate(0, -1* oneRotat ,0);
        }
        else
        {
            monoBehaviour.transform.Rotate(0, oneRotat ,0);
        }
        return false;
    }
}

public class SleepAction : IAiActon {
    private float _sleepValue;
    private float sleepTimer;
    public SleepAction(float sleepValue){
        _sleepValue = sleepValue;
        sleepTimer = sleepValue;
    }
    public bool Act(MonoBehaviour monoBehaviour){ 
        // Debug.Log($"SleepTimer {sleepTimer}");
        sleepTimer -= Time.fixedDeltaTime; // decrease timer by deltaTime
        if (sleepTimer <= 0) // waiting for the timer to hit zero
        {
            sleepTimer = _sleepValue;
            return true;
        }
        else
        {
            return false;
        }
    }
}


public class GuardActivity : MonoBehaviour
{
    private System.Random _random  = new System.Random();
    public int minRotation;     // minimum rotation value
    public int maxRotation;     // maximum rotation value
    public int minSteps = 3;    // minimum steps for random turn funtion
    public int maxSteps = 20;   // maximum steps for random turn function
    public int minSpeed = 10;   // minimum speed for random turn function
    public int maxSpeed = 500;  // maximum speed for random turn function
    public int minSleep = 1; // seconds minimum sleep
    public int maxSleep = 5; // seconds maximum sleep
    public int sleepPercentage = 20; // percentage of steps are sleep
    
    private List<IAiActon> actions = new List<IAiActon>();

    private int pos = 0;

    // Start is called before the first frame update
    void Start()
    {
        var steps = _random.Next(minSteps,maxSteps);

        for (var i = 0; i < steps; i++){
            var rotation = _random.Next(minRotation,maxRotation);
            var speed = _random.Next(minSpeed,maxSpeed);
            var sleep = _random.Next(minSleep,maxSleep);
            actions.Add(new RotateAction(rotation,speed));
            // Debug.Log($"Rotation {rotation} Speed {speed}");
            if (_random.Next(1,100) < sleepPercentage) {
                // should only add in sleepPercentage % cases. 
                actions.Add(new SleepAction(sleep));
                // Debug.Log($"Sleep {sleep}");
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        if(actions[pos].Act(this)){
            pos++;
            if(pos >= actions.Count){
                pos = 0;
            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Guard: Collision detected");

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Guard: Spotted Player.");
            GameStatistics.Instance.EndReason = 2;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Endscreen");
        }
    }
}
