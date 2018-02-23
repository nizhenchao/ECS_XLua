LQueue = SimpleClass()

function LQueue:__init(...)
    self.startIndex = 1
    self.endIndex = 0
    self.vals = { }
end

--入队
function LQueue:enQueue(data)
   local newEnd = self.endIndex + 1
   self.vals[newEnd] = data 
   self.endIndex = newEnd
end 

--出队
function LQueue:deQueue()
	if self:isEmpty() then 
       return nil 
	end 
    local data = self.vals[self.startIndex]
    self.vals[self.startIndex] = nil 
    self.startIndex = self.startIndex + 1
    return data 
end 

--拿到队列最前面的元素
function LQueue:peek()
	if self:isEmpty() then 
       return nil 
	end 
    return self.vals[self.startIndex]
end 

function LQueue:getCount()
	local count = self.endIndex - self.startIndex
	return  count > -1 and count + 1 or 0 
end 

function LQueue:isEmpty()
	return self:getCount() <= 0 
end 