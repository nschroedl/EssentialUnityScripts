using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {
 
    public float maxCount; //Set this in public	
	
	private float gameCount; //Current count of this progress bar during gameplay		
    private float maxScale; //Stores the total size of the original cube
    private float xStartPos; //Stores the starting x position
	
	//Set to true is this is a progress bar that counts down each second  (cooldown bar, timer, etc)
	//Set to false if you will be passing in values to set the meter at (health bar, exp bar, etc)
	public bool isCountDownBar; 
	
	//Is the progress bar counting up or down
	public bool isBarCountingDown;
	
	// Use this for initialization
	void Start () {	
		Vector3 scale = transform.localScale;
		maxScale = scale.x;		
		xStartPos = transform.position.x;
				
		RestartProgressBar();
    }
	
	public void RestartProgressBarMax(){		
		gameCount = maxCount;			
		transform.localScale = new Vector3(maxScale, transform.localScale.y, transform.localScale.z);
	}
	
	public void RestartProgressBarMin(){		
		gameCount = 0;	
		transform.localScale = new Vector3(maxScale, transform.localScale.y, transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
        if (isCountDownBar && gameCount >= 0)
        {
			if(isBarCountingDown){
				gameCount += -Time.deltaTime;
			} else{
				gameCount += Time.deltaTime;
			}
            SetProgressBar(gameCount);
        }
	}
	
    public void SetProgressBar(float currentCount)
    {
        if(currentCount <= maxCount && currentCount > 0) { 
            float percent = (currentCount / maxCount);
            float size = maxScale * percent;
			
			//Reduces the overall size of the bar based on the percentage
            transform.localScale = new Vector3(size, transform.localScale.y, transform.localScale.z);		

			//Maintains the original xPosition so the bar doesn't drift as it is resized
            transform.position = new Vector3(xStartPos + ((maxScale - size)/2), transform.position.y, transform.position.z);
        }
    }
}