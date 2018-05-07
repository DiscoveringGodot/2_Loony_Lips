extends Node2D

func _ready():
	var prompt = ["Yann", "pizza", "full", "sad", "cabbages"]
	var story = "Once upon a time a %s ate a %s and felt very %s. It was a %s day for all good %s."
	$Blackboard/StoryText.text = story % prompt
	$Blackboard/TextBox.text = ""

func _on_TextureButton_pressed():
	var new_text = $Blackboard/TextBox.get_text()
	_on_TextBox_text_entered(new_text)

func _on_TextBox_text_entered(new_text):
	$Blackboard/StoryText.text = new_text
	$Blackboard/TextBox.text = ""

