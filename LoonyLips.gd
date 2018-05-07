extends Node2D

func _ready():
	var prompt = ["Yann", "pizza", "full", "sad", "cabbages"]
	var story = "Once upon a time a %s ate a %s and felt very %s. It was a %s day for all good %s."
	#$Blackboard/StoryText.text = story % prompt
	$Blackboard/StoryText.bbcode_text = story % prompt