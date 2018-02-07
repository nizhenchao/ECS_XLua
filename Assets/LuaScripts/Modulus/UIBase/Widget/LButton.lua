LButton = SimpleClass(LUIWidget)

function LButton:getWidget()
    return self.widgetObj:GetComponent(CSButton) 
end 

--LButton一些相关操作--todo
function LButton:setOnClick(call)
	if self.widget then 
		self.widget.onClick:AddListener(call)
	end 
end 