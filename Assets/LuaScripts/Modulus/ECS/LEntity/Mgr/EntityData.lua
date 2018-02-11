EntityData = SimpleClass()

function EntityData:__init(uid,config,spawn)
	self.uid = uid 
	self.conf = config
	self.compLst = nil 
	self:initCompLst()
end 

function EntityData:getUid()
	return self.uid 
end 

function EntityData:getConfig()
	return self.conf
end 

function EntityData:getEntityType()
end 

function EntityData:isMainPlayer()
	return true 
end 

function EntityData:initCompLst()
   if not self.conf then 
   	  return 
   end
   self.compLst = { }
   for i = 1,20 do 
   	   if self.conf['c'..i] == nil then 
   	   	  break
   	   end 
   	   local type = self.conf['c'..i] 
   	   local args = self.conf['args'..i] 
   	   self.compLst[type] = args
   end 
end 

function EntityData:getCompLst()
   return self.compLst
end 