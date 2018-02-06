BaseUI = SimpleClass()

function BaseUI:__init(obj,uiinfo,args,...)
	self.obj = obj 
	self.uiInfo = uiinfo
	self.args = args
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
	print("BaseUI:onDispose()")
end 