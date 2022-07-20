using UnityEngine;
using UnityEditor;

public class ScriptCleanerPopUp : EditorWindow
{
    private bool _isSuccess;

    private void OnEnable()
    {
        //Create the new pop-up window, this method makes the window draggable, minimize, and closable and adjustable
        GetWindow((typeof(ScriptCleanerPopUp)));
    }

    //Drawing custom editor
    private void OnGUI()
    {
        //add some padding to the top
        GUILayout.Space(20);
        //The message that will be shown, either success or failure
        EditorGUILayout.LabelField(_isSuccess ? "All scripts cleared successfully." : "No scripts detected.");
        //add more padding
        GUILayout.Space(20);
        //Add a button with a name "close" that will close the message
        if (GUILayout.Button("Close")) this.Close();
    }

    //This method is called in the editor script to determine which message to show
    public void ProcessPopUp(bool success)
    {
        _isSuccess = success;
    }
}