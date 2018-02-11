LComponent = SimpleClass()

function LComponent:__init_self()
    self.uid = nil 
	self.isChange = nil 
end

function LComponent:__init(type,uid,...)
   self.type = type 
   self.uid = uid 
end

function LComponent:addProperty(key,val)

end 

function LComponent:removeProperty(key)

end 

function LComponent:isNeedUpdate()
	return false 
end 

function LComponent:getUid()
	return self.uid 
end 

function LComponent:getType()
	return self.type 
end 

function LComponent:onDispose()
	SystemMgr:disposeComp(self:getType(),self)
end 