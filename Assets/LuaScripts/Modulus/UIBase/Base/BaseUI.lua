BaseUI = SimpleClass()

function BaseUI:__init(obj,uiinfo,...)
	self.obj = obj 
	self.uiInfo = uiinfo
	print("<color=yellow>BaseUI:__init(...)</color>")
end 

function BaseUI:initLayout()
end 

function BaseUI:onOpen()
end 

function BaseUI:onClose()
end 

function BaseUI:onRefresh()

end

function BaseUI:onDispose()
end 