extends Control
#vars:
var resolucao
var is_fullscreaw 


func _on_resolucao_item_selected(index: int) -> void:
	resolucao = index#<-pega qual é a resolução 

func _on_tela_cheia_toggled(toggled_on: bool) -> void:
	is_fullscreaw = toggled_on

func _on_aplicar_pressed() -> void:
	if is_fullscreaw:
		DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_FULLSCREEN)
	else:
		DisplayServer.window_set_mode(DisplayServer.WINDOW_MODE_WINDOWED)
	
	match resolucao:#<- swit case godot
		0:
			DisplayServer.window_set_size(Vector2i(1280,720))#<- parametro que altera a resolução
		1:
			DisplayServer.window_set_size(Vector2i(1024,768))
		2:
			DisplayServer.window_set_size(Vector2i(1280, 960))
