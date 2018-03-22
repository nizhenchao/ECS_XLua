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
  self.csEntity = nil --CEntity  
  self.audioListener = Bind(self.playAudio,self)
  self.effectListener = Bind(self.playEffect,self)
  self.hitListener = Bind(self.playHit,self)
  self.compPool = { }
end 

function LEntity:playAudio(args)
  print("cs call lua animator event playAudio args "..tostring(args))
end 
function LEntity:playEffect(args)
end 
function LEntity:playHit(args)
end 

function LEntity:onLoading()	
	self.root = Utils:newObj(tostring(self.uid))	
  self.csEntity = self.root:AddComponent(CEntity)  
  self.csEntity.UID = self.uid 
  self.csEntity:setPlayAudioEvent(self.audioListener)
  self.csEntity:setPlayEffectEvent(self.effectListener)
  self.csEntity:setPlayHitEvent(self.hitListener)
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
  self.audioListener = nil 
  self.effectListener = nil 
  self.hitListener = nil 
end 

function LEntity:updateComp(type,...)
   if self.compPool[type] then 
      self.compPool[type]:update(...)
   end 
end 

function LEntity:getComp(type)
  return self.compPool[type]
end 