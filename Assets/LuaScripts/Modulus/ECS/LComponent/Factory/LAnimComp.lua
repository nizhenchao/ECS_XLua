LAnimComp = SimpleClass(LComponent)

function LAnimComp:__init(type,uid,args)
   self.anim = nil 
   self.animChaned = true 
   self.triggerName = 'idle'
end 

function LAnimComp:isNeedUpdate()
	return self.anim == nil
end 

function LAnimComp:isAnimChange()
	return self.animChaned
end 

function LAnimComp:setTriggerName(name)
	if self.triggerName~= name then 
		self.animChaned = true 
		self.triggerName = name 
	end 
end 

function LAnimComp:update(name)
   self:setTriggerName(name)
end 