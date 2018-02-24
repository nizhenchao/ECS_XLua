BillBoardComp = SimpleClass(LComponent)

function BillBoardComp:__init(type,uid,args)
	self.root = nil 
    self.billBoard = nil 

    self.name = nil 
    self.nameChanged = nil  
    self:changeName(tostring(args))    
end 

function BillBoardComp:isNeedUpdate()
    return self.billBoard == nil 
end 

function BillBoardComp:isNeedUpdateName()
    return self.nameChanged
end 

function BillBoardComp:changeName(str)
    self.name = str 
    self.nameChanged = true  
end 

function BillBoardComp:update()

end 