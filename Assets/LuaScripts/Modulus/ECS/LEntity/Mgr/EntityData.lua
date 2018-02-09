EntityData = SimpleClass()

function EntityData:__init(uid,config,spawn)
	self.uid = uid 
	self.conf = config
	self.spawn = spawn
end 

function EntityData:getUid()
	return self.uid 
end 

function EntityData:getConfig()
	return self.conf
end 

function EntityData:isMainPlayer()
	return true 
end 

--模型加载路径
function EntityData:getPath()
	return self.conf and self.conf.modelName or ""
end 
--模型碰撞器高度
function EntityData:getCCHeight()
	return self.conf and self.conf.ccHeight or ""
end 
--模型碰撞器半径
function EntityData:getCCRadius()
	return self.conf and self.conf.ccRadius or ""
end 

function EntityData:getSpawn()
	return self.spawn
end 