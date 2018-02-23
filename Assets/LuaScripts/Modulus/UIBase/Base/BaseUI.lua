BaseUI = SimpleClass()

local function _create_self_param(self)
	self.obj = nil 
	self.uiInfo = nil 
	self.args = nil 
	self.vo = nil 
	self.isBindComplete = false 
	self.widgetPool = { }
end

function BaseUI:__init(uiInfo,args,...)
    if self.__isInit ~= nil then
        return
    end
    _create_self_param(self)
    self.__isInit = true
	self.uiInfo = uiInfo
	self.uiEnum = uiInfo.UIEnum
	self.args = args
	self:__init_Self()
end 

--绑定布局
function BaseUI:bindLayout(obj)
	self.obj = obj 
	self:bindWidget()
	self:bindNode()
	self.isBindComplete = true 
	self:checkStatus()
end

--检查UI打开状态
function BaseUI:checkStatus()   
   local isOpen = UIMgr:isOpen(self.uiEnum)
   if not isOpen then  
   	    self:onUIClose()
   else
   	    LuaExtend:setActive(self.obj,true)
		self:initLayout()	
		self:onOpen()
		self:onRefresh()
   end 
end 

function BaseUI:updateVO(vo)
	self.vo = vo 
	if self.isBindComplete then 
		self:onRefresh()
	end 
end 

--UI节点
function BaseUI:bindNode()
	--LuaExtend:setUINode(self.obj,self.uiInfo.UINode)
	UIMgr:setNode(self,self.uiInfo.UINode)
end 

--加载UI
function BaseUI:loadUI(path)
	LuaExtend:loadObj(path,function(obj)  
       self:bindLayout(obj)
	end)
end 

--绑定布局
function BaseUI:bindWidget()
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

--关闭UI
function BaseUI:onUIClose()
	local isDestroy = self.uiInfo and self.uiInfo.isDestroy or false 
    if self.isBindComplete then 
       self:onClose()       
       if not isDestroy then 	      
          self:onHide()
	   else
	  	  self:onBaseDispose()
       end
    end 
    return not isDestroy 
end 

function BaseUI:onHide()
   LuaExtend:setActive(self.obj,false)
end

function BaseUI:onBaseDispose()
	self:onDispose()
	for i =1,#self.widgetPool do 
		self[self.widgetPool[i]]:onBaseDispose()
	end     
	self.widgetPool = nil 
	self.uiInfo = nil 
	self.args = nil 
	LuaExtend:destroyObj(self.obj)
	self.obj = nil 
	self.__isInit = nil 
end 

---------------------生命周期 子类重写-------------------
--声明成员变量
function BaseUI:__init_Self()
	--声明节点 节点控件由底层释放
    --self.nameText = UIWidget.LText
    --声明变量 变量在子类onDispose置空
    --self.data = nil 
end 

--初始化界面
function BaseUI:initLayout()

end 

--当界面打开
function BaseUI:onOpen()

end

--当界面关闭
function BaseUI:onClose()

end 

--界面刷新
function BaseUI:onRefresh(vo)

end

--释放UI
function BaseUI:onDispose()

end 