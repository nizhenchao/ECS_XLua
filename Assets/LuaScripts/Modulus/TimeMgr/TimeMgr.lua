TimeMgr = {}

function TimeMgr:init()
    --[[
    self.timerPool = {}
    self.removeLst = {}
	self.timer = os.time()*1000
	self.interval = 20 --20毫秒检测
    --]]
end 

function TimeMgr:onTick()	  
    --self.timer = self.timer + self.interval    
end 

function TimeMgr:update()
	--self:checkTimerPool()
end 

--计数n次 每次回调 完成回调 间隔
function TimeMgr:addSecHandler(endCount,eHandler,cHandler,interval)
   interval = interval and interval or 1
   return CS.LuaExtend.addSecHandler(endCount,eHandler,cHandler,interval)
end 
function TimeMgr:addMillHandler(endCount,eHandler,cHandler,interval)
   interval = interval and interval or 1
   return CS.LuaExtend.addMillHandler(endCount,eHandler,cHandler,interval)
end 
function TimeMgr:addMinHandler(endCount,eHandler,cHandler,interval)
   interval = interval and interval or 1
   return CS.LuaExtend.addMinHandler(endCount,eHandler,cHandler,interval)
end 
function TimeMgr:addEveryMillHandler(eHandler,interval)
   interval = interval and interval or 1
   return CS.LuaExtend.addEveryMillHandler(eHandler,interval)
end 

--[[
function TimeMgr:clear()
    self.timerPool = {}
    self.removeLst = {}
end 

function TimeMgr:checkTimerPool()
    for i = 1,#self.removeLst do 
    	self.timerPool[self.removeLst[i] = nil --少一个]
    	self.removeLst[i] = nil 
    end 

    for k,v in pairs(self.timerPool) do 
    	if v:isInvalid() then 
    		table.insert(self.removeLst,k)
        else
        	v:onCheck(self.timer)
    	end     	
    end 
end 

function TimeMgr:remove(uid)
	if uid then 
		self.timerPool[uid] = nil 
	end     
end

local function addHandler(self,handler)
	local uid = MathUtils:getShortUid()
	self.timerPool[uid] = handler
	return uid
end 

--计数n次 每次回调 完成回调 间隔
function TimeMgr:addSecHandler(endCount,eHandler,cHandler,interval)
    interval = interval and interval or 1    
    local handler = SecTimerHandler(self.timer,endCount,interval,eHandler,cHandler)
    return addHandler(self,handler)
end 
function TimeMgr:addMillHandler(endCount,eHandler,cHandler,interval)
    interval = interval and interval or 20
    interval = interval< 20 and 20 or interval
    local handler = MillTimerHandler(self.timer,endCount,interval,eHandler,cHandler)
    return addHandler(self,handler)
end 
function TimeMgr:addMinHandler(endCount,eHandler,cHandler,interval)
    interval = interval and interval or 1    
    local handler = MinTimerHandler(self.timer,endCount,interval,eHandler,cHandler)
    return addHandler(self,handler)
end 
function TimeMgr:addEveryMillHandler(eHandler,interval)
    interval = interval and interval or 1    
    local handler = EveryMillHandler(self.timer,0,interval,eHandler,nil)
    return addHandler(self,handler)
end 

function TimeMgr:onDispose()
    self.timerPool = {}
    self.removeLst = {}
end 
--]]
create(TimeMgr)