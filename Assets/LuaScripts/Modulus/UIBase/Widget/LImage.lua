LImage = SimpleClass(LUIWidget)

function LImage:getWidget()
    return self.widgetObj:GetComponent(CSImage) 
end 

--Image一些相关操作--todo
function LImage:setImage(name)
    LuaExtend:setSprite(self:getObj(),name)
end 

function LImage:setNativeSize()
	if self.widget then 
		self.widget:SetNativeSize()
	end 
end 

function LImage:setFillAmount(val)
	if self.widget then 
		self.widget.fillAmount = val
	end 
end 

function LImage:setMaterialFloat(key,val)
	LuaExtend:setMaterialFloat(self.widget,key,val)
end 

function LImage:onDispose()
	
end 