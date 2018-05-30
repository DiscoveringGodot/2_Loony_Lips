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

    void CacheComponents()
    {
        // TODO find alternative to string referencing
        storyText = FindNode("StoryText") as RichTextLabel;
        textEntryBox = FindNode("TextBox") as LineEdit;
    }

    public void OnButtonPressed()  // should we have a leading _ style-wise?
    {
        if (IsStoryDone())
        {
            GetTree().ReloadCurrentScene();
        }
        else
        {
            var userInput = textEntryBox.GetText();  // TODO remove string reference?
            OnTextEntry(userInput);
        }
    }

    bool IsStoryDone()
    {
        return playerWords.Count == currentStory.prompts.Count;
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
        foreach (string word in playerWords)
        {
            storyText.Text += " " + word;
        }
        EndGame();
    }

    private Dictionary<string, string> SetStrings()
    {
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
        currentStory.story = "Once upon a time %s ate a %s and felt very %s. It was a %s day for all good %s.";
    }

    private void EndGame()
    {
        textEntryBox.QueueFree();
    }
}
