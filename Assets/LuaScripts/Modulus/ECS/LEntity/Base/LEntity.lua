LEntity = SimpleClass()

function LEntity:__init(uid,data)
    self:__init_self()
    self.data = data 
    self.uid = uid    
end 

function LEntity:__init_self()
	self.uid = nil --实体id
  self.eType = nil --实体类型
	self.data = nil --实体配置
	self.root = nil --实体obj根节点
  self.compPool = { }
end 

function LEntity:onLoading()	
	self.root = Utils:newObj(tostring(self.uid))	
  --add component
  local lst = self.data:getCompLst()
  if lst then 
     for k,v in pairs(lst) do 
        local c = ComponentMgr:addComponent(self,k,v)
        if c then 
           self.compPool[k] = c
        end 
     end
  end   
end 

function LEntity:onBaseDispose()
	self:onDispose()
  for k,v in pairs(self.compPool) do 
      ComponentMgr:removeComponent(self,v)
  end 
  LuaExtend:destroyObj(self.root)
  self.uid = nil 
  self.data = nil 
  self.root = nil 
end 

function LEntity:getRoot()
	return self.root
end 

function LEntity:onDispose()

end 

function LEntity:updateComp(type,...)
   if self.compPool[type] then 
      self.compPool[type]:update(...)
   end 
end 

function LEntity:getComp(type)
  return self.compPool[type]
end 