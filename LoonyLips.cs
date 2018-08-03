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
        
        // TODO currentStory.prompts =  GetPrompts(randomStory)
        currentStory.story = randomStory["story"] as string;
        GD.Print(currentStory.story);
    }

    private JSONParseResult GetJSONParseResult(string localFileName)
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
