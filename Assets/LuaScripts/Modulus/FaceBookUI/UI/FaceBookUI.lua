FaceBookUI = SimpleClass(BaseUI)

function FaceBookUI:__init()
	print("<color=yellow>FaceBookUI:__init()</color>")

	self.img1 = LuaExtend:getNode(self.obj,'img1')
	if self.img1~=nil then 
		TimeMgr:addSecHandler(1,nil,function(count) 
			print("self.img1 setSprite")
			LuaExtend:setSprite(self.img1,'ZJM_jingying')
		end,3)
	end 
end 