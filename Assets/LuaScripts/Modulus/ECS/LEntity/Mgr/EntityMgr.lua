EntityMgr = {}

function EntityMgr:init()
    self.entityPool = { }
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
    self.entityPool[uid] = entity
    if data:isMainPlayer() then 
    	self.mainPlayerId = uid 
    end 
    entity:onLoading()
end 

--销毁实体
function EntityMgr:destroyEntity()

end 

function EntityMgr:onLoadScene()
	for k,v in pairs(self.entityPool) do 
		v:onBaseDispose()
	end 
    self.entityPool = { }
    self.mianPlayerId = nil 
end 

create(EntityMgr)