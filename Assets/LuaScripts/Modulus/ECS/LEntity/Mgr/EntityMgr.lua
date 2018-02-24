EntityMgr = {}

function EntityMgr:init()
    self.entityPool = { }--key = uid   val = entity 
    self.mainPlayerId = nil 
    self.constId = 900000010001
end 

--创建实体 EntityData
function EntityMgr:createEntity(data)
	if not data then 
		return 
	end 
    local uid = data:getUid()
    if self.entityPool[uid] then 
         UIMgr:openUI(UIEnum.UpDownAnimUI,uid.."实体已经创建,请勿重复创建")
         LuaExtend:doShake(1.5,0.02,0.3,0.3)
    	 return 
    end     
    local entity = LEntity(uid,data)
    entity:onLoading()
    self.entityPool[uid] = entity
    if uid == self.constId then 
    	self.mainPlayerId = uid 
    	self:setCameraFollow()
      self:onCreateMainPlayer(entity)
    end     
end 

function EntityMgr:onCreateMainPlayer(entity)   
   EventMgr:sendMsg(MainCmd.On_Create_Main_Player,entity)
end 

function EntityMgr:onDestroyMainPlayer()
   EventMgr:sendMsg(MainCmd.On_Destroy_Main_Player)
end 

--销毁实体
function EntityMgr:destroyEntity(uid)
   if not self.entityPool[uid] then 
      return 
   end 
   local entity = self.entityPool[uid]
   self.entityPool[uid] = nil 
   entity:onBaseDispose()
   if uid == self.mainPlayerId then 
       self:onDestroyMainPlayer()
   end 
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
    self.mainPlayerId = nil 
end 

function EntityMgr:getSubEntity(system)
   for k,v in pairs(self.entityPool) do 

   end 
end 

function EntityMgr:isMainPlayer(uid)
  return self.mainPlayerId == uid 
end 

create(EntityMgr)