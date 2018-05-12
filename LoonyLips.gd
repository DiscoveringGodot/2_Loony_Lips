extends Node2D

var player_words = [] # the words the player chooses

var template = {
	story1 = {
			"prompt":["a name", "a thing", "a feeling", "another feeling", "some things"], 
			"story": "Once upon a time a %s ate a %s and felt very %s. It was a %s day for all good %s."
				}, 
	story2 = {
			"prompt" : ["a noun (a thing)", "an adjective (a description word)", "a person's name", "a place", "a verb", "a second person's name", "another person's name"], 
			"story" : "A poem.\n\nI wish I was a %s, %s as can be, \n Then you could call me %s,\n And I would finally be free.\n\n Then I would visit %s \nAnd %s all day long,\nAnd I would call you %s,\nAnd teach %s my song"}, 
	story3 = {
			"prompt" : ["a person's name", "the name of a place", "the plural of a noun (there's going to be more than one of these)", "an adverb (a word ending in -ly)", "a noun"], 
			"story" : "Dear %s,\n\nI hope this letter finds you well.  I have spent the past three weeks in %s researching the history of %s for my new book.  I miss you %s, and whenever I see a %s I think of you."},
	story4 = {
			"prompt" : ["an adjective", "a person's name", "a place", "an adjective", "a noun", "another place", "an adverb (a word ending in -ly)"], 
			"story" : "Once upon a time, a %s hero called %s was sent to %s, to defeat a %s %s.  He did so, returned home to %s and lived %s ever after"},
	story5 = {
			"prompt" : ["a noun", "an adjective (a description word)", "another noun", " yet another noun", "an adjective", "one more noun", "a verb"], 
			"story" : "The ultimate pizza recipe.\n\n Mix one packet of %s with three spoonfuls of flour.  Knead the dough for 3 minutes until %s.  Roll the dough flat on a %s and sprinkle one pinch of %s and three cups of %s %s.  Bake for 17 minutes at a high heat, then remove from the oven and %s!"}
		}
var current_story

func _ready():
	randomize()  # TODO Yann necessary?
	current_story = template.values() [randi() % template.size()]
	$Blackboard/StoryText.text = ("Welcome to Loony Lips!\n\nWe're going to tell a story and have a lovely time!\n\nCan I have " + current_story.prompt[player_words.size()] + ", please?")
	$Blackboard/TextBox.text = ""

func _on_TextureButton_pressed():
	if is_story_done():
		get_tree().reload_current_scene()
	else:
		var new_text = $Blackboard/TextBox.get_text()
		_on_TextBox_text_entered(new_text)

func _on_TextBox_text_entered(new_text):
	player_words.append(new_text)
	$Blackboard/TextBox.text = ""
	check_player_word_length()

func is_story_done():
	return player_words.size() == current_story.prompt.size()

func prompt_player():
	$Blackboard/StoryText.text = ("Can I have " + current_story.prompt[player_words.size()] + ", please?")

func check_player_word_length():
	if is_story_done():
		tell_story()
	else:
		prompt_player()

func tell_story():
	$Blackboard/StoryText.text = current_story.story % player_words
	$Blackboard/TextureButton/ButtonLabel.text = "Again!"
	end_game()

func end_game():
	$Blackboard/TextBox.queue_free()