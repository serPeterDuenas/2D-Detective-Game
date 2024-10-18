using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Ink.Runtime;
using System.IO;

public class DialogueVariables
{
    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }

    // To compile the Globals.ink script
    public DialogueVariables(TextAsset globalsJSON)
    {
        // create story
        Story globlaVariablesStory = new Story(globalsJSON.text);


        // initialize dictionary
        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach(string name in globlaVariablesStory.variablesState)
        {
            // each loop grabs the compiled Story variables with the string name, adds it to Dictionary
            Ink.Runtime.Object value = globlaVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("Initalize global dialogue varialbe: " + name + " = " + value);
        }
    }



    // when story starts, this listens for when any variables have been changed, 
    // invokes method VariableChanged which parses name and the value of the var 
    public void StartListening(Story story)
    {
        // call first before assinging the listener
        VariablesToStory(story);

        story.variablesState.variableChangedEvent += VariableChanged; 
    }


    public void StopListening(Story story) 
    {
        story.variablesState.variableChangedEvent += VariableChanged;
    } 


    private void VariableChanged(string name, Ink.Runtime.Object value )
    {
        // only maintain variables initialized from global ink file
       if(variables.ContainsKey(name) ) 
        {
            variables.Remove(name);
            variables.Add(name, value);
        }
    }


    private void VariablesToStory(Story story)
    {
        foreach(KeyValuePair<string, Ink.Runtime.Object> var in variables)
        {
            story.variablesState.SetGlobal(var.Key, var.Value);
        }
    }


}
