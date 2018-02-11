SystemMgr = { }

function SystemMgr:init_self()
	self.shortPool = { }
	self.longPool = { }
	self.oncePool = { }
end 

function SystemMgr:init()
	self:init_self()
	self:addSystem()
    
    TimeMgr:addEveryMillHandler(Bind(self.tickShort,self),20)
    TimeMgr:addEveryMillHandler(Bind(self.tickLong,self),100)
end 

function SystemMgr:addSystem()
   self:addShort()
end 

function SystemMgr:addShort()
   self:addLong()
end 

function SystemMgr:addLong()
   local modelSys = LModelSystem()
   if self.longPool[modelSys.subscibe] == nil then 
      self.longPool[modelSys.subscibe] = modelSys
   end   
end 


function SystemMgr:tickShort(count)
    for k,v in pairs(self.shortPool) do 
    	v:onTick()
    end 
end 

function SystemMgr:tickLong(count)	
    for k,v in pairs(self.longPool) do 
    	v:onTick()
    end 
end 

function SystemMgr:tickOnce()

end 

function SystemMgr:disposeComp(type,comp)
   if self.longPool[type] then 
   	  self.longPool[type]:disposeComp(comp)
   	  return 
   end 
   if self.shortPool[type] then 
   	  self.shortPool[type]:disposeComp(comp)
   end 
end 

create(SystemMgr)