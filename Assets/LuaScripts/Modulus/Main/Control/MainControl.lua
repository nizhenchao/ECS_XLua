MainControl = SimpleClass(BaseControl)

function MainControl:init()

end 

function MainControl:initEvent()
	EventMgr:addListener("onOpenUIEvent",Bind(self.onOpenUIEvent,self))
    

    EventMgr:sendMsg("onOpenUIEvent",'盘子脸')
end 

function MainControl:onOpenUIEvent(param)
	Utils:newObj(param)
--[[
	local memory = require 'perf.memory'
    TimeMgr:addEveryMillHandler(function(count) 
    	local mb = string.format("%0.2f",memory.total()/1024) 
    	print("lua memory "..tostring(mb).."mb") 
    end,500)
--]]

---[[
	self.timerId = TimeMgr:addSecHandler(1,function(count) 
		print("count down"..count) 
		ResExtend:loadObj("monster_1001",function(obj)  
	        obj.name ="lua monster"..count
	        self.obj = obj 
		end)
		end,function(count) print("计时器结束") end,1)

        TimeMgr:addSecHandler(20,nil,function(count) 
		print("20sec finish "..count) 
		ResExtend:loadObj("monster_1001",function(obj)  
	        obj.name ="lua monster"..count
	        self.obj = obj 
		end)
		end,1)
--]]
--[[
    timerId
	TimeMgr:addSecHandler(5,nil,function(count) 
		ResExtend:loadScene("level_001",function(val) print("加载场景中..."..tostring(val*100).."%") end)
	end)
--]]
end 

Register('MainControl')