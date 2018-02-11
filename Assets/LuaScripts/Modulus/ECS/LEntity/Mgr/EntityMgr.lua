EntityMgr = {}

function EntityMgr:init()
    self.entityPool = { }--key = uid   val = entity 
    self.mainPlayerId = nil 
end 

--创建实体 EntityData
function EntityMgr:createEntity(data)
	if not data then 
		return 
	end 
    local uid = data:getUid()
    if self.entityPool[uid] then 
    	return 
    end     
    local entity = LEntity(uid,data)
    entity:onLoading()
    self.entityPool[uid] = entity
    if data:isMainPlayer() then 
    	self.mainPlayerId = uid 
    	self:setCameraFollow()
    end     
end 

--销毁实体
function EntityMgr:destroyEntity(uid)
   if not self.entityPool[uid] then 
      return 
   end 
   local entity = self.entityPool[uid]
   self.entityPool[uid] = nil 
   entity:onBaseDispose()
end 

function EntityMgr:isHave(uid)
  return self.entityPool[uid] ~= nil 
end 

--获取一个实体
function EntityMgr:getEntity(uid)
	return self.entityPool[uid]
end 
--
function EntityMgr:getMainEntity()
	return self.entityPool[self.mainPlayerId]
end 

function EntityMgr:setCameraFollow()
	local player = self:getMainEntity()
	LuaExtend:setCameraPlayer(player:getRoot())
end 

function EntityMgr:onLoadScene()
	for k,v in pairs(self.entityPool) do 
		v:onBaseDispose()
	end 
    self.entityPool = { }
    self.mianPlayerId = nil 
end 

function EntityMgr:getSubEntity(system)
   for k,v in pairs(self.entityPool) do 

   end 
end 

create(EntityMgr)