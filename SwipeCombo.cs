using UnityEngine;
public class SwipeCombo
{
    public string[] buttons;
	private int currentIndex = 0;
 
	private float allowedTimeBetweenButtons = 0.6f;
	private float timeLastButtonPressed;

	void Start()
	{
        timeLastButtonPressed = 0f;
		currentIndex = 0; //moves along the array as buttons are pressed
		allowedTimeBetweenButtons = 0.6f; //tweak as needed
	}	
 
    public SwipeCombo(string[] b)
    {
        buttons = b;
    }
 
    //call this once a frame. when the combo has been completed
	// WITHIN THE TIME SPECIFIED
	// it will return true
    public bool ComboCheck()
	{

		//Debug.Log (Time.time);
		
		if (timeLastButtonPressed == 0f) {
			timeLastButtonPressed = Time.time;
		}

		if (Time.time >	 timeLastButtonPressed + allowedTimeBetweenButtons) currentIndex = 0;
        {
            if (currentIndex < buttons.Length)
            {
				if ((buttons[currentIndex] == "[1]" && Input.GetKeyDown("[1]")) ||
					(buttons[currentIndex] == "[2]" && Input.GetKeyDown("[2]")) ||
					(buttons[currentIndex] == "[3]" && Input.GetKeyDown("[3]")) ||
					(buttons[currentIndex] == "[4]" && Input.GetKeyDown("[4]")) ||
					(buttons[currentIndex] == "[5]" && Input.GetKeyDown("[5]")) ||
					(buttons[currentIndex] == "[6]" && Input.GetKeyDown("[6]")) ||
					(buttons[currentIndex] == "[7]" && Input.GetKeyDown("[7]")) ||
					(buttons[currentIndex] == "[8]" && Input.GetKeyDown("[8]")) ||
					(buttons[currentIndex] == "[9]" && Input.GetKeyDown("[9]")))
					{
                    timeLastButtonPressed = Time.time;
                    currentIndex++;
                }
 
                if (currentIndex >= buttons.Length)
                {
                    currentIndex = 0;
                    return true;
                }
                else return false;
            }
        }
 
        return false;
    }
}