LPositionComp = SimpleClass(LComponent)

function LPositionComp:__init(type,uid,args)
    self.pos = Vector3(args[1],args[2],args[3])
    self.isArrive = false 
end 

function LPositionComp:isNeedUpdate()
	return not self.isArrive
end 

function LPositionComp:update(pos)
   self.pos = pos 
   self.isArrive = false 
end 