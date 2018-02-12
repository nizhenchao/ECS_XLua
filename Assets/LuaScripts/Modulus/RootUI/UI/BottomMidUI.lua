BottomMidUI = SimpleClass(BaseUI)

local mainId = 900000010001 
--声明成员变量
function BottomMidUI:__init_Self()
	self.mp = UIWidget.LImage
	self.hp = UIWidget.LImage
	self.createPlayerBtn = UIWidget.LButton
	self.deleteBtn = UIWidget.LButton
end 

function BottomMidUI:initLayout()   
    

    LuaExtend:doFloatTo(function(val) self.hp:setMaterialFloat("_Fill",val) end,1,0.65,0.5)
    LuaExtend:doFloatTo(function(val) self.mp:setMaterialFloat("_Fill",val) end,1,0.25,0.5)

    self.createPlayerBtn:setOnClick(function() 
	    local conf = ConfigHelper:getConfigByKey('EntityConfig',10001)
	    local roleData = EntityData(mainId,conf)
	    EntityMgr:createEntity(roleData)
    end)
    self.deleteBtn:setOnClick(function() 
    	EntityMgr:destroyEntity(mainId)
    end)
end 

function BottomMidUI:onOpen()

end 