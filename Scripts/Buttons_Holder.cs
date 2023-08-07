using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons_Holder : MonoBehaviour
{
    public MainMenu_Manager mainMenu_Manager;
    public Button[] vehicleButtons; // Array of buttons for each vehicle

    // Start is called before the first frame update
    void Start()
    {
        // Attach click event handlers to each vehicle button
        for (int i = 0; i < vehicleButtons.Length; i++)
        {
            int index = i; // Store the index in a local variable to avoid closure issues
            vehicleButtons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    private void Update()
    {

    }

    // Click event handler for vehicle buttons
    public void OnButtonClick(int index)
    {
        //Set the current car index to the clicked button's index
        mainMenu_Manager.SetCurrentCarIndex(index);
    }

    public void Play()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = activeSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
