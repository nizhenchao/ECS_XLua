EventData = SimpleClass()

function EventData:__init(eventName)
	self.eventName = eventName
	self.handlerMap = { }	
end

function EventData:addHandler(handler)
    for i = 1,#self.handlerMap do 
    	if self.handlerMap[i] == handler then 
    	   return 
    	end 
    end 
    table.insert(self.handlerMap,handler)
end 

function EventData:removeListener(handler)
    for i = 1,#self.handlerMap do 
    	if self.handlerMap[i] == handler then 
    	   table.remove(self.handlerMap,i)
    	end 
    end 
end 

function EventData:sendMsg(...)
    for i = 1,#self.handlerMap do 
        self.handlerMap[i](...)
    end 
end

function EventData:onDispose()
	self.eventName = nil 
	self.handlerMap = nil 
end 

--------------------------------------------------------
EventMgr = {}

function EventMgr:init()
	self.eventMap = HashTable()	
end 

function EventMgr:addListener(eventName,handler)
    if eventName == nil then 
        print("<color=red>监听事件  事件名为空</color>")
        return 
    end 
    if not self.eventMap:containsKey(eventName) then 
    	self.eventMap:add(eventName,EventData())
    end 
    local data = self.eventMap:get(eventName)
    data:addHandler(handler)    
end 

function EventMgr:removeListener(eventName,handler)
    if self.eventMap:containsKey(eventName) then 
       local data = self.eventMap:get(eventName)
       data:removeListener(handler)
    end 
end 

function EventMgr:sendMsg(eventName,...)     
     if self.eventMap:containsKey(eventName) then 
       local data = self.eventMap:get(eventName)
       data:sendMsg(...)
    end   
end 

function EventMgr:onDispose()

end

create(EventMgr)