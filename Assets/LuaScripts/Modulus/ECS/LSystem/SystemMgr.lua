SystemMgr = { }

function SystemMgr:init_self()
  --缓存system
	self.sysShortPool = { }
	self.sysLongPool = { }	
  --需要初始化的sys
  self.shortPool = { }
  self.longPool = { }
end 

function SystemMgr:init()
	self:init_self()
	self:addSystem()
    
  TimeMgr:addEveryMillHandler(Bind(self.tickShort,self),10)
  TimeMgr:addEveryMillHandler(Bind(self.tickLong,self),100)
end 

function SystemMgr:addSystem()
   self:addShort()
   self:addLong()

   self:addTo(self.shortPool,self.sysShortPool)
   self:addTo(self.longPool,self.sysLongPool)
end 

function SystemMgr:addShort()     
    table.insert(self.shortPool,'LRotationSystem')
    table.insert(self.shortPool,'LSpeedSystem')   
end 

function SystemMgr:addLong()
    table.insert(self.longPool,'LCCSystem')
    table.insert(self.longPool,'LModelSystem') 
    table.insert(self.longPool,'LAnimSystem')
    table.insert(self.longPool,'LSkillSystem')
    table.insert(self.longPool,'LBillBoardSystem')
end 

function SystemMgr:addTo(pool,sysPool)
    for i = 1,#pool do 
        if _G[pool[i]] then 
          local creator = _G[pool[i]]
          local calss = creator()
          sysPool[calss.subscibe] = calss
        else
          print("<color=red>"..pool[i].."不存在或没有引入</color>")
        end 
    end 
end 

function SystemMgr:tickShort(count)
    for k,v in pairs(self.sysShortPool) do 
    	v:onTick()
    end 
end 

function SystemMgr:tickLong(count)	
    for k,v in pairs(self.sysLongPool) do 
    	v:onTick()
    end 
end 

function SystemMgr:tickOnce()

end 

function SystemMgr:disposeComp(type,comp)
   if self.sysLongPool[type] then 
   	  self.sysLongPool[type]:disposeComp(comp)
   	  return 
   end 
   if self.sysShortPool[type] then 
   	  self.sysShortPool[type]:disposeComp(comp)
   end 
end 

create(SystemMgr)