BaseUI = SimpleClass()

local function _create_self_param(self)
	self.obj = nil 
	self.uiInfo = nil 
	self.args = nil 
	self.widgetPool = { }
end

function BaseUI:__init(obj,uiinfo,args,...)
    if self.__isInit ~= nil then
        return
    end
    _create_self_param(self)
    self.__isInit = true
	self.obj = obj 
	self.uiInfo = uiinfo
	self.args = args
	self:__init_Self()
	self:bindWidget()
	self:initLayout()	
end 

--声明成员变量
function BaseUI:__init_Self()

end 

--绑定布局
function BaseUI:bindWidget()
   local infos = { }
   for k,v in pairs(self) do
		if type(v) == "string" and UIWidget[v] ~= nil then
           --查找并绑定
           local nodeObj = LuaExtend:getNodeByRecursion(self.obj,k)            
           self[k] = LUIWidget(nodeObj,v)
           self.widgetPool[#self.widgetPool+1] = k
		end
   end
end 

--初始化界面
function BaseUI:initLayout()

end 

--界面打开
function BaseUI:onOpen()

end

--界面关闭
function BaseUI:onClose()

end 

--界面刷新
function BaseUI:onRefresh()

end

--释放UI
function BaseUI:onDispose()
	print("BaseUI:onDispose()")
	for i =1,#self.widgetPool do 
		self[self.widgetPool[i]]:onDispose()
	end     
	self.uiInfo = nil 
	self.args = nil 
	LuaExtend:destroyObj(self.obj)
	self.obj = nil 
	self.__isInit = nil 
end 