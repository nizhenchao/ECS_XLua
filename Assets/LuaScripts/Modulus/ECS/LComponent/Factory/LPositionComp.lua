LPositionComp = SimpleClass(LComponent)

function LPositionComp:__init(type,uid,args)
    self.pos = Vector3(args[1],args[2],args[3])
end 

function LPositionComp:isNeedUpdate()
	return self.pos ~= nil 
end 

function LPositionComp:update(pos)
   self.pos = pos 
end 