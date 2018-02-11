LSystem = SimpleClass()

function LSystem:__init_self()
    self.subscibe = nil  
end 

function LSystem:__init()
	self:__init_self()
end 

function LSystem:getSubLst()
	if self.subscibe then 
	   return ComponentMgr:getCompsByType(self.subscibe)
    end
end 	

function LSystem:onTick()
   local lst = self:getSubLst()
   if lst then 
   	  self:onUpdate(lst)
   end 
end 

function LSystem:onUpdate(lst)

end 

function LSystem:onDispose()

end