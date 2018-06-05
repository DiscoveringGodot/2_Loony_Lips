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
    // configuration parameters, consider SO

    // private instance variables for state
    Story currentStory;
    Dictionary<string, string> strings = new Dictionary<string, string>();
    List<String> playerWords = new List<string>();

    // cached references for readability
    RichTextLabel buttonLabel;
    RichTextLabel storyText;
    LineEdit textEntryBox;

    // messages, then public methods, then private methods...
    public override void _Ready()
    {
        CacheComponents();
        ShowIntro();
        SetRandomStory();
        PromptPlayer();
    }

    private void CacheComponents()
    {
        // TODO find alternative to string referencing
        buttonLabel = FindNode("ButtonLabel") as RichTextLabel;
        storyText = FindNode("StoryText") as RichTextLabel;
        textEntryBox = FindNode("TextBox") as LineEdit;
    }

    public void OnButtonPressed()
    {
        if (IsStoryDone())  // Button is now play again
        {
            GetTree().ReloadCurrentScene();
        }
        else
        {
            var userInput = textEntryBox.GetText();
            OnTextEntry(userInput);
        }
    }

    public void OnTextEntry(string entry)  // Note no need to bind in Signals
    {
        playerWords.Add(entry);
        textEntryBox.SetText("");
        storyText.SetText("");
        if (IsStoryDone())
        {
            TellStory();
        }
        else
        {
            PromptPlayer();
        }
    }

    private void ShowIntro()
    {
        strings = SetStrings();
        storyText.Text = strings["intro_text"];
    }

    private void PromptPlayer()
    {
        string nextPrompt = currentStory.prompts[playerWords.Count];
        storyText.Text += String.Format(strings["prompt"], nextPrompt); 
    }

    private void TellStory()
    {
        storyText.Text = String.Format(currentStory.story, playerWords.ToArray());
        buttonLabel.SetText(strings["again"]);
        EndGame();
    }


    private bool IsStoryDone()
    {
        return playerWords.Count == currentStory.prompts.Count;
    }

    private Dictionary<string, string> SetStrings()
    {
        var file = new File();
        file.Open("stories.json", 1);  // Mode 1 is read only
        string jsonString = file.GetAsText();
        var parseResult = JSON.Parse(jsonString);

        // TODO actually get from JSON!
        strings["intro_text"] = "Welcome to Loony Lips!\n\nWe're going to tell a story and have a lovely time!\n\n";
        strings["prompt"] = "Can I have {0} please ?";  // Note difference in syntax
        strings["again"] = "Again!";  // Note difference in syntax
        return strings;
    }

    private void SetRandomStory()
    {
        // TODO actually get from JSON!
        currentStory.prompts = new List<string>(new string[]
        {
            "a person's name",
            "a thing",
            "a feeling",
            "another feeling",
            "some things"
        });
        currentStory.story = "Once upon a time {0} ate a {1} and felt very {2}. It was a {3} day for all good {4}.";
    }

    private void EndGame()
    {
        textEntryBox.QueueFree();  // Remove text box
    }
}
