using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScriptCleaner : Editor
{
    [MenuItem("GameObject/Automation/Clear Scripts", false, -1)]
    public static void ClearScripts()
    {
        List<Component> _scriptList = new List<Component>();

        //Get the components in parent and children
        Component[] _parentScripts = Selection.activeGameObject.GetComponents(typeof(MonoBehaviour));
        Component[] _childScripts = Selection.activeGameObject.GetComponentsInChildren(typeof(MonoBehaviour));

        _scriptList.AddRange(_parentScripts);
        _scriptList.AddRange(_childScripts);

        if (_parentScripts.Length == 0 && _childScripts.Length == 0)
        {
            //Show a message that no scripts were found
            ShowPopUp(false);
            //if no scripts are present in parent and in its children, then stop;
            return;
        }

        foreach (var script in _scriptList)
        {
            if (script != null)
            {
                //Destroy immediate works best in editors to avoid any delays
                DestroyImmediate(script);
            }

            //Show a message for success.
            ShowPopUp(true);
        }
    }

    private static void ShowPopUp(bool isSuccess)
    {
        //Create a new editor window instance from the script
        var popUp = CreateInstance<ScriptCleanerPopUp>();
        //Define position and size
        popUp.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 100);
        //Give permission to show the pop-up
        popUp.ProcessPopUp(isSuccess);
        //Show the popup window
        // popUp.ShowPopUp();
    }
}
