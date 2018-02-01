--pairs可以遍历表中所有的key，并且除了迭代器本身以及遍历表本身还可以返回nil;
 
--但是ipairs则不能返回nil,只能返回数字0，如果遇到nil则退出
-- 属性有 size  方法有 add  remove  clrean List会保证下标的连续 但每次移除，下标都会改变
--下标从1 开始
List = SimpleClass()

function List:__init( ... )
	self.size = 0
	self.items = {}
end

function List:add( item )
	if item == nil then 
		Logger:log('--add to list   data item was nil')
		return
	end
	self.size = self.size + 1
	self.items[self.size] = item
end

function List:get(index)
	return self.items[index]	
--[[	for k,v in pairs(self.items) do
		if k == id then
			return v
		end
	end
	return nil--]]
end
--移除一个元素  后面的元素向前移位
function List:remove(item)
--	for i,v in ipairs(self.items) do
--		if item == v then
--			--self.items[i] = nil
--			table.remove(self.items,i)
--		end
--	end
--	self.size = self.size - 1
	 for i = #self.items, 1, -1 do
        if self.items[i] == item then
            table.remove(self.items, i)
			self.size = self.size - 1
            break
        end
    end
end

function List:clrean()
	for i,v in ipairs(self.items) do
		self.items[i] = nil
	end
	self.items = {}
	self.size = 0
end