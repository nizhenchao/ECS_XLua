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
    self.hp:setMaterialFloat("_Fill",0.75)
    self.mp:setMaterialFloat("_Fill",0.45)

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