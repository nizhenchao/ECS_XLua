BaseItem = SimpleClass()

local function _create_self_param(self)
	self.obj = nil 
	self.args = nil 
	self.isBindComplete = false 
	self.widgetPool = { }
end

function BaseItem:__init(obj,args,...)
    if self.__isInit ~= nil then
        return
    end
    _create_self_param(self)
    self.__isInit = true
    self.args = args 
    self:__init_Self()
    self:bindLayout(obj)
end 

--绑定布局
function BaseItem:bindLayout(obj)
	self.obj = obj 
	self:bindWidget()
	self.isBindComplete = true 
	self:onOpen()
end

--绑定布局
function BaseItem:bindWidget()
   local infos = { }
   for k,v in pairs(self) do
		if type(v) == "string" and UIWidget[v] ~= nil then
           --查找并绑定
           local nodeObj = LuaExtend:getNodeByRecursion(self.obj,k) 
           if _G[UIWidget[v]]~=nil then 
           	   local calss = _G[UIWidget[v]]
	           self[k] = calss(nodeObj,v)
	           self.widgetPool[#self.widgetPool+1] = k
           end 
		end
   end
   --扩展todo
end 

function BaseItem:onHide()
   self:onClose()
   LuaExtend:setActive(self.obj,false)
end

function BaseItem:onBaseDispose()
	self:onDispose()
	for i =1,#self.widgetPool do 
		self[self.widgetPool[i]]:onBaseDispose()
	end     
	self.widgetPool = nil 	
	self.args = nil 	
	self.obj = nil 
	self.__isInit = nil 
end 

---------------------生命周期 子类重写-------------------
--声明成员变量
function BaseItem:__init_Self()
	--声明节点 节点控件由底层释放
    --self.nameText = UIWidget.LText
    --声明变量 变量在子类onDispose置空
    --self.data = nil 
end 

--初始化界面
function BaseItem:initLayout()

end 

--当界面打开
function BaseItem:onOpen()

end

--当界面关闭
function BaseItem:onClose()

end 

--界面刷新
function BaseItem:onRefresh(data)

end

--释放UI
function BaseItem:onDispose()

end 