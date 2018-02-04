MainControl = SimpleClass(BaseControl)

function MainControl:init()

end 

function MainControl:initEvent()
	EventMgr:addListener("onOpenUIEvent",Bind(self.onOpenUIEvent,self))
    

    EventMgr:sendMsg("onOpenUIEvent",'盘子脸')
end 

function MainControl:onOpenUIEvent(param)
	Utils:newObj(param)

	print("source tree debug")
--[[
	local memory = require 'perf.memory'
    TimeMgr:addEveryMillHandler(function(count) 
    	local mb = string.format("%0.2f",memory.total()/1024) 
    	print("lua memory "..tostring(mb).."mb") 
    end,500)
--]]

---[[    
    --创建
    self.obj = nil 
	self.timerId = TimeMgr:addSecHandler(1,function(count) 
		print("count down"..count) 
		ResExtend:loadObj("monster_1001",function(obj)  
	        obj.name ="lua monster"..count
	        self.obj = obj 
		end)
		end,function(count) print("Lua创建obj计时器结束") end,10)
    --销毁
	    TimeMgr:addSecHandler(1,function(count) 

		end,function(count) 
		    	ResExtend:destroyObj(self.obj)         
		        print("Lua销毁obj计时器结束") 
		end,15)

--]]
--[[
    timerId
	TimeMgr:addSecHandler(5,nil,function(count) 
		ResExtend:loadScene("level_001",function(val) print("加载场景中..."..tostring(val*100).."%") end)
	end)
--]]
end 

Register('MainControl')