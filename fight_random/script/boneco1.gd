#pega as probriedades basicas do pai
extends CharacterBody2D
class_name player

#var
#constante
const SPEED = 300.0
const JUMP_FORCE = -400.0

#func loop
func _physics_process(delta: float) -> void:
	# ver ser o player estar no chão
	if not is_on_floor():
		#se não ele adicinoar a gravidade
		velocity += get_gravity() * delta
	#aqui ele pega o equivalende da 'espaço' dependendo da config
	#e ver ser ele tá no chão
	if Input.is_action_just_pressed("ui_accept") and is_on_floor():
		#aqui ele aplica o pulo
		velocity.y = JUMP_FORCE
	#pega o input do user da teclas "direita" e "esquerda"
	var direction := Input.get_axis("ui_left", "ui_right")
	#ver para onde ele tá indo
	if direction:
		velocity.x = direction * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
	#função nativa do gosot para "altaliza" as cenas
	move_and_slide()
