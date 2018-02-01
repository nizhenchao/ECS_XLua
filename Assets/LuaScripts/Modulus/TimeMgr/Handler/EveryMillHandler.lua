EveryMillHandler = SimpleClass(BaseTimerHandler)

function EveryMillHandler:initialize()
	self.interval = self.interval
end 

function EveryMillHandler:isComplete()
   return false
end