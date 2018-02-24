LAIComp = SimpleClass(LComponent)

function LAIComp:__init(type,uid,args)
	self.conf = ConfigHelper:getConfigByKey('AIBehaviorConfig',tonumber(args))
	self.lastThinkTime = -1
end 

function LAIComp:isNeedUpdate()
    return LuaExtend:getSecTimer() - self.lastThinkTime > self:getThinkTime()
end 

function LAIComp:getThinkTime()
	return self.conf and self.conf.thinkTime or 100
end 

function LAIComp:thinkFinish()
    self.lastThinkTime = LuaExtend:getSecTimer()
end 

function LAIComp:update()

end 