using Godot;
using System;
using System.Collections.Generic;

struct Story
{
    public List<String> prompts;
    public String story;
}

public class LoonyLips : Node2D
{
    // private instance variable for state
    Story currentStory;

    Dictionary<String, String> strings = new Dictionary<string, string>();

    // cached references
    RichTextLabel storyText;
    LineEdit textEntryBox;

    public override void _Ready()
    {
        CacheComponents();
        ShowIntro();
        SetRandomStory();
        // PromptPlayer();
    }

    // Start of signals
    void OnTextEntry(String entry)  
    {
        GD.Print("Text entered: " + entry);
    }

    void OnButtonPressed()
    {
        GD.Print("Button pressed");
    }
    // End of signals

    void CacheComponents()
    {
        storyText = FindNode("StoryText") as RichTextLabel;
        textEntryBox = FindNode("TextBox") as LineEdit;
    }

    private void ShowIntro()
    {
        storyText.Text = "It worked!";
        textEntryBox.Text = "I wrote a line of text!";
    }

    private void SetRandomStory()
    {
        var parseResult = GetJSONParseResult("stories.json");
        var stories = parseResult.Result as Array;

        Random rnd = new Random();
        var storyIndex = rnd.Next(0, stories.Length);
        var randomStory = stories.GetValue(storyIndex) as Dictionary<System.Object, System.Object>;
        
        currentStory.prompts = GetPrompts(randomStory);
        currentStory.story = randomStory["story"] as String;
        GD.Print(currentStory.story);
    }

    private List<String> GetPrompts(Dictionary<System.Object, System.Object> story)
    {
        var promptsList = new List<String>();
        var promptObjects = story["prompt"] as Array;
        foreach (System.Object o in promptObjects)
        {
            promptsList.Add(o as String);
        }
        return promptsList;
    }

    private void SetStringsFromFile(string localFileName)
    {
        var parseResult = GetJSONParseResult(localFileName);
        var dict = parseResult.Result as Dictionary<System.Object, System.Object>;
        foreach (var entry in dict)
        {
            var keyString = entry.Key as String;
            strings[keyString] = dict[keyString] as string;
        }
    }

    private JSONParseResult GetJSONParseResult(String localFileName)
    {
        var file = new File();
        file.Open(localFileName, 1);  // Mode 1 is read only
        var text = file.GetAsText();
        file.Close();

        var parseResult = JSON.Parse(text);

        if (parseResult.Error != 0)
        {
            GD.Print(localFileName + " parse error");
            return null;
        }
        else
        {
            GD.Print(localFileName + " read OK");
            return parseResult;
        }
    }
}
