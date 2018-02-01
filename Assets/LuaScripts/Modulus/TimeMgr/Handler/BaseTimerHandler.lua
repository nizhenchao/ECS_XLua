BaseTimerHandler = SimpleClass()

function BaseTimerHandler:__init(startTime,count,interval,eHandler,cHandler)
    self.startTime = startTime
    self.count = count 
    self.interval = interval
    self.eHandler = eHandler 
    self.cHandler = cHandler   
    self.invalid = false 
    self.nowCount = 0
    self:initialize()
end 

function BaseTimerHandler:initialize()

end 

function BaseTimerHandler:isInvalid()
    return self.invalid
end 

function BaseTimerHandler:onCheck(nowTimer)
    if nowTimer - self.startTime > self.interval then 
       if self.eHandler then 
       	  self.eHandler()
       end           
       self.nowCount = self.nowCount + 1  
       if self:isComplete() then 
	       if self.cHandler then 
	       	  self.cHandler()
	       end  
	       self.invalid = true 
       end 
       self.startTime = nowTimer  
    end
end 

function BaseTimerHandler:isComplete()
   return self.nowCount >= self.count
end

function BaseTimerHandler:onDispose()
    self.startTime = nil 
    self.endCount = nil 
    self.currCount = nil 
end 