SecTimerHandler = SimpleClass(BaseTimerHandler)


function SecTimerHandler:initialize()
	self.interval = self.interval*1000
end 