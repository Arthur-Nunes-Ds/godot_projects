extends Control
@export var creditos : String
@export var multiplay : String
@export var singlplay : String
@export var config : String

func _on_credits_pressed() -> void: 
	if creditos == "" or creditos == null:
		print("creditos")
	else:
		get_tree().change_scene_to_file(creditos)

func _on_multiplay_pressed() -> void: 
	if multiplay == "" or multiplay == null:
		print("multiplay")
	else:
		get_tree().change_scene_to_file(multiplay)

func _on_play_pressed() -> void: 
	if singlplay == "" or singlplay == null:
		print("singlplay")
	else:
		get_tree().change_scene_to_file(singlplay)

func _on_exit_pressed() -> void:
	get_tree().quit()

func _on_config_pressed() -> void:
	if config == "" or config ==  null:
		print("config")
	else:
		get_tree().change_scene_to_file(config)
