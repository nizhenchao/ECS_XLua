ComponentMgr = { }

function ComponentMgr:init_self()
    self.compPool = { }  -- key=type    val={ } key=uid val=comp
end 

function ComponentMgr:init()
	self:init_self()
end 

function ComponentMgr:addComponent(entity,type,args)   
   if not entity or not type or entity[type] then 
   	  return 
   end      
   local comp = CompFactory:get(type,entity.uid,args)
   if self.compPool[type] == nil then 
      self.compPool[type] = { }
   end 
   self.compPool[type][entity.uid] = comp 
   return comp 
end 

function ComponentMgr:removeComponent(entity,comp)
    if not entity or  not comp then 
       return 
    end 
    local type = comp:getType()
	if self.compPool[type] and self.compPool[type][entity.uid] then 
	   self.compPool[type][entity.uid] = nil
	end
	comp:onDispose()
	return type 
end 

function ComponentMgr:getCompsByType(key)
	return self.compPool[key]
end 

function ComponentMgr:clear()

end 

create(ComponentMgr)