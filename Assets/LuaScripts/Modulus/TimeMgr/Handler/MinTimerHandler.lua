MinTimerHandler = SimpleClass(BaseTimerHandler)

function MinTimerHandler:initialize()
	self.interval = self.interval*60000
end 