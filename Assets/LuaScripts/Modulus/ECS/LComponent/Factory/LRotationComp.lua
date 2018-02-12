LRotationComp = SimpleClass(LComponent)

function LRotationComp:__init(type,uid,args)
    self.angle = nil 
end 

function LRotationComp:isNeedUpdate()
	return self.isChange 
end 

function LRotationComp:update(angle)
   self.angle = angle 
   self.isChange = true 
end 