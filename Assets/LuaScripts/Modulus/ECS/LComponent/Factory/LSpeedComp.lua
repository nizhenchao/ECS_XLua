LSpeedComp = SimpleClass(LComponent)

function LSpeedComp:__init(type,uid,args)
    self.speed = args[1]
end 

function LSpeedComp:isNeedUpdate()
	return self.isChange
end 

function LSpeedComp:update(sp)
	self.speed = sp 
end 